using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private float productionSpeed;
   // [SerializeField] private GameObject buildingDetailsUI;

    

    // Start is called before the first frame update
   private void Start() 
   {
        StartProductionCoroutine();
   }

    public void StartProductionCoroutine()
    {
        StartCoroutine("ProductionCoroutine");
    }

    private IEnumerator ProductionCoroutine()
    {
        // Debug.Log("prod coroutine");
        while(true)
        {
            // Debug.Log("prod cycle");
            SignalBuildingsProduction();
            yield return new WaitForSeconds(productionSpeed);
        }
    }

    private void SignalBuildingsProduction()
    {
        for(int i = 0; i < buildingList.Count; i++) 
        {
            // Debug.LogWarning("signal loop");
            buildingList[i].DoProductionEffect();
        }
    }

    // Propriétés et méthodes statiques

    private static List<Building> buildingList = new List<Building>();
    // public static List<Building> BuildingList
    // {
    //     get { return buildingList ;}
    // }

    public static void SubscribeToBuildingList(Building newBuilding)
    {
        buildingList.Add(newBuilding);
        //Debug.Log( buildingList.Count);
    }

    public static void Unsubscribe(Building newBuilding)
    {
        buildingList.Add(newBuilding);
    }

    
}
