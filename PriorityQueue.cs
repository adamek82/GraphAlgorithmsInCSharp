using System;

namespace Graph_Algorithms
{
	/// <summary>
	/// A priority queue collection
	/// </summary>
	public class PriorityQueue
	{
		int maxElements;

		private struct HeapItem
		{
			public int priority;
			public object key;
			public object data;
		}

		private struct Pqtype
		{
			public HeapItem[] contents;
			public int[] position;
			public int num;				// number of elements in the queue
		}

		Pqtype pq;

		/// <summary>
		/// Constructor - allocates memory for the queue
		/// </summary>
		/// <param name="pqmax">Maximum number of elements in the queue</param>
		public PriorityQueue(int pqmax)
		{
			maxElements = pqmax;
			pq.contents = new HeapItem[pqmax];
			pq.position = new int[pqmax];
		}

		/// <summary>
		/// Initiates the priority queue
		/// </summary>
		public void init()
		{
			pq.num = 0;
			for (int i=0; i<maxElements; i++)
			{
				pq.position[i] = maxElements+1;
			}
		}

		/// <summary>
		/// Checks whether the queue is empty
		/// </summary>
		/// <returns>1 for empty, 0 otherwise</returns>
		public bool Empty()
		{
			return pq.num == 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="key"></param>
		/// <param name="priority"></param>
		/// <param name="data"></param>
		private void upheap(int pos, object key, int priority, object data)
		{
			int parent;

			while (pos>0 && pq.contents[parent=(pos-1)/2].priority > priority)
			{
				pq.contents[pos] = pq.contents[parent];
				if (key is Node)
					pq.position[(pq.contents[pos].key as Node).Number] = pos;
				pos = parent;
			}
			pq.contents[pos].key = key;
			pq.contents[pos].priority = priority;
			pq.contents[pos].data = data;
			// save position
			if (key is Node)
				pq.position[(key as Node).Number] = pos;
		}

		/// <summary>
		/// Returns smaller child of the node
		/// </summary>
		/// <param name="lc">First child</param>
		/// <param name="rc">Second child</param>
		/// <returns>Smaller child's position</returns>
		private int smallerChild(int lc, out int rc)
		{
			rc = lc + 1;
			if ((rc < pq.num) && (pq.contents[rc].priority < pq.contents[lc].priority))
				return rc;
			else
				return lc;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="key"></param>
		/// <param name="priority"></param>
		/// <param name="data"></param>
		private void downheap(int pos, object key, int priority, object data)
		{
			int lc, rc, child;

			while (((lc=2*pos+1) < pq.num) && pq.contents[child=smallerChild(lc, out rc)].priority < priority)
			{
				pq.contents[pos] = pq.contents[child];
				if (key is Node)
					pq.position[(pq.contents[pos].key as Node).Number] = pos;
				pos = child;
			}
			pq.contents[pos].key = key;
			pq.contents[pos].priority = priority;
			pq.contents[pos].data = data;

			// added by me !! - add new element
			if (key is Node)
				if (pq.position[(key as Node).Number] >= pq.num)
					pq.position[(key as Node).Number] = pos;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="priority"></param>
		/// <param name="data"></param>
		public void enqueue(object key, int priority, object data)
		{
			upheap(pq.num++, key, priority, data);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="priority"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public object dequeue(out int priority, out object data)
		{
			object key = pq.contents[0].key;
			priority = pq.contents[0].priority;
			data = pq.contents[0].data;
			downheap(0, pq.contents[--pq.num].key, pq.contents[pq.num].priority, pq.contents[pq.num].data);
			return key;
		}

		public void change(object key,int priority, object data)
		{
			int pos = pq.position[(key as Node).Number];

			if (pos >= pq.num)
				upheap(pq.num++,key,priority,data);
			else if (pq.contents[pos].priority > priority) 
				upheap(pos,key,priority,data);
		}
	}
}
