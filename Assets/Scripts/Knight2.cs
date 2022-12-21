using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class Knight2 : BaseBehaviour
{
    public bool right;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    [SerializeField] GameObject sound;
    Rigidbody2D rigidbody2D;
    Collider2D[] enemiesToDamage;

    public Transform attackPos;

    public LayerMask whatIsEnemies;
    public float movementSpeed;
    public int damage;
    public float attackRange;
    private bool startDecrease;
    Animator m_Animator;
    private float timeForStop;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        right = true;
        timeForStop = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().knightAttackSpeed)
        {
            startTimeBtwAttack = 4;
        }
        else
        {
            startTimeBtwAttack = 2;
        }
        // lookPlayer();

        if (timeBtwAttack >= 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        else
        {
            lookPlayer();
        }
        if(timeForStop > 0 & startDecrease)
        {
            timeForStop -= Time.deltaTime;
        }
        if(timeForStop <= 0 & startDecrease)
        {
            rigidbody2D.velocity = new Vector2(0,0);
            startDecrease = false;
        }
        Attack();

    }
    public void lookPlayer()
    {
        if (gameObject.transform.position.x > FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

            right = true;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            right = false;
        }

    }
    public void makeSound()
    {
        Instantiate(sound, transform.position, transform.rotation);
    }
    public void Attack()
    {

        if (timeBtwAttack <= 0)
        {
            /*
            enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            if (enemiesToDamage.Length > 0)
            {
                if (enemiesToDamage[0])
                {
                    lookPlayer();
                    timeBtwAttack = startTimeBtwAttack;
                
                    m_Animator.SetTrigger("isAttacking");
                }
            }
            */

            if (Mathf.Abs(gameObject.transform.position.x - FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x) < 7f
             && Mathf.Abs(gameObject.transform.position.y - FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.y) < 2.3f)
            {
                lookPlayer();
                timeBtwAttack = startTimeBtwAttack;

                m_Animator.SetTrigger("isAttacking");
            }

        }

    }
    void jump()
    {
        timeForStop = 0.25f;
        startDecrease = true;
        if (right)
        {
            if (time.timeScale > 0) // Move only when time is going forward
            {
                time.rigidbody2D.AddForce(new Vector2(-325f, 0f), ForceMode2D.Impulse);
            }
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(-30f, 0f), ForceMode2D.Impulse);
        }
        else
        {
            if (time.timeScale > 0) // Move only when time is going forward
            {
                time.rigidbody2D.AddForce(new Vector2(325f, 0f), ForceMode2D.Impulse);
            }
            // GetComponent<Rigidbody2D>().AddForce(new Vector2(30f, 0f), ForceMode2D.Impulse);
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
}
