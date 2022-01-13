using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FactoryMethod;

public class BarracksBorderController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
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


            if (2 <= x && x < PathFinding.Instance.GetGrid().GetWidth() - 1 &&
                2 <= y && y < PathFinding.Instance.GetGrid().GetHeight() - 1)
            {
                transform.position = PathFinding.Instance.GetGrid().GetWorldPosition(x, y);


                for (int i = x + 1; i >= x - 2; i--)
                {
                    for (int j = y + 1; j >= y - 2; j--)
                    {
                        if (!PathFinding.Instance.GetNode(i, j).GetIsWalkable())
                        {
                            spriteRenderer.color = Color.red;
                            return;
                        }
                        else if (spriteRenderer.color != Color.green)
                        {
                            spriteRenderer.color = Color.green;
                        }
                    }
                }
            }

        }
    }
}
