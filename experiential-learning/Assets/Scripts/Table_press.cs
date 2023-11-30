using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TablePress : MonoBehaviour, IDropHandler
{  
    private GameObject dialogBubble;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OnStart");
        dialogBubble = transform.Find("DialogBubble").gameObject;
        HideDialogBubble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
    }

    void OnMouseOver() {

        if (Input.GetMouseButtonDown(0)) {
            dialogBubble.SetActive(true);
            Invoke("HideDialogBubble", 2f);
        }
    }

    private void HideDialogBubble() {
        dialogBubble.SetActive(false);
    }
}
