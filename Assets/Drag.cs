using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour
{
    public Canvas canvas;

     Vector2 startPos;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }

    public void Drop()
    {
        gameObject.transform.position = startPos;
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointer = (PointerEventData)data;

        Vector2 position;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointer.position, canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);

    }


}
