namespace CharEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbCharDraw = new System.Windows.Forms.PictureBox();
            this.rbHiResCharacter = new System.Windows.Forms.RadioButton();
            this.rbMultiColorCharacter = new System.Windows.Forms.RadioButton();
            this.panelColors = new System.Windows.Forms.Panel();
            this.panelHiResMultiColor = new System.Windows.Forms.Panel();
            this.lblCharacterMode = new System.Windows.Forms.Label();
            this.rbCharMultiColor1 = new System.Windows.Forms.RadioButton();
            this.panelCharMultiColor1 = new System.Windows.Forms.Panel();
            this.rbCharMultiColor0 = new System.Windows.Forms.RadioButton();
            this.panelCharMultiColor0 = new System.Windows.Forms.Panel();
            this.rbCharBackgroundColor = new System.Windows.Forms.RadioButton();
            this.panelCharBackgroundColor = new System.Windows.Forms.Panel();
            this.panelCharColor = new System.Windows.Forms.Panel();
            this.rbCharColor = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbCharData = new System.Windows.Forms.TextBox();
            this.pbChars = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMirrorHorizontal = new System.Windows.Forms.Button();
            this.btnMirrorVertical = new System.Windows.Forms.Button();
            this.btnShiftRight = new System.Windows.Forms.Button();
            this.btnShiftLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnShiftDown = new System.Windows.Forms.Button();
            this.btnShiftUp = new System.Windows.Forms.Button();
            this.rbExtendedGeneral = new System.Windows.Forms.RadioButton();
            this.rbHiResGeneral = new System.Windows.Forms.RadioButton();
            this.rbMultiColorGeneral = new System.Windows.Forms.RadioButton();
            this.lblGeneralMode = new System.Windows.Forms.Label();
            this.rbExtendedBackgroundColor1 = new System.Windows.Forms.RadioButton();
            this.panelExtendedBackgroundColor1 = new System.Windows.Forms.Panel();
            this.rbExtendedBackgroundColor2 = new System.Windows.Forms.RadioButton();
            this.panelExtendedBackgroundColor0 = new System.Windows.Forms.Panel();
            this.panelExtendedBackgroundColor3 = new System.Windows.Forms.Panel();
            this.rbExtendedBackgroundColor0 = new System.Windows.Forms.RadioButton();
            this.rbExtendedBackgroundColor3 = new System.Windows.Forms.RadioButton();
            this.panelExtendedBackgroundColor2 = new System.Windows.Forms.Panel();
            this.panelExtendedMode = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharDraw)).BeginInit();
            this.panelColors.SuspendLayout();
            this.panelHiResMultiColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChars)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panelExtendedMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCharDraw
            // 
            this.pbCharDraw.BackColor = System.Drawing.Color.Black;
            this.pbCharDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCharDraw.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbCharDraw.Location = new System.Drawing.Point(12, 27);
            this.pbCharDraw.Name = "pbCharDraw";
            this.pbCharDraw.Size = new System.Drawing.Size(80, 80);
            this.pbCharDraw.TabIndex = 0;
            this.pbCharDraw.TabStop = false;
            this.pbCharDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCharDraw_Paint);
            this.pbCharDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCharDraw_MouseDown);
            this.pbCharDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCharDraw_MouseUp);
            // 
            // rbHiResCharacter
            // 
            this.rbHiResCharacter.AutoSize = true;
            this.rbHiResCharacter.Checked = true;
            this.rbHiResCharacter.Location = new System.Drawing.Point(157, 3);
            this.rbHiResCharacter.Name = "rbHiResCharacter";
            this.rbHiResCharacter.Size = new System.Drawing.Size(54, 17);
            this.rbHiResCharacter.TabIndex = 1;
            this.rbHiResCharacter.TabStop = true;
            this.rbHiResCharacter.Text = "HiRes";
            this.rbHiResCharacter.UseVisualStyleBackColor = true;
            this.rbHiResCharacter.CheckedChanged += new System.EventHandler(this.rbHiResCharacter_CheckedChanged);
            // 
            // rbMultiColorCharacter
            // 
            this.rbMultiColorCharacter.AutoSize = true;
            this.rbMultiColorCharacter.Enabled = false;
            this.rbMultiColorCharacter.Location = new System.Drawing.Point(220, 3);
            this.rbMultiColorCharacter.Name = "rbMultiColorCharacter";
            this.rbMultiColorCharacter.Size = new System.Drawing.Size(71, 17);
            this.rbMultiColorCharacter.TabIndex = 1;
            this.rbMultiColorCharacter.Text = "MultiColor";
            this.rbMultiColorCharacter.UseVisualStyleBackColor = true;
            this.rbMultiColorCharacter.CheckedChanged += new System.EventHandler(this.rbMultiColorCharacter_CheckedChanged);
            // 
            // panelColors
            // 
            this.panelColors.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColors.Controls.Add(this.panelHiResMultiColor);
            this.panelColors.Controls.Add(this.rbCharMultiColor1);
            this.panelColors.Controls.Add(this.panelCharMultiColor1);
            this.panelColors.Controls.Add(this.rbCharMultiColor0);
            this.panelColors.Controls.Add(this.panelCharMultiColor0);
            this.panelColors.Controls.Add(this.rbCharBackgroundColor);
            this.panelColors.Controls.Add(this.panelCharBackgroundColor);
            this.panelColors.Controls.Add(this.panelCharColor);
            this.panelColors.Controls.Add(this.rbCharColor);
            this.panelColors.Location = new System.Drawing.Point(12, 409);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(304, 155);
            this.panelColors.TabIndex = 2;
            // 
            // panelHiResMultiColor
            // 
            this.panelHiResMultiColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelHiResMultiColor.Controls.Add(this.lblCharacterMode);
            this.panelHiResMultiColor.Controls.Add(this.rbHiResCharacter);
            this.panelHiResMultiColor.Controls.Add(this.rbMultiColorCharacter);
            this.panelHiResMultiColor.Location = new System.Drawing.Point(5, 5);
            this.panelHiResMultiColor.Name = "panelHiResMultiColor";
            this.panelHiResMultiColor.Size = new System.Drawing.Size(294, 24);
            this.panelHiResMultiColor.TabIndex = 2;
            // 
            // lblCharacterMode
            // 
            this.lblCharacterMode.AutoSize = true;
            this.lblCharacterMode.Location = new System.Drawing.Point(5, 5);
            this.lblCharacterMode.Name = "lblCharacterMode";
            this.lblCharacterMode.Size = new System.Drawing.Size(86, 13);
            this.lblCharacterMode.TabIndex = 22;
            this.lblCharacterMode.Text = "Character Mode:";
            // 
            // rbCharMultiColor1
            // 
            this.rbCharMultiColor1.AutoSize = true;
            this.rbCharMultiColor1.Enabled = false;
            this.rbCharMultiColor1.Location = new System.Drawing.Point(5, 127);
            this.rbCharMultiColor1.Name = "rbCharMultiColor1";
            this.rbCharMultiColor1.Size = new System.Drawing.Size(77, 17);
            this.rbCharMultiColor1.TabIndex = 0;
            this.rbCharMultiColor1.Text = "MultiColor1";
            this.rbCharMultiColor1.UseVisualStyleBackColor = true;
            // 
            // panelCharMultiColor1
            // 
            this.panelCharMultiColor1.BackColor = System.Drawing.Color.Gray;
            this.panelCharMultiColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharMultiColor1.Enabled = false;
            this.panelCharMultiColor1.Location = new System.Drawing.Point(216, 127);
            this.panelCharMultiColor1.Name = "panelCharMultiColor1";
            this.panelCharMultiColor1.Size = new System.Drawing.Size(80, 18);
            this.panelCharMultiColor1.TabIndex = 1;
            this.panelCharMultiColor1.Click += new System.EventHandler(this.panelCharColor_Click);
            // 
            // rbCharMultiColor0
            // 
            this.rbCharMultiColor0.AutoSize = true;
            this.rbCharMultiColor0.Enabled = false;
            this.rbCharMultiColor0.Location = new System.Drawing.Point(4, 105);
            this.rbCharMultiColor0.Name = "rbCharMultiColor0";
            this.rbCharMultiColor0.Size = new System.Drawing.Size(77, 17);
            this.rbCharMultiColor0.TabIndex = 0;
            this.rbCharMultiColor0.Text = "MultiColor0";
            this.rbCharMultiColor0.UseVisualStyleBackColor = true;
            // 
            // panelCharMultiColor0
            // 
            this.panelCharMultiColor0.BackColor = System.Drawing.Color.LightGray;
            this.panelCharMultiColor0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharMultiColor0.Enabled = false;
            this.panelCharMultiColor0.Location = new System.Drawing.Point(216, 105);
            this.panelCharMultiColor0.Name = "panelCharMultiColor0";
            this.panelCharMultiColor0.Size = new System.Drawing.Size(80, 18);
            this.panelCharMultiColor0.TabIndex = 1;
            this.panelCharMultiColor0.Click += new System.EventHandler(this.panelCharColor_Click);
            // 
            // rbCharBackgroundColor
            // 
            this.rbCharBackgroundColor.AutoSize = true;
            this.rbCharBackgroundColor.Location = new System.Drawing.Point(4, 83);
            this.rbCharBackgroundColor.Name = "rbCharBackgroundColor";
            this.rbCharBackgroundColor.Size = new System.Drawing.Size(83, 17);
            this.rbCharBackgroundColor.TabIndex = 0;
            this.rbCharBackgroundColor.Text = "Background";
            this.rbCharBackgroundColor.UseVisualStyleBackColor = true;
            // 
            // panelCharBackgroundColor
            // 
            this.panelCharBackgroundColor.BackColor = System.Drawing.Color.Black;
            this.panelCharBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharBackgroundColor.Location = new System.Drawing.Point(216, 83);
            this.panelCharBackgroundColor.Name = "panelCharBackgroundColor";
            this.panelCharBackgroundColor.Size = new System.Drawing.Size(80, 18);
            this.panelCharBackgroundColor.TabIndex = 1;
            this.panelCharBackgroundColor.Click += new System.EventHandler(this.panelCharColor_Click);
            // 
            // panelCharColor
            // 
            this.panelCharColor.BackColor = System.Drawing.Color.White;
            this.panelCharColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharColor.Location = new System.Drawing.Point(216, 60);
            this.panelCharColor.Name = "panelCharColor";
            this.panelCharColor.Size = new System.Drawing.Size(80, 18);
            this.panelCharColor.TabIndex = 1;
            this.panelCharColor.Click += new System.EventHandler(this.panelCharColor_Click);
            // 
            // rbCharColor
            // 
            this.rbCharColor.AutoSize = true;
            this.rbCharColor.Checked = true;
            this.rbCharColor.Location = new System.Drawing.Point(4, 60);
            this.rbCharColor.Name = "rbCharColor";
            this.rbCharColor.Size = new System.Drawing.Size(49, 17);
            this.rbCharColor.TabIndex = 0;
            this.rbCharColor.TabStop = true;
            this.rbCharColor.Text = "Color";
            this.rbCharColor.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 694);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(304, 24);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbCharData
            // 
            this.tbCharData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCharData.BackColor = System.Drawing.SystemColors.Info;
            this.tbCharData.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCharData.Location = new System.Drawing.Point(322, 27);
            this.tbCharData.Multiline = true;
            this.tbCharData.Name = "tbCharData";
            this.tbCharData.ReadOnly = true;
            this.tbCharData.Size = new System.Drawing.Size(659, 691);
            this.tbCharData.TabIndex = 4;
            // 
            // pbChars
            // 
            this.pbChars.BackColor = System.Drawing.Color.Black;
            this.pbChars.Location = new System.Drawing.Point(12, 113);
            this.pbChars.Name = "pbChars";
            this.pbChars.Size = new System.Drawing.Size(290, 290);
            this.pbChars.TabIndex = 5;
            this.pbChars.TabStop = false;
            this.pbChars.Click += new System.EventHandler(this.pbChars_Click);
            this.pbChars.Paint += new System.Windows.Forms.PaintEventHandler(this.pbChars_Paint);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(984, 25);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadBinaryToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 19);
            this.toolStripMenuItem1.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadBinaryToolStripMenuItem
            // 
            this.loadBinaryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadBinaryToolStripMenuItem.Image")));
            this.loadBinaryToolStripMenuItem.Name = "loadBinaryToolStripMenuItem";
            this.loadBinaryToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadBinaryToolStripMenuItem.Text = "Load Binary";
            this.loadBinaryToolStripMenuItem.Click += new System.EventHandler(this.loadBinaryToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToolStripMenuItem.Image")));
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 19);
            this.toolStripMenuItem2.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manualToolStripMenuItem.Image")));
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnMirrorHorizontal
            // 
            this.btnMirrorHorizontal.BackColor = System.Drawing.Color.White;
            this.btnMirrorHorizontal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMirrorHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("btnMirrorHorizontal.Image")));
            this.btnMirrorHorizontal.Location = new System.Drawing.Point(12, 570);
            this.btnMirrorHorizontal.Name = "btnMirrorHorizontal";
            this.btnMirrorHorizontal.Size = new System.Drawing.Size(56, 56);
            this.btnMirrorHorizontal.TabIndex = 8;
            this.btnMirrorHorizontal.UseVisualStyleBackColor = false;
            this.btnMirrorHorizontal.Click += new System.EventHandler(this.btnMirrorHorizontal_Click);
            // 
            // btnMirrorVertical
            // 
            this.btnMirrorVertical.BackColor = System.Drawing.Color.White;
            this.btnMirrorVertical.Image = ((System.Drawing.Image)(resources.GetObject("btnMirrorVertical.Image")));
            this.btnMirrorVertical.Location = new System.Drawing.Point(74, 570);
            this.btnMirrorVertical.Name = "btnMirrorVertical";
            this.btnMirrorVertical.Size = new System.Drawing.Size(56, 56);
            this.btnMirrorVertical.TabIndex = 9;
            this.btnMirrorVertical.UseVisualStyleBackColor = false;
            this.btnMirrorVertical.Click += new System.EventHandler(this.btnMirrorVertical_Click);
            // 
            // btnShiftRight
            // 
            this.btnShiftRight.BackColor = System.Drawing.Color.White;
            this.btnShiftRight.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftRight.Image")));
            this.btnShiftRight.Location = new System.Drawing.Point(136, 570);
            this.btnShiftRight.Name = "btnShiftRight";
            this.btnShiftRight.Size = new System.Drawing.Size(56, 56);
            this.btnShiftRight.TabIndex = 10;
            this.btnShiftRight.UseVisualStyleBackColor = false;
            this.btnShiftRight.Click += new System.EventHandler(this.btnShiftRight_Click);
            // 
            // btnShiftLeft
            // 
            this.btnShiftLeft.BackColor = System.Drawing.Color.White;
            this.btnShiftLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftLeft.Image")));
            this.btnShiftLeft.Location = new System.Drawing.Point(198, 570);
            this.btnShiftLeft.Name = "btnShiftLeft";
            this.btnShiftLeft.Size = new System.Drawing.Size(56, 56);
            this.btnShiftLeft.TabIndex = 11;
            this.btnShiftLeft.UseVisualStyleBackColor = false;
            this.btnShiftLeft.Click += new System.EventHandler(this.btnShiftLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.BackColor = System.Drawing.Color.White;
            this.btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateRight.Image")));
            this.btnRotateRight.Location = new System.Drawing.Point(12, 632);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(56, 56);
            this.btnRotateRight.TabIndex = 12;
            this.btnRotateRight.UseVisualStyleBackColor = false;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.BackColor = System.Drawing.Color.White;
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(74, 632);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(56, 56);
            this.btnRotateLeft.TabIndex = 13;
            this.btnRotateLeft.UseVisualStyleBackColor = false;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.White;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(136, 632);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(56, 56);
            this.btnCopy.TabIndex = 14;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.BackColor = System.Drawing.Color.White;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Location = new System.Drawing.Point(198, 632);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(56, 56);
            this.btnPaste.TabIndex = 15;
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnShiftDown
            // 
            this.btnShiftDown.BackColor = System.Drawing.Color.White;
            this.btnShiftDown.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftDown.Image")));
            this.btnShiftDown.Location = new System.Drawing.Point(260, 632);
            this.btnShiftDown.Name = "btnShiftDown";
            this.btnShiftDown.Size = new System.Drawing.Size(56, 56);
            this.btnShiftDown.TabIndex = 17;
            this.btnShiftDown.UseVisualStyleBackColor = false;
            this.btnShiftDown.Click += new System.EventHandler(this.btnShiftDown_Click);
            // 
            // btnShiftUp
            // 
            this.btnShiftUp.BackColor = System.Drawing.Color.White;
            this.btnShiftUp.Image = ((System.Drawing.Image)(resources.GetObject("btnShiftUp.Image")));
            this.btnShiftUp.Location = new System.Drawing.Point(260, 570);
            this.btnShiftUp.Name = "btnShiftUp";
            this.btnShiftUp.Size = new System.Drawing.Size(56, 56);
            this.btnShiftUp.TabIndex = 16;
            this.btnShiftUp.UseVisualStyleBackColor = false;
            this.btnShiftUp.Click += new System.EventHandler(this.btnShiftUp_Click);
            // 
            // rbExtendedGeneral
            // 
            this.rbExtendedGeneral.AutoSize = true;
            this.rbExtendedGeneral.Location = new System.Drawing.Point(98, 89);
            this.rbExtendedGeneral.Name = "rbExtendedGeneral";
            this.rbExtendedGeneral.Size = new System.Drawing.Size(70, 17);
            this.rbExtendedGeneral.TabIndex = 20;
            this.rbExtendedGeneral.Text = "Extended";
            this.rbExtendedGeneral.UseVisualStyleBackColor = true;
            this.rbExtendedGeneral.CheckedChanged += new System.EventHandler(this.rbExtendedGeneral_CheckedChanged);
            // 
            // rbHiResGeneral
            // 
            this.rbHiResGeneral.AutoSize = true;
            this.rbHiResGeneral.Checked = true;
            this.rbHiResGeneral.Location = new System.Drawing.Point(98, 43);
            this.rbHiResGeneral.Name = "rbHiResGeneral";
            this.rbHiResGeneral.Size = new System.Drawing.Size(54, 17);
            this.rbHiResGeneral.TabIndex = 18;
            this.rbHiResGeneral.TabStop = true;
            this.rbHiResGeneral.Text = "HiRes";
            this.rbHiResGeneral.UseVisualStyleBackColor = true;
            this.rbHiResGeneral.CheckedChanged += new System.EventHandler(this.rbHiResGeneral_CheckedChanged);
            // 
            // rbMultiColorGeneral
            // 
            this.rbMultiColorGeneral.AutoSize = true;
            this.rbMultiColorGeneral.Location = new System.Drawing.Point(98, 66);
            this.rbMultiColorGeneral.Name = "rbMultiColorGeneral";
            this.rbMultiColorGeneral.Size = new System.Drawing.Size(71, 17);
            this.rbMultiColorGeneral.TabIndex = 19;
            this.rbMultiColorGeneral.Text = "MultiColor";
            this.rbMultiColorGeneral.UseVisualStyleBackColor = true;
            this.rbMultiColorGeneral.CheckedChanged += new System.EventHandler(this.rbMultiColorGeneral_CheckedChanged);
            // 
            // lblGeneralMode
            // 
            this.lblGeneralMode.AutoSize = true;
            this.lblGeneralMode.Location = new System.Drawing.Point(95, 27);
            this.lblGeneralMode.Name = "lblGeneralMode";
            this.lblGeneralMode.Size = new System.Drawing.Size(77, 13);
            this.lblGeneralMode.TabIndex = 21;
            this.lblGeneralMode.Text = "General Mode:";
            // 
            // rbExtendedBackgroundColor1
            // 
            this.rbExtendedBackgroundColor1.AutoSize = true;
            this.rbExtendedBackgroundColor1.Location = new System.Drawing.Point(4, 26);
            this.rbExtendedBackgroundColor1.Name = "rbExtendedBackgroundColor1";
            this.rbExtendedBackgroundColor1.Size = new System.Drawing.Size(44, 17);
            this.rbExtendedBackgroundColor1.TabIndex = 24;
            this.rbExtendedBackgroundColor1.Text = "Bg1";
            this.rbExtendedBackgroundColor1.UseVisualStyleBackColor = true;
            this.rbExtendedBackgroundColor1.CheckedChanged += new System.EventHandler(this.rbExtendedBackgroundColor_CheckedChanged);
            // 
            // panelExtendedBackgroundColor1
            // 
            this.panelExtendedBackgroundColor1.BackColor = System.Drawing.Color.White;
            this.panelExtendedBackgroundColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExtendedBackgroundColor1.Location = new System.Drawing.Point(53, 25);
            this.panelExtendedBackgroundColor1.Name = "panelExtendedBackgroundColor1";
            this.panelExtendedBackgroundColor1.Size = new System.Drawing.Size(52, 18);
            this.panelExtendedBackgroundColor1.TabIndex = 28;
            this.panelExtendedBackgroundColor1.Click += new System.EventHandler(this.panelBackgroundColor_Click);
            // 
            // rbExtendedBackgroundColor2
            // 
            this.rbExtendedBackgroundColor2.AutoSize = true;
            this.rbExtendedBackgroundColor2.Location = new System.Drawing.Point(3, 49);
            this.rbExtendedBackgroundColor2.Name = "rbExtendedBackgroundColor2";
            this.rbExtendedBackgroundColor2.Size = new System.Drawing.Size(44, 17);
            this.rbExtendedBackgroundColor2.TabIndex = 23;
            this.rbExtendedBackgroundColor2.Text = "Bg2";
            this.rbExtendedBackgroundColor2.UseVisualStyleBackColor = true;
            this.rbExtendedBackgroundColor2.CheckedChanged += new System.EventHandler(this.rbExtendedBackgroundColor_CheckedChanged);
            // 
            // panelExtendedBackgroundColor0
            // 
            this.panelExtendedBackgroundColor0.BackColor = System.Drawing.Color.Black;
            this.panelExtendedBackgroundColor0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExtendedBackgroundColor0.Location = new System.Drawing.Point(53, 3);
            this.panelExtendedBackgroundColor0.Name = "panelExtendedBackgroundColor0";
            this.panelExtendedBackgroundColor0.Size = new System.Drawing.Size(52, 18);
            this.panelExtendedBackgroundColor0.TabIndex = 29;
            this.panelExtendedBackgroundColor0.Click += new System.EventHandler(this.panelBackgroundColor_Click);
            // 
            // panelExtendedBackgroundColor3
            // 
            this.panelExtendedBackgroundColor3.BackColor = System.Drawing.Color.LightGray;
            this.panelExtendedBackgroundColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExtendedBackgroundColor3.Location = new System.Drawing.Point(53, 71);
            this.panelExtendedBackgroundColor3.Name = "panelExtendedBackgroundColor3";
            this.panelExtendedBackgroundColor3.Size = new System.Drawing.Size(52, 18);
            this.panelExtendedBackgroundColor3.TabIndex = 26;
            this.panelExtendedBackgroundColor3.Click += new System.EventHandler(this.panelBackgroundColor_Click);
            // 
            // rbExtendedBackgroundColor0
            // 
            this.rbExtendedBackgroundColor0.AutoSize = true;
            this.rbExtendedBackgroundColor0.Checked = true;
            this.rbExtendedBackgroundColor0.Location = new System.Drawing.Point(3, 3);
            this.rbExtendedBackgroundColor0.Name = "rbExtendedBackgroundColor0";
            this.rbExtendedBackgroundColor0.Size = new System.Drawing.Size(44, 17);
            this.rbExtendedBackgroundColor0.TabIndex = 25;
            this.rbExtendedBackgroundColor0.TabStop = true;
            this.rbExtendedBackgroundColor0.Text = "Bg0";
            this.rbExtendedBackgroundColor0.UseVisualStyleBackColor = true;
            this.rbExtendedBackgroundColor0.CheckedChanged += new System.EventHandler(this.rbExtendedBackgroundColor_CheckedChanged);
            // 
            // rbExtendedBackgroundColor3
            // 
            this.rbExtendedBackgroundColor3.AutoSize = true;
            this.rbExtendedBackgroundColor3.Location = new System.Drawing.Point(4, 72);
            this.rbExtendedBackgroundColor3.Name = "rbExtendedBackgroundColor3";
            this.rbExtendedBackgroundColor3.Size = new System.Drawing.Size(44, 17);
            this.rbExtendedBackgroundColor3.TabIndex = 22;
            this.rbExtendedBackgroundColor3.Text = "Bg3";
            this.rbExtendedBackgroundColor3.UseVisualStyleBackColor = true;
            this.rbExtendedBackgroundColor3.CheckedChanged += new System.EventHandler(this.rbExtendedBackgroundColor_CheckedChanged);
            // 
            // panelExtendedBackgroundColor2
            // 
            this.panelExtendedBackgroundColor2.BackColor = System.Drawing.Color.Gray;
            this.panelExtendedBackgroundColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExtendedBackgroundColor2.Location = new System.Drawing.Point(53, 49);
            this.panelExtendedBackgroundColor2.Name = "panelExtendedBackgroundColor2";
            this.panelExtendedBackgroundColor2.Size = new System.Drawing.Size(52, 18);
            this.panelExtendedBackgroundColor2.TabIndex = 27;
            this.panelExtendedBackgroundColor2.Click += new System.EventHandler(this.panelBackgroundColor_Click);
            // 
            // panelExtendedMode
            // 
            this.panelExtendedMode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelExtendedMode.Controls.Add(this.panelExtendedBackgroundColor2);
            this.panelExtendedMode.Controls.Add(this.rbExtendedBackgroundColor3);
            this.panelExtendedMode.Controls.Add(this.rbExtendedBackgroundColor0);
            this.panelExtendedMode.Controls.Add(this.panelExtendedBackgroundColor3);
            this.panelExtendedMode.Controls.Add(this.panelExtendedBackgroundColor0);
            this.panelExtendedMode.Controls.Add(this.rbExtendedBackgroundColor2);
            this.panelExtendedMode.Controls.Add(this.panelExtendedBackgroundColor1);
            this.panelExtendedMode.Controls.Add(this.rbExtendedBackgroundColor1);
            this.panelExtendedMode.Location = new System.Drawing.Point(194, 12);
            this.panelExtendedMode.Name = "panelExtendedMode";
            this.panelExtendedMode.Size = new System.Drawing.Size(108, 95);
            this.panelExtendedMode.TabIndex = 30;
            this.panelExtendedMode.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 741);
            this.Controls.Add(this.panelExtendedMode);
            this.Controls.Add(this.lblGeneralMode);
            this.Controls.Add(this.rbExtendedGeneral);
            this.Controls.Add(this.rbHiResGeneral);
            this.Controls.Add(this.rbMultiColorGeneral);
            this.Controls.Add(this.btnShiftDown);
            this.Controls.Add(this.btnShiftUp);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.btnShiftLeft);
            this.Controls.Add(this.btnShiftRight);
            this.Controls.Add(this.btnMirrorVertical);
            this.Controls.Add(this.btnMirrorHorizontal);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pbChars);
            this.Controls.Add(this.tbCharData);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.pbCharDraw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 780);
            this.Name = "MainForm";
            this.Text = "CharEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pbCharDraw)).EndInit();
            this.panelColors.ResumeLayout(false);
            this.panelColors.PerformLayout();
            this.panelHiResMultiColor.ResumeLayout(false);
            this.panelHiResMultiColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChars)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelExtendedMode.ResumeLayout(false);
            this.panelExtendedMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCharDraw;
        private System.Windows.Forms.RadioButton rbHiResCharacter;
        private System.Windows.Forms.RadioButton rbMultiColorCharacter;
        private System.Windows.Forms.Panel panelColors;
        private System.Windows.Forms.RadioButton rbCharColor;
        private System.Windows.Forms.Panel panelCharColor;
        private System.Windows.Forms.RadioButton rbCharMultiColor1;
        private System.Windows.Forms.Panel panelCharMultiColor1;
        private System.Windows.Forms.RadioButton rbCharMultiColor0;
        private System.Windows.Forms.Panel panelCharMultiColor0;
        private System.Windows.Forms.RadioButton rbCharBackgroundColor;
        private System.Windows.Forms.Panel panelCharBackgroundColor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbCharData;
        private System.Windows.Forms.PictureBox pbChars;
        private System.Windows.Forms.Panel panelHiResMultiColor;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnMirrorHorizontal;
        private System.Windows.Forms.Button btnMirrorVertical;
        private System.Windows.Forms.Button btnShiftRight;
        private System.Windows.Forms.Button btnShiftLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnShiftDown;
        private System.Windows.Forms.Button btnShiftUp;
        private System.Windows.Forms.Label lblCharacterMode;
        private System.Windows.Forms.RadioButton rbExtendedGeneral;
        private System.Windows.Forms.RadioButton rbHiResGeneral;
        private System.Windows.Forms.RadioButton rbMultiColorGeneral;
        private System.Windows.Forms.Label lblGeneralMode;
        private System.Windows.Forms.RadioButton rbExtendedBackgroundColor1;
        private System.Windows.Forms.Panel panelExtendedBackgroundColor1;
        private System.Windows.Forms.RadioButton rbExtendedBackgroundColor2;
        private System.Windows.Forms.Panel panelExtendedBackgroundColor0;
        private System.Windows.Forms.Panel panelExtendedBackgroundColor3;
        private System.Windows.Forms.RadioButton rbExtendedBackgroundColor0;
        private System.Windows.Forms.RadioButton rbExtendedBackgroundColor3;
        private System.Windows.Forms.Panel panelExtendedBackgroundColor2;
        private System.Windows.Forms.Panel panelExtendedMode;
        private System.Windows.Forms.ToolStripMenuItem loadBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

