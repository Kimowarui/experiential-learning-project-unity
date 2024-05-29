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
    private Vector2 startPos;
    private Transform originalParent;
    private Vector2 originalScale;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrap");
        if (transform.GetComponentInParent<Slot>()) {
            startPos = rectTransform.anchoredPosition;
            originalParent = transform.parent;
            originalScale = transform.localScale;
        }
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
        if (!gameObject.transform.parent.GetComponent<Slot>()) respawn();
    }

    void Start(){
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        parent = transform.parent;
        startPos = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        originalScale = transform.localScale;
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

    private void respawn() {
        GameObject obj = Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(originalParent);
        obj.transform.localScale = originalScale;
        obj.GetComponent<RectTransform>().anchoredPosition = startPos;
        Destroy(gameObject);
    }
}
