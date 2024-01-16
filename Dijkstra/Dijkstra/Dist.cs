using Dijkstra;

class Dist
{
    public int start {  get; set; }
    public Item[] dist { get; set; }

    public Dist(int size)
    {
        dist = new Item[size];
    }
}
