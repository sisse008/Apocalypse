using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : CollectableItem
{
    protected override void OnCollected(ICollect collectedBy)
    {
        base.OnCollected(collectedBy);
    }
}
