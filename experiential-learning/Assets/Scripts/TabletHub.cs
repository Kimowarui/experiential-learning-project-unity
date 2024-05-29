using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabletHub : MonoBehaviour
{
    // Start is called before the first frame update
    public static TabletHub _instance;
    public TMP_InputField inputField;
    private Tablet tablet;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start() {
        gameObject.SetActive(false);
    }

    public void ShowTabletHub(Tablet tablet, Vector2 positiion) {
        gameObject.SetActive(true);
        this.tablet = tablet;
        transform.position = positiion;
    }

    public void OnClick() {
        if (!this.tablet || this.inputField.text == "") return;
        this.tablet.NameTablet(this.inputField.text);
        HideTabletHub();
    }

    public void OnCrossClick() {
        HideTabletHub();
    }

    private void HideTabletHub() {
        this.inputField.text = "";
        this.tablet = null;
        gameObject.SetActive(false);
    }
}
