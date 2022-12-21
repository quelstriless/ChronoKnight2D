using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject ShatterBox;
    [SerializeField] GameObject takenDamageVFX;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject meat, sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destroy(Vector2 strike)
    {
        Instantiate(sound, transform.position, transform.rotation);
        Instantiate(takenDamageVFX, new Vector2(strike.x, strike.y + 0.3f), transform.rotation);
        Instantiate(ShatterBox, transform.position, transform.rotation);
        int meatChange;
        meatChange = Random.Range(1, 9);
        int goldNumber;
        goldNumber = Random.Range(1, 3);
        if (meatChange < 3 )
        {
            Instantiate(meat, transform.position, transform.rotation);
        }
            for (int i = 0; i < goldNumber; i++)
        {
            Instantiate(gold, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
