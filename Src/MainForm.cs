using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharEditor
{
    public partial class MainForm : Form
    {
        #region Members

        // Chars data (1 byte per pixel, so 8 by 8 bytes)
        private byte[,,] charData;

        // Chars color (indexed 0x00 to 0x0F in bit 0, 1 and 2) and multicolor control (bit3)
        private byte[] charColor;

        // Chars background color in hires or multicolor mode
        private byte charBackgroundColor;

        // Chars backgroundcolor in extended mode (indexed 0x00 to 0x0F in bit 0, 1 and 2)
        private byte charBackgroundColorExtended0;
        private byte charBackgroundColorExtended1;
        private byte charBackgroundColorExtended2;
        private byte charBackgroundColorExtended3;

        // Chars background color (4 choices) in extended mode
        private byte[] charBackgroundColorExtended;
        
        // Chars multicolor (indexed 0x00 to 0x0F in bit 0, 1 and 2)
        private byte charMultiColor0;
        private byte charMultiColor1;

        // Selected char index
        private byte selectedChar;

        // Mouse down flag
        private bool mouseDown;

        // Clipboard char data (1 byte per pixel, so 8 by 8 bytes)
        private byte[,] clipboardCharData;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm(string fileName = "")
        {
            InitializeComponent();

            mouseDown = false;

            // Set data, colors, screens etc
            Init();

            // Open file (if provided)
            if (fileName != "")
            {
                LoadFile(fileName);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Paint event handler char draw picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void pbCharDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (rbHiResGeneral.Checked || (rbMultiColorGeneral.Checked && rbHiResCharacter.Checked))
            {
                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        if (charData[selectedChar, column, row] == 0x00)
                        {
                            Brush brush = new SolidBrush(panelCharBackgroundColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 10, 10));
                        }

                        if (charData[selectedChar, column, row] == 0x01)
                        {
                            Brush brush = new SolidBrush(panelCharColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 10, 10));
                        }
                    }
                }
            }

            if (rbMultiColorGeneral.Checked && rbMultiColorCharacter.Checked)
            {
                for (int column = 0; column < Constants.CHAR_WIDTH; column += 2)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        if ((charData[selectedChar, column, row] == 0x00) && (charData[selectedChar, column + 1, row] == 0x00))
                        {
                            Brush brush = new SolidBrush(panelCharBackgroundColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }

                        if ((charData[selectedChar, column, row] == 0x00) && (charData[selectedChar, column + 1, row] == 0x01))
                        {
                            Brush brush = new SolidBrush(panelCharMultiColor0.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }

                        if ((charData[selectedChar, column, row] == 0x01) && (charData[selectedChar, column + 1, row] == 0x00))
                        {
                            Brush brush = new SolidBrush(panelCharMultiColor1.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }

                        if ((charData[selectedChar, column, row] == 0x01) && (charData[selectedChar, column + 1, row] == 0x01))
                        {
                            Brush brush = new SolidBrush(panelCharColor.BackColor);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 20, 10));
                        }
                    }
                }
            }

            if (rbExtendedGeneral.Checked)
            {
                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        Color color = Color.Black;
                        if (charData[selectedChar, column, row] == 0x00)
                        {
                            switch (charBackgroundColorExtended[selectedChar])
                            {
                                case 0:
                                    color = panelExtendedBackgroundColor0.BackColor;
                                    break;

                                case 1:
                                    color = panelExtendedBackgroundColor1.BackColor;
                                    break;

                                case 2:
                                    color = panelExtendedBackgroundColor2.BackColor;
                                    break;

                                case 3:
                                    color = panelExtendedBackgroundColor3.BackColor;
                                    break;
                            }

                            Brush brush = new SolidBrush(color);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 10, 10));
                        }

                        if (charData[selectedChar, column, row] == 0x01)
                        {
                            Brush brush = new SolidBrush(Constants.Colors[charColor[selectedChar] & 0b00001111]);
                            g.FillRectangle(brush, new Rectangle(column * 10, row * 10, 10, 10));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Paint event handler chars preview picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbChars_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int num_rows = rbExtendedGeneral.Checked ? 4: 16;
            int num_columns = 16;

            for (int row = 0; row < num_rows; row++)
            {
                for (int column = 0; column < num_columns; column++)
                {
                    g.DrawRectangle(Pens.SteelBlue, new Rectangle(2 * column * (Constants.CHAR_WIDTH + 1), 2 * row * (Constants.CHAR_HEIGHT + 1), 2 * (Constants.CHAR_WIDTH + 1), 2 * (Constants.CHAR_HEIGHT + 1)));
                }
            }

            int r = selectedChar / 16;
            int c = selectedChar % 16;
            g.DrawRectangle(Pens.Red, new Rectangle(2 * c * (Constants.CHAR_WIDTH + 1), 2 * r * (Constants.CHAR_HEIGHT + 1), 2 * (Constants.CHAR_WIDTH + 1), 2 * (Constants.CHAR_HEIGHT + 1)));

            int num_chars = rbExtendedGeneral.Checked ? Constants.NUM_CHARS_EXTENDED : Constants.NUM_CHARS;
            for (int i = 0; i < num_chars; i++)
            {
                if (rbHiResGeneral.Checked)
                {
                    for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                    {
                        for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            if (charData[i, column, row] == 0x00)
                            {
                                brush = new SolidBrush(panelCharBackgroundColor.BackColor);
                            }

                            if (charData[i, column, row] == 0x01)
                            {
                                brush = new SolidBrush(Constants.Colors[charColor[i] & 0b00001111]);
                            }

                            g.FillRectangle(brush, new Rectangle(1 + 2 * (column + (Constants.CHAR_WIDTH + 1) * (i % 16)), 1 + 2 * (row + (Constants.CHAR_HEIGHT + 1) * (i / 16)), 2, 2));
                        }
                    }
                }

                if (rbMultiColorGeneral.Checked && ((charColor[i] & 0b00001000) == 0b00000000))
                {
                    for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                    {
                        for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            if (charData[i, column, row] == 0x00)
                            {
                                brush = new SolidBrush(panelCharBackgroundColor.BackColor);
                            }

                            if (charData[i, column, row] == 0x01)
                            {
                                brush = new SolidBrush(Constants.Colors[charColor[i] & 0b00000111]);
                            }

                            g.FillRectangle(brush, new Rectangle(1 + 2 * (column + (Constants.CHAR_WIDTH + 1) * (i % 16)), 1 + 2 * (row + (Constants.CHAR_HEIGHT + 1) * (i / 16)), 2, 2));
                        }
                    }
                }

                if (rbMultiColorGeneral.Checked && ((charColor[i] & 0b00001000) == 0b00001000))
                {
                    for (int column = 0; column < Constants.CHAR_WIDTH; column += 2)
                    {
                        for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            if ((charData[i, column, row] == 0x00) && (charData[i, column + 1, row] == 0x00))
                            {
                                brush = new SolidBrush(panelCharBackgroundColor.BackColor);
                            }

                            if ((charData[i, column, row] == 0x00) && (charData[i, column + 1, row] == 0x01))
                            {
                                brush = new SolidBrush(panelCharMultiColor0.BackColor);
                            }

                            if ((charData[i, column, row] == 0x01) && (charData[i, column + 1, row] == 0x00))
                            {
                                brush = new SolidBrush(panelCharMultiColor1.BackColor);
                            }

                            if ((charData[i, column, row] == 0x01) && (charData[i, column + 1, row] == 0x01))
                            {
                                brush = new SolidBrush(Constants.Colors[charColor[i] & 0b00000111]);
                            }

                            g.FillRectangle(brush, new Rectangle(1 + 2 * (column + (Constants.CHAR_WIDTH + 1) * (i % 16)), 1 + 2 * (row + (Constants.CHAR_HEIGHT + 1) * (i / 16)), 4, 2));
                        }
                    }
                }

                if (rbExtendedGeneral.Checked)
                {
                    for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                    {
                        for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            if (charData[i, column, row] == 0x00)
                            {
                                if (charBackgroundColorExtended[i] == 0) brush = new SolidBrush(panelExtendedBackgroundColor0.BackColor);
                                if (charBackgroundColorExtended[i] == 1) brush = new SolidBrush(panelExtendedBackgroundColor1.BackColor);
                                if (charBackgroundColorExtended[i] == 2) brush = new SolidBrush(panelExtendedBackgroundColor2.BackColor);
                                if (charBackgroundColorExtended[i] == 3) brush = new SolidBrush(panelExtendedBackgroundColor3.BackColor);
                            }

                            if (charData[i, column, row] == 0x01)
                            {
                                brush = new SolidBrush(Constants.Colors[charColor[i] & 0b00001111]);
                            }

                            g.FillRectangle(brush, new Rectangle(1 + 2 * (column + (Constants.CHAR_WIDTH + 1) * (i % 16)), 1 + 2 * (row + (Constants.CHAR_HEIGHT + 1) * (i / 16)), 2, 2));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Mouse button down event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCharDraw_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            Graphics gCharDraw = pbCharDraw.CreateGraphics();
            Graphics gChars = pbChars.CreateGraphics();

            Brush brush = Brushes.Black;
            if (rbCharColor.Checked) brush = new SolidBrush(panelCharColor.BackColor);
            if (rbCharBackgroundColor.Checked) brush = new SolidBrush(panelCharBackgroundColor.BackColor);
            if (rbCharMultiColor0.Checked) brush = new SolidBrush(panelCharMultiColor0.BackColor);
            if (rbCharMultiColor1.Checked) brush = new SolidBrush(panelCharMultiColor1.BackColor);
            if (e.Button == MouseButtons.Right) brush = new SolidBrush(panelCharBackgroundColor.BackColor);

            while (mouseDown)
            {
                int mouseX = Cursor.Position.X - this.Location.X - pbCharDraw.Location.X - 10;
                int mouseY = Cursor.Position.Y - this.Location.Y - pbCharDraw.Location.Y - 32;

                int x = (mouseX / 10);
                int y = (mouseY / 10);

                if ((x < 0) || (y < 0) || (x >= 8) || (y >= 8)) return;

                if (rbHiResCharacter.Checked)
                {
                    gCharDraw.FillRectangle(brush, new Rectangle(x * 10, y * 10, 10, 10));
                    gChars.FillRectangle(brush, new Rectangle(((selectedChar % 16) * (Constants.CHAR_WIDTH + 1) + x) * 2 + 1, ((selectedChar / 16) * (Constants.CHAR_HEIGHT + 1) + y) * 2 + 1, 2, 2));
                    if (rbCharColor.Checked) charData[selectedChar, x, y] = (byte)0x01;
                    if (rbCharBackgroundColor.Checked) charData[selectedChar, x, y] = (byte)0x00;
                    if (e.Button == MouseButtons.Right) charData[selectedChar, x, y] = (byte)0x00;
                }

                if (rbMultiColorCharacter.Checked)
                {
                    if (x % 2 != 0) x--;
                    gCharDraw.FillRectangle(brush, new Rectangle(x * 10, y * 10, 20, 10));
                    gChars.FillRectangle(brush, new Rectangle(((selectedChar % 16) * (Constants.CHAR_WIDTH + 1) + x) * 2 + 1, ((selectedChar / 16) * (Constants.CHAR_HEIGHT + 1) + y) * 2 + 1, 4, 2));

                    if (rbCharColor.Checked)
                    {
                        charData[selectedChar, x, y] = (byte)0x1;
                        charData[selectedChar, x + 1, y] = (byte)0x1;
                    }

                    if (rbCharBackgroundColor.Checked)
                    {
                        charData[selectedChar, x, y] = (byte)0x00;
                        charData[selectedChar, x + 1, y] = (byte)0x00;
                    }

                    if (rbCharMultiColor0.Checked)
                    {
                        charData[selectedChar, x, y] = (byte)0x00;
                        charData[selectedChar, x + 1, y] = (byte)0x01;
                    }

                    if (rbCharMultiColor1.Checked)
                    {
                        charData[selectedChar, x, y] = (byte)0x01;
                        charData[selectedChar, x + 1, y] = (byte)0x00;
                    }

                    if (e.Button == MouseButtons.Right)
                    {
                        charData[selectedChar, x, y] = (byte)0x00;
                        charData[selectedChar, x + 1, y] = (byte)0x00;
                    }
                }

                Application.DoEvents();
            }
        }

        /// <summary>
        /// Mouse button up event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCharDraw_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            FillCharData();
        }

        /// <summary>
        /// Chars preview picturebox clicked event => choose char for editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbChars_Click(object sender, EventArgs e)
        {
            int mouseX = Cursor.Position.X - this.Location.X - pbChars.Location.X - 9;
            int mouseY = Cursor.Position.Y - this.Location.Y - pbChars.Location.Y - 32;

            selectedChar = (byte)(mouseY / (2 * (Constants.CHAR_HEIGHT + 1)) * 16 + mouseX / (2 * (Constants.CHAR_WIDTH + 1)));
            if ((selectedChar >= Constants.NUM_CHARS_EXTENDED) && rbExtendedGeneral.Checked) selectedChar = (byte)(Constants.NUM_CHARS_EXTENDED -1);

            RefreshSelectedChar();
        }

        /// <summary>
        /// Char color panel clicked event => choose color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelCharColor_Click(object sender, EventArgs e)
        {
            byte numColors = 16;

            Panel panel = (Panel)sender;
            if (panel == panelCharColor)
            {
                numColors = rbMultiColorGeneral.Checked ? (byte)8 : (byte)16;
            }

            FormColorDialog colorDialog = new FormColorDialog(panel.BackColor, numColors);
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                panel.BackColor = colorDialog.color;
                if (panel.Name == "panelCharBackgroundColor")
                {
                    charBackgroundColor = colorDialog.colorIndex;
                }

                if (panel.Name == "panelCharColor")
                {
                    charColor[selectedChar] = Convert.ToByte((charColor[selectedChar] & 0b11110000) | colorDialog.colorIndex);
                }

                if (panel.Name == "panelCharMultiColor0")
                {
                    charMultiColor0 = colorDialog.colorIndex;
                }

                if (panel.Name == "panelCharMultiColor1")
                {
                    charMultiColor1 = colorDialog.colorIndex;
                }
            }

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Background color panel clicked event => choose color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelBackgroundColor_Click(object sender, EventArgs e)
        {
            byte numColors = 16;

            Panel panel = (Panel)sender;

            FormColorDialog colorDialog = new FormColorDialog(panel.BackColor, numColors);
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                panel.BackColor = colorDialog.color;

                if (panel.Name == "panelExtendedBackgroundColor0")
                {
                    charBackgroundColorExtended0 = colorDialog.colorIndex;
                }

                if (panel.Name == "panelExtendedBackgroundColor1")
                {
                    charBackgroundColorExtended1 = colorDialog.colorIndex;
                }

                if (panel.Name == "panelExtendedBackgroundColor2")
                {
                    charBackgroundColorExtended2 = colorDialog.colorIndex;
                }

                if (panel.Name == "panelExtendedBackgroundColor3")
                {
                    charBackgroundColorExtended3 = colorDialog.colorIndex;
                }
            }

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Radio button General HiRes clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHiResGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHiResGeneral.Checked)
            {
                rbMultiColorCharacter.Enabled = false;

                rbCharBackgroundColor.Enabled = true;
                panelCharBackgroundColor.Enabled = true;

                rbCharMultiColor0.Enabled = false;
                rbCharMultiColor1.Enabled = false;

                rbHiResCharacter.Checked = true;

                panelExtendedMode.Visible = false;

                pbCharDraw.Invalidate();
                pbChars.Invalidate();

                FillCharData();
            }
        }

        /// <summary>
        /// Radio button General MultiColor clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbMultiColorGeneral_CheckedChanged(object sender, EventArgs e)
        {
            for (int i=0; i< Constants.NUM_CHARS; i++)
            {
                charColor[i] = Convert.ToByte(charColor[i] & 0b11110111);
            }

            if (rbMultiColorGeneral.Checked)
            {
                rbMultiColorCharacter.Enabled = true;

                rbCharBackgroundColor.Enabled = true;
                panelCharBackgroundColor.Enabled = true;

                panelCharColor.BackColor = Constants.Colors[charColor[selectedChar] & 0b00000111];

                panelExtendedMode.Visible = false;

                pbCharDraw.Invalidate();
                pbChars.Invalidate();

                FillCharData();
            } 
        }

        /// <summary>
        /// Radio button General Extended clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbExtendedGeneral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExtendedGeneral.Checked)
            {
                if (selectedChar > Constants.NUM_CHARS_EXTENDED)
                {
                    selectedChar = 0;
                    RefreshSelectedChar();
                }

                rbCharBackgroundColor.Enabled = false;
                panelCharBackgroundColor.Enabled = false;

                rbCharMultiColor0.Enabled = false;
                rbCharMultiColor1.Enabled = false;

                rbHiResCharacter.Checked = true;
                rbMultiColorCharacter.Enabled = false;

                panelExtendedMode.Visible = true;

                pbCharDraw.Invalidate();
                pbChars.Invalidate();

                FillCharData();
            }
        }

        /// <summary>
        /// Radio button extended background color clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbExtendedBackgroundColor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExtendedBackgroundColor0.Checked) charBackgroundColorExtended[selectedChar] = 0;
            if (rbExtendedBackgroundColor1.Checked) charBackgroundColorExtended[selectedChar] = 1;
            if (rbExtendedBackgroundColor2.Checked) charBackgroundColorExtended[selectedChar] = 2;
            if (rbExtendedBackgroundColor3.Checked) charBackgroundColorExtended[selectedChar] = 3;

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Radio button Character HiRes clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHiResCharacter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHiResCharacter.Checked)
            {
                rbCharColor.Checked = true;
                rbCharMultiColor0.Enabled = false;
                rbCharMultiColor1.Enabled = false;
                panelCharMultiColor0.Enabled = false;
                panelCharMultiColor1.Enabled = false;

                if (rbMultiColorGeneral.Checked) charColor[selectedChar] = Convert.ToByte(charColor[selectedChar] & 0b11110111);
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Radio button Character MultiColor clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbMultiColorCharacter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMultiColorCharacter.Checked)
            {
                rbCharMultiColor0.Enabled = true;
                rbCharMultiColor1.Enabled = true;
                panelCharMultiColor0.Enabled = true;
                panelCharMultiColor1.Enabled = true;

                if (rbMultiColorGeneral.Checked) charColor[selectedChar] = Convert.ToByte(charColor[selectedChar] | 0b00001000);
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Load a header file with char data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Char|*.chr";
            openFileDialog.Title = "Open a char file";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                LoadFile(openFileDialog.FileName);

                RefreshSelectedChar();
            }
        }

        /// <summary>
        /// Load binary character file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files | *.*";
            openFileDialog.Title = "Open a binary file";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                FormSkipBytes formSkipBytes = new FormSkipBytes();
                formSkipBytes.ShowDialog();

                int skipBytes = formSkipBytes.skipBytes;

                LoadBinaryFile(openFileDialog.FileName, skipBytes);
                FillCharData();

                pbCharDraw.Invalidate();
                pbChars.Invalidate();
            }
        }

        /// <summary>
        /// Save a header file with char data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Char|*.chr";
            saveFileDialog.Title = "Save a char file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                SaveFile(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Export char images
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image(*.png)|*.png";
            saveFileDialog.Title = "Save chars image file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                Bitmap bmChars = new Bitmap(pbChars.Width, pbChars.Height);
                pbChars.DrawToBitmap(bmChars, pbChars.ClientRectangle);
                bmChars.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Program exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// View manual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.ShowDialog();
        }

        /// <summary>
        /// View about box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        /// <summary>
        /// Clear the current selected char
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics gCharDraw = pbCharDraw.CreateGraphics();

            gCharDraw.Clear(panelCharBackgroundColor.BackColor);
            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = (byte)0x00;
                }
            }

            tbCharData.Text = "";

            pbCharDraw.Invalidate();
            pbChars.Invalidate();

            FillCharData();
        }

        /// <summary>
        /// Mirror the current selected char in horizontal direction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMirrorHorizontal_Click(object sender, EventArgs e)
        {
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    tempCharData[column, row] = charData[selectedChar, Constants.CHAR_WIDTH - 1 - column, row];
                }
            }

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = tempCharData[column, row];
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Mirror the current selected char in vertical direction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMirrorVertical_Click(object sender, EventArgs e)
        {
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    tempCharData[column, row] = charData[selectedChar, column, Constants.CHAR_HEIGHT - 1 - row];
                }
            }

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = tempCharData[column, row];
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Rotate the current selected char right (clockwise)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            // Since the char is not a square, use space width in both dimensions
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_WIDTH];

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    tempCharData[Constants.CHAR_WIDTH - 1 - row, column] = charData[selectedChar, column, row];
                }
            }

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = tempCharData[column, row];
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Rotate the current selected char left (counter clockwise)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            // Since the char is not a square, use space width in both dimensions
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_WIDTH];

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    tempCharData[row, Constants.CHAR_WIDTH - 1 - column] = charData[selectedChar, column, row];
                }
            }

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = tempCharData[column, row];
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Shift all pixels right in the currently selected char
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftRight_Click(object sender, EventArgs e)
        {
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            if (rbHiResCharacter.Checked)
            {
                for (int column = 0; column < Constants.CHAR_WIDTH - 1; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        tempCharData[column + 1, row] = charData[selectedChar, column, row];
                    }
                }

                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        charData[selectedChar, column, row] = tempCharData[column, row];
                    }
                }
            }

            if (rbMultiColorCharacter.Checked)
            {
                for (int column = 0; column < Constants.CHAR_WIDTH - 2; column+=2)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        tempCharData[column + 2, row] = charData[selectedChar, column, row];
                        tempCharData[column + 3, row] = charData[selectedChar, column + 1, row];
                    }
                }

                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        charData[selectedChar, column, row] = tempCharData[column, row];
                    }
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Shift all pixels left in the currently selected char
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftLeft_Click(object sender, EventArgs e)
        {
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            if (rbHiResCharacter.Checked)
            {
                for (int column = 1; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        tempCharData[column - 1, row] = charData[selectedChar, column, row];
                    }
                }

                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        charData[selectedChar, column, row] = tempCharData[column, row];
                    }
                }
            }

            if (rbMultiColorCharacter.Checked)
            {
                for (int column = 2; column < Constants.CHAR_WIDTH; column+=2)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        tempCharData[column - 2, row] = charData[selectedChar, column, row];
                        tempCharData[column - 1, row] = charData[selectedChar, column + 1, row];
                    }
                }

                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        charData[selectedChar, column, row] = tempCharData[column, row];
                    }
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }


        /// <summary>
        /// Shift all pixels of the current char 1 up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftUp_Click(object sender, EventArgs e)
        {
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 1; row < Constants.CHAR_HEIGHT; row++)
                {
                    tempCharData[column, row - 1] = charData[selectedChar, column, row];
                }
            }

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = tempCharData[column, row];
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Shift all pixels of the current char 1 down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShiftDown_Click(object sender, EventArgs e)
        {
            byte[,] tempCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT - 1; row++)
                {
                    tempCharData[column, row + 1] = charData[selectedChar, column, row];
                }
            }

            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = tempCharData[column, row];
                }
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Paste image from clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    charData[selectedChar, column, row] = clipboardCharData[column, row];
                }
            }

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Copy image to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            for (int column = 0; column < Constants.CHAR_WIDTH; column++)
            {
                for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                {
                    clipboardCharData[column, row] = charData[selectedChar, column, row];
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Init, set all variables, screen etc.
        /// </summary>
        private void Init()
        {
            charData = new byte[Constants.NUM_CHARS, Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            charColor = new byte[Constants.NUM_CHARS];
            for (int i=0; i< Constants.NUM_CHARS; i++)
            {
                charColor[i] = 0x01;
            }

            charBackgroundColor = 0x00;

            charBackgroundColorExtended = new byte[Constants.NUM_CHARS_EXTENDED]; 
            for (int i=0; i< Constants.NUM_CHARS_EXTENDED; i++)
            {
                charBackgroundColorExtended[i] = 0x00;
            }

            charBackgroundColorExtended0 = 0x00;
            charBackgroundColorExtended1 = 0x01;
            charBackgroundColorExtended2 = 0x0C;
            charBackgroundColorExtended3 = 0x0F;

            charMultiColor0 = 0x0F;
            charMultiColor1 = 0x0C;

            selectedChar = 0;

            panelCharColor.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
            panelCharBackgroundColor.BackColor = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
            panelCharMultiColor0.BackColor = Color.FromArgb(0xFF, 0xBB, 0xBB, 0xBB);
            panelCharMultiColor1.BackColor = Color.FromArgb(0xFF, 0x77, 0x77, 0x77);

            clipboardCharData = new byte[Constants.CHAR_WIDTH, Constants.CHAR_HEIGHT];

            ToolTip toolTipClear = new ToolTip();
            toolTipClear.ShowAlways = true;
            toolTipClear.SetToolTip(btnClear, "Clear (delete) current char");

            ToolTip toolTipCopy = new ToolTip();
            toolTipCopy.ShowAlways = true;
            toolTipCopy.SetToolTip(btnCopy, "Copy current char to the clipboard");

            ToolTip toolTipPaste = new ToolTip();
            toolTipPaste.ShowAlways = true;
            toolTipPaste.SetToolTip(btnPaste, "Paste clipboard data to current char");

            ToolTip toolTipRotateRight = new ToolTip();
            toolTipRotateRight.ShowAlways = true;
            toolTipRotateRight.SetToolTip(btnRotateRight, "Rotate current char right (clockwise) 90 degrees");

            ToolTip toolTipRotateLeft = new ToolTip();
            toolTipRotateLeft.ShowAlways = true;
            toolTipRotateLeft.SetToolTip(btnRotateLeft, "Rotate current char left (counter clockwise) 90 degrees");

            ToolTip toolTipMirrorHorizontal = new ToolTip();
            toolTipMirrorHorizontal.ShowAlways = true;
            toolTipMirrorHorizontal.SetToolTip(btnMirrorHorizontal, "Mirror current char horizontally");

            ToolTip toolTipMirrorVertical = new ToolTip();
            toolTipMirrorVertical.ShowAlways = true;
            toolTipMirrorVertical.SetToolTip(btnMirrorVertical, "Mirror current char vertically");

            ToolTip toolTipShiftRight = new ToolTip();
            toolTipShiftRight.ShowAlways = true;
            toolTipShiftRight.SetToolTip(btnShiftRight, "Shift all pixels of the current char to the right");

            ToolTip toolTipShiftLeft = new ToolTip();
            toolTipShiftLeft.ShowAlways = true;
            toolTipShiftLeft.SetToolTip(btnShiftLeft, "Shift all pixels of the current char to the left");

            ToolTip toolTipShiftDown = new ToolTip();
            toolTipShiftDown.ShowAlways = true;
            toolTipShiftDown.SetToolTip(btnShiftDown, "Shift all pixels of the current char down");

            ToolTip toolTipShiftUp = new ToolTip();
            toolTipShiftUp.ShowAlways = true;
            toolTipShiftUp.SetToolTip(btnShiftUp, "Shift all pixels of the current char up");

            ToolTip toolTipColor = new ToolTip();
            toolTipColor.ShowAlways = true;
            toolTipColor.SetToolTip(panelCharColor, "Choose color");
            toolTipColor.SetToolTip(panelCharBackgroundColor, "Choose color");
            toolTipColor.SetToolTip(panelCharMultiColor0, "Choose color");
            toolTipColor.SetToolTip(panelCharMultiColor1, "Choose color");

            FillCharData();
        }

        /// <summary>
        /// Refresh content, colors and radiobuttons to the char currently selected
        /// </summary>
        private void RefreshSelectedChar()
        {
            if (rbHiResGeneral.Checked)
            {
                rbHiResCharacter.Checked = true;
                panelCharColor.BackColor = Constants.Colors[charColor[selectedChar]];
            }

            if (rbMultiColorGeneral.Checked && (charColor[selectedChar] & 0b00001000) == 0b00001000)
            {
                rbMultiColorCharacter.Checked = true;

                if ((charColor[selectedChar] & 0b00001000) == 0b00001000)
                {
                    rbMultiColorCharacter.Checked = true;
                }

                panelCharColor.BackColor = Constants.Colors[charColor[selectedChar] & 0b00000111];
            }

            if (rbMultiColorGeneral.Checked && (charColor[selectedChar] & 0b00001000) == 0b00000000)
            {
                rbHiResCharacter.Checked = true;
                panelCharColor.BackColor = Constants.Colors[charColor[selectedChar] & 0b00000111];
            }

            if (rbExtendedGeneral.Checked)
            {
                if (charBackgroundColorExtended[selectedChar] == 0) rbExtendedBackgroundColor0.Checked = true;
                if (charBackgroundColorExtended[selectedChar] == 1) rbExtendedBackgroundColor1.Checked = true;
                if (charBackgroundColorExtended[selectedChar] == 2) rbExtendedBackgroundColor2.Checked = true;
                if (charBackgroundColorExtended[selectedChar] == 3) rbExtendedBackgroundColor3.Checked = true;

                panelCharColor.BackColor = Constants.Colors[charColor[selectedChar]];
            }

            FillCharData();

            pbCharDraw.Invalidate();
            pbChars.Invalidate();
        }

        /// <summary>
        /// Redraw the char data textbox
        /// </summary>
        private void FillCharData()
        {
            tbCharData.Text = "/* CHAR " + selectedChar.ToString() + ": ";
            tbCharData.Text += rbExtendedGeneral.Checked ? "Extended ": "";
            tbCharData.Text += rbHiResCharacter.Checked ? "Hi - Res */\r\n\r\n" : "";
            tbCharData.Text += rbMultiColorCharacter.Checked ? "Multicolor */\r\n\r\n" : "";

            string[] lines = new string[21];
            string[] comment = new string[21];

            for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
            {
                lines[row] = "";
                comment[row] = "/* ";

                for (int column = 0; column < Constants.CHAR_WIDTH; column += 8)
                {
                    byte data = (byte)0x00;

                    if (rbHiResCharacter.Checked)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            data += charData[selectedChar, column + i, row] == 0x01 ? (byte)(Math.Pow(2, (7 - i))): (byte)0;
                            comment[row] += charData[selectedChar, column + i, row] == 0x01 ? "X" : ".";
                        }
                    }

                    if (rbMultiColorCharacter.Checked)
                    {
                        for (int i = 0; i < 8; i += 2)
                        {
                            data += charData[selectedChar, column + i,     row] == 0x01 ? (byte)(Math.Pow(2, (7 - i    ))) : (byte)0;
                            data += charData[selectedChar, column + i + 1, row] == 0x01 ? (byte)(Math.Pow(2, (7 - i - 1))) : (byte)0;

                            if ((charData[selectedChar, column + i, row] == 0x00) && (charData[selectedChar, column + i + 1, row] == 0x00)) comment[row] += "..";
                            if ((charData[selectedChar, column + i, row] == 0x00) && (charData[selectedChar, column + i + 1, row] == 0x01)) comment[row] += "@@";
                            if ((charData[selectedChar, column + i, row] == 0x01) && (charData[selectedChar, column + i + 1, row] == 0x00)) comment[row] += "%%";
                            if ((charData[selectedChar, column + i, row] == 0x01) && (charData[selectedChar, column + i + 1, row] == 0x01)) comment[row] += "XX";
                        }
                    }

                    lines[row] += "0x";
                    lines[row] += string.Format("{0:X2}", data) + ", ";
                }

                comment[row] += " */";
            }

            for (int i = 0; i < lines.Length; i++)
            {
                tbCharData.Text += lines[i];
                if (i == lines.Length - 1)
                {
                    tbCharData.Text = tbCharData.Text.Trim();
                    tbCharData.Text = tbCharData.Text.TrimEnd(',');
                    tbCharData.Text = tbCharData.Text + "  ";
                }

                tbCharData.Text += comment[i];
                if (i != lines.Length - 1) tbCharData.Text += "\r\n";
            }

            tbCharData.Text += "\r\n\r\n";
        }

        /// <summary>
        /// Save header file
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveFile(string fileName)
        {
            string fileContent = "";

            fileContent += "HiResGeneral = " + (rbHiResGeneral.Checked ? "true" : "false") + "\r\n";
            fileContent += "MultiColorGeneral = " + (rbMultiColorGeneral.Checked ? "true" : "false") + "\r\n";
            fileContent += "ExtendedGeneral = " + (rbExtendedGeneral.Checked ? "true" : "false") + "\r\n";
            fileContent += "BackGroundColor  = 0x" + string.Format("{0:X2}", charBackgroundColor) + "\r\n";

            if (rbMultiColorGeneral.Checked)
            {
                fileContent += "CharMultiColor0 = 0x" + string.Format("{0:X2}", charMultiColor0) + "\r\n";
                fileContent += "CharMultiColor1 = 0x" + string.Format("{0:X2}", charMultiColor1) + "\r\n";
            }

            if (rbExtendedGeneral.Checked)
            {
                fileContent += "CharBackgroundColorExtended0 = 0x" + string.Format("{0:X2}", charBackgroundColorExtended0) + "\r\n";
                fileContent += "CharBackgroundColorExtended1 = 0x" + string.Format("{0:X2}", charBackgroundColorExtended1) + "\r\n";
                fileContent += "CharBackgroundColorExtended2 = 0x" + string.Format("{0:X2}", charBackgroundColorExtended2) + "\r\n";
                fileContent += "CharBackgroundColorExtended3 = 0x" + string.Format("{0:X2}", charBackgroundColorExtended3) + "\r\n";
            }

            fileContent += "\r\nCharsColor = \r\n{\r\n    ";

            int num_chars;
            if (rbExtendedGeneral.Checked)
            {
                num_chars = Constants.NUM_CHARS_EXTENDED;
            } else
            {
                num_chars = Constants.NUM_CHARS;
            }

            for (int i = 0; i < num_chars; i++)
            {
                fileContent += "0x" + string.Format("{0:X2}", charColor[i]);
                if (i != num_chars - 1) fileContent += ", ";
                if (((i + 1) % 16 == 0) && ((i + 1) != num_chars)) fileContent += "\r\n    ";
            }

            fileContent += "\r\n}\r\n\r\n";

            if (rbExtendedGeneral.Checked)
            {
                fileContent += "CharsBackgroundColor = \r\n{\r\n    ";
                for (int i = 0; i < num_chars; i++)
                {
                    fileContent += "0x" + string.Format("{0:X2}", charBackgroundColorExtended[i]);
                    if (i != num_chars - 1) fileContent += ", ";
                    if (((i + 1) % 16 == 0) && ((i + 1) != num_chars)) fileContent += "\r\n    ";
                }

                fileContent += "\r\n}\r\n\r\n";
            }

            try
            {
                File.WriteAllText(fileName, fileContent);
            } catch (Exception ex)
            {
                MessageBox.Show("Can't write file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fileName = fileName.Split('.')[0];
            SaveBinaryFile(fileName);

            MessageBox.Show("File saved as\r\n" + fileName, "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Load header file
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadFile(string fileName)
        {
            int numChars = Constants.NUM_CHARS;
            string message = "";
            string fileContent;
            string search;
            int pos = 0;

            try
            {
                fileContent = File.ReadAllText(fileName);
            } catch (Exception ex)
            {
                MessageBox.Show("Can't read file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Radiobuttons
                search = "HiResGeneral";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    bool val = false;
                    bool result = ReadBoolean(fileContent, pos, ref val);
                    if (result)
                    {
                        rbHiResGeneral.Checked = val;
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                search = "MultiColorGeneral";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    bool val = false;
                    bool result = ReadBoolean(fileContent, pos, ref val);
                    if (result)
                    {
                        rbMultiColorGeneral.Checked = val;
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                search = "ExtendedGeneral";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    bool val = false;
                    bool result = ReadBoolean(fileContent, pos, ref val);
                    if (result)
                    {
                        rbExtendedGeneral.Checked = val;
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                // Adjust number of characters if extended mode
                if (rbExtendedGeneral.Checked) numChars = Constants.NUM_CHARS_EXTENDED;

                // Chars backgroundcolor
                search = "BackGroundColor";
                pos = fileContent.IndexOf(search) + search.Length;
                if (pos >= 0)
                {
                    int number = 0;
                    bool result = ReadNumber(fileContent, pos, ref number);
                    if (result)
                    {
                        panelCharBackgroundColor.BackColor = Constants.Colors[number];
                    } else
                    {
                        message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                    }
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                // Char color
                search = "CharsColor";
                pos = fileContent.IndexOf(search);
                if (pos >= 0)
                {
                    pos += search.Length;
                    int posStart = fileContent.IndexOf('{', pos);
                    int posEnd = fileContent.IndexOf('}', pos);
                    string strValues = fileContent.Substring(posStart + 1, posEnd - posStart - 2);
                    string[] temp = strValues.Split(',');

                    string[] values = new string[temp.Length];
                    int index_values = 0;
                    for (int index_temp=0; index_temp < temp.Length; index_temp++)
                    {
                        temp[index_temp] = temp[index_temp].Trim();
                        temp[index_temp] = temp[index_temp].TrimStart('\r');
                        temp[index_temp] = temp[index_temp].TrimStart('\n');
                        if (temp[index_temp][0] == '0') 
                        {
                            values[index_values] = temp[index_temp];
                        }

                        index_values++;
                    }

                    if (index_values == numChars)
                    {
                        for (int index=0; index < values.Length; index++)
                        {
                            int val = 0;;
                            bool result = ReadNumber(values[index], 0, ref val);
                            if (result)
                            {
                                charColor[index] = Convert.ToByte(val);                                
                            } else
                            {
                                message += "Invalid values found for:\r\n" + search + "\r\n\r\n";
                            }
                        }
                    } else
                    {
                        message += "Number of values found for character colors don't match.\r\nExpected: " + numChars + "\r\nFound: " + index_values + "\r\n";
                    } 
                } else
                {
                    message += "Parameter '" + search + "' not found.\r\n\r\n";
                }

                // Char background color
                if (rbExtendedGeneral.Checked)
                {
                    // BackgroundColorExtended 0
                    search = "CharBackgroundColorExtended0";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            charBackgroundColorExtended0 = Convert.ToByte(number);
                            panelExtendedBackgroundColor0.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }

                    // BackgroundColorExtended 1
                    search = "CharBackgroundColorExtended1";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            charBackgroundColorExtended1 = Convert.ToByte(number);
                            panelExtendedBackgroundColor1.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }

                    // BackgroundColorExtended 2
                    search = "CharBackgroundColorExtended2";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            charBackgroundColorExtended2 = Convert.ToByte(number);
                            panelExtendedBackgroundColor2.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }

                    // BackgroundColorExtended 3
                    search = "CharBackgroundColorExtended3";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            charBackgroundColorExtended3 = Convert.ToByte(number);
                            panelExtendedBackgroundColor3.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }

                    search = "CharsBackgroundColor";
                    pos = fileContent.IndexOf(search);
                    if (pos >= 0)
                    {
                        pos += search.Length;
                        int posStart = fileContent.IndexOf('{', pos);
                        int posEnd = fileContent.IndexOf('}', pos);
                        string strValues = fileContent.Substring(posStart + 1, posEnd - posStart - 2);
                        string[] temp = strValues.Split(',');

                        string[] values = new string[temp.Length];
                        int index_values = 0;
                        for (int index_temp = 0; index_temp < temp.Length; index_temp++)
                        {
                            temp[index_temp] = temp[index_temp].Trim();
                            temp[index_temp] = temp[index_temp].TrimStart('\r');
                            temp[index_temp] = temp[index_temp].TrimStart('\n');
                            if (temp[index_temp][0] == '0')
                            {
                                values[index_values] = temp[index_temp];
                            }

                            index_values++;
                        }

                        if (index_values == numChars)
                        {
                            for (int index = 0; index < values.Length; index++)
                            {
                                int val = 0; ;
                                bool result = ReadNumber(values[index], 0, ref val);
                                if (result)
                                {
                                    charBackgroundColorExtended[index] = Convert.ToByte(val);
                                } else
                                {
                                    message += "Invalid values found for:\r\n" + search + "\r\n\r\n";
                                }
                            }
                        } else
                        {
                            message += "Not enough (valid) values found for character background colors\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }
                }

                if (rbMultiColorGeneral.Checked)
                {
                    // Multicolor 0
                    search = "CharMultiColor0";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            charMultiColor0 = Convert.ToByte(number);
                            panelCharMultiColor0.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }

                    // Multicolor 1
                    search = "CharMultiColor1";
                    pos = fileContent.IndexOf(search) + search.Length;
                    if (pos >= 0)
                    {
                        int number = 0;
                        bool result = ReadNumber(fileContent, pos, ref number);
                        if (result && (number >= 0x00) && (number <= 0x0F))
                        {
                            charMultiColor1 = Convert.ToByte(number);
                            panelCharMultiColor1.BackColor = Constants.Colors[number];
                        } else
                        {
                            message += "No (valid) value found for:\r\n" + search + "\r\n\r\n";
                        }
                    } else
                    {
                        message += "Parameter '" + search + "' not found.\r\n\r\n";
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Can't read file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (message != "")
            {
                MessageBox.Show(message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            fileName = fileName.Split('.')[0];
            LoadBinaryFile(fileName + ".64c", 0);
        }

        /// <summary>
        /// Load binary character file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="skipBytes"></param>
        private void LoadBinaryFile(string fileName, int skipBytes)
        {
            byte[] fileContent;

            try
            {
                int index = 0;
                fileContent = File.ReadAllBytes(fileName);

                if (fileContent.Length > skipBytes)
                {
                    for (int i = 0; i < Constants.NUM_CHARS; i++)
                    {
                        for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                        {
                            if ((index + skipBytes) < fileContent.Length)
                            {
                                byte valrow = fileContent[index + skipBytes];
                                for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                                {
                                    byte valcol = (byte)(valrow & (byte)Math.Pow(2, column));
                                    charData[i, Constants.CHAR_WIDTH - 1 - column, row] = (valcol == (byte)0) ? (byte)0 : (byte)1;
                                }

                                index++;
                            }
                        }
                    }
                } else
                {
                    MessageBox.Show("File is smaller then bytes to be skipped\r\n", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Can't read file: " + fileName + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Save binary character file
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveBinaryFile(string fileName)
        {
            byte[] fileContent;
            
            // Char data
            fileContent = new byte[Constants.NUM_CHARS * Constants.CHAR_HEIGHT];

            try
            {
                int index = 0;
                for (int i = 0; i < Constants.NUM_CHARS; i++)
                {
                    for (int row = 0; row < Constants.CHAR_HEIGHT; row++)
                    {
                        for (int column = 0; column < Constants.CHAR_WIDTH; column++)
                        {
                            fileContent[index] += charData[i, Constants.CHAR_WIDTH - 1 - column, row] == 1 ? Convert.ToByte(Math.Pow(2, column)): (byte)0;
                        }

                        index++;
                    }
                }

                File.WriteAllBytes(fileName + ".64c", fileContent);
            } catch (Exception ex)
            {
                MessageBox.Show("Can't write file: " + fileName + ".64c" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Char color data
            int num_chars;
            if (rbExtendedGeneral.Checked)
            {
                num_chars = Constants.NUM_CHARS_EXTENDED;
            } else
            {
                num_chars = Constants.NUM_CHARS;
            }

            fileContent = new byte[num_chars];

            try
            {
                for (int i = 0; i < num_chars; i++)
                {
                    fileContent[i] += charColor[i];
                }

                File.WriteAllBytes(fileName + ".col", fileContent);
            } catch (Exception ex)
            {
                MessageBox.Show("Can't write file: " + fileName + ".col" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Char background color data
            if (rbExtendedGeneral.Checked)
            {
                fileContent = new byte[num_chars];

                try
                {
                    for (int i = 0; i < num_chars; i++)
                    {
                        if (charBackgroundColorExtended[i] == 0) fileContent[i] += charBackgroundColorExtended0;
                        if (charBackgroundColorExtended[i] == 1) fileContent[i] += charBackgroundColorExtended1;
                        if (charBackgroundColorExtended[i] == 2) fileContent[i] += charBackgroundColorExtended2;
                        if (charBackgroundColorExtended[i] == 3) fileContent[i] += charBackgroundColorExtended3;
                    }

                    File.WriteAllBytes(fileName + ".bac", fileContent);
                } catch (Exception ex)
                {
                    MessageBox.Show("Can't write file: " + fileName + ".bac" + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Read a number in the file (decimal, hexadecimal or binary)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pos"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool ReadNumber(string content, int pos, ref int number)
        {
            if (content == null) return false;
            if (pos >= content.Length) return false;

            string skipChars = " \t\n\r=;,";

            // Skip spaces, tabs, newlines etc.
            while ((pos < content.Length) && skipChars.Contains(content[pos])) pos++;

            // Skip comment
            if ((pos < content.Length) && (content[pos] == '/') && (content[pos + 1] == '*'))
            {
                while ((pos < content.Length) && !((content[pos] == '*') && (content[pos + 1] == '/'))) pos++;
                if ((content[pos] == '*') && (content[pos + 1] == '/')) pos += 2;
                while ((pos < content.Length) && skipChars.Contains(content[pos])) pos++;
            }

            // EOF
            if (pos == content.Length) return false;

            if ((content[pos] == '0') && (content[pos + 1] == 'x')) // HEX number
            {
                pos += 2;

                // Read positions until space, newline, tab etc.
                string strNum = "";
                while ((pos < content.Length) && !skipChars.Contains(content[pos]))
                {
                    strNum += content[pos];
                    pos++;
                }

                // Calculate number
                bool result = int.TryParse(strNum, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out number);

                return result;
            } else
            if ((content[pos] == '0') && (content[pos + 1] == 'b')) // BIN number
            {
                pos += 2;

                // Read positions until space, newline, tab etc.
                string strNum = "";
                while (!skipChars.Contains(content[pos]) && (pos < content.Length)) strNum += content[pos++];

                // Calculate number
                number = 0;
                for (int i = 0; i < strNum.Length; i++)
                {
                    if (strNum[i] == '1') number += Convert.ToInt32(Math.Pow(2, strNum.Length - i -1));
                }

                return true;
            } else
            if (char.IsDigit(content[pos])) // DEC number
            {
                // Read positions until space, newline, tab etc.
                string strNum = "";
                while (!skipChars.Contains(content[pos]) && (pos < content.Length)) strNum += content[pos++];

                // Calculate number
                bool result = int.TryParse(strNum, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out number);

                return result;
            }

            return false;
        }

        /// <summary>
        /// Read a boolean in the file (true/false)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pos"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool ReadBoolean(string content, int pos, ref bool val)
        {
            if (content == null) return false;
            if (pos >= content.Length) return false;

            string skipChars = " \t\n\r=;,";

            // Skip spaces, tabs, newlines etc.
            while ((pos < content.Length) && skipChars.Contains(content[pos])) pos++;

            // Skip comment
            if ((pos < content.Length) && (content[pos] == '/') && (content[pos + 1] == '*'))
            {
                while ((pos < content.Length) && !((content[pos] == '*') && (content[pos + 1] == '/'))) pos++;
                if ((content[pos] == '*') && (content[pos + 1] == '/')) pos += 2;
                while ((pos < content.Length) && skipChars.Contains(content[pos])) pos++;
            }

            // EOF
            if (pos == content.Length) return false;
            if (pos + 1 == content.Length) return false;
            if (pos + 2 == content.Length) return false;
            if (pos + 3 == content.Length) return false;

            if ((content[pos] == 't') && (content[pos + 1] == 'r') && (content[pos + 2] == 'u') && (content[pos + 3] == 'e')) // True
            {
                val = true;
                return true;
            }

            if (pos + 4 == content.Length) return false;

            if ((content[pos] == 'f') && (content[pos + 1] == 'a') && (content[pos + 2] == 'l') && (content[pos + 3] == 's') && (content[pos + 4] == 'e')) // False
            {
                val = false;
                return true;
            }

            return false;
        }

        #endregion
    }
}
