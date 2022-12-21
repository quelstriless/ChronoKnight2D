using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public bool isAttack;
    [SerializeField] GameObject sound;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 8;
        isAttack = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void isAttackTrue()
    {
        isAttack = true;
        if(Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x ) <= 12f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.y - transform.position.y) <= 7f)
        Instantiate(sound, transform.position, transform.rotation);

    }
    public void isAttackFalse()
    {
        isAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (isAttack)
            {
                FindObjectOfType<Player>().GetComponent<Player>().TakeDamage(damage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (isAttack)
            {
                FindObjectOfType<Player>().GetComponent<Player>().TakeDamage(damage);
            }
        }
    }
    
}
