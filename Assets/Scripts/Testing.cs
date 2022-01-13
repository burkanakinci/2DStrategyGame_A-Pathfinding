using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    Vector3 mouseWorldPosition;
    PathFinding pathFinding;
    public SoldierMovement soldierMovement;
    private void Start()
    {
        soldierMovement = FindObjectOfType<SoldierMovement>();
        pathFinding = new PathFinding(10, 14, transform.position);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);

            if (0 <= x && x < PathFinding.Instance.GetGrid().GetWidth() &&
                0 <= y && y < PathFinding.Instance.GetGrid().GetHeight())
            {
                List<PathNode> path = pathFinding.FindPath(0, 0, x, y);

                if (path != null)
                {

                    for (int i = 0; i < path.Count - 1; i++)
                    {

                        Debug.DrawLine((new Vector3(path[i].x, path[i].y) * pathFinding.GetGrid().GetCellSize() + transform.position) + Vector3.one * pathFinding.GetGrid().GetCellSize() * 0.5f,
                                        (new Vector3(path[i + 1].x, path[i + 1].y) * pathFinding.GetGrid().GetCellSize() + transform.position) + Vector3.one * pathFinding.GetGrid().GetCellSize() * 0.5f,
                                        Color.black,
                                        5f);
                    }
                }
                soldierMovement.SetTargetPosition(mouseWorldPosition);
            }


        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathFinding.GetNode(x, y).SetIsWalkable(!pathFinding.GetNode(x, y).GetIsWalkable());

        }
    }
}
