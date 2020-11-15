using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
    public Transform debugTarget;
    public float maxSpeed = 5;
    public float detectionRadius = 30;
    public float closeProx = 1;
    public float uprightForce = 100;
    public float maxRotDelta = 10;
    public float hoverHeight = 10;
    public float hoverForce = 1;
    public float laserWidth = 0.05f;

    public float shotCooldown = 6;

    public Vector2 targetPos;
    private Rigidbody2D rb;
    private EnemyInfo info;

    public float debugRot;
    private Vector2 targetUp = Vector2.up;
    private bool movingRight = true;

    public Transform turret;
    public Transform laser;
    public LayerMask groundMask;

    private float chargeUpTime = 0;
    private float maxCharge = 6;
    private float flickerCharge = 0.8f;
    private float flickerFreq = 20;

    public MuzzleFlash muzzleFlash;
    public float shootForce = 5;
    public GameObject impact;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        info = GetComponent<EnemyInfo>();
    }

    
    float DistanceToGround()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position,Vector2.down, 100, groundMask);
        if(groundHit.collider != null)
            return groundHit.distance;
        return -1;
    }

    private bool hadFoundTarget;

    private void Update()
    {
        float progress = (GameTimer.time - chargeUpTime) / maxCharge;
        bool foundTarget = (Vector2.Distance(info.target.position, transform.position) < detectionRadius);

        bool isFlicker = (progress >= flickerCharge) && progress <= 1;
        if (isFlicker)
            laser.gameObject.SetActive(Mathf.Sin(((Mathf.PI * 2) * (flickerFreq)) * progress) > 0);
        else
            laser.gameObject.SetActive(foundTarget);

        
        if (foundTarget && !isFlicker)
        {
            targetPos = info.target.position;
            
        }

        if(hadFoundTarget != foundTarget)
        {
            hadFoundTarget = foundTarget;
            if(foundTarget && (GameTimer.time > chargeUpTime))
                chargeUpTime = GameTimer.time;
        }

        if (progress >= 1)
        {
            RaycastHit2D shot = Physics2D.Raycast(turret.position, -turret.up);
            muzzleFlash.Replay();
            if (shot.collider != null)
            {

                if (shot.transform.tag == "Player")
                {
                    Player p = shot.transform.GetComponent<Player>();
                    rb.AddForceAtPosition(turret.up * shootForce, turret.position, ForceMode2D.Impulse);
                    p.TakeDamage(info.attackDamage);
                    Physics2D.IgnoreCollision(p.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    var dustEffect = Instantiate(impact, shot.point, Quaternion.identity);
                    dustEffect.transform.up = shot.normal;
                    Destroy(dustEffect, 1);
                }
            }
            chargeUpTime = GameTimer.time + shotCooldown;
        }


        Vector2 diff = (targetPos - (Vector2) turret.transform.position);
        Vector3 mid = (targetPos + (Vector2) turret.transform.position) / 2;
        mid.z = 10;

        laser.position = mid;
        laser.right = diff;

        laser.localScale = new Vector3(diff.magnitude / transform.localScale.x, laserWidth / transform.localScale.y, 1);

        

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!info.isDead)
        {
            Vector2 diff = targetPos - (Vector2)turret.transform.position;

            turret.up = -diff;

            float dist = diff.magnitude;
            diff = diff.normalized * (dist - closeProx);

            float height = DistanceToGround();

            if (height < hoverHeight && height > 0)
            {
                diff.y += (hoverHeight - height) * hoverForce * Time.fixedDeltaTime;
            }
            if (diff.sqrMagnitude < 0.1f) diff = Vector2.zero;
            rb.velocity += (Vector2.ClampMagnitude(diff, maxSpeed) - rb.velocity)*0.9f;

            var rot = Vector2.SignedAngle(transform.up, targetUp);
            rb.AddTorque(rot * uprightForce);
            debugRot = rot;

            movingRight = (diff.x > 0);
            float speedCoef = (dist - closeProx) / (maxSpeed / 2);

            targetUp = Quaternion.AngleAxis(speedCoef * maxRotDelta * (movingRight ? -1 : 1), Vector3.forward) * Vector3.up;
        } else
        {
            rb.gravityScale = 1;
        }
        


    }
}
