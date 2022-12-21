using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBox : MonoBehaviour
{
    [SerializeField] GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fire()
    {
      Instantiate(fireBall, new Vector2(transform.position.x,transform.position.y + 0.69f), transform.rotation); 
        var fire2 = Instantiate(fireBall, new Vector2(transform.position.x, transform.position.y + 0.69f), transform.rotation);
        fire2.GetComponent<Fireball>().goLeft = true;
        fire2.GetComponent<SpriteRenderer>().flipX = true;
        Instantiate(fireBall, new Vector2(transform.position.x - 0.7f, transform.position.y ), Quaternion.Euler(0.0f, 0.0f, 90f));
        Instantiate(fireBall, new Vector2(transform.position.x + 0.63f, transform.position.y + 0.17f), Quaternion.Euler(0.0f, 0.0f, -90f));
 
    }
}
