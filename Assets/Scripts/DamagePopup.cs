using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{

    //Critical hit will be added.
    public float disappearTime;
    public float rofl;
    public void Create(int damageAmount, Vector3 position)
    {
        Setup(damageAmount);
        Instantiate(this, position, Quaternion.identity);
    }
    
    private TextMeshPro textMesh;
    private Color textcolor;

    private void Start()
    {
        rofl = 1f;
        textMesh = GetComponent<TextMeshPro>();
        disappearTime = 0.4f;
    }

    public void Setup(int damage)
    {
        GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        textcolor = GetComponent<TextMeshPro>().color;
    }

    private void Update()
    {
        float moveYSpeed = 1.5f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTime -= Time.deltaTime;
        if(disappearTime < 0)
        {
            float disappearSpeed = 3f;
            textcolor.a -= disappearSpeed * Time.deltaTime;
            GetComponent<TextMeshPro>().color = new Color(1.976675f, 1.976675f, 1.976675f, rofl);
            rofl -= disappearSpeed * Time.deltaTime;
            if(rofl < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
