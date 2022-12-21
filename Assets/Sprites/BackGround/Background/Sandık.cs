using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandık : MonoBehaviour
{
    [SerializeField] GameObject takenDamageVFX;
    [SerializeField] GameObject gold;
    [SerializeField] Transform pos;
    [SerializeField] int up, down;
    private bool OneTime;
    private Animator animator;
    void Start()
    {
        OneTime = true;
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void Destroy(Vector2 strike)
    {
        if(OneTime)
        {
            int number;
            number = Random.Range(down, up);
            Instantiate(takenDamageVFX, new Vector2(strike.x, strike.y + 0.3f), transform.rotation);
            animator.SetTrigger("Attacked");
            for (int i = 0; i < number; i++)
            {
                Instantiate(gold, pos.position, transform.rotation);
            }
            OneTime = false;
        }

    }
}
