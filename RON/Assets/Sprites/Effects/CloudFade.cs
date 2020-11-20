using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFade : MonoBehaviour
{
    public float duration = 1;
    public Color fromColor;
    public Color toColor;
    public float gradSteps = 3;
    public float fromSize = 1;
    public float toSize = 1.1f;

    private float timeStart;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = GameTimer.time;
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, duration);
    }

    float easeOut(float x)
    {
        float invX = 1 - x;
        return 1 - (invX * invX * invX);
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (GameTimer.time - timeStart) / duration;
        progress = easeOut(progress);
        progress = ((int)(progress * gradSteps)) / gradSteps;
        
        sprite.color = Color.Lerp(fromColor, toColor,progress);
        transform.localScale = Vector3.one * Mathf.Lerp(fromSize, toSize, progress);
    }
}
