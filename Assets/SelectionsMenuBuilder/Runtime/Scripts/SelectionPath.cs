using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPath : MonoBehaviour
{
   
    [SerializeField]
    private float radiuForCircleofSelectableObjects;

    [SerializeField] 
    float switchTimeInSeconds;

    [SerializeField]
    float yOffset = -1.5f;

    [SerializeField]
    float zOffset = 3;


    private List<Vector3> positions;

    private int numOfItems;
    private float DegreeDelta => 360f/(float)numOfItems;

    bool rotating = false;

    public void Init(List<GameObject> items)
    {
        numOfItems = items.Count;
        positions = GetItemsPositionsOnCyclicPath();
        InstantiateItems(items);
        ResetPosition();
    }

    void ResetPosition()
    {
        Vector3 camPos = SelectionMenuGenerator.CamPosition;
        transform.position = new Vector3(camPos.x, camPos.y + yOffset, camPos.z + radiuForCircleofSelectableObjects + zOffset);
    }

    void InstantiateItems(List<GameObject> items)
    {
        for (int i = 0; i < numOfItems; i++)
        {
            GameObject item = Instantiate(items[i], positions[i], items[i].transform.rotation, transform);
        }
    }

    public void NextItem(bool clockwise)
    {
        StartCoroutine(Rotate(clockwise));
    }

    IEnumerator Rotate(bool clockwise)
    {
        if (rotating)
            yield break;
        rotating = true;
        float time = 0;
        Vector3 current = transform.eulerAngles;
        Vector3 newRotation = new Vector3(current.x, clockwise? current.y+DegreeDelta : current.y - DegreeDelta, current.z);
        while (time < switchTimeInSeconds)
        {
            time += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(current, newRotation, time/switchTimeInSeconds);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        rotating = false;
    }

    private List<Vector3> GetItemsPositionsOnCyclicPath()
    {
        List<Vector3> _positions = new List<Vector3>();
      
        for (int i = 0; i < numOfItems; i++)
        {
            float angle = DegreeDelta * (float)i;
            /*float radians = angle/ Mathf.PI ;
            float x = Mathf.Cos(radians) * radius + transform.position.x;
            float y = Mathf.Sin(radians) * radius + transform.position.y;
            */
            var direction = Quaternion.Euler(0, angle, 0) * Vector3.back;
            _positions.Add(transform.position + direction * radiuForCircleofSelectableObjects);
           // Debug.Log("position = " + _positions[i]);

        }

        return _positions;
    }
 
}
