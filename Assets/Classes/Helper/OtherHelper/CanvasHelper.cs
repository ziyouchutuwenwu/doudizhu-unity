using UnityEngine;
using System.Collections.Generic;


public class CanvasHelper: MonoBehaviour
{
    public static void setOtherCanvasTouchEnabled(Transform exceptedTransform, bool enabled)
    {
        Canvas[] canvasArray = (Canvas[])Object.FindObjectsOfType(typeof(Canvas));
        for (int i = 0; i < canvasArray.Length; i++)
        {
            if (canvasArray[i].transform != exceptedTransform)
            {
                CanvasGroup canvasGroup = canvasArray[i].transform.GetComponent<CanvasGroup>();
                if (null != canvasGroup)
                {
                    canvasGroup.interactable = enabled;
                }
            }
        }
    }
}