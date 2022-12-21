using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public float speed;
    public bool right;
    public float timeBtwAttack = 0.8f;
    public int damage;
    public bool continue1;
    public bool isDestination;
    public Transform target;
    float X;
    float Y;
    private Transform cloud;
    void Start()
    {
        right = true;
        cloud = transform.Find("Cloud");
        isDestination = false;
        continue1 = true; 
        speed = 5.5f;
    }
    private void Update()
    {
        if(Mathf.Abs( FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x) < 12f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.y - transform.position.y) < 20f)
       {
        target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
        X = target.position.x;
        Y = target.position.y;
        timeBtwAttack -= Time.deltaTime;

        if((Mathf.Abs(transform.position.x - target.position.x ) < 0.15f && (transform.position.y - target.position.y ) < 4.3f) && !isDestination)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
            isDestination = true;
            continue1 = false;
            timeBtwAttack = 0.8f;
            cloud.GetComponent<Animator>().SetTrigger("isAttacking");
        }
        if (timeBtwAttack <= 0)
        {
            continue1 = true;
            isDestination = false;
        }
            if(continue1)
        {
            if (FindObjectOfType<Timekeeper>().GetComponent<TimeControl>().witchSpeed)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(X, Y + 3.9f), (speed / 2) * Time.deltaTime);
                cloud.GetComponent<Animator>().speed = 0.5f;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(X, Y + 3.9f), speed * Time.deltaTime);
                cloud.GetComponent<Animator>().speed = 1;
            }
            lookPlayer();
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
       }
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
            right = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }
    public void l00k()
    {

        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ - 180));
    }
}
