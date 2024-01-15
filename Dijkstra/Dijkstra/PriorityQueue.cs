using System.Collections.Generic;

namespace Dijkstra
{
    class PriorityQueue
    {
        private List<Item> items;
        
        public PriorityQueue()
        {
            items = new List<Item>();
        }

        public void Enqueue(int dist, int vertex)
        {
            items.Add(new Item { Dist = dist, Vertex = vertex });
        }

        public void Dequeue() //dist값이 작은것부터 삭제
        {
            int idx = getIndex();
            items.RemoveAt(idx);
        }

        public int[] Peak()
        {
            int idx = getIndex();
            int[] peak = { items[idx].Dist, items[idx].Vertex };
            return peak;
        }

        public int getIndex() //dist 값이 작은 인덱스 반환
        {
            int min = items[0].Dist;
            int idx = 0;

            for(int i=1; i<items.Count; i++)
            {
                if(min > items[i].Dist)
                {
                    min = items[i].Dist;
                    idx = i;
                }
            }

            return idx;
        }

        public bool isEmpty()
        {
            if (items.Count == 0)
                return true;
            return false;
        }
    }
}