using System;
using System.Collections;

namespace Graph_Algorithms
{
	/// <summary>
	/// Solves the problem of minimum spanning tree
	/// </summary>
	public class MST
	{
		Graph graph;
		ArrayList minimumSpanningTree = new ArrayList();
		bool[] visited;

		/// <summary>
		/// Constructor - takes the graph to find minimum spanning tree
		/// </summary>
		/// <param name="g">A indirected graph to solve</param>
		public MST(Graph g)
		{
			graph = g;
			PerformMST();
		}

		private void PerformMST()
		{
			int n = graph.Links;
			int treearcs = 0;
			int comp1, comp2;
			object data;
			int priority;
			Link l;
			PriorityQueue pq = new PriorityQueue(n/2);
			pq.init();
			UnionFind uf = new UnionFind(n/2);

			foreach (Node node in graph.Nodes)
			{
				foreach (Link arc in node.Links)
				{
					if (node.Number < arc.DestNode.Number)
					{
						pq.enqueue(arc, arc.Weight, 0);
					}
				}
			}

			uf.InitSets();
			while (treearcs < graph.Nodes.Count-1)
			{
				l = (Link)pq.dequeue(out priority, out data);
				comp1 = uf.find(l.SrcNode.Number);
				comp2 = uf.find(l.DestNode.Number);
				if (comp1 != comp2)
				{
					uf.setUnion(comp1, comp2);
					this.minimumSpanningTree.Add(l);
					treearcs++;
				}
			}
		}

		public void visit(Node node)
		{
			visited[node.Number] = true;
			System.Diagnostics.Debug.WriteLine(node.Number);
			foreach (Link link in node.Links)
				if (!visited[link.DestNode.Number])
					visit(link.DestNode);
		}

		public void PreOrder(Node startNode)
		{
			int i, n = graph.Nodes.Count;
			visited = new bool[n];
			for (i=0; i<n; i++)
				visited[i] = false;
			visit(startNode);
		}

		public ArrayList MSTLinks
		{
			get
			{
				return minimumSpanningTree;
			}
		}

		public Link GetMSTLink(int index)
		{
			return minimumSpanningTree[index] as Link;
		}
	}
}
