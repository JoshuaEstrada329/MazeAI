namespace mazeTest
{
    partial class MazeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazeForm));
            this.cmd_solve = new System.Windows.Forms.Button();
            this.cmd_exit = new System.Windows.Forms.Button();
            this.mzdbLH = new System.Windows.Forms.Label();
            this.mzdbLW = new System.Windows.Forms.Label();
            this.mazeControl = new mazeTest.MazeControl();
            this.SuspendLayout();
            // 
            // cmd_solve
            // 
            this.cmd_solve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_solve.Location = new System.Drawing.Point(13, 513);
            this.cmd_solve.Name = "cmd_solve";
            this.cmd_solve.Size = new System.Drawing.Size(75, 23);
            this.cmd_solve.TabIndex = 0;
            this.cmd_solve.Text = "Solve";
            this.cmd_solve.UseVisualStyleBackColor = true;
            this.cmd_solve.Click += new System.EventHandler(this.cmd_solve_Click);
            // 
            // cmd_exit
            // 
            this.cmd_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_exit.Location = new System.Drawing.Point(565, 513);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(75, 23);
            this.cmd_exit.TabIndex = 1;
            this.cmd_exit.Text = "Exit";
            this.cmd_exit.UseVisualStyleBackColor = true;
            this.cmd_exit.Click += new System.EventHandler(this.cmd_exit_Click);
            // 
            // mzdbLH
            // 
            this.mzdbLH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mzdbLH.AutoSize = true;
            this.mzdbLH.Location = new System.Drawing.Point(374, 518);
            this.mzdbLH.Name = "mzdbLH";
            this.mzdbLH.Size = new System.Drawing.Size(35, 13);
            this.mzdbLH.TabIndex = 7;
            this.mzdbLH.Text = "label1";
            // 
            // mzdbLW
            // 
            this.mzdbLW.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mzdbLW.AutoSize = true;
            this.mzdbLW.Location = new System.Drawing.Point(312, 518);
            this.mzdbLW.Name = "mzdbLW";
            this.mzdbLW.Size = new System.Drawing.Size(35, 13);
            this.mzdbLW.TabIndex = 6;
            this.mzdbLW.Text = "label1";
            // 
            // mazeControl
            // 
            this.mazeControl.Location = new System.Drawing.Point(12, 12);
            this.mazeControl.Name = "mazeControl";
            this.mazeControl.Size = new System.Drawing.Size(628, 480);
            this.mazeControl.TabIndex = 8;
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 548);
            this.Controls.Add(this.mazeControl);
            this.Controls.Add(this.mzdbLH);
            this.Controls.Add(this.mzdbLW);
            this.Controls.Add(this.cmd_exit);
            this.Controls.Add(this.cmd_solve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MazeForm";
            this.RightToLeftLayout = true;
            this.Text = "Maze";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_solve;
        private System.Windows.Forms.Button cmd_exit;
        private MazeControl mazeControl;
        private System.Windows.Forms.Label mzdbLH;
        private System.Windows.Forms.Label mzdbLW;
    }
}

