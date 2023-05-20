using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BlackScreenUIController : MonoBehaviour
{

    [Range(1, 5)]
    [SerializeField] float fadeTime = 2f;

    Image blackImage;

    private void Awake()
    {
        blackImage = GetComponent<Image>();
    }
    public IEnumerator FadeToBlack()
    {
        float time = 0;
        Color currentColor = blackImage.color;
        while (time < fadeTime)
        {
            time += Time.deltaTime;
            Color c = blackImage.color;
            blackImage.color = Color.Lerp(currentColor, Color.black, time/fadeTime);

            yield return null;
        }
    }
}
