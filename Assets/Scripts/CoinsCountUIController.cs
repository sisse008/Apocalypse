using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCountUIController : MonoBehaviour
{
    [SerializeField] TMP_Text count;

    public void UpdateCoinCount(int newCount)
    { 
        count.text = newCount.ToString();
    }
}
