using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeTest
{
    class Graph<E>
    {
        private LinkedList<GraphNode<E>> graphSet;

        public Graph()
        {
            graphSet = new LinkedList<GraphNode<E>>();
        }
        public Graph(LinkedList<GraphNode<E>> graph)
        {
            graphSet = graph;
        }
        /// <summary>
        /// Adds to the end of the graphset linked list the given node
        /// </summary>
        /// <param name="node"></param>
        public void AddGraphNode(GraphNode<E> node)
        {
            graphSet.AddLast(node);
        }
        /// <summary>
        /// Adds to the end of the graphset linked list the given data
        /// </summary>
        /// <param name="data"></param>
        public void AddGraphNode(E data)
        {
            graphSet.AddLast(new GraphNode<E>(data));
        }
        /// <summary>
        /// attempts to remove the value given from the graph
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true = removed false = not removed</returns>
        public bool Remove(E value)
        {
            if (!graphSet.Remove(new GraphNode<E>(value)))
                return false;
            foreach(GraphNode<E> gnode in graphSet)
            {
                gnode.Neighbors.Remove(new GraphNode<E>(value));
            }

            return true;

        }
        /// <summary>
        /// Adds an double edge to both the given GraphNodes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AddEdge(GraphNode<E> from, GraphNode<E> to)
        {
            from.Neighbors.AddLast(to);
            to.Neighbors.AddLast(from);
        }
        /// <summary>
        /// Adds a single edge to the from Node to the to Node
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AddSingleEdge(GraphNode<E> from, GraphNode<E> to)
        {
            from.Neighbors.AddLast(to);
        }
        /// <summary>
        /// Gets the first node in the Linked List
        /// </summary>
        /// <returns>Returns the first node in the LinkedList</returns>
        public LinkedListNode<GraphNode<E>> getFirst()
        {
            return graphSet.First;
        }
        /// <summary>
        /// finds the specific node
        /// </summary>
        /// <param name="node"></param>
        /// <returns>returns the given Node from the linked list</returns>
        public LinkedListNode<GraphNode<E>> Find(GraphNode<E> node)
        {
            return graphSet.Find(node);
        }
    }
}
