 using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Powder : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{   
    private RectTransform rectTransform;
    private Image image;
    private CanvasGroup canvasGroup;
    private bool isExcessive;
    public Sprite tablet;
    private Vector2 startPos;
    private Transform originalParent;
    private Vector2 originalScale;
    [SerializeField] private TablePress tablePress;

    private struct Ingredient
    {
        public int drug;
        public int paracetamol;
        public int lactose;
        public int mgst;

        public Ingredient(int drug, int paracetamol, int lactose, int mgst) {
            this.drug = drug;
            this.paracetamol = paracetamol;
            this.lactose = lactose;
            this.mgst = mgst;
        }

    }
    private Ingredient ingredient;

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
        if (!gameObject.transform.parent.GetComponent<TablePress>()) {
            respawn();
        }
    }

    void Start(){
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        isExcessive = true;
        startPos = rectTransform.anchoredPosition;
        originalParent = transform.parent;
        originalScale = transform.localScale;
        ingredient = new Ingredient(0, 0, 0, 0);
    }
    public void removeExcessivePowder() {
        Debug.Log("Remove Excessive Powder");
        tablePress.Talk("Excessive Powder removed");
        isExcessive = false;
    }
    public bool getIsExcessive() {
        return isExcessive;
    }
    public void prepare(int drug, int paracetamol, int lactose, int mgst) {
        ingredient = new Ingredient(drug, paracetamol, lactose, mgst);
        tablePress.Talk($"Powder Prepared! Paracetamol: {paracetamol}% Lactose: {lactose}% Mgst: {mgst}%");
    }

    public void toTablet() {
        this.image.sprite = tablet;
    }

    private void OnMouseEnter() {
        if (!gameObject.GetComponentInParent<TablePress>()) {
            string message = $"Paracetamol: {this.ingredient.paracetamol}% \nLactose: {this.ingredient.lactose}% \nMgst: {this.ingredient.mgst}%";
            TooltipManager._instance.SetAndShowTooltip(message);
        }
    }

    private void OnMouseExit() {
        TooltipManager._instance.HideTooltip();
    }

    private void OnDestroy() {
        TooltipManager._instance.HideTooltip();
    }

    private void respawn() {
        GameObject obj = Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(originalParent);
        obj.transform.localScale = originalScale;
        obj.GetComponent<RectTransform>().anchoredPosition = startPos;
        Destroy(gameObject);
    }


}
