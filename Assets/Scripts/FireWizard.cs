using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizard : MonoBehaviour
{
    [SerializeField] GameObject fireBall, gun, fireSound;
    public bool right;
    void Start()
    {

    }

    void Update()
    {
        lookPlayer();
    }
    public void Fire()
    {
        if (gameObject.transform.position.x > FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x)
        {
            fireBall.GetComponent<Fireball>().right = true;
        }
        else
        {
            fireBall.GetComponent<Fireball>().right = false;
        }

        if( Mathf.Abs(FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x - gameObject.transform.position.x) < 16f  && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.y - gameObject.transform.position.y) < 6f)
            Instantiate(fireBall, gun.transform.position, transform.rotation);

    }
    public void lookPlayer()
    {
        if(gameObject.transform.position.x > FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x)
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
    public void sound()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.x - gameObject.transform.position.x) < 16f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Player>().gameObject.transform.position.y - gameObject.transform.position.y) < 6f)
            Instantiate(fireSound, transform.position, transform.rotation);
    }

}
