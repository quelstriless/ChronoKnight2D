using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWaterWizard : MonoBehaviour
{
    [SerializeField] GameObject fireBall, gun, gun2, sound;
    public bool right;
    public Transform player;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;

    }

    void Update()
    {
        lookPlayer();
    }
    public void Fire()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) < 14.2f && Mathf.Abs(transform.position.y - player.position.y) < 6f)
        {
            if (right)
            {
                Instantiate(fireBall, gun.transform.position, transform.rotation);

            }
            else
            {
                Instantiate(fireBall, gun2.transform.position, transform.rotation);
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
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            right = false;

        }

    }
    public void waterSound()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) < 14.2f && Mathf.Abs(transform.position.y - player.position.y) < 6f)
            Instantiate(sound, gun.transform.position, transform.rotation);
    }
}
