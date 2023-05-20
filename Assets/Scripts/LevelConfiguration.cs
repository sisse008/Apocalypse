using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelConfiguration : ScriptableObject
{
    [System.Serializable]
    public class EnemyConfiguration
    {
        public Enemy prefab;
        [Range(0, 1)]
        public float enemyDamage;
    }

    [System.Serializable]
    public class CoinConfiguration
    {
        public Coin prefab;
    }
    public string level_name;

    [Range(0.2f, 1.5f)]
    public float hightBetweenPlatforms;

    public EnemyConfiguration enemyConfiguration;
    public CoinConfiguration coinConfiguration;
    public Key keyPrefab;

    public List<PlatformController> platforms;

    public PlatformController platformWithKey;

    public PlatformController platformWithDoor;


}
