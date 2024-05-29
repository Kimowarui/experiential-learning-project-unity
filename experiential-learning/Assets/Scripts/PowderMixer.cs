using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.Collections;
using System;
using UnityEngine.UI;

public class PowderMixer : MonoBehaviour, IDropHandler
{
    public GameObject InputDisplay;
    public GameObject InfoDisplay;
    public TextMeshProUGUI InfoText;
    public TextMeshProUGUI InputText;
    public GameObject Powderprefab;
    private List<IngredientPowder> ingredientPowders;
    private IngredientPowder ingredient;
    void Start() {
        ingredientPowders = new List<IngredientPowder>();
    }

    public void OnDrop(PointerEventData eventData) {
        // Debug.Log("On Drop");
        if (this.ingredient && !ingredientPowders.Contains(this.ingredient)) {
            Destroy(this.ingredient.gameObject);
        }

        this.ingredient = eventData.pointerDrag.GetComponent<IngredientPowder>();
        if (!this.ingredient) {
            return;
        }
        this.ingredient.transform.SetParent(this.transform);
        // InfoDisplay.SetActive(false);
        InputDisplay.SetActive(true);

        string message = $"Specify the weight of {this.ingredient.ingredientInfo.name}:";
        InputText.SetText(message);
    }

    public void OnConfirmClick() {
        if (!this.ingredient) return;

        TMP_InputField inputField = InputDisplay.transform.Find("Input").GetComponent<TMP_InputField>();
        try {
            float weight = float.Parse(inputField.text);
            this.ingredient.SetWeight(weight);
            ingredientPowders.Add(this.ingredient);
        } catch (FormatException) {
            Debug.LogWarning("Invalid Format");
        } finally {
            inputField.text = "";
        }

        showInfoDisplay();
    }

    public void OnCancelClick() {
        ingredientPowders.Remove(this.ingredient);
        Destroy(this.ingredient.gameObject);

        showInfoDisplay();
    }
    public void OnMixClick(){
        if (this.ingredientPowders.Count > 0) {
            Transform spot = transform.Find("GenerationSpot");
            GameObject powderGameObject = Instantiate(Powderprefab, spot.position, Quaternion.identity);
            powderGameObject.transform.SetParent(GetComponentInParent<Canvas>().transform);
            Powder powder = powderGameObject.GetComponent<Powder>();

            foreach (IngredientPowder ingredientPowder in this.ingredientPowders) {
                powder.AddIngredient(ingredientPowder.ingredientInfo);
            }

            foreach (var ingredientPowder in this.ingredientPowders) {
                Destroy(ingredientPowder.gameObject);
            }
            this.ingredientPowders.Clear();
            InfoText.text = "";
        }   else{
            Debug.LogWarning("Not enough ingredient powders in the mixer to generate a new Powder.");
        }
    }
    private void showInfoDisplay() {
        InputDisplay.SetActive(false);
        // InfoDisplay.SetActive(true);

        InfoText.text = "";
        foreach (IngredientPowder ingredientPowder in ingredientPowders) {
            InfoText.text += ingredientPowder.ingredientInfo.ToString() + "\n";
        }
    }


}
