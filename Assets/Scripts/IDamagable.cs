using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamagable 
{
    public Transform BloodSpillPosition { get; }
    public ParticleSystem BloodSpillParticlesPrefab { get; }
    public UnityAction OnHurt { get; set; }
    public UnityAction OnDead { get; set; }


    float Health { get; }

    void OnDamadge(float damage);

}
