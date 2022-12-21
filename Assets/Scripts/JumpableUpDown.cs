using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpableUpDown : MonoBehaviour
{

    [SerializeField] public float moveSpeedRL;

    private bool moveUp;
    private float firstPosY;

    void Start()
    {
        firstPosY = transform.position.y;
        moveUp = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y - firstPosY > 6.5f)
        {
            moveUp = false;
        }
        if (transform.position.y - firstPosY < -6.5f)
        {
            moveUp = true;
        }
        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeedRL * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeedRL * Time.deltaTime);
        }
    }
}
