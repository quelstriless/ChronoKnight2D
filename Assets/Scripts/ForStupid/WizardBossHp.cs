using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBossHp : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");

    }
    private void Update()
    {

        bar.localScale = new Vector3(FindObjectOfType<WizardBoss>().GetComponent<Enemy>().health / FindObjectOfType<WizardBoss>().GetComponent<Enemy>().fullHP, 1f);
    }

}
