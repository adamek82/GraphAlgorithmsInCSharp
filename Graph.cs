using System;
using System.Collections;

namespace Graph_Algorithms
{
	/// <summary>
	/// Represents a graph in memory
	/// </summary>
	public class Graph
	{
		string name;
		int last_node_number;
		int nodeSize;
		int links;
		ArrayList nodes = new ArrayList();

		public Graph()
		{
			name = "";
			last_node_number = -1;
			links = 0;
			nodeSize = 15;
		}

		public Graph(string name, int nodeSize)
		{
			this.name = name;
			last_node_number = -1;
			this.nodeSize = nodeSize;
		}

		public void AddNode(int number, string name, int x, int y)
		{
			last_node_number++;
			Node n = new Node(this, number, name, x, y);
			nodes.Add(n);
		}

		public void AddNode(int x, int y)
		{
			last_node_number++;
			Node n = new Node(this, last_node_number, last_node_number.ToString(), x, y);
			nodes.Add(n);
		}

		public void AddLink(Node src, Node trg, int weight)
		{
			src.AddLink(trg, weight);
			links++;
		}

		public void AddLink(Node src, Node trg)
		{
			int x = src.X-trg.X;
			int y = src.Y-trg.Y;
			int distance = (int)Math.Round(Math.Sqrt(x*x + y*y));
			AddLink(src, trg, distance);
		}

		public void RemoveNode(Node node)
		{
			last_node_number--;
			nodes.RemoveAt(node.Number);
			ReindexGraph(node);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="deletedNode">deleted node</param>
		private void ReindexGraph(Node deletedNode)
		{
			int i;
			Link l;
			if (deletedNode.Number != this.Nodes.Count)
				for (i=deletedNode.Number; i<this.Nodes.Count; i++)
					GetNode(i).Number--;
			foreach (Node n in Nodes)
			{
				for (i=0; i<n.Links.Count; i++)
				{
					l = n.Links[i] as Link;
					if (l.DestNode == deletedNode)
					{
						l.SrcNode.RemoveLink(l.DestNode);
						continue;
					}
				}
			}
		}

		public Node GetNode(int number)
		{
			return nodes[number] as Node;
		}

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

		public ArrayList Nodes
		{
			get
			{
				return nodes;
			}
		}

		public int NodeSize
		{
			get
			{
				return nodeSize;
			}
			set
			{
				nodeSize = value;
			}
		}

		public int Links
		{
			get
			{
				return links;
			}
			set
			{
				links = value;
			}
		}
	}
}
