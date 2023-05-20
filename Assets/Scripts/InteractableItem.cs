using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Collider))]
public abstract class InteractableItem : MonoBehaviour, ISpinnable
{
   
    [SerializeField] bool _spin = true;

    [Range(0.1f, 1.5f)]
    [SerializeField] float _spinRate = 1.5f;


    public float spinRate { get { return _spinRate; } }
    public bool spin { get { return _spin; } }



    Collider _collider;
    Collider Collider
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<Collider>();
                _collider.isTrigger = true;
            }
            return _collider;
        }
    }

    private void Awake()
    {     
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    public void Spin()
    {
        transform.Rotate(0, spinRate, 0, Space.Self);
    }

    private void FixedUpdate()
    {
        if (spin)
            Spin();
    }
}
