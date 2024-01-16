using Dijkstra;

class Result
{
    public int start {  get; set; }
    public Dist[] dist { get; set; }

    public Result(int size)
    {
        dist = new Dist[size];
    }
}
