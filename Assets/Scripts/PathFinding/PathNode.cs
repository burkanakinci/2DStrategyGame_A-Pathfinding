
public class PathNode
{
    private Grid<PathNode> grid;
    public int x;
    public int y;
    public int gCost;
    public int hCost;
    public int fCost;
    private bool isWalkable;

    public PathNode cameFromNode;
    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = true;
    }
    public Grid<PathNode> GetGrid()
    {
        return grid;
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;

    }
    public override string ToString()
    {
        return x + "," + y;
    }
    public void SetIsWalkable(bool _isWalkable)
    {
        this.isWalkable = _isWalkable;
    }
    public bool GetIsWalkable()
    {
        return isWalkable;
    }
}
