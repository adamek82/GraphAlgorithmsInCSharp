using System;

namespace Graph_Algorithms
{
	/// <summary>
	/// Union-find structure
	/// </summary>
	public class UnionFind
	{
		int maxElements;

		private struct Set
		{
			public int[] parent;
			public int[] num;
		}

		Set set;

		/// <summary>
		/// Constructor - allocates memory for union-find
		/// </summary>
		/// <param name="max">Maximum number of elements in union-find</param>
		public UnionFind(int max)
		{
			maxElements = max;
			set.parent = new int[max];
			set.num = new int[max];
		}

		public void InitSets()
		{
			for (int i=0; i<maxElements; i++)
			{
				set.parent[i] = -1;
				set.num[i] = 1;
			}
		}

		public int find(int key)
		{
			int i, p, retVal;
			for (i=key; (p=set.parent[i])>=0; i=p)
				;
			retVal = i;
			for (i=key; (p=set.parent[i])>=0; i=p)
				set.parent[i] = retVal;
			return retVal;
		}

		public void setUnion(int s1, int s2)
		{
			if (set.num[s1] < set.num[s2])
			{
				set.parent[s1] = s2;
				set.num[s2] += set.num[s1];
			}
			else
			{
				set.parent[s2] = s1;
				set.num[s1] += set.num[s2];
			}
		}
	}
}
