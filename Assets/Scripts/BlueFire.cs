using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFire : MonoBehaviour
{
    public float timeBtwAttack = 2;
    public int damage = 6;
    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
        if (timeBtwAttack <= 0)
        {
            Destroy(gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.GetComponent<Player>())
        {
            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                collision.gameObject.GetComponent<Player>().rightDamage = true;
            }
            else
            {
                collision.gameObject.GetComponent<Player>().rightDamage = false;
            }
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
