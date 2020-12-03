using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBurst : MonoBehaviour
{
    public float damageRate = 25;
    public LayerMask damageLayer;

    public float chargeDuration = 3;
    public float pulseDuration = 1;

    public float maxWidth = 5;

    private float spawnTime = 0;
    private SpriteRenderer sprite;
    public Color pulseColor;
    public Color chargeColor;
    private Color currentColor;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        spawnTime = GameTimer.time;
        filter.layerMask = damageLayer;
        Destroy(gameObject, chargeDuration + pulseDuration);
    }

    private float easeIn(float x)
    {
        return x * x * x * x * x;
    }


    private Collider2D[] hitList = new Collider2D[1];
    private ContactFilter2D filter;
// Update is called once per frame
    void Update()
    {
        float timeSince = GameTimer.time - spawnTime;
        float chargeProgress = (timeSince)/chargeDuration;

        float ease = easeIn(chargeProgress);

        float newWidth = Mathf.Lerp(0, maxWidth, ease);
        sprite.color = Color.Lerp(chargeColor, pulseColor, ease);
        transform.localScale = new Vector3(10000, newWidth, 1);

        if(chargeProgress > 1)
        {
            var hit = Physics2D.OverlapBox(transform.position, transform.localScale, 0, filter, hitList);
            //Debug.Log(hit);
            if (hit > 0)
            {
                Player p = hitList[0].GetComponent<Player>();
                if(p)
                    p.TakeDamage(damageRate * Time.deltaTime);
            }
        }
    }
}
