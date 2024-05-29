using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabletStoreSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        if (gameObject.GetComponentInChildren<Tablet>()) return;
        if (!eventData.pointerDrag.GetComponent<Tablet>()) return;

        Debug.Log("On Drop (TabletStore Slot)");
        eventData.pointerDrag.transform.SetParent(transform);
        eventData.pointerDrag.transform.position = transform.position;
    }
}
