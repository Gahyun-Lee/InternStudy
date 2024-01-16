using System.Collections.Generic;

namespace Dijkstra
{
    class PriorityQueue
    {
        private List<Dist> items;
        
        public PriorityQueue()
        {
            items = new List<Dist>();
        }

        public void Enqueue(int dist, int vertex)
        {
            items.Add(new Dist { Distance = dist, Vertex = vertex });
        }

        public void Dequeue() //dist값이 작은것부터 삭제
        {
            int idx = GetIndex();
            items.RemoveAt(idx);
        }

        public int[] Peak()
        {
            int idx = GetIndex();
            int[] peak = { items[idx].Distance, items[idx].Vertex };
            return peak;
        }

        public int GetIndex() //dist 값이 작은 인덱스 반환
        {
            int min = items[0].Distance;
            int idx = 0;

            for(int i=1; i<items.Count; i++)
            {
                if(min > items[i].Distance)
                {
                    min = items[i].Distance;
                    idx = i;
                }
            }

            return idx;
        }

        public bool IsEmpty()
        {
            if (items.Count == 0)
                return true;
            return false;
        }
    }
}