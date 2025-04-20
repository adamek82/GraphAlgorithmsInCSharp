using System;
using System.Collections;

namespace Graph_Algorithms
{
	/// <summary>
	/// Determines the shortest path from one node to another
	/// </summary>
	public class ShortestPath
	{
		int nodesCount;
		Graph graph;
		Node firstNode, lastNode;
		Node[] fathers;
		bool[] visited;
		ArrayList path = new ArrayList();

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="g">Graph to perform the search</param>
		/// <param name="first">The node to start</param>
		/// <param name="last">The node to finish</param>
		public ShortestPath(Graph g, Node first, Node last)
		{
			graph = g;
			firstNode = first;
			lastNode = last;
			nodesCount = g.Nodes.Count;
			fathers = new Node[nodesCount];
			visited = new bool[nodesCount];
			for (int i=0; i<nodesCount; i++)
			{
				fathers[i] = null;
				visited[i] = false;
			}
			CalculateShortestPath();
		}

		private void CalculateShortestPath()
		{
			PriorityQueue pq = new PriorityQueue(nodesCount);
			pq.init();
			pq.enqueue(firstNode, 0, 0);
			pfs(pq);
			savePath();
		}

		private void pfs(PriorityQueue pq)
		{
			Node node;
			int priority;
			object father;

			while (!pq.Empty())
			{
				node = (Node)pq.dequeue(out priority, out father);
				fathers[node.Number] = father as Node;
				visited[node.Number] = true;
				System.Diagnostics.Debug.WriteLine(node.Number.ToString() + " " + priority.ToString());
				if (node == lastNode)
					break;
				foreach (Link l in node.Links)
					if (!visited[l.DestNode.Number])
						pq.change(l.DestNode, l.Weight+priority, node);
			}
		}

		private void savePath()
		{
			path.Add(lastNode);
			Node n = lastNode;
			while (fathers[n.Number] != null)
			{
				path.Add(fathers[n.Number]);
				n = fathers[n.Number];
			}
		}

		public Graph Graph
		{
			get
			{
				return graph;
			}
			set
			{
				graph = value;
			}
		}

		public ArrayList Path
		{
			get
			{
				return path;
			}
		}
	}
}
