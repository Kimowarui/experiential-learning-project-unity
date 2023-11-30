using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Die : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("On Drop");
        if (eventData.pointerDrag != null) {
            Vector2 position = GetComponent<RectTransform>().anchoredPosition;
            Transform parent = GetComponent<RectTransform>().parent;
            eventData.pointerDrag.transform.SetParent(parent);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = position;
        }
    }
}
