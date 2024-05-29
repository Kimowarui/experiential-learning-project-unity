using System;
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
    public GameObject tabletPrefab;
    public Sprite lessPowder;
    private Vector2 startPos;
    private Transform originalParent;
    private Vector2 originalScale;
    // [SerializeField] private TablePress tablePress;

    private List<IngredientInfo> ingredients = new List<IngredientInfo>();

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.GetComponentInParent<Slot>()) {
            startPos = rectTransform.anchoredPosition;
            originalParent = transform.parent;
            originalScale = transform.localScale;
        }
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
        if (gameObject.transform.parent.GetComponent<Canvas>()) {
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
    }
    public void removeExcessivePowder() {
        Debug.Log("Remove Excessive Powder");
        // tablePress.Talk("Excessive Powder removed");
        this.image.sprite = lessPowder;
        isExcessive = false;
    }
    public bool getIsExcessive() {
        return isExcessive;
    }
    public void AddIngredient(IngredientInfo ingredientInfo) {
        ingredients.Add(ingredientInfo);
    }

    public void GenerateTablet() {
        GameObject tabletObj = Instantiate(tabletPrefab, transform.position, Quaternion.identity);
        tabletObj.transform.SetParent(transform.parent);
        tabletObj.transform.localScale = this.originalScale;
        Tablet tablet = tabletObj.GetComponent<Tablet>();

        foreach (IngredientInfo ingredient in this.ingredients) {
            tablet.AddIngredient(ingredient);
        }      
        Destroy(gameObject);
    }

    public void OnClick() {
        TooltipManager._instance.SetAndShowTooltip(this.ToString(), transform.position);
    }

    public override string ToString() {
        float totalWeight = 0f;
        foreach (IngredientInfo ingredient in this.ingredients) {
            totalWeight += ingredient.weight;
        }

        string message = $"Total Weight: {totalWeight}g\n";
        foreach (IngredientInfo ingredient in this.ingredients) {
            float weight = (float)Math.Round(ingredient.weight/totalWeight, 2);
            message += $"{ingredient.name}: {weight*100}%\n";
        }

        return message;
    }

    private void respawn() {
        GameObject obj = Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity);
        Powder powder = obj.GetComponent<Powder>();

        foreach (IngredientInfo ingredient in this.ingredients) {
            powder.AddIngredient(ingredient);
        }


        obj.transform.SetParent(originalParent);
        obj.transform.localScale = originalScale;
        obj.GetComponent<RectTransform>().anchoredPosition = startPos;
        Destroy(gameObject);
    }


}
