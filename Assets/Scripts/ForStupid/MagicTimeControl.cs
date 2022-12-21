using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTimeControl : MonoBehaviour
{
    [SerializeField] GameObject magic;
    public bool make;
    private bool make2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        make = false;
        make2 = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(make)
        {
            timer = 3f;
            make2 = true;
            make = false;
        }
        if(timer <= 0 && make2)
        {
            var buyu = Instantiate(magic, FindObjectOfType<Player>().transform.position, transform.rotation);
            buyu.GetComponent<MagicTime>().third = true;
            make2 = false;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


}
