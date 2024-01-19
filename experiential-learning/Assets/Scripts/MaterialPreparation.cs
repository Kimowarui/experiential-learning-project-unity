using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MaterialPreparation : MonoBehaviour
{
    private TMP_InputField drugIn;
    private TMP_InputField paracetamolIn;
    private TMP_InputField lactoseIn;
    private TMP_InputField mgstIn;

  // Start is called before the first frame update
    void Start()
    {
        drugIn = transform.Find("Container/Slot/DrugIn").GetComponent<TMP_InputField>();
        paracetamolIn = transform.Find("Container/Slot (1)/ParacetamolIn").GetComponent<TMP_InputField>();
        lactoseIn = transform.Find("Container/Slot (2)/LactoseIn").GetComponent<TMP_InputField>(); 
        mgstIn = transform.Find("Container/Slot (3)/MgStIn").GetComponent<TMP_InputField>(); 
    }

    public void PrepareMaterial() {
        Powder powder = GameObject.FindGameObjectWithTag("Powder").GetComponent<Powder>();
        if (!powder) {
            Debug.LogError("No Powder Found");
        }
        int drug;
        int paracetamol;
        int lactose;
        int mgst;
        try {
            drug = int.Parse(drugIn.text);
            paracetamol = int.Parse(paracetamolIn.text);
            lactose = int.Parse(lactoseIn.text);
            mgst = int.Parse(mgstIn.text);

            powder.prepare(drug, paracetamol, lactose, mgst);

        } catch (FormatException) {
            Debug.Log("Invalid Format");
        } finally {
            drugIn.text = "";
            paracetamolIn.text = "";
            lactoseIn.text = "";
            mgstIn.text = "";
        }
    }
}
