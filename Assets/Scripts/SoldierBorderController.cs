using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBorderController : MonoBehaviour
{
    Vector3 mouseWorldPosition;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {

            mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;

            PathFinding.Instance.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);

            transform.position =
                 PathFinding.Instance.GetGrid().GetWorldPosition(x, y) + Vector3.one * PathFinding.Instance.GetGrid().GetCellSize() * 0.5f;

            if (PathFinding.Instance.GetGrid().GetGridObject(mouseWorldPosition).GetIsWalkable())
            {
                spriteRenderer.color = Color.green;
            }
            else
            {
                spriteRenderer.color = Color.red;
            }

        }
    }
}
