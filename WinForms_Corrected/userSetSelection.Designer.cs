namespace WinForms
{
    partial class userSetSelection
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PhotoSetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhotoSetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfPhotos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PhotoSetName,
            this.PhotoSetID,
            this.NumberOfPhotos});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(342, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PhotoSetName
            // 
            this.PhotoSetName.HeaderText = "PhotoSetName";
            this.PhotoSetName.Name = "PhotoSetName";
            // 
            // PhotoSetID
            // 
            this.PhotoSetID.HeaderText = "PhotoSetID";
            this.PhotoSetID.Name = "PhotoSetID";
            // 
            // NumberOfPhotos
            // 
            this.NumberOfPhotos.HeaderText = "NumberOfPhotos";
            this.NumberOfPhotos.Name = "NumberOfPhotos";
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(111, 186);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(162, 35);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // userSetSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 262);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.dataGridView1);
            this.Name = "userSetSelection";
            this.Text = "Select Your Photo Sets by  Clicking On Their Respective PhotoSetID";
            this.Load += new System.EventHandler(this.userSetSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhotoSetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhotoSetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfPhotos;
        private System.Windows.Forms.Button Next;
    }
}