
namespace CharEditor
{
    partial class FormSkipBytes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSkipBytes));
            this.btnOK = new System.Windows.Forms.Button();
            this.numBytes = new System.Windows.Forms.NumericUpDown();
            this.lblSkip = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBytes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(197, 126);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // numBytes
            // 
            this.numBytes.Location = new System.Drawing.Point(197, 100);
            this.numBytes.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.numBytes.Name = "numBytes";
            this.numBytes.Size = new System.Drawing.Size(75, 20);
            this.numBytes.TabIndex = 1;
            // 
            // lblSkip
            // 
            this.lblSkip.AutoSize = true;
            this.lblSkip.Location = new System.Drawing.Point(12, 102);
            this.lblSkip.Name = "lblSkip";
            this.lblSkip.Size = new System.Drawing.Size(148, 13);
            this.lblSkip.TabIndex = 2;
            this.lblSkip.Text = "Skip bytes at beginning of file:";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(12, 12);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ReadOnly = true;
            this.tbComment.Size = new System.Drawing.Size(260, 82);
            this.tbComment.TabIndex = 3;
            this.tbComment.Text = resources.GetString("tbComment.Text");
            // 
            // FormSkipBytes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.ControlBox = false;
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.lblSkip);
            this.Controls.Add(this.numBytes);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FormSkipBytes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SkipBytes";
            ((System.ComponentModel.ISupportInitialize)(this.numBytes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numBytes;
        private System.Windows.Forms.Label lblSkip;
        private System.Windows.Forms.TextBox tbComment;
    }
}