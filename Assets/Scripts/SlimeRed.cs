using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeRed : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public int health = 20;
    [SerializeField] GameObject takeDamage;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (isFacingRight())
            {
                rigidbody2D.velocity = new Vector2(1f, 0f);
            }

            else
            {
                rigidbody2D.velocity = new Vector2(-1f, 0f);
            }
    }
    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Instantiate(takeDamage, new Vector3(transform.position.x + 1.60f, transform.position.y - 1.70f), transform.rotation); ;
        Debug.Log("Damage Taken");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), 1f);
    }

}
