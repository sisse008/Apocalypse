using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    [SerializeField] float afterSeconds;

    private void OnEnable()
    {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(afterSeconds);
        Destroy(gameObject);
    }
}
