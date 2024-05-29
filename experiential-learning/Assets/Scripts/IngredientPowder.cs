using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class IngredientInfo {
    public string name; 
    public float weight;
    public override string ToString() {
        return $"{this.name}: {this.weight}g";
    }
}

public class IngredientPowder : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public IngredientInfo ingredientInfo;
    public string Description;
    private RectTransform rectTransform;
    private Image image;
    private CanvasGroup canvasGroup;
    private Vector2 initPosition;
    private Vector2 originalScale;
    private Transform parent;

    void Start(){
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPosition = rectTransform.anchoredPosition;
        parent = transform.parent;
        originalScale = transform.localScale;
    }

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

        respawn();
    }

    public void OnClick() {
        InfoDisplayManager._instance.HideDisplay();
        InfoDisplayManager._instance.DisplayInformation(ingredientInfo.name, Description);
    }


    public void SetWeight(float weight) {
        this.ingredientInfo.weight = weight;
    }

    private void respawn() {
        GameObject obj = Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(parent);
        obj.transform.localScale = originalScale;
        obj.GetComponent<RectTransform>().anchoredPosition = initPosition;
        if (!gameObject.transform.parent.GetComponent<PowderMixer>()){
            Destroy(gameObject);
        } else {
            image.color = new Color32(255, 255, 255, 0);

            image.raycastTarget = false; 
        }
    }    
    


}
