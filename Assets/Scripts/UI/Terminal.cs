using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Terminal : MonoBehaviour
{
    [SerializeField] private TMP_Text display;
    
    public void WriteMessage(string message) {
        display.text = message;
    }
}
