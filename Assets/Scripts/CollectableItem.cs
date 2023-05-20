using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollectableItem : InteractableItem
{

    protected override void OnTriggerEnter(Collider other)
    {
        //TODO: directly call other.GetComponent<ICollect>().Collect()
        //figure out what to do with key and coin
        if (other.GetComponent<ICollect>() != null)
        {
            OnCollected(other.GetComponent<ICollect>());
        }
    }

    protected virtual void OnCollected(ICollect collectedBy)
    {
        collectedBy.OnCollect(this);
        Destroy(gameObject);
    }
}
