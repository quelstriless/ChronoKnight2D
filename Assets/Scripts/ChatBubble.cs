using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ChatBubble : MonoBehaviour
{

    private TextMeshPro textMeshPro;
    public bool player;
    public bool enemy;
    public bool bossSpecial;
    private float timer;
    private bool small, prop, boss;
    public bool check;
    private float propTimer;
    private void Awake()
    {
        prop = false;
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        if(prop)
        {
            SceneManager.LoadScene("UpgradeScreen");
        }
        if(propTimer >0 && boss)
        {
            propTimer -= Time.deltaTime;
        }
        if(propTimer <= 0 && boss)
        {
            prop = true;
        }
        if(timer >= 0 && check)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            check = false;
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        if(player)
        {
            transform.position = new Vector2(FindObjectOfType<Player>().GetComponent<Transform>().position.x - 1.65f, FindObjectOfType<Player>().GetComponent<Transform>().position.y);

        }
        else if(small)
        {
            transform.position = new Vector2(FindObjectOfType<Traitor>().GetComponent<Transform>().position.x - 1.2f, FindObjectOfType<Traitor>().GetComponent<Transform>().position.y + 0.7f);
        }
        else if(bossSpecial)
        {
            transform.position = new Vector2(-38.92f,78.66f);

        }
        else if(enemy)
        {
            transform.position = new Vector2(FindObjectOfType<Traitor>().GetComponent<Transform>().position.x - 1.9f, FindObjectOfType<Traitor>().GetComponent<Transform>().position.y + 0.7f);
 
        }
        else
        {
            transform.position = new Vector2(FindObjectOfType<OldPlayer>().GetComponent<Transform>().position.x - 2.3f, FindObjectOfType<OldPlayer>().GetComponent<Transform>().position.y + 0.2f);

        }
    }
    private void Start()
    {
        check = true;
        timer = 1f;
    }
    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        GetComponent<TextWriter>().AddWriter(textMeshPro, text, .07f);

    }
    public void Speech1()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        Setup("The power is inside the chest");
        Destroy(gameObject, 4.8f);
    }
    public void Speech2()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        Setup("Haaah..... I feel the power. I will use this power to \nget back in time and be young again");
        Destroy(gameObject, 8f);
    }
    public void Speech3()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        Setup("I will finally find the time controlling power");
         Destroy(gameObject, 6.5f);
    }
    public void Speech4()
    {
        player = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        Setup("Where am I? Who are you.");
        Destroy(gameObject, 5f);

    }
    public void Speech5()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        enemy = true;
        Setup("I am the guardian of this place\nHow did you come here");
        Destroy(gameObject, 6f);
    }
    public void Speech6()
    {
        player = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        Setup("I did time travel and found myself \nin here. How can i leave");
        Destroy(gameObject, 6f);
    }
    public void Speech7()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        enemy = true;
        Setup("Hmmm... Give me your power\nSo I can fix the portal");
        Destroy(gameObject, 6.5f);
    }
    public void Speech8()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        player = true;
        Setup("Okay... please send me to my home");
        Destroy(gameObject, 6f);
        FindObjectOfType<MagicTimeControl>().GetComponent<MagicTimeControl>().make = true;
    }
    public void Speech9()
    {
        small = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        enemy = true;
        Setup("Enter the portal");
        Destroy(gameObject, 7.5f);
    }
    public void Speech10()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        player = true;
        Setup("What did you do... I can't move");
        Destroy(gameObject, 6.5f);
    }
    public void Speech11()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        enemy = true;
        Setup("Hahahah I deceived you. Now\n I have the time control power");
        Destroy(gameObject, 6.5f);
    }
    public void Speech12()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        player = true;
        Setup("I am going to portal.");
        Destroy(gameObject, 7.5f);
        FindObjectOfType<MagicTimeControl>().GetComponent<MagicTimeControl>().make = true; 
    }
    public void Speech13()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        player = true;
        Setup("Finally i got my power back but it's imperfect.");
        propTimer = 6f;
        Destroy(gameObject, 6.5f);
        boss = true;

    }
    public void Speech14()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        player = true;
        Setup("Ok then let me help to go my real time.");
        Destroy(gameObject, 7.5f);
        FindObjectOfType<MagicTimeControl>().GetComponent<MagicTimeControl>().make = true;
    }
    public void bossSpeech()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        bossSpecial = true;
        Setup("I don't think you would come here.\nNow you will see my real form");
        Destroy(gameObject, 7.5f);

    }
}
