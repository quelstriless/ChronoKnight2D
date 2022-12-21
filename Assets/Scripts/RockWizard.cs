using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWizard : MonoBehaviour
{
    [SerializeField] public GameObject rock, gun;
    public bool right;
    private GameObject currentRock;
    private int name1 = 1;
    private bool created;
    Animator m_Animator;
    void Start()
    {
        created = false;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        lookPlayer();
        if(created)
        {
            if(currentRock != null)
            {
                if (!currentRock.GetComponent<Rock>().go)
                {
                    m_Animator.SetTrigger("isFall");
                    created = false;
                }
                if (currentRock.GetComponent<Rock>().go)
                {
                    m_Animator.SetBool("isAir", false);
                }
            }
            else
            {
                m_Animator.SetBool("isAir", true);
            }
        }
    }
    public void Fire()
    {
        if (Mathf.Abs(transform.position.x - FindObjectOfType<Player>().GetComponent<Transform>().position.x) < 13f && transform.position.y - FindObjectOfType<Player>().GetComponent<Transform>().position.y > -2.2f)
        {

            var myNewSmoke = Instantiate(rock, gun.transform.position, transform.rotation);

           // myNewSmoke.transform.parent = gameObject.transform;
            currentRock = myNewSmoke.gameObject;


            created = true;
            m_Animator.SetTrigger("next");
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

}
