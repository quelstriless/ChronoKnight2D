using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarText : MonoBehaviour
{
    //public GameObject HealthText;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        
       textMesh.text = FindObjectOfType<Player>().GetComponent<Player>().health.ToString() + "/" + FindObjectOfType<Player>().GetComponent<Player>().FullHP.ToString();

    }
}
