using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntLogic : MonoBehaviour
{
    public EnemyInfo info;
    public AudioSource audio;


    public float detectionRadius = 10;
    public bool foundTarget = false;
    public int attackMax = 3;
    private float attackCooldown = 0;
    private float swingCooldown = 0;
    private float alertCooldown = 0;
    private int attackCount = 0;
    public int moveSpeed = 5;
    public Player player;

    public float wanderCooldown = 0;

    public GameObject projectile;

    public Vector3 waypoint;

    [SerializeField]
    private float attackCooldownMax = 15;
    [SerializeField]
    private float swingCooldownMax = 1;
    [SerializeField]
    private float attackDelay = 0.25f;

    private bool canAttack = false;
    private bool sawPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 1;
        swingCooldown = 1;
        info = GetComponent<EnemyInfo>();
        audio = GetComponent<AudioSource>();
        audio.volume = VolumeManager.sfxVal;
        this.player = Player.playerInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player == null)
        {
            this.player = this.info.target.GetComponent<Player>();
        }

        if (info.health > 0)
        {
            foundTarget = (Vector2.Distance(info.target.position, transform.position) < detectionRadius);


            attackCooldown -= Time.deltaTime;
            swingCooldown -= Time.deltaTime;
            wanderCooldown -= Time.deltaTime;
            alertCooldown -= Time.deltaTime;

            bool facing = (waypoint - transform.position).x > 0;
            info.sprite.flipX = !facing;

            //Debug.Log(!this.player.invisible);
            if (foundTarget && !this.player.invisible)
            {
                waypoint = info.target.transform.position;

                if (!sawPlayer)
                {
                    facing = (waypoint - transform.position).x > 0;
                    info.sprite.flipX = facing;
                    audio.Play();
                    sawPlayer = true;
                    alertCooldown = attackDelay;
                }

                if (sawPlayer && alertCooldown <= 0)
                {

                    if (attackCooldown <= 0)
                    {
                        attackCooldown = attackCooldownMax;
                        attackCount = 0;
                    }
                    if (attackCount < attackMax)
                    {

                        if (swingCooldown <= 0)
                        {
                            info.animator.SetTrigger("Shoot");

                            var proj = Instantiate(projectile, transform.position + Vector3.right * (facing ? 1 : -1) * 3, Quaternion.identity);
                            proj.GetComponent<Rigidbody2D>().velocity = (waypoint - transform.position).normalized * 10;
                            proj.GetComponent<Projectile>().damage = (int)(info.attackDamage * info.difficultyScale.Evaluate(GameTimer.time));
                            attackCount++;

                            swingCooldown = swingCooldownMax / (info.attackSpeed);
                        }
                    }
                }
            }
            else
            {
                sawPlayer = false;
                if (wanderCooldown <= 0)
                {
                    waypoint = transform.position + (Vector3.right * Random.Range(-3, 3)).normalized;
                    wanderCooldown = 10;
                }
            }
            if (Vector2.Distance(waypoint, transform.position) > 0.1f)
            {
                transform.position += (waypoint - transform.position).normalized * Time.deltaTime * this.moveSpeed;
                info.animator.SetBool("isRunning", true);
            } else
                info.animator.SetBool("isRunning", false);
        }
        else
        {
            info.animator.SetTrigger("Die");
        }
    }

    private void UpdateSFXVolume()
    {
        audio.volume = VolumeManager.sfxVal;
    }

    private void OnEnable()
    {
        VolumeManager.OnMusicVolumeChange += UpdateSFXVolume;
    }

    private void OnDisable()
    {
        VolumeManager.OnMusicVolumeChange -= UpdateSFXVolume;
    }

    private void OnDestroy()
    {
        VolumeManager.OnMusicVolumeChange -= UpdateSFXVolume;
    }

}
