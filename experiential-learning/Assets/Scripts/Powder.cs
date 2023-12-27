 using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Powder : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{   
    private RectTransform rectTransform;
    private Image image;
    private CanvasGroup canvasGroup;
    private bool isExcessive;
    public LayerMask targetLayer;

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
        isExcessive = true;
    }
    public void removeExcessivePowder() {
        Debug.Log("Remove Excessive Powder");
        isExcessive = false;
    }
    public bool getIsExcessive() {
        return isExcessive;
    }

}
