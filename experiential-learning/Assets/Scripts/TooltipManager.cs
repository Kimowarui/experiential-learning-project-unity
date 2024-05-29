using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TooltipManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TooltipManager _instance;
    public TextMeshProUGUI textComponent;
    public RectTransform canvasRectTransform;
    private RectTransform rectTransform;
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        rectTransform = GetComponent<RectTransform>();
    }

    void Start() {
        gameObject.SetActive(false);
    }

    void Update() {
    }

    public void SetAndShowTooltip(string message, Vector2 positiion) {
        gameObject.SetActive(true);
        this.textComponent.SetText(message);

        transform.position = positiion;
        Invoke("HideTooltip", 1f);
    }

    public void HideTooltip() {
        gameObject.SetActive(false);
        this.textComponent.text = "";
    }

}