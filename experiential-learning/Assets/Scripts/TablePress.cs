using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TablePress : MonoBehaviour
{  
    private GameObject dialogBubble;
    private Slider slider;  
    private bool isReleaseValveLocked;
    private double pressure;
    private bool inProgress;
    private bool hasTablet;
    private Powder powder;
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
    }

    public void ToggleIsReleaseValve() {
        Powder powder = GetComponentInChildren<Powder>();
        if (isReleaseValveLocked) pressure = 0;
        isReleaseValveLocked = !isReleaseValveLocked;
        Debug.Log("Release Valve:" + isReleaseValveLocked);
        string message = isReleaseValveLocked ? "Locked" : "Unlocked";
        Talk("Release Valve is " + message);
    }


    public void LowerPunch() {
        Powder powder = GetComponentInChildren<Powder>();
        if (isReleaseValveLocked) {
            pressure += 0.25;
        } else {
            Talk("Please lock release valve");
            return;
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
            this.powder.gameObject.SetActive(true);
            powder.GenerateTablet();
            Talk("Congrats! You successfully make your own tablet.");
            Debug.Log("Congrats! You successfully make your own tablet.");
        } else if (pressure != 0) {
            Talk("Please unlock release valve before ejecting tablet");
        }
    }

    private void HideDialogBubble() {
        dialogBubble.SetActive(false);
    }

    private void StartPressTablet() {
        inProgress = true;
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
        Powder powder = GetComponentInChildren<Powder>();
        this.powder = powder;
        powder.gameObject.SetActive(false);
        Talk("Pressing Tablet Completed!");
        Debug.Log("Pressing Tablet Completed");
    }

    public void Talk(string text) {
        HideDialogBubble();
        TMP_Text content = dialogBubble.GetComponentInChildren<TMP_Text>();
        content.text = text;
        dialogBubble.SetActive(true);
        Invoke("HideDialogBubble", 2f);
    }

}