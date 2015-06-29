namespace parseJson
{
    partial class MainForm
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
            this.output = new System.Windows.Forms.RichTextBox();
            this.btnCreateIndex = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFindSpamUsers = new System.Windows.Forms.Button();
            this.btnMergeReviews = new System.Windows.Forms.Button();
            this.btnCalcUFR = new System.Windows.Forms.Button();
            this.btnCalcBFR = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setInputFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsersFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReviewsFiles = new System.Windows.Forms.Label();
            this.lblBusinessFile = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMemoryUsage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMemoryUsage1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPeakMemoryUsage = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.Black;
            this.output.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.output.ForeColor = System.Drawing.Color.YellowGreen;
            this.output.Location = new System.Drawing.Point(13, 130);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(592, 317);
            this.output.TabIndex = 1;
            this.output.Text = "";
            // 
            // btnCreateIndex
            // 
            this.btnCreateIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateIndex.Enabled = false;
            this.btnCreateIndex.Location = new System.Drawing.Point(611, 250);
            this.btnCreateIndex.Name = "btnCreateIndex";
            this.btnCreateIndex.Size = new System.Drawing.Size(156, 34);
            this.btnCreateIndex.TabIndex = 2;
            this.btnCreateIndex.Text = "Create ReviewBusiness Json";
            this.btnCreateIndex.UseVisualStyleBackColor = true;
            this.btnCreateIndex.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFindSpamUsers
            // 
            this.btnFindSpamUsers.Location = new System.Drawing.Point(22, 250);
            this.btnFindSpamUsers.Name = "btnFindSpamUsers";
            this.btnFindSpamUsers.Size = new System.Drawing.Size(75, 23);
            this.btnFindSpamUsers.TabIndex = 4;
            this.btnFindSpamUsers.Text = "Find possible spam";
            this.btnFindSpamUsers.UseVisualStyleBackColor = true;
            this.btnFindSpamUsers.Visible = false;
            this.btnFindSpamUsers.Click += new System.EventHandler(this.btnFindSpamUsers_Click);
            // 
            // btnMergeReviews
            // 
            this.btnMergeReviews.Location = new System.Drawing.Point(22, 308);
            this.btnMergeReviews.Name = "btnMergeReviews";
            this.btnMergeReviews.Size = new System.Drawing.Size(75, 23);
            this.btnMergeReviews.TabIndex = 5;
            this.btnMergeReviews.Text = "button4";
            this.btnMergeReviews.UseVisualStyleBackColor = true;
            this.btnMergeReviews.Visible = false;
            this.btnMergeReviews.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCalcUFR
            // 
            this.btnCalcUFR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcUFR.Enabled = false;
            this.btnCalcUFR.Location = new System.Drawing.Point(611, 290);
            this.btnCalcUFR.Name = "btnCalcUFR";
            this.btnCalcUFR.Size = new System.Drawing.Size(156, 36);
            this.btnCalcUFR.TabIndex = 6;
            this.btnCalcUFR.Text = "UFR";
            this.btnCalcUFR.UseVisualStyleBackColor = true;
            this.btnCalcUFR.Click += new System.EventHandler(this.btnCalcUFR_Click);
            // 
            // btnCalcBFR
            // 
            this.btnCalcBFR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcBFR.Enabled = false;
            this.btnCalcBFR.Location = new System.Drawing.Point(611, 332);
            this.btnCalcBFR.Name = "btnCalcBFR";
            this.btnCalcBFR.Size = new System.Drawing.Size(156, 37);
            this.btnCalcBFR.TabIndex = 7;
            this.btnCalcBFR.Text = "BFR";
            this.btnCalcBFR.UseVisualStyleBackColor = true;
            this.btnCalcBFR.Click += new System.EventHandler(this.btnCalcBFR_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(612, 414);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(155, 33);
            this.btnMerge.TabIndex = 8;
            this.btnMerge.Text = "Merge UFR+BFR";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setInputFilesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setInputFilesToolStripMenuItem
            // 
            this.setInputFilesToolStripMenuItem.Name = "setInputFilesToolStripMenuItem";
            this.setInputFilesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.setInputFilesToolStripMenuItem.Text = "Set input files";
            this.setInputFilesToolStripMenuItem.Click += new System.EventHandler(this.setInputFilesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblUsersFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblReviewsFiles);
            this.groupBox1.Controls.Add(this.lblBusinessFile);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 97);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Users Json";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reviews Json";
            // 
            // lblUsersFile
            // 
            this.lblUsersFile.AutoSize = true;
            this.lblUsersFile.Location = new System.Drawing.Point(85, 68);
            this.lblUsersFile.Name = "lblUsersFile";
            this.lblUsersFile.Size = new System.Drawing.Size(11, 13);
            this.lblUsersFile.TabIndex = 0;
            this.lblUsersFile.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Json";
            // 
            // lblReviewsFiles
            // 
            this.lblReviewsFiles.AutoSize = true;
            this.lblReviewsFiles.Location = new System.Drawing.Point(85, 44);
            this.lblReviewsFiles.Name = "lblReviewsFiles";
            this.lblReviewsFiles.Size = new System.Drawing.Size(11, 13);
            this.lblReviewsFiles.TabIndex = 0;
            this.lblReviewsFiles.Text = "-";
            // 
            // lblBusinessFile
            // 
            this.lblBusinessFile.AutoSize = true;
            this.lblBusinessFile.Location = new System.Drawing.Point(85, 19);
            this.lblBusinessFile.Name = "lblBusinessFile";
            this.lblBusinessFile.Size = new System.Drawing.Size(11, 13);
            this.lblBusinessFile.TabIndex = 0;
            this.lblBusinessFile.Text = "-";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMemoryUsage,
            this.toolStripStatusLabel1,
            this.lblMemoryUsage1,
            this.toolStripStatusLabel2,
            this.lblPeakMemoryUsage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(779, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(12, 17);
            this.lblMemoryUsage.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // lblMemoryUsage1
            // 
            this.lblMemoryUsage1.Name = "lblMemoryUsage1";
            this.lblMemoryUsage1.Size = new System.Drawing.Size(12, 17);
            this.lblMemoryUsage1.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // lblPeakMemoryUsage
            // 
            this.lblPeakMemoryUsage.Name = "lblPeakMemoryUsage";
            this.lblPeakMemoryUsage.Size = new System.Drawing.Size(12, 17);
            this.lblPeakMemoryUsage.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 472);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnCalcBFR);
            this.Controls.Add(this.btnCalcUFR);
            this.Controls.Add(this.btnMergeReviews);
            this.Controls.Add(this.btnFindSpamUsers);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreateIndex);
            this.Controls.Add(this.output);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "AEPPI - JsonParser ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button btnCreateIndex;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFindSpamUsers;
        private System.Windows.Forms.Button btnMergeReviews;
        private System.Windows.Forms.Button btnCalcUFR;
        private System.Windows.Forms.Button btnCalcBFR;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setInputFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsersFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReviewsFiles;
        private System.Windows.Forms.Label lblBusinessFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMemoryUsage;
        private System.Windows.Forms.ToolStripStatusLabel lblMemoryUsage1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblPeakMemoryUsage;
    }
}

