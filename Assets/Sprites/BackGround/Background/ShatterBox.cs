using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterBox : MonoBehaviour
{
    Rigidbody2D rg;
    public float rofl;
    float disappearSpeed;
    private Color textcolor;
    // Start is called before the first frame update
    void Start()
    {
        rofl = 1;
        float number, number2;
        number = Random.Range(-7, 7);
        number2 = Random.Range(-5, 5);
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(number,number2);
        textcolor = GetComponent<SpriteRenderer>().color;
        disappearSpeed = Random.Range(0.35f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {

        textcolor.a -= disappearSpeed * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, rofl);
        rofl -= disappearSpeed * Time.deltaTime;
        if (rofl < 0)
        {
            Destroy(gameObject);
        }
    }
}
