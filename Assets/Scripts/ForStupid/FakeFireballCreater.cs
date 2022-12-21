using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFireballCreater : MonoBehaviour
{
    [SerializeField] GameObject fireball;
    [SerializeField] bool right;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    { 
        if(timer > 0)
        timer -= Time.deltaTime;
       
        if(timer<= 0)
        {


            var name = Instantiate(fireball, transform.position, transform.rotation);

            name.gameObject.GetComponent<Fireball>().fakeFireball = true;
            if (right)
            {
                name.gameObject.GetComponent<Fireball>().goLeft = true;
                name.gameObject.GetComponent<SpriteRenderer>().flipX = true;

            }
            float number = Random.Range(8, 20);
            timer = number;

        }
    }
}
