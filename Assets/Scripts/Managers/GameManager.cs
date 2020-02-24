using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("User Selection")]
    public DrinkSelector drinkSelection;
    public TMP_InputField sugarCubeInput;
    public TMP_InputField milkPortionInput;
    
    [Header("User Action")]
    public ConfirmButton confirmButton;
    public AbortButton abortButton;

    [Header("Feedback")]
    public MoneyDisplay moneyDisplay;
    public Terminal terminal;

    public Bulb goodBulb;
    public Bulb dangerBulb;

    [Header("Payment")]
    public MoneyButton tenCentButton;
    public MoneyButton twentyCentButton;
    public MoneyButton fiftyCentButton;
    public MoneyButton oneEuroButton;
    public MoneyButton twoEuroButton;


    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    
    [HideInInspector]
    public bool IsReady = false;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    private void Start() {
        DisableInputElements();

        IsReady = true;
    }

    // Each State enables the input elements it needs and deactivates them if the state gets changed
    private void DisableInputElements() {
        drinkSelection.SetUserCanInput(false);

        confirmButton.SetUserCanInput(false);
        abortButton.SetUserCanInput(false);

        SetMoneyButtonEnabled(false);
    }

    public void SetMoneyButtonEnabled(bool isActive) {
        tenCentButton.SetUserCanInput(isActive);
        twentyCentButton.SetUserCanInput(isActive);
        fiftyCentButton.SetUserCanInput(isActive);
        oneEuroButton.SetUserCanInput(isActive);
        twoEuroButton.SetUserCanInput(isActive);
    }
}
