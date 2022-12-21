using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class Viking : MonoBehaviour
{
    public bool right;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attack;
    Rigidbody2D rigidbody2D;
    Collider2D[] enemiesToDamage;

    [SerializeField] public bool Stay;
    [SerializeField] GameObject sound;
    private bool oneTime;

    public Transform attackPos;
    public Transform groundDetection;
    public LayerMask whatIsEnemies;
    public float movementSpeed;
    public int damage;
    public float attackRange;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        right = true;
        attack = startTimeBtwAttack;
    }

    // Update is called once per frame
    void Update()
    {


        if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().vikingAttackSpeed)
        {
            startTimeBtwAttack = attack;
        }
        else
        {
            startTimeBtwAttack = attack / 2 ;
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        RaycastHit2D groundInfo2;
        RaycastHit2D groundInfo3;
        RaycastHit2D groundInfo4 = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, LayerMask.GetMask("Trap"));
        if (right)
        {
           groundInfo2  = Physics2D.Raycast(groundDetection.position, Vector2.left, 0.3f, LayerMask.GetMask("Ground"));
            groundInfo3 = Physics2D.Raycast(groundDetection.position, Vector2.left, 0.3f, LayerMask.GetMask("Trap"));
        }
        else
        {
            groundInfo2 = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.3f, LayerMask.GetMask("Ground"));
            groundInfo3 = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.3f, LayerMask.GetMask("Trap"));
        }
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        if (enemiesToDamage.Length > 0)
        {
            if (enemiesToDamage[0])
            {
                lookPlayer();
            }
            Stay = true;
        }
        if(enemiesToDamage.Length == 0)
        {
            Stay = false;
            m_Animator.SetBool("Stay", false);
            if (groundInfo == false || groundInfo2 == true || groundInfo3 == true || groundInfo4 == true)
            {
                if (right)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                    right = false;
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);

                    right = true;
                }
            }
        }
              
   
        if(!Stay)
        {
            m_Animator.SetBool("Stay", false);
            if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().vikingSpeed)
            {
                if (right)
                {
                    rigidbody2D.velocity = new Vector2(-movementSpeed / 2, 0f);

                }
                else
                {
                    rigidbody2D.velocity = new Vector2(movementSpeed / 2, 0f);

                }
            }
            else
            {
                if (right)
                {
                    rigidbody2D.velocity = new Vector2(-movementSpeed, 0f);

                }
                else
                {
                    rigidbody2D.velocity = new Vector2(movementSpeed, 0f);

                }
            }
        }
        else
        {
            m_Animator.SetBool("Stay", true);
        }
        
        if (timeBtwAttack >= 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        Attack();
    }
    public void lookPlayer()
    {
        if (gameObject.transform.position.x > FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            right = true;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            right = false;
        }

    }
    public void Attack()
    {

        if (timeBtwAttack <= 0)
        {
             enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            if(enemiesToDamage.Length > 0)
            {
                if (enemiesToDamage[0] )
                {
                    lookPlayer();
                    timeBtwAttack = startTimeBtwAttack;
                    m_Animator.SetTrigger("isAttacking");
                }
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void Damage()
    {
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        if (enemiesToDamage.Length > 0)
        {
            if (enemiesToDamage[0])
            {
                if (transform.position.x > FindObjectOfType<Player>().transform.position.x)
                {
                    FindObjectOfType<Player>().GetComponent<Player>().rightDamage = true;
                }
                else
                {
                    FindObjectOfType<Player>().GetComponent<Player>().rightDamage = false;
                }
                FindObjectOfType<Player>().GetComponent<Player>().TakeDamage(damage);             
            }
        }
    }
    public void setSpeed(float speed)
    {
        movementSpeed = speed;
    }
    public void startSound()
    {
        Instantiate(sound, transform.position, transform.rotation);
    }
    
}
