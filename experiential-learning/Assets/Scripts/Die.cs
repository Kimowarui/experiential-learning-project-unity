using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Die : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("On Drop");
        if (eventData.pointerDrag.GetComponent<Powder>()) {
            Vector2 position = GetComponent<RectTransform>().anchoredPosition;
            Transform parent = GetComponent<RectTransform>().parent;
            eventData.pointerDrag.transform.SetParent(parent);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = position;
        } else if (eventData.pointerDrag.GetComponent<Spatula>()) {
            Transform parent = GetComponent<RectTransform>().parent;
            if (parent.GetComponentInChildren<Powder>()) {
                eventData.pointerDrag.transform.SetParent(parent);
                // eventData.pointerDrag.GetComponent<Spatula>().RemoveExcessPowder();
                Destroy(eventData.pointerDrag);
            }
        }
    }
}
