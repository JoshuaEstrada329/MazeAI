using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeTest
{
    class State
    {

        public LinkedListNode<GraphNode<MazeNode>> CurrentNode { get; set; }
        public List<GraphNode<MazeNode>> NeighborList { get; set; }
        /// <summary>
        /// Creates a State to hold the current node, list of neighbors, and solutions
        /// </summary>
        /// <param name="node">The Node you're currently at</param>
        /// <param name="neighbors">The list of neighbors your node has</param>
        /// <param name="solution">The list of solutions</param>
        public State(LinkedListNode<GraphNode<MazeNode>> node, List<GraphNode<MazeNode>> neighbors)
        {
            CurrentNode = node;
            NeighborList = neighbors;
        }
    }
}
