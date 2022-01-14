using System.Collections.Generic;
using UnityEngine;
using FactoryMethod;

public class PowerPlantBorderController : MonoBehaviour, IBorder<List<PathNode>>
{
    public SpriteRenderer spriteRenderer { get; set; }
    public List<PathNode> nodesInBorder { get; set; }
    private PowerPlantFactory powerPlantFactory = new PowerPlantFactory();
    public bool canBuild { get; set; }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;

        nodesInBorder = new List<PathNode>();
    }

    void Update()
    {

        PathFinding.Instance.GetGrid().GetXY(MouseController.Instance.GetMouseWorldPosition(), out int x, out int y);

        if (2 <= x && x < PathFinding.Instance.GetGrid().GetWidth() &&
            1 <= y && y < PathFinding.Instance.GetGrid().GetHeight())
        {
            Move(x, y);
            NotWalkable(x, y);

            if (Input.GetKeyDown(KeyCode.Mouse0) && canBuild)
            {
                PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()).SetIsWalkable(false);
                powerPlantFactory.SpawnBuild(transform.position, nodesInBorder);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Move(int x, int y)
    {
        transform.position =
        (PathFinding.Instance.GetGrid().GetWorldPosition(x, y) - Vector3.right * PathFinding.Instance.GetGrid().GetCellSize() * 0.5f);
    }
    public List<PathNode> NotWalkable(int x, int y)
    {
        nodesInBorder.Clear();

        spriteRenderer.color = Color.green;
        canBuild = true;

        for (int i = x; i >= x - 2; i--)
        {
            for (int j = y; j >= y - 1; j--)
            {
                nodesInBorder.Add(PathFinding.Instance.GetGrid().GetGridObject(i, j));
                if (!nodesInBorder[nodesInBorder.Count - 1].GetIsWalkable())
                {
                    spriteRenderer.color = Color.red;
                    canBuild = false;
                }
            }
        }
        return nodesInBorder;
    }
}
