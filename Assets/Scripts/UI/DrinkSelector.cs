using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrinkSelector : MonoBehaviour {
    [SerializeField]
    private Dropdown dropdownMenu = null;
    [SerializeField]
    private string placeholder = "Auswählen...";
    [SerializeField]
    private List<DrinkData> drinks = new List<DrinkData>();

    private TMP_InputField sugarCubeInput;
    private int desiredSugarCubes;

    private TMP_InputField milkPortionInput;
    private int desiredMilkPortions;

    private DrinkData selectedDrink;
    public DrinkData SelectedDrink { get {
            if (selectedDrink) {
                selectedDrink.desiredMilkPortions = desiredMilkPortions;
                selectedDrink.desiredSugarCubes = desiredSugarCubes;
            }
            return selectedDrink;
        }
        private set { selectedDrink = value; } }

    public void SetUserCanInput(bool isActive) {
        dropdownMenu.interactable = isActive;
        sugarCubeInput.interactable = isActive;
        milkPortionInput.interactable = isActive;
    }

    public void SelectPlaceholder() {
        dropdownMenu.SetValueWithoutNotify(0);
    }


    private void OnSelectListener(int index) {
        SelectedDrink = index > 0 ? drinks[index - 1] : null;
    }

    private void Awake() {
        sugarCubeInput = GameManager.Instance.sugarCubeInput;
        milkPortionInput = GameManager.Instance.milkPortionInput;
        sugarCubeInput.onValueChanged.AddListener(delegate {
            if (!int.TryParse(sugarCubeInput.text, out desiredSugarCubes)) {
                desiredSugarCubes = 0;
            }
        });
        milkPortionInput.onValueChanged.AddListener(delegate {
            if (int.TryParse(milkPortionInput.text, out desiredMilkPortions)) {
                desiredMilkPortions = 0;
            }
        });

        // Setup Dropdown Options and OnChangeListener
        dropdownMenu.onValueChanged.AddListener(OnSelectListener);
        List<Dropdown.OptionData> dropdownOptions = new List<Dropdown.OptionData>();
        dropdownOptions.Add(new Dropdown.OptionData(placeholder));

        foreach (DrinkData drink in drinks) {
            dropdownOptions.Add(new Dropdown.OptionData(drink.drinkName));
        }

        dropdownMenu.options = dropdownOptions;
    }
}
