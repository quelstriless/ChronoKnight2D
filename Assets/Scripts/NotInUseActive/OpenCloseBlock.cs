using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseBlock : MonoBehaviour
{
    Animator m_animator;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_animator.SetBool("isOpen", true);
    }
    public void collide()
    {
        collider.isTrigger = true;
    }
}
