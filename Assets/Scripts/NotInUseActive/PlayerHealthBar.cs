using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
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
        player = FindObjectOfType<Player>().gameObject;
        bar.localScale = new Vector3(player.GetComponent<Player>().health / player.GetComponent<Player>().FullHP, 1f);
    }

}
