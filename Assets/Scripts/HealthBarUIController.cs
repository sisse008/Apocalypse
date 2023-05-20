using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBarUIController : MonoBehaviour
{

    Image filledImage;

    private void Awake()
    {
        filledImage = GetComponent<Image>();
    }

    public void UpdateHealthBar(float newHealth)
    {
        filledImage.fillAmount = newHealth;
    }
}
