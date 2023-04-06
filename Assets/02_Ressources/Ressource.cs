using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RessourceScriptableObject", order = 1)]
public class Ressource : ScriptableObject
{
    //[SerializeField] private string name;
    [SerializeField] private int id;
    public int Id {get{return id;}}

    [SerializeField] private Sprite icon;
    public Sprite Icon{get{return icon;}}
    
}
