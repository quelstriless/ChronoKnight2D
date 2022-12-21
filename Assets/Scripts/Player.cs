using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] public float runSpeed = 4f;
    GameObject hpUI;
    public ParticleSystem dust;
    [SerializeField] GameObject DeathUI;
    public float dashForce;
    public float StartDashTimer;
    float currentDashTimer;
    public bool isDashing;
    public bool Dashtrue;
    private bool dashSoundT;
    public int firstHealth;
    public int firstDamage;

    public int health;
    public float FullHP;
    [SerializeField] GameObject damagePopup;
    [SerializeField] GameObject hitSound, runSound, attackSound, attackSound2, dashSound, jumpSound, groundHitSound, hurtSound, reviveSound;

    public float WaitForDamage;
    private bool WaitDamage;
    public bool rightDamage;
    public bool goRight;
    public bool goLeft;

    private float dashTimer;
    private bool isAttacking;
    private float spikeTimer;
    public bool scenario;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public bool attack;
    public bool right;
    public int jumpCount;
    private float damageCD;
    public float startdamageCD;
    public bool isJumpUp;
    public bool isJumpDown;
    Animator m_Animator;
    public Rigidbody2D myRigidBody;
    Collider2D myCollider2D;
    AudioSource slash;
    void Start()
    {
  
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().Set();

        health = FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.health;
        damage = FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage;


        dashTimer = 0;
        FullHP = health;
        slash = GetComponent<AudioSource>();
        goLeft = false;
        goRight = false;
        Dashtrue = false;
        right = true;
        rightDamage = false;
        WaitDamage = false;
        jumpCount = 1;
        spikeTimer = 0.1f;

        damage = FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage;
        m_Animator = gameObject.GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.freezeRotation = true;

        if(dashTimer >= 0)
        {
            dashTimer -= Time.deltaTime;
        }
        if(WaitForDamage >= 0)
        {
            WaitForDamage -= Time.deltaTime;
        }
        if(WaitDamage && WaitForDamage <= 0)
        {
            Tween colorTween = this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(new Color(0.4f,0.4f,0.4f,1), 0.2f);
            colorTween.OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f)
            .OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(new Color(0.4f, 0.4f, 0.4f, 1), 0.2f)
            .OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f)
            .OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(new Color(0.4f, 0.4f, 0.4f, 1), 0.2f)
            .OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f)
            .OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(new Color(0.4f, 0.4f, 0.4f, 1), 0.2f)
            .OnStepComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f))))))));

            WaitDamage = false;
        }
        if (timeBtwAttack >= 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if(damageCD >= 0)
        {
            damageCD -= Time.deltaTime;
        }

        Dash();
        if(!isDashing)
        {
            Run();
            Jump();
        }

        if(Mathf.Abs(myRigidBody.velocity.y)< 0.1f)
        {
            isJumpUp = false;
            isJumpDown = false;
        }
        else if(myRigidBody.velocity.y > 0.1f)
        {
            isJumpUp = true;
            isJumpDown = false;
        }
        else if (myRigidBody.velocity.y < -0.1f)
        {
            isJumpDown = true;
            isJumpUp = false;
        }        
    }
    public void DontAllowMovement()
    {
        goLeft = false;
        goRight = false;
    }
    public void Right()
    {
        goRight = true;
        goLeft = false;
    }
    public void Left()
    {
        goLeft = true;
        goRight = false;
    }
    private void Run()
    {
        m_Animator.SetBool("Running", false);

        if (Input.GetKey(KeyCode.D) ||goRight)
        {

            m_Animator.SetBool("Running", true);

            if (!isAttacking)
            {
                createDust();
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                right = true;
                transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            }
            else
            {
                if (!right)
                {
                    transform.Translate(Vector2.left * runSpeed * Time.deltaTime);

                }
                else
                {
                    transform.Translate(Vector2.right * runSpeed * Time.deltaTime);

                }

            }

        }
         else if (Input.GetKey(KeyCode.A) || goLeft)
        {

            m_Animator.SetBool("Running", true);

            if (!isAttacking)
            {
                createDust();
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                right = false;
                transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            }
            else
            {
                if (right)
                {
                    transform.Translate(Vector2.left * runSpeed * Time.deltaTime);

                }
                else
                {
                    transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
                }

            }

        }
        else
        {
            slash.Stop();
        }

    }
    private void Jump()
    {

        m_Animator.SetBool("Jump", false);
        if(myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) && myRigidBody.velocity.y < 0.1)
        {
            jumpCount = 2;
        }
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")) && myRigidBody.velocity.y < 0.1)
        {
            jumpCount = 2;
        }
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) && !myCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")) && !myCollider2D.IsTouchingLayers(LayerMask.GetMask("Kirilabilirler")))
        {
            m_Animator.SetBool("Jump", true);
        }
        if ( Input.GetKey(KeyCode.W) && jumpCount > 0)
        {
            m_Animator.SetBool("Jump", true);
            Vector2 jumpVelocityAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity = jumpVelocityAdd;
            jumpCount--;
        }
    }
    public void makeJump()
    {
        if(jumpCount > 0)
        {
            createDust();
            Instantiate(jumpSound, transform.position, transform.rotation);
            m_Animator.SetBool("Jump", true);
            Vector2 jumpVelocityAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity = jumpVelocityAdd;
            jumpCount--;
        }
    }
    public void makeAttackTrue()
    {
        attack = true;
    }
    public void makeAttackFalse()
    {
        attack = false;
    }

    public void Dash()
    {
        if(isDashing)
        {
            dashTimer = 0.55f;
            if(!dashSoundT)
            {
                var rofl = Instantiate(dashSound, transform.position, transform.rotation);

                dashSoundT = true;
            }

            myRigidBody.velocity = transform.right * dashForce;
            currentDashTimer -= Time.deltaTime;
            if(currentDashTimer <= 0)          
            {
                Dashtrue = false;
                isDashing = false;
                myRigidBody.velocity = Vector2.zero;
                myRigidBody.gravityScale = 4.1f;
                dashSoundT = false;
            }
        }
    }
    public void makeDashTrue()
    {
        if (!isAttacking && dashTimer <= 0)
        {
            isDashing = true;
            currentDashTimer = StartDashTimer;
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.gravityScale = 0;
            m_Animator.SetTrigger("isDashing");
        }

    }
    public void Attack()
    {

        if (timeBtwAttack <= 0 && !isDashing)
        {
            timeBtwAttack = startTimeBtwAttack;
            m_Animator.SetTrigger("isAttacking");

            RaycastHit2D[] raycastHits = Physics2D.CircleCastAll(attackPos.position, attackRange, new Vector2(1,0), 0, whatIsEnemies);

            float number3 = Random.Range(0, 4);

            
            if (raycastHits.Length == 0)
            {
                if(number3 <= 2)
                    Instantiate(attackSound, transform.position, transform.rotation);
                else if( number3 <= 4)
                    Instantiate(attackSound2, transform.position, transform.rotation);

            }
            else
            {
                for(int i = 0; i < raycastHits.Length; i++)
                {
                    if (raycastHits[i].collider.gameObject.tag == "Box")
                    {
                      
                    }
                    else
                    {
                        Instantiate(hitSound, transform.position, transform.rotation);
                    }
                }
               

 
            }

            for (int i = 0; i < raycastHits.Length; i++)
            { 
                Vector2 pointHitten = raycastHits[i].point;
                if (raycastHits[i].collider.gameObject.tag == "Box")
                {
                    raycastHits[i].collider.gameObject.GetComponent<Box>().Destroy(pointHitten);
                }
                else if (raycastHits[i].collider.gameObject.tag == "Chest")
                {
                    raycastHits[i].collider.gameObject.GetComponent<Sandık>().Destroy(pointHitten);
                }
                else if (raycastHits[i].collider.gameObject.tag == "Magics")
                {
                    if(raycastHits[i].collider.gameObject.GetComponent<Fireball>())
                    {
                        raycastHits[i].collider.gameObject.GetComponent<Fireball>().playerAttack();
                    }
                    else if(raycastHits[i].collider.gameObject.GetComponent<Waterball>())
                    {
                        raycastHits[i].collider.gameObject.GetComponent<Waterball>().playerAttack();
                    }
                    else if (raycastHits[i].collider.gameObject.GetComponent<Rock>())
                    {
                        raycastHits[i].collider.gameObject.GetComponent<Rock>().playerAttack();
                    }
                    
                }
                else if(raycastHits[i].collider.gameObject.GetComponent<Enemy>())
                {
                    raycastHits[i].collider.gameObject.GetComponent<Enemy>().TakeDamage(damage, pointHitten);
                }
                else if (raycastHits[i].collider.gameObject.GetComponent<Cage>())
                {
                    raycastHits[i].collider.gameObject.GetComponent<Cage>().TakeDamage(pointHitten);
                }
                CinemachineShake.Instance.ShakeCamera(4f, .07f);

            }

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void freeze()
    {
        isAttacking = true;
    }
    void unFreeze()
    {
        isAttacking = false;
    }
    public void TakeDamage(int damage)
    {


        if (damageCD <= 0)
        {
            damageCD = startdamageCD;

            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin2)
            {
                damage -= 1;
            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin3)
            {
                damage -= 1;

            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin4)
            {
                damage -= 2;

            }
            else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin5)
            {
                damage -= 3;
            }
            if(damage <= 0)
            {
                damage = 1;
            }
            Instantiate(hurtSound, transform.position, transform.rotation);
            health -= damage;
            if (health <= 0)
            {
                hpUI = GameObject.Find("Player HP");
                hpUI.SetActive(false);
                DeathUI.SetActive(true);
                Time.timeScale = 0f;
            }
            if (health > 0)
            {
                StartCoroutine(DamageTaken(damage));
            }
        }

    }
    ///////
    IEnumerator DamageTaken(int damage)
    {
        myRigidBody.velocity = Vector2.zero;
        if (rightDamage)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-8f, 7f), ForceMode2D.Impulse);
        }
       else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(8f, 7f), ForceMode2D.Impulse);
        }
        CinemachineShake.Instance.ShakeCamera(5f, .08f);
       Tween colorTween = this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.01f);
       colorTween.OnComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.1f));
        damagePopup.GetComponent<DamagePopup>().Create(damage, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.2f));

        Time.timeScale = 0.03f;
        yield return new WaitForSeconds(0.009f);
        Time.timeScale = 1f;

        WaitDamage = true;
        WaitForDamage = 0.1f;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            if (spikeTimer >= 0 )
            {
                spikeTimer -= Time.deltaTime;
            }
            if (spikeTimer < 0)
            { 
                spikeTimer = 0.1f;
                TakeDamage(4);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            TakeDamage(6);
        }
        if(collision.gameObject.tag =="ground" )
        {
           Instantiate(groundHitSound, transform.position, transform.rotation);
        }
    }
    public void Revive()
    {
        if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 200)
        {
            Instantiate(reviveSound, transform.position, transform.rotation);
            hpUI.SetActive(true);
            DeathUI.SetActive(false);
            Time.timeScale = 1f;
            health = (int)(FullHP / 2);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 200;
        }
      
    }
    public void Restart()
    {
        FindObjectOfType<FakeSave>().money = FindObjectOfType<FakeSave>().firstMoney;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void createDust()
    {
        if(dust != null)
        dust.Play();
    }
}
