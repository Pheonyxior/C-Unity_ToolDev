using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BuildingSizeInitiator : MonoBehaviour
{
    Building building;

    private void Awake() {
        building = this.gameObject.GetComponent<Building>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.IsPlaying(gameObject))
        {
            UpdateBuildingDimensions();
        }
    }

    void UpdateBuildingDimensions()
    {
        List<Vector2> currentBuildingDimensions = new List<Vector2>();
        for(int i = 0; i < this.transform.childCount; i++) 
        {
            currentBuildingDimensions.Add(this.transform.GetChild(i).transform.position);
        }
        building.BuildingOccupation = currentBuildingDimensions;
        Debug.Log("ble");
    }
}
