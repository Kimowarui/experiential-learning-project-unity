using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShifter : MonoBehaviour
{
    public static RoomShifter _instance;
    public GameObject[] Scenes;
    private int currentIdx;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }    
    public void ShiftRoom(int index) {
        Scenes[currentIdx].SetActive(false);
        Scenes[index].SetActive(true);
        currentIdx = index;
    }
}
