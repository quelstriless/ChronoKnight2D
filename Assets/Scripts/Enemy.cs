using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : BaseBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject takeDamage, deathSound;
    [SerializeField] public int health = 20;
    public float fullHP;
    public float firstMass;
    bool checkDash;
    bool staying;
    bool damage;
    private float number;
    float dashTimer;
    Rigidbody2D rb;
    [SerializeField] GameObject damagePopup;
    [SerializeField] GameObject takenDamageVFX;
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject gold;

    void Start()
    {
        damage = false;
        staying = false;
        number = 1.8f;
        checkDash = true;
        dashTimer = 0.1f;
        if(!gameObject.GetComponent<Witch>() && ! gameObject.GetComponent<WaterSpirit>())
        {
            rb = GetComponent<Rigidbody2D>();
            firstMass = rb.mass;
        }
        fullHP = health;

            if(gameObject.tag != "Boss")
        healthBar = transform.Find("HealthBar").gameObject;

    }
    // Update is called once per frame
    void Update()
    {
       /*
        if(gameObject.tag == "Boss" && !gameObject.GetComponent<WaterSpirit>())
        {
            healthBar.GetComponent<HealthBar>().SetSize(health / fullHP);
            healthBar.SetActive(true);
        }
       */
        dashTimer -= Time.deltaTime;
        if( !gameObject.GetComponent<Witch>() && !gameObject.GetComponent<WaterSpirit>())
        {
            if (rb.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                if (FindObjectOfType<Player>().GetComponent<Player>().isDashing)
                {
                    dashTimer = 0.15f;
                    rb.mass = 200;
                    checkDash = true;
                }
            }
            if (dashTimer <= 0 && checkDash)
            {
                rb.mass = firstMass;
                checkDash = false;
            }
        }
        if(staying)
        {
            number -= Time.deltaTime;
        }
        if(number <= 0)
        {
            damage = true;
            staying = false;
            number = 1.8f;
        }
    }

    public void TakeDamage(int damage, Vector2 strike)
    {
        Instantiate(takenDamageVFX, new Vector2(strike.x, strike.y + 0.3f), transform.rotation);
        Tween colorTween;
        health -= damage;
        int goldNumber;
        goldNumber = Random.Range(1, 3);
        if (health <= 0)
        {

            Instantiate(deathSound, transform.position, transform.rotation);

            if (gameObject.GetComponent<BossLevel>())
            {
                ///
                gameObject.GetComponent<BossLevel>().load();
            }
            if(gameObject.GetComponent<WaterSpirit>())
            {
               // goldNumber = Random.Range(20, 25);
                gameObject.GetComponent<WaterSpirit>().world3();
                FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.ponceDeLeon = true;
                FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
            }
            if (gameObject.GetComponent<Knight>())
            {
                goldNumber = Random.Range(2, 4);
                if (gameObject.GetComponent<Knight>().right)
                {

                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<Knight2>())
            {
                goldNumber = Random.Range(4, 6);
                if (gameObject.GetComponent<Knight2>().right)
                {

                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {

                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<Viking>())
            {
                goldNumber = Random.Range(1, 2);
                if (gameObject.GetComponent<Viking>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<FireWizard>())
            {
                goldNumber = Random.Range(1, 3);
                if (gameObject.GetComponent<FireWizard>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<DarkFireWizard>())
            {
                goldNumber = Random.Range(3, 5);
                if (gameObject.GetComponent<DarkFireWizard>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<WaterWizard>())
            {
                goldNumber = Random.Range(2, 3);
                if (gameObject.GetComponent<WaterWizard>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<DarkWaterWizard>())
            {
                goldNumber = Random.Range(4, 6);
                if (gameObject.GetComponent<DarkWaterWizard>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<RockWizard>())
            {
                goldNumber = Random.Range(1, 2);
                if (gameObject.GetComponent<RockWizard>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
           else if (gameObject.GetComponent<Witch>())
            {
                goldNumber = Random.Range(4, 6);
                if (gameObject.GetComponent<Witch>().right)
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                }
                else
                {
                    Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                }
            }
            for (int i = 0; i < goldNumber; i++)
            {
                Instantiate(gold, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
        else
        {
             colorTween = this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.3f);
            colorTween.OnComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f));
            damagePopup.GetComponent<DamagePopup>().Create(damage, new Vector2(transform.position.x,transform.position.y + 0.2f));
            if (gameObject.tag != "Boss")
            {
                healthBar.GetComponent<HealthBar>().SetSize(health / fullHP);
                healthBar.SetActive(true);
            }
        }

        if (GetComponent<FireWizard>() && !GetComponent<FireWizard>().right)
        {

            Instantiate(takeDamage, new Vector3(transform.position.x + -2.20f, transform.position.y - 1.70f), transform.rotation);
            time.rigidbody2D.AddForce(new Vector2(-110f, 110f), ForceMode2D.Impulse);
        }
        else if (GetComponent<FireWizard>() && GetComponent<FireWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(110f, 110f), ForceMode2D.Impulse);
        }
        else if (GetComponent<DarkFireWizard>() && !GetComponent<DarkFireWizard>().right)
        {

            Instantiate(takeDamage, new Vector3(transform.position.x + -2.20f, transform.position.y - 1.70f), transform.rotation);
            time.rigidbody2D.AddForce(new Vector2(-110f, 110f), ForceMode2D.Impulse);
        }
        else if (GetComponent<DarkFireWizard>() && GetComponent<DarkFireWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(110f, 110f), ForceMode2D.Impulse);
        }
        else if (GetComponent<Viking>() && !GetComponent<Viking>().right)
        {
            Instantiate(takeDamage, new Vector3(transform.position.x + -2.20f, transform.position.y - 1.70f), transform.rotation);
        }
        else if(GetComponent<Viking>())
        {
            Instantiate(takeDamage, new Vector3(transform.position.x + 2.1f, transform.position.y - 1.70f), transform.rotation);

        }
        else if(GetComponent<WaterWizard>() && !GetComponent<WaterWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(-110f, 110f), ForceMode2D.Impulse);
            Instantiate(takeDamage, new Vector3(transform.position.x + -2.20f, transform.position.y - 1.70f), transform.rotation);
        }
        else if (GetComponent<WaterWizard>() && GetComponent<WaterWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(110f, 110f), ForceMode2D.Impulse);
            Instantiate(takeDamage, new Vector3(transform.position.x + 1.80f, transform.position.y - 1.70f), transform.rotation);
        }
        else if (GetComponent<DarkWaterWizard>() && !GetComponent<DarkWaterWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(-110f, 110f), ForceMode2D.Impulse);
            Instantiate(takeDamage, new Vector3(transform.position.x + -2.20f, transform.position.y - 1.70f), transform.rotation);
        }
        else if (GetComponent<DarkWaterWizard>() && GetComponent<DarkWaterWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(110f, 110f), ForceMode2D.Impulse);
            Instantiate(takeDamage, new Vector3(transform.position.x + 1.80f, transform.position.y - 1.70f), transform.rotation);
        }
        else if (GetComponent<RockWizard>() && !GetComponent<RockWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(-110f, 110f), ForceMode2D.Impulse);
            Instantiate(takeDamage, new Vector3(transform.position.x + -2.20f, transform.position.y - 1.70f), transform.rotation);
        }
        else if (GetComponent<RockWizard>() && GetComponent<RockWizard>().right)
        {
            time.rigidbody2D.AddForce(new Vector2(110f, 110f), ForceMode2D.Impulse);
            Instantiate(takeDamage, new Vector3(transform.position.x + 1.80f, transform.position.y - 1.70f), transform.rotation);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tween colorTween;
        if (collision.tag == "spike")
        {
            int goldNumber;
            goldNumber = Random.Range(1, 3);
            health -= 6;
            if (health <= 0)
            {
                for (int i = 0; i < goldNumber; i++)
                {
                    Instantiate(gold, transform.position, transform.rotation);
                }
                if (gameObject.GetComponent<Knight>())
                {
                    if (gameObject.GetComponent<Knight>().right)
                    {

                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                    else
                    {

                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                }
                if (gameObject.GetComponent<Viking>())
                {
                    if (gameObject.GetComponent<Viking>().right)
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                    else
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                    }
                }
                if (gameObject.GetComponent<FireWizard>())
                {
                    if (gameObject.GetComponent<FireWizard>().right)
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                    else
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                    }
                }
                if (gameObject.GetComponent<WaterWizard>())
                {
                    if (gameObject.GetComponent<WaterWizard>().right)
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                    else
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                    }
                }
                if (gameObject.GetComponent<RockWizard>())
                {
                    if (gameObject.GetComponent<RockWizard>().right)
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                    else
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                    }
                }
                if (gameObject.GetComponent<Witch>())
                {
                    if (gameObject.GetComponent<Witch>().right)
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                    }
                    else
                    {
                        Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                    }
                }

                Destroy(gameObject);
            }
            else
            {
                colorTween = gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.3f);
                colorTween.OnComplete(() => gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f));
                damagePopup.GetComponent<DamagePopup>().Create(4, new Vector2(transform.position.x, transform.position.y + 0.2f));
                if (gameObject.tag != "Boss")
                {
                    healthBar.GetComponent<HealthBar>().SetSize(health / fullHP);
                    healthBar.SetActive(true);
                }
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Tween colorTween;
        if (collision.tag == "spike")
        {
            int goldNumber;
            goldNumber = Random.Range(1, 3);
            staying = true;
            if (damage)
            {
                damage = false;
                health -= 4;

                if (health <= 0)
                {
                    for (int i = 0; i < goldNumber; i++)
                    {
                        Instantiate(gold, transform.position, transform.rotation);
                    }
                    if (gameObject.GetComponent<Knight>())
                    {
                        if (gameObject.GetComponent<Knight>().right)
                        {

                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                        else
                        {

                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                    }
                    if (gameObject.GetComponent<Viking>())
                    {
                        if (gameObject.GetComponent<Viking>().right)
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                        else
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                        }
                    }
                    if (gameObject.GetComponent<FireWizard>())
                    {
                        if (gameObject.GetComponent<FireWizard>().right)
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                        else
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                        }
                    }
                    if (gameObject.GetComponent<WaterWizard>())
                    {
                        if (gameObject.GetComponent<WaterWizard>().right)
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                        else
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                        }
                    }
                    if (gameObject.GetComponent<RockWizard>())
                    {
                        if (gameObject.GetComponent<RockWizard>().right)
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                        else
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                        }
                    }
                    if (gameObject.GetComponent<Witch>())
                    {
                        if (gameObject.GetComponent<Witch>().right)
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x + 1.6f, transform.position.y), transform.rotation);
                        }
                        else
                        {
                            Instantiate(deathVFX, new Vector2(transform.position.x - 1.6f, transform.position.y), transform.rotation);
                        }
                    }

                    Destroy(gameObject);
                }
                else
                {
                    colorTween = gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.3f);
                    colorTween.OnComplete(() => gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.2f));
                    damagePopup.GetComponent<DamagePopup>().Create(4, new Vector2(transform.position.x, transform.position.y + 0.2f));
                    if (gameObject.tag != "Boss")
                    {
                        healthBar.GetComponent<HealthBar>().SetSize(health / fullHP);
                        healthBar.SetActive(true);
                    }
                }
            }
           
            
        }
    }
}
