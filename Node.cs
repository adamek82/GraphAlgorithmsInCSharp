using System;
using System.Collections;

namespace Graph_Algorithms
{
	/// <summary>
	/// Represents a node of a graph
	/// </summary>
	public class Node
	{
		string name;						// name of the node
		int number;							// number of the node in graph
		int x, y;							// position on the screen
		Graph graph;						// graph

		ArrayList links = new ArrayList();	// links from this node

		public Node(Graph g, int number, string name, int x, int y)
		{
			graph = g;
			AddNode(number, name, x, y);
		}

		public void AddNode(int number, string name, int x, int y)
		{
			this.number = number;
			this.name = name;
			this.x = x;
			this.y = y;
		}

		public void AddLink(int dstNodeNr, int weight)
		{
			Link l = new Link(this, graph.GetNode(dstNodeNr), weight);
			links.Add(l);
			graph.Links++;
		}

		public void AddLink(Node dstNode, int weight)
		{
			Link l = new Link(this, dstNode, weight);
			links.Add(l);
			graph.Links++;
		}

		public void RemoveLink(Node dstNode)
		{
			// have to find a better way of doing this...
			foreach (Link l in links)
			{
				if (l.DestNode == dstNode)
				{
					links.Remove(l);
					graph.Links--;
					break;
				}
			}
		}

		public Link FindLink(Node dstNode)
		{
			foreach (Link l in links)
				if (l.DestNode == dstNode)
					return l;
			return null;
		}

		public Link GetLink(int number)
		{
			return links[number] as Link;
		}

		/// <summary>
		/// gets or sets the name of the node
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		/// <summary>
		/// gets the ordinal number of the node
		/// </summary>
		public int Number
		{
			get
			{
				return number;
			}
			set
			{
				number = value;
			}
		}

		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public ArrayList Links
		{
			get
			{
				return links;
			}
		}

		public Graph Graph
		{
			get
			{
				return graph;
			}
		}
	}
}
