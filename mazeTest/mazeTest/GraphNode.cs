using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeTest
{
    class GraphNode<E>
    {
        private E data;
        private LinkedList<GraphNode<E>> neighbors = new LinkedList<GraphNode<E>>();

        public GraphNode(E data)
        {
            this.data = data;
        }

        public E Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public LinkedList<GraphNode<E>> Neighbors
        {
            get
            {
                return neighbors;
            }
        }
    }
}
