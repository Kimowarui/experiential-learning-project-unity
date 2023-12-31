using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spatula : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Image image;
    private CanvasGroup canvasGroup;
    private Transform parent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrap");
        image.color = new Color32(255, 255, 255, 170);
        transform.SetParent(GetComponentInParent<Canvas>().transform);
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrap");
        image.color = new Color32(255, 255, 255, 255);
        canvasGroup.blocksRaycasts = true;
        // Destroy(gameObject);
    }

    void Start(){
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        parent = transform.parent;
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        // if ((targetLayer.value & (1 << collider2D.gameObject.layer)) != 0) {
        //     isExcessive = false;
        //     Debug.Log("Collision detected with " + collider2D.gameObject.name);
        // }
        if (collider2D.GetComponentInParent<TablePress>()) {
            collider2D.GetComponent<Powder>().removeExcessivePowder();
        }
    }
}
