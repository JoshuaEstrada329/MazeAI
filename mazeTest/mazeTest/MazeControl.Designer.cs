namespace mazeTest
{
    partial class MazeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSolutions = new System.Windows.Forms.TextBox();
            this.grpSolution = new System.Windows.Forms.GroupBox();
            this.grpPath = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.grpSolution.SuspendLayout();
            this.grpPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSolutions
            // 
            this.txtSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSolutions.Location = new System.Drawing.Point(3, 16);
            this.txtSolutions.Multiline = true;
            this.txtSolutions.Name = "txtSolutions";
            this.txtSolutions.ReadOnly = true;
            this.txtSolutions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSolutions.Size = new System.Drawing.Size(65, 176);
            this.txtSolutions.TabIndex = 4;
            // 
            // grpSolution
            // 
            this.grpSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSolution.Controls.Add(this.txtSolutions);
            this.grpSolution.Location = new System.Drawing.Point(525, 3);
            this.grpSolution.Name = "grpSolution";
            this.grpSolution.Size = new System.Drawing.Size(71, 195);
            this.grpSolution.TabIndex = 6;
            this.grpSolution.TabStop = false;
            this.grpSolution.Text = "Solution";
            // 
            // grpPath
            // 
            this.grpPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPath.Controls.Add(this.txtPath);
            this.grpPath.Location = new System.Drawing.Point(525, 220);
            this.grpPath.Name = "grpPath";
            this.grpPath.Size = new System.Drawing.Size(71, 215);
            this.grpPath.TabIndex = 7;
            this.grpPath.TabStop = false;
            this.grpPath.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Location = new System.Drawing.Point(3, 16);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPath.Size = new System.Drawing.Size(65, 196);
            this.txtPath.TabIndex = 0;
            // 
            // MazeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPath);
            this.Controls.Add(this.grpSolution);
            this.Name = "MazeControl";
            this.Size = new System.Drawing.Size(609, 435);
            this.grpSolution.ResumeLayout(false);
            this.grpSolution.PerformLayout();
            this.grpPath.ResumeLayout(false);
            this.grpPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSolutions;
        private System.Windows.Forms.GroupBox grpSolution;
        private System.Windows.Forms.GroupBox grpPath;
        private System.Windows.Forms.TextBox txtPath;
    }
}
