using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;

namespace mazeTest
{
    public partial class MazeControl : UserControl
    {
        private Maze maze;
        public bool error = false;

        public MazeControl()
        {
            InitializeComponent();

            try
            {
                 maze = new Maze(@"./Files/Maze.xml");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error reading the XML document, format was not correct!");
                MessageBox.Show("Error reading the XML document, format was not correct!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Error cannot open the XML document! File Not Found!");
                MessageBox.Show("Error cannot open the XML document! File Not Found!", "File Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("data was not valid, Values cannot be less than 0!");
                MessageBox.Show("Error, the data is not valid! Values cannot be less than 0! Check the Maze.xml document!", "Data Not Valid!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                error = true;
            }

            Size = new Size((maze.Xsize + 3) * 20, (maze.Ysize + 1) * 20);
        }    

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            
            Pen bluePen = new Pen(Color.Blue, 1);

            Pen orangePen = new Pen(Color.Orange,3);
            LinkedListNode<GraphNode<MazeNode>> currentNode;
            currentNode = maze.GetFirstNode();

            while (currentNode != null)
            {
                LinkedListNode<GraphNode<MazeNode>> currentNeighbor;
                currentNeighbor = currentNode.Value.Neighbors.First;

                while(currentNeighbor != null)
                {
                    e.Graphics.DrawLine(bluePen, new Point(currentNode.Value.Data.Point.X * 20, currentNode.Value.Data.Point.Y * 20), new Point( currentNeighbor.Value.Data.Point.X * 20, currentNeighbor.Value.Data.Point.Y * 20));
                    currentNeighbor = currentNeighbor.Next;
                }
                //drawing an 'S' at any node that is the begning of the maze
                if(currentNode.Value.Data.Type == NodeType.Start)
                {
                    e.Graphics.DrawString("S", new Font(FontFamily.GenericSansSerif, 8.5f),new SolidBrush(Color.Black), new Point(currentNode.Value.Data.X * 20, currentNode.Value.Data.Y * 20));
                }
                //drawing an 'E' at any node that is the ending of the maze
                else if(currentNode.Value.Data.Type == NodeType.End)
                {
                    e.Graphics.DrawString("E", new Font(FontFamily.GenericSansSerif, 8.5f), new SolidBrush(Color.Black), new Point(currentNode.Value.Data.X * 20, currentNode.Value.Data.Y * 20));
                }
                currentNode = currentNode.Next;
            }

            for(int i = 0; i < maze.Solution.Count -1; i++)
            {
                e.Graphics.DrawLine(orangePen, new Point(maze.Solution[i].Point.X * 20, maze.Solution[i].Point.Y * 20), new Point(maze.Solution[i +1].Point.X * 20, maze.Solution[i +1].Point.Y * 20));
            }

        }       

        public void SolveMaze()
        {
            int returnValue= maze.Solve();
            
            if(returnValue == -1)
            {
                MessageBox.Show("Maze does not contain a start node!", "No start!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(returnValue == -2)
            {
                MessageBox.Show("Maze cannot be solved!", "No solution!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            AddPaths(maze.PathList);
            AddSolutions(maze.Solution);
            Invalidate();
        }

        private void AddPaths(List<MazeNode> list)
        {
            for(int i =0; i < list.Count; i++)
            {
                txtPath.Text += $"{list[i].ID}\r\n";
            }
            
        }

        private void AddSolutions(List<MazeNode> solutionList)
        {
            txtSolutions.Text = "";           
            
            for (int i = 0; i < solutionList.Count; i++)
            {
                txtSolutions.Text += $"{solutionList[i].ID}\r\n";
            }
        }
    }
}
