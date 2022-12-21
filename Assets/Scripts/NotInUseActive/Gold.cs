using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] GameObject goldEffect;
    [SerializeField] GameObject goldPopup, goldSound;
    private float timer;
    private bool time;
    // Start is called before the first frame update
    void Start()
    {
        time = false;
        timer = 0.1f;
        float number, number2;
        number = Random.Range(-16, 16);
        number2 = Random.Range(15, 23);
        rg = GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(number,number2), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            time = true;
        }
        if (time && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x) <= 0.66f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.y - transform.position.y) <= 1.4f)
        {
            Instantiate(goldSound, transform.position, transform.rotation);
            Instantiate(goldEffect, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money = FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money + 10;
            goldPopup.GetComponent<GoldPopUp>().Create(new Vector3(FindObjectOfType<Player>().GetComponent<Transform>().position.x - 0.3f, FindObjectOfType<Player>().GetComponent<Transform>().position.y + 0.43f, FindObjectOfType<Player>().GetComponent<Transform>().position.z));
            Destroy(gameObject);
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() && time)
        {
        }
    }
    */
}
