using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellOffPlatformCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravitationalCharacter>())
        {
            other.GetComponent<GravitationalCharacter>().FallToDeath();
        }
    }
}
