using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificPortal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] Transform portal;
    [SerializeField] public float X, Y;
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.x - portal.position.x) <= 0.4f && Mathf.Abs(FindObjectOfType<Player>().GetComponent<Transform>().position.y - portal.position.y) <= 0.5f)
        {
            player.transform.position = new Vector3(X,Y, player.transform.position.z);
           
        }
 
    }
}
