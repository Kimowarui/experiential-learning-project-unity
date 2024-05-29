using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour
{
    public void OnExitButtonClick() {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void OnStartButtonClick() {
        LevelManager.Instance.LoadSceneAsync("PreparationRoom");
    }
}
