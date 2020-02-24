using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text display;

    private float currentValue = 0f;

    private void Start()
    {
        UpdateDisplay();    
    }


    // Overload for redisplaying the currentValue variable
    public void UpdateDisplay() {
        display.text = string.Format("{0:n}", currentValue);
    }

    public void UpdateDisplay(float newValue) {
        currentValue = newValue;
        UpdateDisplay();
    }


    public void SubtractAmount(float amount) {
        currentValue -= amount;
        UpdateDisplay();
    }
}
