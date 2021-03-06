﻿using System.Collections;
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

    [Header("Widgets")]
    public GameObject machineWidget;
    public GameObject controlPanelWidget;
    public GameObject stateDiagramWidget;

    [Header("Misc")]
    public Transform ejectSlot;

    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    
    [HideInInspector]
    public bool IsReady = false;
    

    [SerializeField] private GameObject oddMoneyPrefab;
    private Canvas canvas = null;
    private bool displayStateDiagram = false;

    private void Awake() {
        canvas = FindObjectOfType<Canvas>();

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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.H))
            ToggleStateDiagram();
    }

    public void SetMoneyButtonEnabled(bool isActive) {
        tenCentButton.SetUserCanInput(isActive);
        twentyCentButton.SetUserCanInput(isActive);
        fiftyCentButton.SetUserCanInput(isActive);
        oneEuroButton.SetUserCanInput(isActive);
        twoEuroButton.SetUserCanInput(isActive);
    }

    public GameObject CreateDrinkGameObject(DrinkData drink) {
        return CreateUIElement(drink.prefab);
    }

    public GameObject CreateOddMoneyGameObject() {
        return CreateUIElement(oddMoneyPrefab);
    }

    private void ToggleStateDiagram() {
        displayStateDiagram = !displayStateDiagram;

        if (displayStateDiagram) {
            machineWidget.transform.localPosition = new Vector3(-481, 0, 0);
            controlPanelWidget.transform.localPosition = new Vector3(0, 0, 0);
            stateDiagramWidget.transform.localPosition = new Vector3(514, 0, 0);
        } else {
            machineWidget.transform.localPosition = new Vector3(-250, 0, 0);
            controlPanelWidget.transform.localPosition = new Vector3(380, 0, 0);
            stateDiagramWidget.transform.localPosition = new Vector3(1273, 0, 0);
        }
    }

    private GameObject CreateUIElement(GameObject gameObject) {
        GameObject uiElement = Instantiate(gameObject);
        uiElement.transform.position = ejectSlot.position;
        uiElement.transform.SetParent(canvas.transform);

        return uiElement;
    }
    
    // Each State enables the input elements it needs and deactivates them if the state gets changed
    private void DisableInputElements() {
        drinkSelection.SetUserCanInput(false);

        confirmButton.SetUserCanInput(false);
        abortButton.SetUserCanInput(false);

        SetMoneyButtonEnabled(false);
    }
}
