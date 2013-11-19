namespace WinForms
{
    partial class userPhotosGUI
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
            this.FromPhotoSet = new System.Windows.Forms.Button();
            this.FromGallery = new System.Windows.Forms.Button();
            this.FromPhotoStream = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FromPhotoSet
            // 
            this.FromPhotoSet.Location = new System.Drawing.Point(46, 31);
            this.FromPhotoSet.Name = "FromPhotoSet";
            this.FromPhotoSet.Size = new System.Drawing.Size(174, 51);
            this.FromPhotoSet.TabIndex = 0;
            this.FromPhotoSet.Text = "FromPhotoSet";
            this.FromPhotoSet.UseVisualStyleBackColor = true;
            this.FromPhotoSet.Click += new System.EventHandler(this.FromPhotoSet_Click);
            // 
            // FromGallery
            // 
            this.FromGallery.Location = new System.Drawing.Point(46, 112);
            this.FromGallery.Name = "FromGallery";
            this.FromGallery.Size = new System.Drawing.Size(174, 47);
            this.FromGallery.TabIndex = 1;
            this.FromGallery.Text = "FromGallery";
            this.FromGallery.UseVisualStyleBackColor = true;
            this.FromGallery.Click += new System.EventHandler(this.FromGallery_Click);
            // 
            // FromPhotoStream
            // 
            this.FromPhotoStream.Location = new System.Drawing.Point(46, 189);
            this.FromPhotoStream.Name = "FromPhotoStream";
            this.FromPhotoStream.Size = new System.Drawing.Size(174, 42);
            this.FromPhotoStream.TabIndex = 2;
            this.FromPhotoStream.Text = "FromPhotoStream";
            this.FromPhotoStream.UseVisualStyleBackColor = true;
            this.FromPhotoStream.Click += new System.EventHandler(this.FromPhotoStream_Click);
            // 
            // userPhotosGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.FromPhotoStream);
            this.Controls.Add(this.FromGallery);
            this.Controls.Add(this.FromPhotoSet);
            this.Name = "userPhotosGUI";
            this.Text = "GetPhotos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FromPhotoSet;
        private System.Windows.Forms.Button FromGallery;
        private System.Windows.Forms.Button FromPhotoStream;
    }
}