using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TablePress : MonoBehaviour
{  
    private GameObject dialogBubble;
    private Slider slider;  
    private bool isReleaseValveLocked;
    private double pressure;
    private bool inProgress;
    private bool hasTablet;
    public bool isPowderExcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OnStart");
        dialogBubble = transform.Find("DialogBubble").gameObject;
        slider = GetComponentInChildren<Slider>(true);
        Debug.Log(slider);
        isReleaseValveLocked = false;
        pressure = 0;
        inProgress = false;
        hasTablet = false;
        isPowderExcess = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleIsReleaseValve() {
        Powder powder = GetComponentInChildren<Powder>();
        if (isReleaseValveLocked) pressure = 0;
        isReleaseValveLocked = !isReleaseValveLocked;
        Debug.Log("Release Valve:" + isReleaseValveLocked);
    }


    public void LowerPunch() {
        Powder powder = GetComponentInChildren<Powder>();
        if (isReleaseValveLocked) {
            pressure += 0.25;
        }
        Talk("Current Pressure:" + pressure + " ton");
        if (pressure >= 1 && powder && !inProgress) {
            Debug.Log(powder.getIsExcessive());
            if (powder.getIsExcessive()) {
                Talk("Please remove Excess Powder!");
                pressure = 0;
                return;
            }
            StartPressTablet();
        }

        Debug.Log("Current Pressure:" + pressure + " ton");
    }

    public void EjectTablet() {
        if (hasTablet && pressure == 0) {
            hasTablet = false;
            inProgress = false;
            Talk("Congrats! You successfully make your own tablet.");
            Debug.Log("Congrats! You successfully make your own tablet.");
        }
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && !GetComponentInChildren<Powder>() && !inProgress) {
            string message = "Feed it some powder for a magical transformation!";
            Talk(message);
        }
    }

    private void HideDialogBubble() {
        dialogBubble.SetActive(false);
    }

    private void StartPressTablet() {
        inProgress = true;
        Powder powder = GetComponentInChildren<Powder>();
        Destroy(powder.gameObject);
        StartCoroutine(SimulatePressTablet());
    }

    IEnumerator SimulatePressTablet() {
        float progress = 0f;
        slider.gameObject.SetActive(true);
        while (progress < 1f) {
            progress += Time.deltaTime / 2f;
            slider.value = progress;
            yield return null;
        }
        slider.gameObject.SetActive(false);
        hasTablet = true;
        Talk("Pressing Tablet Completed!");
        Debug.Log("Pressing Tablet Completed");
    }

    private void Talk(string text) {
        HideDialogBubble();
        TMP_Text content = dialogBubble.GetComponentInChildren<TMP_Text>();
        content.text = text;
        dialogBubble.SetActive(true);
        Invoke("HideDialogBubble", 2f);
    }

}
