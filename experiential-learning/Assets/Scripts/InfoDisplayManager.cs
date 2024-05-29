using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDisplayManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InfoDisplayManager _instance;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void DisplayInformation(string name, string description) {
        nameText.text = name;
        descriptionText.text = description;
    }

    public void HideDisplay() {
        nameText.text = "";
        descriptionText.text = "";
    }
}
