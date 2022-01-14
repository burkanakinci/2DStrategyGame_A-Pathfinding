using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public enum SoldierState
    {
        Build,
        Selected,
        Move
    }
    public SoldierState soldierState;
    private int currentPathIndex;
    [SerializeField] private List<Vector3> pathVectorList;
    private const float speed = 2f;

    private void OnEnable()
    {
        soldierState = SoldierState.Build;
    }
    public void SetTargetPosition()
    {
        currentPathIndex = 0;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Update()
    {
        if (pathVectorList != null && soldierState == SoldierState.Move)
            HandleMovement();
    }

    private void HandleMovement()
    {

        if (pathVectorList != null && pathVectorList.Count > 0)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (transform.position != targetPosition)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                transform.position = Vector3.MoveTowards(transform.position + moveDir * Time.deltaTime, targetPosition, speed);
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }

    }

    private void StopMoving()
    {
        PathFinding.Instance.GetGrid().GetGridObject(transform.position).SetIsWalkable(false);
        Testing.Instance.soldierMovement = null;
        soldierState = SoldierState.Build;
        pathVectorList = null;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = PathFinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
    private void OnMouseDown()
    {
        if (soldierState == SoldierState.Build)
        {
            PathFinding.Instance.GetGrid().GetGridObject(MouseController.Instance.GetMouseWorldPosition()).SetIsWalkable(true);
            //soldierState = SoldierState.Selected;
            Testing.Instance.soldierMovement = this;
        }
    }
}
