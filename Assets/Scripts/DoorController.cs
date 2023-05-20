using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class DoorController : MonoBehaviour
{
    Collider _collider;
    [SerializeField] Animator _animator;

    const string openDoorAnimatorKey = "open";

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDoorOpener doorOpener = other.GetComponent<IDoorOpener>();
        if (doorOpener != null)
        {
            if (doorOpener.canOpenDoor)
            {
                doorOpener.OnOpenedDoor?.Invoke();
                _animator.SetTrigger(openDoorAnimatorKey);
            }
        }
    }
}
