using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FactoryMethod;

public class SoldierBorderController : MonoBehaviour, IBorder<PathNode>
{

    public SpriteRenderer spriteRenderer { get; set; }
    public PathNode nodesInBorder { get; set; }
    public bool canBuild { get; set; }
    private SoldierFactory soldierFactory = new SoldierFactory();
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()).SetIsWalkable(false);
            soldierFactory.SpawnBuild(transform.position, PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()));
        }

        PathFinding.Instance.GetGrid().GetXY(MouseController.Instance.GetMouseWorldPosition(), out int x, out int y);

        if (0 <= x && x < PathFinding.Instance.GetGrid().GetWidth() &&
            0 <= y && y < PathFinding.Instance.GetGrid().GetHeight())
        {
            Move(x, y);
            NotWalkable(x, y);
        }
    }
    public void Move(int x, int y)
    {
        transform.position =
             PathFinding.Instance.GetGrid().GetWorldPosition(x, y) + Vector3.one * PathFinding.Instance.GetGrid().GetCellSize() * 0.5f;
    }
    public PathNode NotWalkable(int x, int y)
    {
        if (!PathFinding.Instance.GetNode(x, y).GetIsWalkable())
        {
            spriteRenderer.color = Color.red;
            canBuild = false;
        }
        else
        {
            spriteRenderer.color = Color.green;
            canBuild = true;
        }
        return nodesInBorder;
    }
}
