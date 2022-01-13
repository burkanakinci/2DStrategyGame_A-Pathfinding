using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantBorderController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private List<PathNode> pathsInBorder = new List<PathNode>();
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;
    }

    void Update()
    {

        PathFinding.Instance.GetGrid().GetXY(MouseController.Instance.GetMouseWorldPosition(), out int x, out int y);

        if (Input.GetKey(KeyCode.Y))
        {


            if (2 <= x && x < PathFinding.Instance.GetGrid().GetWidth() &&
                1 <= y && y < PathFinding.Instance.GetGrid().GetHeight())
            {
                transform.position =
                                 (PathFinding.Instance.GetGrid().GetWorldPosition(x, y) - Vector3.right * PathFinding.Instance.GetGrid().GetCellSize() * 0.5f);

            }

        }
    }

    private List<PathNode> asd()
    {
        PathFinding.Instance.GetGrid().GetXY(MouseController.Instance.GetMouseWorldPosition(), out int x, out int y);

        pathsInBorder.Clear();

        for (int i = x; i >= x - 2; i--)
        {
            for (int j = y; j >= y - 1; j--)
            {
                pathsInBorder.Add(PathFinding.Instance.GetNode(i, j));
            }
        }

        return pathsInBorder;
    }
}
