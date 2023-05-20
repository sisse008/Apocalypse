using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlatformController : PlatformController
{

    [SerializeField] protected Transform keyPosition;

    public override void Init(LevelConfiguration.EnemyConfiguration enemyConfiguration, LevelConfiguration.CoinConfiguration coinconfiguration, Key keyPrefab)
    {
        Key k = Instantiate(keyPrefab, keyPosition.position, Quaternion.identity);
        k.transform.SetParent(transform);   
       
        base.Init(enemyConfiguration, coinconfiguration, keyPrefab);
    }
}
