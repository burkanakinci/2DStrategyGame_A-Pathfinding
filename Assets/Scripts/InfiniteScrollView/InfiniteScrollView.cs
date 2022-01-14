using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfiniteScrollView : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
{
    [SerializeField] private ScrollContent scrollContent;
    private ScrollRect scrollRect;
    private Vector2 lastDragPosition;
    [SerializeField] private bool positiveDrag = true;
    private Transform tempTransformImage, spawnedTransform;
    private Camera mainCam;
    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.vertical = scrollContent.Vertical;

        tempTransformImage = scrollContent.transform.GetChild(scrollContent.transform.childCount - 1);

        mainCam = Camera.main;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

        positiveDrag = eventData.position.y > lastDragPosition.y;

        VisibleControl();

        lastDragPosition = eventData.position;
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (scrollContent.Vertical)
        {
            positiveDrag = eventData.scrollDelta.y > 0;
        }
        else
        {
            positiveDrag = eventData.scrollDelta.y < 0;
        }
    }

    private void VisibleControl()
    {
        if (!tempTransformImage.GetComponent<RectTransform>().IsVisibleFrom(mainCam))
        {
            spawnedTransform = ObjectPool.Instance.SpawnScrollObject(tempTransformImage.gameObject, scrollContent.transform);
        }
        if (positiveDrag)
        {
            
            if (spawnedTransform != null)
            {
                spawnedTransform.SetSiblingIndex(0);
                scrollContent.ContentAlign();

                spawnedTransform = null;
            }
            if (tempTransformImage != scrollContent.transform.GetChild(scrollContent.transform.childCount - 1))
                tempTransformImage = scrollContent.transform.GetChild(scrollContent.transform.childCount - 1);
        }
        else
        {

            if (spawnedTransform != null)
            {
                spawnedTransform.SetSiblingIndex(scrollContent.transform.childCount - 1);
                scrollContent.ContentAlign();

                spawnedTransform = null;
            }
            if (tempTransformImage != scrollContent.transform.GetChild(0))
                tempTransformImage = scrollContent.transform.GetChild(0);
        }

    }

}
