using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] Transform initPosition;

    [SerializeField] protected List<Transform> enemiesPositions;
    [SerializeField] protected List<Transform> coinsPositions;

    public float Length => platform.localScale.z;
    public Vector3 PlayerInitPosition => initPosition.position;


    public virtual void Init(LevelConfiguration.EnemyConfiguration enemyconfiguration, LevelConfiguration.CoinConfiguration coinconfiguration, Key keyPrefab)
    {
        foreach (Transform position in enemiesPositions)
        {
            Enemy e = Instantiate(enemyconfiguration.prefab, position.position, Quaternion.identity);
            e.transform.SetParent(transform);
            e.InitEnemy(enemyconfiguration);
        }

        foreach (Transform position in coinsPositions)
        {
            Coin c = Instantiate(coinconfiguration.prefab, position.position, Quaternion.identity);
            c.transform.SetParent(transform);
        }
    }


}
