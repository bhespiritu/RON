using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator an;
    public SpriteRenderer sprite;

    [Header("Important Values")]
    public float health;
    public float maxHealth;
    public int money;
    [Header("Items")]
    public List<ActiveItem> activeItems;
    public List<PassiveItem> passiveItems;
    public SecondaryItem secondaryItem;
    [Header("Player Stats")]
    public float jumpSpeed;
    public float speed;
    public float attack;
    public float defense;
    public float damageMultiplier;
    public float healMultiplier;
    public float critChance;
    public float blockChance;
    public bool canShoot = true;
    public bool invisible;

    [Header("GameObject References")]
    public MuzzleFlash muzzleFlash;
    public Transform firePos;
    public GameObject projectile;
    public GameObject critProjectile;
    public GameObject shield;
    public float projSpeed = 100;

    private bool isGrounded = true;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public delegate void PlayerEvent(float f);
    public static event PlayerEvent mChange;
    public static event PlayerEvent hChange;

    public float autofireDelay = 0f;
    public System.Random rand = new System.Random();

    // fucky sounds :)
    [Header("Sounds")]
    public float delay = 0f;
    public float timeBetweenSteps = 0.2f;
    public AudioSource footsteps;
    public AudioClip[] footstepClips;
    public AudioClip[] gunSounds;
    public AudioClip[] hurtSounds;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip knockback;
    public AudioClip shieldUp;
    public AudioClip shieldHum;
    public AudioClip invisIn;
    public AudioClip invisOut;
    public AudioClip dead;

    [Header("Daze Settings")]
    public float dazedFor = 0f;
    public float hitDazeDuration = 1f;
    public float knockBackStrength = 1;

    private float moveInfluence = 1;

    public Player(float health = 100, float maxHealth = 100, int money = 0, List<ActiveItem> activeItems = null, List<PassiveItem> passiveItems = null, float speed = 10, float jumpSpeed = 40, float attack = 10, float defense = 10, float damageMultiplier = 1f, float healMultiplier = 1f)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.money = money;
        this.speed = speed;
        this.jumpSpeed = jumpSpeed;
        this.attack = attack;
        this.defense = defense;
        this.damageMultiplier = damageMultiplier;
        this.healMultiplier = healMultiplier;

        if (activeItems != null)
        {
            this.activeItems = activeItems;
        }
        else
        {
            this.activeItems = new List<ActiveItem>();
        }

        if (passiveItems != null)
        {
            this.passiveItems = passiveItems;
        }
        else
        {
            this.passiveItems = new List<PassiveItem>();
        }
    }

    public void TakeDamage(float damage)
    {

        float oldHealth = this.health / this.maxHealth;
        

        if (this.rand.NextDouble() > this.blockChance)
        {
            this.health -= damage * defense;
            dazedFor = hitDazeDuration;
            rb.velocity = Vector2.up * knockBackStrength + Vector2.right * knockBackStrength * (Random.value < 0.5f ? -1 : 1);
        }
        else
        {
        }

        if (this.health <= 0)
        {
            an.SetBool("ded", true);
            this.footsteps.PlayOneShot(this.dead, 1f);
        }

        float newHealth = this.health / this.maxHealth;

        if (oldHealth >= 0.75f && newHealth < 0.75f)
        {
            this.footsteps.PlayOneShot(this.hurtSounds[Random.Range(0, 5)], 0.25f);
        }

        if (oldHealth >= 0.35f && newHealth < 0.35f)
        {
            this.footsteps.PlayOneShot(this.hurtSounds[Random.Range(0, 5)], 0.5f);
        }

        if (oldHealth >= 0.1f && newHealth < 0.1f)
        {
            this.footsteps.PlayOneShot(this.hurtSounds[Random.Range(0, 5)], 1f);
        }

        hChange?.Invoke(this.health / this.maxHealth);
    }

    public void Heal(float healing)
    {
        this.health += healing;

        if (this.health > this.maxHealth)
        {
            this.health = this.maxHealth;
        }

        hChange?.Invoke(this.health / this.maxHealth);
    }

    public void Die()
    {
        //an.SetBool("ded", true); 
        an.SetBool("ded", false);
        rb.velocity = new Vector2(0, 0);
        Destroy(gameObject);
        Destroy(GameTimer._instance.gameObject);
        SceneManager.LoadScene(3);
    }

    public void AddMoney(int amt)
    {
        this.money += amt;
        mChange(this.money);
    }

    public void Pay(int amt)
    {
        this.money -= amt;
        mChange(this.money);
    }

    public void Shoot(Vector2 direction)
    {
        if (this.activeItems.Count >= 1)
        {
            direction = Vector3.Slerp(Random.onUnitSphere, direction, this.activeItems[0].accuracy);

            muzzleFlash.transform.right = direction;
            muzzleFlash.Replay();

            float crit = (float)this.rand.NextDouble();
            if (crit < this.critChance)
            {
                var instance = Instantiate(critProjectile, (firePos.position + (Vector3)direction), Quaternion.identity);
                instance.GetComponent<Rigidbody2D>().velocity = direction * this.activeItems[0].projectileSpeed;
                instance.GetComponent<PlayerBullet>().damage = (int)(this.activeItems[0].damage * damageMultiplier * 3);
                instance.GetComponent<PlayerBullet>().effect = this.activeItems[0].effect;
            }
            else
            {
                var instance = Instantiate(projectile, (firePos.position + (Vector3)direction), Quaternion.identity);
                instance.GetComponent<Rigidbody2D>().velocity = direction * this.activeItems[0].projectileSpeed;
                instance.GetComponent<PlayerBullet>().damage = (int)(this.activeItems[0].damage * damageMultiplier);
                instance.GetComponent<PlayerBullet>().effect = this.activeItems[0].effect;
            }
        }
    }

    public static Player playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (playerInstance == null)
        {
            playerInstance = this;
            GameTimer.playerObject = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        this.health = 100;
        this.maxHealth = 100;
        this.money = 0;
        this.speed = 10f;
        this.jumpSpeed = 40f;
        this.attack = 10f;
        this.defense = 1f;
        this.damageMultiplier = 1f;
        this.healMultiplier = 1f;
        this.activeItems = new List<ActiveItem>();
        this.passiveItems = new List<PassiveItem>();
        this.secondaryItem = null;
        this.rb = GetComponent<Rigidbody2D>();
        this.an = GetComponent<Animator>();
        this.sprite = GetComponent<SpriteRenderer>();
        this.rb.gravityScale = 9;
        this.activeItems.Add(new BaseGun());
        gameObject.tag = "Player";
        this.rand = new System.Random();
        this.critChance = 0.0f;
        this.blockChance = 0f;
        this.canShoot = true;
        this.moveInfluence = 1;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        dazedFor -= Time.deltaTime;
        if (this.health <= 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (dazedFor > 0)
        {
            int dazeFlash = (int)(dazedFor * 100);
            sprite.enabled = (dazeFlash % 2 == 0);
            gameObject.layer = 18;
            moveInfluence = 0.25f;
        }
        else
        {
            sprite.enabled = true;
            gameObject.layer = 14;
            moveInfluence = 1;
        }


        autofireDelay += Time.deltaTime;
        float desiredVelocityX = Input.GetAxisRaw("Horizontal") * this.speed;
        float deltaVel = desiredVelocityX - rb.velocity.x;
        Vector2 oldVel = rb.velocity;
        oldVel.x += Mathf.Lerp(0,deltaVel, moveInfluence);
        rb.velocity = oldVel;

        if (rb.velocity.x != 0 && this.isGrounded)
        {
            if (delay >= timeBetweenSteps)
            {
                this.footsteps.PlayOneShot(this.footstepClips[Random.Range(0, 6)], 0.5f*VolumeManager.sfxVal);
                delay = 0;
            }
            else
            {
                delay += Time.deltaTime;
            }

        }

        an.SetFloat("Dir", Mathf.Abs(rb.velocity.x));
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // apply healing
        Heal(healMultiplier * Time.deltaTime);

        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown("up")) && this.isGrounded && rb.velocity.y >= 0)
        {
            this.footsteps.PlayOneShot(this.jump, 1f * VolumeManager.sfxVal);
            rb.velocity = new Vector2(rb.velocity.x, this.jumpSpeed);
            isGrounded = false;
            an.SetBool("jumped", true);
            this.delay = this.timeBetweenSteps;
        }
        if (isGrounded)
        {
            an.SetBool("jumped", false);

        }

        if ((Input.GetMouseButton(0) && this.activeItems[0].autofire && this.autofireDelay >= 0.09 && canShoot) || (Input.GetMouseButtonDown(0) && canShoot))
        {
            this.autofireDelay = 0;
            this.footsteps.PlayOneShot(gunSounds[this.activeItems[0].id], 0.5f * VolumeManager.sfxVal);
            Shoot((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized);
        }

        if (this.secondaryItem != null)
        {
            if (this.secondaryItem.id == 1 && Input.GetMouseButtonDown(1) && this.secondaryItem.canUse)
            {
                this.footsteps.PlayOneShot(this.shieldUp, 1f);
                this.footsteps.PlayOneShot(this.shieldHum, 0.5f);
            }

            if (this.secondaryItem.id == 2 && Input.GetMouseButtonDown(1) && this.secondaryItem.canUse)
            {
                this.footsteps.PlayOneShot(this.invisIn, 1f * VolumeManager.sfxVal);
            }

            if (this.secondaryItem.id ==2)
            {
                Invisible i = (Invisible) this.secondaryItem;
                if (i.invisibleTimer >= i.invisibleDelay)
                {
                    this.footsteps.PlayOneShot(this.invisOut, 1f * VolumeManager.sfxVal);
                }
            }

            if (this.secondaryItem.id == 0 && Input.GetMouseButtonDown(1) && this.secondaryItem.canUse)
            {
                this.footsteps.PlayOneShot(this.dash, 0.5f * VolumeManager.sfxVal);
            }

            if (this.secondaryItem.id == 3 && Input.GetMouseButtonDown(1) && this.secondaryItem.canUse)
            {
                this.footsteps.PlayOneShot(this.knockback, 0.5f * VolumeManager.sfxVal);
            }

            this.secondaryItem.Effect(Input.GetMouseButtonDown(1));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PassiveItem")
        {

            PassiveItemSprite itemSprite = collision.gameObject.GetComponent<PassiveItemSprite>();
            PassiveItem item = itemSprite.PickUpItem();
            item.ApplyBonus(this);
            this.passiveItems.Add(item);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ActiveItem")
        {
            ActiveItemSprite item = collision.gameObject.GetComponent<ActiveItemSprite>();
            this.activeItems.Add(item.PickUpItem());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == 10) // if we're on ground layer
        {
            this.isGrounded = true;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        rb.velocity = new Vector2(0, 0);
        rb.position = new Vector3(15.91f, 2.15f, -8.793485f);
        this.health = 100;
    }
}
