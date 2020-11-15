using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
    public Transform debugTarget;
    public float maxSpeed = 5;
    public float closeProx = 1;
    public float uprightForce = 100;
    public float maxRotDelta = 10;
    public float hoverHeight = 10;
    public float hoverForce = 1;

    public Vector2 targetPos;
    public Rigidbody2D rb;

    public float debugRot;
    private Vector2 targetUp = Vector2.up;
    private bool movingRight = true;

    public Transform turret;
    public LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    float DistanceToGround()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position,Vector2.down, 100, groundMask);
        if(groundHit.collider != null)
            return groundHit.distance;
        return -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 diff = debugTarget.position - transform.position;
        
        float dist = diff.magnitude;
        if(dist > closeProx)
        {

            diff = diff.normalized * (dist - closeProx);
            targetPos = (Vector2) transform.position + diff;
            turret.up = -diff;
        } else
        {
            diff = Vector2.zero;
            targetUp = Vector2.up;
        }

        

        float height = DistanceToGround();

        if (height < hoverHeight && height > 0 && diff.y < 0)
        {
            diff.y += (hoverHeight - height)*hoverForce*Time.fixedDeltaTime;
        }

        rb.velocity = Vector2.ClampMagnitude(diff, maxSpeed);

        var rot = Vector2.SignedAngle(transform.up, targetUp);
        rb.AddTorque(rot * uprightForce);
        debugRot = rot;

        movingRight = (diff.x > 0);
        float speedCoef = (dist - closeProx) / (maxSpeed / 2);

        targetUp = Quaternion.AngleAxis(speedCoef*maxRotDelta * (movingRight ? -1 : 1), Vector3.forward) * Vector3.up;

        


    }
}
