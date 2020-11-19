using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public bool isPhysicsBased = false;
    public Animator animator;
    public SpriteRenderer sprite;
    public GameObject elevator;
    private Spawner_Master spawner;

    public static float hurtDuration = 1/8f;

    public bool isDead = false;

    public float dazedFor = 0;
    public float hurtFor = 0;
    public float health = 100f;
    public float attackSpeed = 10;
    public float moveSpeed = 5;

    public int difficulty = 0;

    public bool facing = true;


    public int attackDamage = 10;
    public AnimationCurve difficultyScale;

    public Transform target;

    public GameObject[] itemPrefabs;
    
    public void Start()
    {
        gameObject.tag = "Enemy";
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        elevator = GameObject.FindGameObjectWithTag("Elevator");
        spawner = elevator.GetComponent<Spawner_Master>();
    }

    public void Update()
    {
        if (sprite)
        {
            if (hurtFor > 0)
            {
                sprite.color = Color.red;
            }
            else
            {
                sprite.color = Color.white;
            }
        }


        dazedFor -= Time.deltaTime;
        if (dazedFor < 0) dazedFor = 0;
        hurtFor -= Time.deltaTime;
        if (hurtFor < 0) hurtFor = 0;
        if (health <= 0 && !isDead) Die();
    }

    public void Hurt(float damage)
    {
        health -= damage;
        hurtFor = hurtDuration;
        if (health <= 0 && !isDead) Die();
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject, 3);

        
        if (!isPhysicsBased)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        target.GetComponent<Player>().AddMoney(10);
        spawner.kill(gameObject);

        var iPrefab = itemPrefabs[Random.Range(0,itemPrefabs.Length)];
        var item = Instantiate(iPrefab, transform.position, Quaternion.identity);
    }

    //NOTE FOR REVIEWER
    //It may be a good idea to put reverse this sort of code and put it in the Player class
    //This is being called EVERY time ANY enemy touches something.
    //Since we know there'll only be one player, there'll be a lot fewer calls if it triggers only when
    // a player touches something.
    public void OnCollisionEnter2D(Collision2D c)
    {
        if(c.collider != null && !isDead)
        {
            if(c.gameObject.tag == "Player")
            {
                c.gameObject.GetComponent<Player>().TakeDamage((int)(attackDamage*difficultyScale.Evaluate(GameTimer.time)));
            }
        }
    }

}
