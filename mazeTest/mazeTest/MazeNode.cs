using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mazeTest
{
    /// <summary>
    /// Start = the start of the maze
    /// End = end of the maze
    /// None = neither the start or the end
    /// </summary>
    public enum NodeType { Start, End, None };
    class MazeNode
    {
        private NodeType nodeType;
        private int id;
        private Point point;
        public List<int> idsToEdge { get; set; }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ID cannot be 0 or less", "id");
                }
                else
                    id = value;
            }
        }
        public int X
        {
            get
            {
                return point.X;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("X value cannot be 0 or less", "X");
                }
                else
                {
                    point.X = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return point.Y;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Y value cannot be 0 or less", "Y");
                }
                else
                {
                    point.Y = value;
                }
            }
        }

        public Point Point
        {
            get
            {
                return point;
            }
            set
            {
               if(value.X <= 0)
                {
                    throw new ArgumentOutOfRangeException("X value cannot be 0 or less", "X");
                }
               else if(value.Y <= 0)
                {
                    throw new ArgumentOutOfRangeException("Y value cannot be 0 or less", "Y");
                }
                else
                {
                    point = value;
                }
            }
        }


        public NodeType Type
        {
            get
            {
                return nodeType;
            }
            set
            {
                nodeType = value;
            }
        }

        /// <summary>
        /// Initializes a new MazeNode object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x">the X value of the MazeNode Point</param>
        /// <param name="y">The Y value of the MazeNode Point</param>
        /// <param name="type">Type of Node the MazeNode is</param>
        public MazeNode(int id, int x, int y,NodeType type)
        {
            ID = id;
            Point = new Point(x, y);
            nodeType = type;
        }

        public MazeNode()
        {
            id = 0;
            point = new Point(0, 0);
            nodeType = NodeType.None;
            idsToEdge = new List<int>();
        }

        /// <summary>
        /// Initializes a new MazeNode object
        /// </summary>
        /// <param name="id">the ID to identify the Node in the maze</param>
        /// <param name="point">The point where the node is located on the grid</param>
        /// <param name="type">Type of Node the MazeNode is</param>
        public MazeNode(int id, Point point, NodeType type)
        {
            ID = id;
            Point = point;
            nodeType = type;
        }
    }
}
