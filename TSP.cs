using System;
using System.Collections;
using System.Windows.Forms;

namespace Graph_Algorithms
{
	/// <summary>
	/// Solves the problem of minimum spanning tree
	/// </summary>
	public class TSP
	{
		Graph graph, copy, full;
		ArrayList tour;
		ArrayList tourNodes;
		int totalCost;
		bool[] visited;

		/// <summary>
		/// Constructor - takes the graph to solve the travelling salesman
		/// </summary>
		/// <param name="g">A indirected graph to solve</param>
		public TSP(Graph g)
		{
			graph = g;
			copy = new Graph();
			tour = new ArrayList();
			tourNodes = new ArrayList();
			totalCost = 0;
			MakeFullGraph();
			MST mst = new MST(full);
			foreach(Node n in full.Nodes)
				copy.AddNode(n.Number, n.Name, n.X, n.Y);
			// now its time for the links
			foreach(Link l in mst.MSTLinks)
			{
				copy.GetNode(l.SrcNode.Number).AddLink(l.DestNode.Number, l.Weight);
				copy.GetNode(l.DestNode.Number).AddLink(l.SrcNode.Number, l.Weight);
			}
			PerformTSP();
		}

		/// <summary>
		/// Create the full graph with an Euclidean distances from the source graph
		/// </summary>
		private void MakeFullGraph()
		{
			full = new Graph();
			foreach (Node n in graph.Nodes)
				full.AddNode(n.Number, n.Name, n.X, n.Y);
			foreach (Node src in full.Nodes)
				foreach (Node trg in full.Nodes)
					if (src != trg)
						full.AddLink(src, trg);
		}
			
		private void PerformTSP()
		{
			PreOrder(copy.GetNode(0));
			BuildTourFromMST();
			OptimizeTour();
		}

		private void visit(Node node)
		{
			visited[node.Number] = true;
			tourNodes.Add(node);
			foreach (Link link in node.Links)
				if (!visited[link.DestNode.Number])
					visit(link.DestNode);
		}

		private void PreOrder(Node startNode)
		{
			int i, n = graph.Nodes.Count;
			visited = new bool[n];
			for (i=0; i<n; i++)
				visited[i] = false;
			visit(startNode);
		}

		private void BuildTourFromMST()
		{
			Link link;
			int i;
			if (tourNodes.Count < 2)
				return;
			for (i=0; i<tourNodes.Count-1; i++)
			{
				link = new Link(tourNodes[i] as Node, tourNodes[i+1] as Node);
				tour.Add(link);
				totalCost += link.Weight;
			}
			link = new Link(tourNodes[tourNodes.Count-1] as Node, tourNodes[0] as Node);
			tour.Add(link);
			totalCost += link.Weight;
		}

		private int CalculateTotalCost(ArrayList newTour)
		{
			int cost = 0;
			foreach (Link l in newTour)
				cost += l.Weight;
			return cost;
		}

		// the most tricky and tough part of the algorithm :)
		private void OptimizeTour()
		{
			int i, j;
			bool improved;
			ArrayList newTour;
			int newCost;
		
			do
			{
				improved = false;
				for (i=0; i<tour.Count-1; i++)
				{
					for (j=i+2; j<tour.Count-1; j++)
					{
						newTour = new ArrayList(tour);		// copy the tour
						Transform(newTour, i, j);
						newCost = CalculateTotalCost(newTour);
						if (newCost < totalCost)
						{
							tour = new ArrayList(newTour);	// accept new tour
							totalCost = newCost;
							improved = true;
							goto end;
						}
					}
				}
				// the last
				for (i=1; i<tour.Count-2; i++)
				{
					newTour = new ArrayList(tour);		// copy the tour
					Transform(newTour, newTour.Count-1, i);
					newCost = CalculateTotalCost(newTour);
					if (newCost < totalCost)
					{
						tour = new ArrayList(newTour);	// accept new tour
						totalCost = newCost;
						improved = true;
						goto end;
					}
				}
				end: 
				;
			} while (improved == true);
		}

		private void Transform(ArrayList newTour, int t, int v)
		{
			int u = (t+1) % newTour.Count;
			int w = v+1;
			Node tNode = (newTour[t] as Link).SrcNode;
			Node uNode = (newTour[u] as Link).SrcNode;
			Node vNode = (newTour[v] as Link).SrcNode;
			Node wNode = (newTour[w] as Link).SrcNode;

			int i;
			// reverse links
			ArrayList reversed = new ArrayList();
			Link l;

			for (i=u; i<=v-1; i++)
			{
				l = new Link((newTour[i] as Link).DestNode, (newTour[i] as Link).SrcNode);
				reversed.Add(l);
			}
			// copy the links to the tour
			for (i=0; i<reversed.Count; i++)
				newTour[u+i] = reversed[reversed.Count-i-1];
			// change some links on the way
			newTour[t] = new Link(tNode, vNode);
			newTour[v] = new Link(uNode, wNode);
		}

		public Graph Copy
		{
			get
			{
				return copy;
			}
		}

		public Graph Full
		{
			get
			{
				return full;
			}
		}

		public ArrayList Tour
		{
			get
			{
				return tour;
			}
		}
	}
}
