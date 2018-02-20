using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace mazeTest
{
    public partial class MazeForm : Form
    { 

        public MazeForm()
        {

            InitializeComponent();

            MaximizeBox = false;

            Size = new Size(mazeControl.Width + 50, mazeControl.Height + 100);

            mzdbLW.Text = $"Width: {mazeControl.Width.ToString()}";
            mzdbLH.Text = $"Height: {mazeControl.Height.ToString()}";

            if (mazeControl.error == true)
            {
                cmd_solve.Enabled = false;
            }

            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

           // e.Graphics.DrawLine(redPen, test.Start, test.End);

        }

        private void cmd_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmd_solve_Click(object sender, EventArgs e)
        {
            mazeControl.SolveMaze();
        }
    }
}

