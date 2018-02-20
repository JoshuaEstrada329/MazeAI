using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace mazeTest
{

    class Maze
    {
        private int xsize;
        private int ysize;
        private Graph<MazeNode> maze;
        private List<MazeNode> solution;
        private List<MazeNode> pathList;

        public List<MazeNode> Solution
        {
            get
            {
                return solution;
            }
        }

        public List<MazeNode> PathList
        {
            get
            {
                return pathList;
            }
        }

        public int Xsize
        {
            get
            {
                return xsize;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Size cannot be 0 or less.", "X Size");
                }
                else
                {
                    xsize = value;
                }
            }
        }

        public int Ysize
        {
            get
            {
                return ysize;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Size cannot be 0 or less.", "Y Size");
                }
                else
                {
                    ysize = value;
                }
            }
        }

        public Maze()
        {
            Xsize = 1;
            Ysize = 1;
            maze = new Graph<MazeNode>();
            solution = new List<MazeNode>();
            pathList = new List<MazeNode>();
        }

        public Maze(string mazePath)
        {
            maze = new Graph<MazeNode>();
            solution = new List<MazeNode>();
            pathList = new List<MazeNode>();
            InitalizeMaze(mazePath);
            AddNeighbors();
        }

        public Maze(int XSize, int YSize)
        {
            Xsize = XSize;
            Ysize = YSize;
            maze = new Graph<MazeNode>();
        }
        public void AddNode(MazeNode node)
        {
            maze.AddGraphNode(node);
        } 

        public void AddSingleEdge(int fromId, int toId)
        {
            LinkedListNode<GraphNode<MazeNode>> fromNode = maze.getFirst();
            LinkedListNode<GraphNode<MazeNode>> toNode = maze.getFirst();
            while (fromNode != null && fromNode.Value.Data.ID != fromId)
            {
                fromNode = fromNode.Next;
            }
            if(fromNode == null)
            {
                Console.WriteLine($"Could not find a node with the ID: {fromId}");
                return;
            }

            while(toNode != null && toNode.Value.Data.ID != toId)
            {
                toNode = toNode.Next;
            }
            if(toNode == null)
            {
                Console.WriteLine($"Could not find a node with the ID: {toId}");
                return;
            }

            maze.AddSingleEdge(fromNode.Value, toNode.Value);
            Console.WriteLine($"Succesfully added an edge to {fromId} to {toId}");
        }

        public LinkedListNode<GraphNode<MazeNode>> GetFirstNode()
        {
            LinkedListNode<GraphNode<MazeNode>> currentNode = maze.getFirst();

            return currentNode;
        }
        /// <summary>
        /// Gets the first LinkedListNode that has the Node Type 'start'
        /// </summary>
        /// <returns>returns the first instance of Node type 'start' in the linked list. Null if no start node</returns>
        public LinkedListNode<GraphNode<MazeNode>> GetStartNode()
        {
            LinkedListNode<GraphNode<MazeNode>> currentNode = maze.getFirst();

            while(currentNode != null)
            {
                if(currentNode.Value.Data.Type == NodeType.Start)
                {
                    return currentNode;
                }
            }

            return currentNode;
        }

        public LinkedListNode<GraphNode<MazeNode>> GetNode(GraphNode<MazeNode> desiredNode)
        {
            return maze.Find(desiredNode);
        }

        private void InitalizeMaze(string path)
        {
            //Maze maze = new Maze();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create($@"{path}", settings);

            //reading of the XML document
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.EndElement)
                {
                    //reading of the 'Maze' Node
                    switch (reader.Name)
                    {
                        //setting properties
                        case "xsize":
                            {
                                reader.Read();

                                Xsize = int.Parse(reader.Value);
                                break;
                            }
                        case "ysize":
                            {
                                reader.Read();
                                Ysize = int.Parse(reader.Value);
                                break;
                            }
                        //Reading of the individual MazeNode Nodes
                        case "MazeNode":
                            {
                                //creating a new node
                                MazeNode node = new MazeNode();
                                reader.Read();
                                //until we get to the end of the MazeNode Node
                                while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name == "MazeNode"))
                                {
                                    if (reader.NodeType != XmlNodeType.EndElement && reader.NodeType != XmlNodeType.Whitespace)
                                    {
                                        //read each Name and set properties accordingly
                                        switch (reader.Name)
                                        {
                                            case "id":
                                                {
                                                    reader.Read();
                                                    node.ID = int.Parse(reader.Value);
                                                    break;
                                                }
                                            case "x":
                                                {
                                                    reader.Read();
                                                    node.X = int.Parse(reader.Value);
                                                    break;
                                                }
                                            case "y":
                                                {
                                                    reader.Read();
                                                    node.Y = int.Parse(reader.Value);
                                                    break;
                                                }
                                            case "NodeType":
                                                {
                                                    //Node types have 3 different types
                                                    reader.Read();
                                                    switch (reader.Value)
                                                    {
                                                        case "Start":
                                                            {
                                                                node.Type = NodeType.Start;
                                                                break;
                                                            }
                                                        case "End":
                                                            {
                                                                node.Type = NodeType.End;
                                                                break;
                                                            }
                                                        case "None":
                                                            {
                                                                node.Type = NodeType.None;
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                            //cant add neighbors yet because some neighbors dont exsist yet
                                            //instead store them in a list and add later
                                            case "neighbors":
                                                {
                                                    reader.Read();
                                                    string strValue = reader.Value;
                                                    string[] strList;

                                                    strList = strValue.Split(',');

                                                    foreach (string s in strList)
                                                    {
                                                        node.idsToEdge.Add(int.Parse(s));
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    reader.Read();
                                }
                                //add the node to the graph
                                AddNode(node);
                                break;
                            }
                    }
                }
            }
            //now that we have added all the nodes in the graph we add the neighbors
            //AddNeighbors(maze);

            //return maze;
        }

        private void AddNeighbors()
        {
            LinkedListNode<GraphNode<MazeNode>> currentNode;
            currentNode = GetFirstNode();

            while (currentNode != null)
            {
                for (int i = 0; i < currentNode.Value.Data.idsToEdge.Count; i++)
                {
                    AddSingleEdge(currentNode.Value.Data.ID, currentNode.Value.Data.idsToEdge[i]);
                }
                currentNode = currentNode.Next;
            }
        }
        /// <summary>
        /// Takes the current maze and solves it
        /// </summary>
        /// <returns>Returns an integer depending on the exit path.
        /// 1 = successful, -1 = no start node, -2 not a solveable maze, -3 somehow couldnt find the ending node</returns>
        public int Solve()
        {
            //get the node with the Type 'start'
            LinkedListNode<GraphNode<MazeNode>> currentNode = GetStartNode();
            List<MazeNode> solutionList = new List<MazeNode>();
            List<GraphNode<MazeNode>> pathList = new List<GraphNode<MazeNode>>();
            AddPath(currentNode.Value.Data);
            pathList.Add(currentNode.Value);
            solutionList.Add(currentNode.Value.Data);
            LinkedListNode<GraphNode<MazeNode>> previousNode = currentNode;
            //create the stack
            Stack<State> stateStack = new Stack<State>();
            //we dont have a current state
            State currentState = null;
            //list of solutions

            //if we never found a start node
            if (currentNode == null)
            {
                Console.WriteLine("Maze does not contain a start node!");
                return -1;              
            }
            else
            {
                List<GraphNode<MazeNode>> neighborList = currentNode.Value.Neighbors.ToList();
                //while the neighborList doesnt contain the Node Type End;
                while (!ContainsEnd(neighborList))
                {

                    //removes the previous node from the neighborList, if it's there
                    if (neighborList.Contains(previousNode.Value))
                    {
                        neighborList.Remove(previousNode.Value);
                    }
                    //if we've already been to one of these nodes, dont go back! (useful for mazes that have loops)
                    for (int i = 0; i < solutionList.Count; i++)
                    {
                        if (neighborList.Contains(pathList[i]))
                        {
                            neighborList.Remove(pathList[i]);
                        }
                    }

                    //checking to see if it's a dead end
                    while (neighborList.Count == 0)
                    {
                        //if the stack is 0 and there are no neighbors we cant solve
                        if (stateStack.Count == 0)
                        {
                            Console.WriteLine("Error cannot solve maze!");                 
                            return -2;
                        }
                        //reset the state and set variables to current state
                        currentState = stateStack.Pop();

                        neighborList = currentState.NeighborList;

                        //previousNode = currentNode;
                        currentNode = currentState.CurrentNode;

                        //remove our solutions
                        solutionList.RemoveAt(solutionList.Count - 1);
                    }

                    currentState = new State(currentNode, neighborList);

                    //push the current State onto the stack
                    stateStack.Push(currentState);

                    //set the current node to the first node in the neighborList

                    Console.WriteLine($"Moving from node {currentNode.Value.Data.ID} to {neighborList[0].Data.ID}.");

                    previousNode = currentNode;
                    currentNode = GetNode(neighborList[0]);
                    //add the node to the solution
                    AddPath(currentNode.Value.Data);
                    pathList.Add(currentNode.Value);
                    solutionList.Add(currentNode.Value.Data);
                    //remove the first neighbor in the list (so we dont vist it again
                    neighborList.RemoveAt(0);

                    //set the new list to the what the current Node is
                    neighborList = currentNode.Value.Neighbors.ToList();
                }
                //we should never catch this exception because we know the there is a node with end type
                try
                {
                    currentNode = GetNode(neighborList[GetEndIndex(neighborList)]);

                    solutionList.Add(currentNode.Value.Data);
                    AddPath(currentNode.Value.Data);
                    pathList.Add(currentNode.Value);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("How did you get here!");
                    return -3;
                }

                Console.WriteLine($"Found a solution! End of maze is {currentNode.Value.Data.ID}");
                solution = solutionList;
                return 1;
            }
        }
        /// <summary>
        /// checks to see if the neighbor list has an end node
        /// </summary>
        /// <param name="List">The list of neighbors the current node sees</param>
        /// <returns>Returns true if an end node is found, else returns false</returns>
        private bool ContainsEnd(List<GraphNode<MazeNode>> List)
        {
            bool contained = false;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Data.Type == NodeType.End)
                {
                    contained = true;
                }
            }
            return contained;
        }

        private void AddPath(MazeNode node)
        {
            pathList.Add(node);
        }

        /// <summary>
        /// returns the index that has a node with the end Type
        /// </summary>
        /// <param name="List"></param>
        /// <returns>returns the index the first Node with the type End was found, else returns -1</returns>
        private int GetEndIndex(List<GraphNode<MazeNode>> List)
        {
            int index = -1;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Data.Type == NodeType.End)
                {
                    index = i;
                }
            }
            return index;
        }

    }
}
