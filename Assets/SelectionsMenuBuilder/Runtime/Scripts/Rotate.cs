using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, Time.deltaTime*70f, 0, Space.Self);
    }
}
