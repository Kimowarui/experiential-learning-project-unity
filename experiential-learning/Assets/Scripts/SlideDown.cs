using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDown : MonoBehaviour
{
    public GameObject[] Contents;
    private int currentIdx;
    public void OnClick(int index) {
        Animator animator = GetComponent<Animator>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log(stateInfo);

        Contents[currentIdx].SetActive(false);

        if (stateInfo.IsName("Opened")) {
            animator.SetTrigger("Close");
        }

        
        if (stateInfo.IsName("Closed") || index != currentIdx) {
            animator.SetTrigger("Open");
            if (index != currentIdx) Invoke("ShowContent", 0.5f);
            else Invoke("ShowContent", 0f);
            currentIdx = index;
        }

    }

    private void ShowContent() {
        Contents[currentIdx].SetActive(true);
    }
}
