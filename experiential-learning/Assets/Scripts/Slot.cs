using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        if (gameObject.GetComponentInChildren<Powder>() || gameObject.GetComponentInChildren<Spatula>()) return;
        Debug.Log("On Drop (Slot)");
        eventData.pointerDrag.transform.SetParent(transform);
        eventData.pointerDrag.transform.position = transform.position;
    }
}
