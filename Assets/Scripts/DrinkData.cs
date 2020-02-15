using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DrinkData", menuName = "DrinkData")]
public class DrinkData : ScriptableObject
{
    public string drinkName = "Kein Name";

    public float price;

    public int desiredSugarCubes;
    public int desiredMilkPortions;
    public int neededCoffeePowder; // in grams
    public int neededMilkPowder; // ing grams
    public int neededWater; // in milliliters
}