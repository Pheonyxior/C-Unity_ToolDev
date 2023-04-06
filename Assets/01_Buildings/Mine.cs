using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    public override void DoProductionEffect()
    {
        RessourceInventoryManager.IncreaseRessourceAmount(this.producedRessource.name, this.producedAmount);
    }
}
