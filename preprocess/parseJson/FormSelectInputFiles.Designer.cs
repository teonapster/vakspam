namespace parseJson
{
    partial class FormSelectInputFiles
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSetBusinessJson = new System.Windows.Forms.Button();
            this.btnSetReviewsJson = new System.Windows.Forms.Button();
            this.btnSetUsersJson = new System.Windows.Forms.Button();
            this.txtBusinessFile = new System.Windows.Forms.TextBox();
            this.txtReviewsFile = new System.Windows.Forms.TextBox();
            this.txtUsersFile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(399, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSetBusinessJson
            // 
            this.btnSetBusinessJson.Location = new System.Drawing.Point(14, 24);
            this.btnSetBusinessJson.Name = "btnSetBusinessJson";
            this.btnSetBusinessJson.Size = new System.Drawing.Size(78, 23);
            this.btnSetBusinessJson.TabIndex = 1;
            this.btnSetBusinessJson.Text = "Business";
            this.btnSetBusinessJson.UseVisualStyleBackColor = true;
            this.btnSetBusinessJson.Click += new System.EventHandler(this.btnSetBusinessJson_Click);
            // 
            // btnSetReviewsJson
            // 
            this.btnSetReviewsJson.Location = new System.Drawing.Point(13, 51);
            this.btnSetReviewsJson.Name = "btnSetReviewsJson";
            this.btnSetReviewsJson.Size = new System.Drawing.Size(78, 23);
            this.btnSetReviewsJson.TabIndex = 2;
            this.btnSetReviewsJson.Text = "Reviews";
            this.btnSetReviewsJson.UseVisualStyleBackColor = true;
            this.btnSetReviewsJson.Click += new System.EventHandler(this.btnSetReviewsJson_Click);
            // 
            // btnSetUsersJson
            // 
            this.btnSetUsersJson.Location = new System.Drawing.Point(13, 82);
            this.btnSetUsersJson.Name = "btnSetUsersJson";
            this.btnSetUsersJson.Size = new System.Drawing.Size(78, 23);
            this.btnSetUsersJson.TabIndex = 3;
            this.btnSetUsersJson.Text = "Users";
            this.btnSetUsersJson.UseVisualStyleBackColor = true;
            this.btnSetUsersJson.Click += new System.EventHandler(this.btnSetUsersJson_Click);
            // 
            // txtBusinessFile
            // 
            this.txtBusinessFile.Location = new System.Drawing.Point(97, 25);
            this.txtBusinessFile.Name = "txtBusinessFile";
            this.txtBusinessFile.ReadOnly = true;
            this.txtBusinessFile.Size = new System.Drawing.Size(406, 21);
            this.txtBusinessFile.TabIndex = 4;
            // 
            // txtReviewsFile
            // 
            this.txtReviewsFile.Location = new System.Drawing.Point(97, 52);
            this.txtReviewsFile.Name = "txtReviewsFile";
            this.txtReviewsFile.ReadOnly = true;
            this.txtReviewsFile.Size = new System.Drawing.Size(406, 21);
            this.txtReviewsFile.TabIndex = 4;
            // 
            // txtUsersFile
            // 
            this.txtUsersFile.Location = new System.Drawing.Point(97, 83);
            this.txtUsersFile.Name = "txtUsersFile";
            this.txtUsersFile.ReadOnly = true;
            this.txtUsersFile.Size = new System.Drawing.Size(406, 21);
            this.txtUsersFile.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsersFile);
            this.groupBox1.Controls.Add(this.txtReviewsFile);
            this.groupBox1.Controls.Add(this.txtBusinessFile);
            this.groupBox1.Controls.Add(this.btnSetUsersJson);
            this.groupBox1.Controls.Add(this.btnSetReviewsJson);
            this.groupBox1.Controls.Add(this.btnSetBusinessJson);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 268);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select input Json files";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(480, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormSelectInputFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 321);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectInputFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSelectInputFiles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSetBusinessJson;
        private System.Windows.Forms.Button btnSetReviewsJson;
        private System.Windows.Forms.Button btnSetUsersJson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtBusinessFile;
        public System.Windows.Forms.TextBox txtReviewsFile;
        public System.Windows.Forms.TextBox txtUsersFile;
    }
}