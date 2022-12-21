using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonceDeLeonHP : MonoBehaviour
{
    private Transform bar;
    private GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");

    }
    private void Update()
    {
        player = FindObjectOfType<WaterSpirit>().gameObject;
       
        bar.localScale = new Vector3(FindObjectOfType<WaterSpirit>().GetComponent<Enemy>().health / FindObjectOfType<WaterSpirit>().GetComponent<Enemy>().fullHP, 1f);
    }

}
