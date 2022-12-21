using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayer : MonoBehaviour
{
    [SerializeField] float runSpeed = 2f;
    [SerializeField] GameObject magic;
    private float timeMagic;
    private bool start;
    public bool goRight;
    public bool goLeft;
    public bool right;
    public Rigidbody2D myRigidBody;
    Animator m_Animator;
    void Start()
    {
        start = false;
        timeMagic = -0.1f;
        goLeft = false;
        goRight = false;
        right = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        FindObjectOfType<Portalling>().GetComponent<Portalling>().make = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeMagic >= 0)
        {
            timeMagic -= Time.deltaTime;
        }
        if(timeMagic <= 0 && start) 
        {

            var buyu = Instantiate(magic, transform.position, transform.rotation);
            buyu.GetComponent<MagicTime>().second = true;
            start = false;
        }
        myRigidBody.freezeRotation = true;
        Run();
    }
    public void DontAllowMovement()
    {
        goLeft = false;
        goRight = false;
    }
    public void Right()
    {
        goRight = true;
        goLeft = false;
    }
    public void Left()
    {
        goLeft = true;
        goRight = false;
    }

    private void Run()
    {
        m_Animator.SetBool("Running", false);

        if (Input.GetKey(KeyCode.D) || goRight)
        {
            m_Animator.SetBool("Running", true);

                transform.localRotation = Quaternion.Euler(0, 0, 0);
                right = true;
                transform.Translate(Vector2.right * runSpeed * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.A) || goLeft)
        {
            m_Animator.SetBool("Running", true);
  
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                right = false;
                transform.Translate(Vector2.right * runSpeed * Time.deltaTime);

        }

    }
    public void magicStart()
    {
        start = true;
        timeMagic = 3f;
    }
}
