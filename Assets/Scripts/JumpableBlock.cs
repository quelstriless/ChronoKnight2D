using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpableBlock : MonoBehaviour
{

    [SerializeField] public float moveSpeedRL;

    private bool moveRight;
    private float firstPosX;
    
    void Start()
    {
        firstPosX = transform.position.x;
            moveRight = true;
        

    }

    // Update is called once per frame
    void Update()
    {

            if(transform.position.x - firstPosX > 8.5f)
            {
                moveRight = false;
            }
            if(transform.position.x - firstPosX < -8.5f)
            {
                moveRight = true;
            }
            if(moveRight)
            {
                transform.position = new Vector2(transform.position.x + moveSpeedRL * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - moveSpeedRL * Time.deltaTime, transform.position.y);
            }
        }
    
}
