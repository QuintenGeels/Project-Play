using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float delayDuration = 2f;
    public float changeDuration = 2f;

    public Color startColor;
    public Color endColor = new Color(0f, 0f, 0f, 0f);
    private float elapsedTime = 0f;
    private bool shouldChangeColor = false;

    void Start()
    {
        startColor = spriteRenderer.color;
        Invoke("StartColorChange", delayDuration);
    }

    void StartColorChange()
    {
        shouldChangeColor = true;
    }

    void Update()
    {
        if (shouldChangeColor)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / changeDuration);
            spriteRenderer.color = Color.Lerp(startColor, endColor, t);
        }
    }
}
