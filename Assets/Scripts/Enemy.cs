using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : InteractableItem
{
    [Range(0,1)]
    [SerializeField] float damage;


    public void InitEnemy(LevelConfiguration.EnemyConfiguration configuration)
    {
        damage = configuration.enemyDamage;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamagable>() != null)
        {
            other.GetComponent<IDamagable>().OnDamadge(damage);
            Destroy(gameObject);
        }
    }
}
