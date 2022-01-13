using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FactoryMethod;

public class SoldierBorderController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private SoldierFactory soldierFactory = new SoldierFactory();
    private List<PathNode> pathsInBorder = new List<PathNode>();
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pathsInBorder.Clear();
            pathsInBorder.Add(PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()));
            PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()).SetIsWalkable(false);
            soldierFactory.SpawnBuild(transform.position, pathsInBorder);
        }

        PathFinding.Instance.GetGrid().GetXY(MouseController.Instance.GetMouseWorldPosition(), out int x, out int y);

        transform.position =
             PathFinding.Instance.GetGrid().GetWorldPosition(x, y) + Vector3.one * PathFinding.Instance.GetGrid().GetCellSize() * 0.5f;

        if (PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()).GetIsWalkable())
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }


    }
}
