using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepoPagination : MonoBehaviour
{
    public GameObject[] Pages;
    private int page;
    void Start() {
        page = 0;
    }
    public void NextPage() {
        if (page + 1 >= Pages.Length) return;
        Pages[page].SetActive(false);
        page += 1;
        Pages[page].SetActive(true);
    }

    public void PreviousPage() {
        if (page - 1 < 0) return;
        Pages[page].SetActive(false);
        page -= 1;
        Pages[page].SetActive(true);
    }
}
