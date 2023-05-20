using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public Transform startPoint;

    public float distanceBetweenPlatforms = 2f;



     List<PlatformController> GetPlatformsFromLevelData(LevelConfiguration levelData)
     {
        //create a list with key platform in random position in list and door platform at the end of list.
        int randomIndex = Random.Range(0, levelData.platforms.Count); //0 to count-1

        List<PlatformController> platformList = new List<PlatformController>(levelData.platforms);

        platformList.Insert(randomIndex, levelData.platformWithKey);

        platformList.Add(levelData.platformWithDoor);

        return platformList;
    }

    List<PlatformController> InstantiatePlatforms(List<PlatformController> platformPrefabs, LevelConfiguration level)
    {
        Vector3 previousPosition = startPoint.position;
        float previousLength = 0;

        float[] hights = { level.hightBetweenPlatforms*-1, level.hightBetweenPlatforms };

        List<PlatformController> platformInstances = new List<PlatformController>();

        foreach (PlatformController _platform in platformPrefabs)
        {
            int rand = Random.Range(0,2); // 0 or 1

            Vector3 nextPosition = previousPosition + new Vector3(0f, hights[rand],
                _platform.Length/2 + previousLength/2 + distanceBetweenPlatforms);

            previousLength = _platform.Length;

            PlatformController platform = Instantiate(_platform, nextPosition, Quaternion.identity);

            platform.Init(level.enemyConfiguration, level.coinConfiguration, level.keyPrefab);

            platformInstances.Add(platform);    

            previousPosition = nextPosition;
        }

        return platformInstances;
    }

  

    public Vector3 GenerateLevelPlatforms(LevelConfiguration level)
    {
        List<PlatformController> plaformsPrefabs = GetPlatformsFromLevelData(level);

        List<PlatformController> plaformsInstances = InstantiatePlatforms(plaformsPrefabs, level);

        return plaformsInstances[0].PlayerInitPosition;
    }


}
