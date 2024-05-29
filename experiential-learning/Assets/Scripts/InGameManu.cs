using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManu : MonoBehaviour
{
    public void OnExit() {
        LevelManager.Instance.LoadScene("HomeScene");
    }

    public void OnBack() {
        gameObject.SetActive(false);
    }

    public void OnManu() {
        gameObject.SetActive(true);
    }
}
