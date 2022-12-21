using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public float showTime;
    public bool check;
    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        showTime = 2f;
        check = false;
        gameObject.SetActive(false);
    }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
        check = true;
        showTime = 2f;
    }
    private void Update()
    {
        if(check)
        {
            showTime -= Time.deltaTime;
        }
        if(showTime <= 0)
        {
            check = false;
            gameObject.SetActive(false);
        }
    }

}
