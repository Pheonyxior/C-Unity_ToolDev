using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceInventoryManager : MonoBehaviour
{
    [SerializeField] private List<Ressource> ressourceList = new List<Ressource>();
    private static Dictionary<string, int> ressourceInventory = new Dictionary<string, int>();

    private static Dictionary<string, RessourceSlotBehaviour> ressourceSlots = new Dictionary<string, RessourceSlotBehaviour>();

    private void Awake() 
    {
        foreach ( Ressource ressource in ressourceList)
        {
            ressourceInventory.Add(ressource.name, 0);
        }

        // IncreaseRessourceAmount(ressourceList[0].name, 5);

        // foreach ( KeyValuePair<string, int> keyValuePair in ressourceInventory)
        // {
        //     Debug.Log(keyValuePair);
        // }
    }

    public static void IncreaseRessourceAmount(string ressourceName, int amount)
    {
        // Debug.Log(ressourceInventory[ressourceName]);
        ressourceInventory[ressourceName] += amount;
        // Debug.Log(ressourceInventory[ressourceName]);
        ressourceSlots[ressourceName + " ressource slot"].UpdateAmountDisplay(ressourceInventory[ressourceName]);
    }

    public static void SubscribeToRessourceSlots(RessourceSlotBehaviour newRessourceSlot)
    {
        ressourceSlots.Add(newRessourceSlot.gameObject.name, newRessourceSlot);
    }
    
    
}
