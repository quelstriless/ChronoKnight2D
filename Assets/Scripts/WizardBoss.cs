using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoss : MonoBehaviour
{
    [SerializeField] GameObject fireBall, waterBall, gun, gun1, gun2;
    public bool right;

    void Update()
    {
        lookPlayer();
    }

    public void Fire()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().gameObject.GetComponent<Transform>().position.y - transform.position.y) < 10)
            Instantiate(fireBall, gun.transform.position, transform.rotation);
    
    }
    public void Fire2()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().gameObject.GetComponent<Transform>().position.y - transform.position.y) < 10)
            Instantiate(fireBall, gun1.transform.position, transform.rotation);
       
    }
    public void Fire3()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().gameObject.GetComponent<Transform>().position.y - transform.position.y) < 10)
            Instantiate(fireBall, gun2.transform.position, transform.rotation);
        
    }
    public void Water()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().gameObject.GetComponent<Transform>().position.y - transform.position.y) < 10)
            Instantiate(waterBall, new Vector2(transform.position.x - 6f,transform.position.y+2f), transform.rotation);
    }
    public void Water2()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().gameObject.GetComponent<Transform>().position.y - transform.position.y) < 10)
            Instantiate(waterBall, new Vector2(transform.position.x - 8f, transform.position.y+4f), transform.rotation);
    }
    public void Water3()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().gameObject.GetComponent<Transform>().position.y - transform.position.y) < 10)
            Instantiate(waterBall, new Vector2(transform.position.x - 10f, transform.position.y+6f), transform.rotation);
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
}
