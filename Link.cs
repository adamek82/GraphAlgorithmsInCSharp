using System;

namespace Graph_Algorithms
{
	/// <summary>
	/// Represents a link in a graph
	/// </summary>
	public class Link
	{
		int weight;
		Node sourceNode;			// node the link come out from
		Node destinationNode;		// node to which link leads to

		public Link(Node src, Node dst, int weight)
		{
			this.weight = weight;
			sourceNode = src;
			destinationNode = dst;
		}

		public Link(Node src, Node dst)
		{
			sourceNode = src;
			destinationNode = dst;
			int x = src.X-dst.X;
			int y = src.Y-dst.Y;
			int distance = (int)Math.Round(Math.Sqrt(x*x + y*y));
			this.weight = distance;
		}

		public Node DestNode
		{
			get
			{
				return destinationNode;
			}
			set
			{
				destinationNode = value;
			}
		}

		public Node SrcNode
		{
			get
			{
				return sourceNode;
			}
			set
			{
				sourceNode = value;
			}
		}

		public int Weight
		{
			get
			{
				return weight;
			}
			set
			{
				weight = value;
			}
		}
	}
}
