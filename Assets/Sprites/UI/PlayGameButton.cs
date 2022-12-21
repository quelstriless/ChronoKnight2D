using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayGameButton : MonoBehaviour
{
    public float disappearTime;
    public float rofl;
    private TextMeshPro textMesh;
    private Color textcolor;
    private bool small;
    private bool large;

    // Start is called before the first frame update
    void Start()
    {
        small = false;
        large = false;
        rofl = 1f;
        textMesh = GetComponent<TextMeshPro>();
        disappearTime = 0.4f;
        GetComponent<TextMeshPro>().text = "PLAY GAME";
        textcolor = GetComponent<TextMeshPro>().color;
    }

    // Update is called once per frame
    void Update()
    {

        if(rofl >= 1)
        {
            large = true;
            small = false;
        }
        if (rofl <= 0)
        {
            small = true;
            large = false;

        }
        if(large)
        {
            float disappearSpeed = 2f;
            textcolor.a -= disappearSpeed * Time.deltaTime;
            GetComponent<TextMeshPro>().color = new Color(0.7924528f, 0.7924528f, 0.7924528f, rofl);
            rofl -= disappearSpeed * Time.deltaTime;
        }
        else if(small)
        {
            float disappearSpeed = 2f;
            textcolor.a += disappearSpeed * Time.deltaTime;
            GetComponent<TextMeshPro>().color = new Color(4.924578f, 4.924578f, 4.924578f, rofl);
            rofl += disappearSpeed * Time.deltaTime;

        }
    }
}
