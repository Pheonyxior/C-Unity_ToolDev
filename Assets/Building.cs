using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{


    [SerializeField] private GameObject constructionOverlay;
    public GameObject ConstructionOverlay
    {
        get { return this.constructionOverlay; }
    }

    [SerializeField] private List<Vector2> buildingDimensions;
    public List<Vector2> BuildingDimensions
    {
        get
        {
            return this.buildingDimensions;
        }
    }

    [SerializeField] private List<Vector2> buildingOccupation;
    public List<Vector2> BuildingOccupation
    {
        get { return this.buildingOccupation; }
        set { buildingOccupation = value; }
    }

    [SerializeField] protected Ressource producedRessource;
    [SerializeField] protected int producedAmount;

    private void Awake() 
    {
        BuildingManager.SubscribeToBuildingList(this);
        
        // Debug.Log(this.gameObject.name + " has subscribed");
    }

    public virtual void DoProductionEffect()
    {
        Debug.Log(this.gameObject.name + " has produced");
    }

    private void OnMouseDown() 
    {
        //Debug.Log(this.gameObject.name + " clicked");

    }

    private void DestroyBuilding () 
    {
        
    }

    
}
