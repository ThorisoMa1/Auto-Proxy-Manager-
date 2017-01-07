namespace autoPchanger.Presentation
{
    partial class AboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUs));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lbl_AuthorName = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.Txt_Desc = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 195);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(255, 74);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(35, 13);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.Text = "About";
            // 
            // lbl_AuthorName
            // 
            this.lbl_AuthorName.AutoSize = true;
            this.lbl_AuthorName.Location = new System.Drawing.Point(149, 24);
            this.lbl_AuthorName.Name = "lbl_AuthorName";
            this.lbl_AuthorName.Size = new System.Drawing.Size(66, 13);
            this.lbl_AuthorName.TabIndex = 2;
            this.lbl_AuthorName.Text = "AuthorName";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(341, 24);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(42, 13);
            this.lbl_Version.TabIndex = 3;
            this.lbl_Version.Text = "Version";
            // 
            // Txt_Desc
            // 
            this.Txt_Desc.Enabled = false;
            this.Txt_Desc.Location = new System.Drawing.Point(166, 109);
            this.Txt_Desc.Name = "Txt_Desc";
            this.Txt_Desc.Size = new System.Drawing.Size(261, 98);
            this.Txt_Desc.TabIndex = 5;
            this.Txt_Desc.Text = "";
            // 
            // AboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 219);
            this.Controls.Add(this.Txt_Desc);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.lbl_AuthorName);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AboutUs";
            this.Text = "AboutUs";
            this.Load += new System.EventHandler(this.AboutUs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lbl_AuthorName;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.RichTextBox Txt_Desc;

       
    }
}