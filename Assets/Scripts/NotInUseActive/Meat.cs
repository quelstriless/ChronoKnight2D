using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] GameObject meatPopup, sound;
    // Start is called before the first frame update
    void Start()
    {
        float number, number2;
        number = Random.Range(-6, 6);
        number2 = Random.Range(10, 12);
        rg = GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(number, number2), ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x) <= 0.66f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.y - transform.position.y) <= 1.4f)
        {
            if (FindObjectOfType<Player>().GetComponent<Player>().health <= FindObjectOfType<Player>().GetComponent<Player>().FullHP - 4) 
            {
                FindObjectOfType<Player>().GetComponent<Player>().health = FindObjectOfType<Player>().GetComponent<Player>().health + (int)4;
                
                meatPopup.GetComponent<GoldPopUp>().Create(new Vector3(FindObjectOfType<Player>().GetComponent<Transform>().position.x - 0.3f, FindObjectOfType<Player>().GetComponent<Transform>().position.y + 0.43f, FindObjectOfType<Player>().GetComponent<Transform>().position.z));
                Instantiate(sound, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if (FindObjectOfType<Player>().GetComponent<Player>().health > FindObjectOfType<Player>().GetComponent<Player>().FullHP - 4 && FindObjectOfType<Player>().GetComponent<Player>().health < FindObjectOfType<Player>().GetComponent<Player>().FullHP)
            {
                FindObjectOfType<Player>().GetComponent<Player>().health = (int)FindObjectOfType<Player>().GetComponent<Player>().FullHP;
                meatPopup.GetComponent<GoldPopUp>().Create(new Vector3(FindObjectOfType<Player>().GetComponent<Transform>().position.x - 0.3f, FindObjectOfType<Player>().GetComponent<Transform>().position.y + 0.43f, FindObjectOfType<Player>().GetComponent<Transform>().position.z));
                Instantiate(sound, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
    }

}
