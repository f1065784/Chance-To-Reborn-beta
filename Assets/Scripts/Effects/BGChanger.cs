using System.Collections;
using UnityEngine;

public class BGChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color targetColor;
    private float transitionDuration = 1.5f;
    private bool isChangingColor = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomTargetColor();
        StartCoroutine(ChangeColorSmoothly());
    }

    public void OnRoomChanged()
    {
        if (!isChangingColor)
        {
            SetRandomTargetColor();
            StartCoroutine(ChangeColorSmoothly());
        }
    }

    private void SetRandomTargetColor()
    {
        float r = 125f / 255f;
        float g = 125f / 255f;
        float b = 125f / 255f;

        int randomChannel = Random.Range(0, 3);
        float randomValue = Random.Range(125f / 255f, 180f / 255f);
        if (randomChannel == 0) r = randomValue;
        else if (randomChannel == 1) g = randomValue;
        else if (randomChannel == 2) b = randomValue;
        targetColor = new Color(r, g, b);
    }

    private IEnumerator ChangeColorSmoothly()
    {
        isChangingColor = true;
        Color startColor = spriteRenderer.color;
        float elapsed = 0f;
        
        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsed / transitionDuration);
            yield return null;
        }
        
        spriteRenderer.color = targetColor;
        isChangingColor = false;
    }
}