using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void yokEt()
    {
        Destroy(gameObject);
    }
    void spawnBoss()
    {
        Instantiate(boss, transform.position, transform.rotation);
    }
    void traitorYoket()
    {
        Destroy(FindObjectOfType<Traitor>().gameObject);
    }
}
