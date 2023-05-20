using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : CollectableItem
{
    protected override void OnCollected(ICollect collectedBy)
    {
       // Debug.Log("coin collected");
        base.OnCollected(collectedBy);
    }
}
