using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourceSlotBehaviour : MonoBehaviour
{
    [SerializeField] private Ressource ressource;
    
    private TextMeshProUGUI amountDisplay;
    [SerializeField] private Image ressourceIcon;

    private void Awake() 
    {
        amountDisplay = GetComponentInChildren<TextMeshProUGUI>();
        amountDisplay.text = 0.ToString();

        this.gameObject.name = ressource.name + " ressource slot";
        ressourceIcon.sprite = ressource.Icon;

        RessourceInventoryManager.SubscribeToRessourceSlots(this);
    }

    public void UpdateAmountDisplay(int newAmount) 
    {
        amountDisplay.text = newAmount.ToString();
    }
    
    
}
