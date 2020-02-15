using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkSelector : MonoBehaviour {
    [SerializeField]
    private Dropdown dropdownMenu = null;
    [SerializeField]
    private string placeholder = "Auswählen...";
    [SerializeField]
    private List<DrinkData> drinks = new List<DrinkData>();


    public void SetDropdownActive(bool isActive) {
        dropdownMenu.enabled = isActive;
    }

    public void SelectPlaceholder() {
        dropdownMenu.SetValueWithoutNotify(0);
    }

    private void Awake() {
        dropdownMenu.onValueChanged.AddListener(OnSelect);

        List<Dropdown.OptionData> dropdownOptions = new List<Dropdown.OptionData>();
        dropdownOptions.Add(new Dropdown.OptionData(placeholder));

        foreach (DrinkData drink in drinks) {
            dropdownOptions.Add(new Dropdown.OptionData(drink.drinkName));
        }

        dropdownMenu.options = dropdownOptions;
    }

    private void Update() {
        if (StateMachine.Instance.CurrentState.StateName != StateName.ChooseDrink) {
            dropdownMenu.enabled = false;
        } else {
            dropdownMenu.enabled = true;
        }
    }

    private void OnSelect(int index) {
        DrinkData newDrink = index > 0 ? drinks[index - 1] : null;
        StateMachine.Instance.CurrentState.SelectDrink(newDrink);
    }  
}
