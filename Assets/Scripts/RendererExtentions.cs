using UnityEngine;

public static class RendererExtensions
{
    private static int CountCornersVisibleFrom(this RectTransform rectTransform, Camera camera)
    {
        Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height); 
        Vector3[] objectCorners = new Vector3[4];
        rectTransform.GetWorldCorners(objectCorners);

        for (int o = objectCorners.Length - 1; o >= 0; o--)
        {

            objectCorners[o] = objectCorners[o] / 200 - new Vector3(4f, 2.5f, 0f);

        }

        int visibleCorners = 0;
        Vector3 tempScreenSpaceCorner; 
        for (var i = 0; i < objectCorners.Length; i++) 
        {
            tempScreenSpaceCorner = camera.WorldToScreenPoint(objectCorners[i]);
            if (screenBounds.Contains(tempScreenSpaceCorner)) 
            {
                visibleCorners++;
            }
            Debug.DrawLine(Vector3.zero, camera.WorldToScreenPoint(objectCorners[0]), Color.black);
            if (i == objectCorners.Length - 1)
                Debug.DrawLine(tempScreenSpaceCorner, camera.WorldToScreenPoint(objectCorners[0]), Color.black);
            else
            {
                Debug.DrawLine(tempScreenSpaceCorner, camera.WorldToScreenPoint(objectCorners[i + 1]), Color.black);
            }
        }
        return visibleCorners;
    }

    public static bool IsFullyVisibleFrom(this RectTransform rectTransform, Camera camera)
    {
        return CountCornersVisibleFrom(rectTransform, camera) == 4; 
    }

    public static bool IsVisibleFrom(this RectTransform rectTransform, Camera camera)
    {
        return CountCornersVisibleFrom(rectTransform, camera) > 0; 
    }
}