using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject mydraggablesprite;
    Vector3 startPosition;
    float zDistanceToCamera;
    Vector3 touchOffSet;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mydraggablesprite = gameObject;
        startPosition = transform.position;
        zDistanceToCamera = Mathf.Abs(startPosition.z - Camera.main.transform.position.z);
        touchOffSet = startPosition - Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceToCamera));
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (Input.touchCount > 1)
            return;

        transform.position = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistanceToCamera)) + touchOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mydraggablesprite = null;
        touchOffSet = Vector3.zero;

    }
    
}
