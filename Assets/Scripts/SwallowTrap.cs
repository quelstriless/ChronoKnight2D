using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwallowTrap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x > collision.gameObject.transform.position.x)
        {
            collision.gameObject.GetComponent<Player>().rightDamage = true;
        }
        else
        {
            collision.gameObject.GetComponent<Player>().rightDamage = false;
        }
        collision.gameObject.GetComponent<Player>().TakeDamage(10);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (transform.position.x > collision.gameObject.transform.position.x)
        {
            collision.gameObject.GetComponent<Player>().rightDamage = true;
        }
        else
        {
            collision.gameObject.GetComponent<Player>().rightDamage = false;
        }
        collision.gameObject.GetComponent<Player>().TakeDamage(10);

    }
}
