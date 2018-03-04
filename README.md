# MazeAI
MazeAI is a windows program that does a depth first search of a custom graph that represents a maze.
## Maze
The maze is built apon what are called maze nodes which are objects that represent a desision point in a maze. A desision point is a point in which the AI would have to make a choice for which direction to go in. For my implimentation of the maze I choose to create nodes at every desision point where the program could go in a different direction than they're currently going in i.e turning left or right. 
When creating the maze I took a picture of a maze and converted it into a plane of x and y's and figured out where each descison point would be at as shown in picture below.
![MazeGrid](https://JoshuaEstrada329.github.io/MazeAI/blob/master/mazeTest/mazeGrid.png)

### Maze Node
as mention aboved a Maze Node is used to represent a decision point in the maze. Furthermore, the following information is stored in the Maze Node object
```
Enum NodeType: Gives the node special attributes if given the NodeType Start or 
End, both types represent the start and finish of the maze of the respective type.

ID: The ID is used to uniquely identify the node from the rest of the nodes.

Point: The point the node is on the windows form. For this program points 
are mutliplied by 20 to get a better view of the maze.

```

### Maze Class
The maze itself is the equivelent of a graph. All the maze class does is manage and keeps track of which Maze Nodes are neighbors to which node. When the maze is read in from the Maze.xml document under the MazeNode attribute there is another attribute called Neighbors which contains which ID's are connected to that node. The maze then goes and creates connections to these nodes so that the AI will know what it can see at any given node.


## Form
The form is a simple GUI that contains two buttons to solve and exit the program along with a custom user control that handles and displays any interaction between the maze and the user. The only real interaction between a user and the maze is a user clicking the solve button. In responce the user control was call the Maze's solve method and display which Nodes were visited and the path of Nodes needed to solve the Maze. The user control also draws each point onto the form with different color lines to visualize the maze to the user.
Example of the form:

![Maze Form Example](https://JoshuaEstrada329.github.io/MazeAI/blob/master/mazeTest/FormExample.PNG)
![Maze Form Solved](https://JoshuaEstrada329.github.io/MazeAI/blob/master/mazeTest/FormExampleSolved.PNG)


## Algorithm

The Algorithm is simple and uses a stack to keep track of the States of the program. A State is a desision point in the maze where the AI has more than 1 choice to go besides back.

```
check to see if theres a start node
until we reach a node that contains the end node:
get a list of neighbors
if no neighbors pop the stack
if theres more than 1 in the list push which ever node we didnt visit onto the stack
go into the first neighbors  
```
If the Maze does not contain a Start node, End node, or a solvable path the program will display a warning message letting them know the maze is unsolvable.



