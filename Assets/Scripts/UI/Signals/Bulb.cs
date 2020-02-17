using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Bulb : MonoBehaviour
{
    [SerializeField]
    protected Color lightColor = Color.white;
    [SerializeField]
    protected Color defaultColor = Color.black;
    
    protected Image image;

    private void Awake() {
        image = GetComponent<Image>();
        image.color = defaultColor;
    }

    public void TurnOn() {
        image.color = lightColor;
    }

    public void TurnOff() {
        image.color = defaultColor;
    }
}
