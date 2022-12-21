using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTime : MonoBehaviour
{
    [SerializeField] GameObject effect;
    public float speed;
    public Transform target;
    float X;
    float Y;
    public bool second;
    public bool third;
    public bool forth;
    public bool fifth;
    void Start()
    {
        target = FindObjectOfType<OldPlayer>().gameObject.GetComponent<Transform>();
        X = target.position.x;
        Y = target.position.y;
        look();
    }
    private void Update()
    {
        if(second)
        {
            target = FindObjectOfType<Portalling>().gameObject.GetComponent<Transform>();
        }
        if(third)
        {
            target = FindObjectOfType<Traitor>().gameObject.GetComponent<Transform>();
        }
        if(forth)
        {
            target = FindObjectOfType<Portalling>().gameObject.GetComponent<Transform>();
        }
        if(fifth)
        {
            target = FindObjectOfType<Player>().gameObject.GetComponent<Transform>();
        }
        X = target.position.x;
        Y = target.position.y;
        look();

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(X, Y), speed * Time.deltaTime);
       
        if(transform.position.x == target.transform.position.x && !second && !third && !forth && !fifth)
        {
            FindObjectOfType<OldPlayer>().GetComponent<OldPlayer>().magicStart();
            Destroy(gameObject);
        }
        if(transform.position.x == target.transform.position.x && second)
        {
            FindObjectOfType<Portalling>().GetComponent<Portalling>().startShow();
            Destroy(gameObject);
        }
        if (transform.position.x == target.transform.position.x && third)
        {
            FindObjectOfType<Portalling>().GetComponent<Portalling>().startShow3();
            Destroy(gameObject);
        }
        if (transform.position.x == target.transform.position.x && forth)
        {
            FindObjectOfType<Portalling>().GetComponent<Portalling>().startShow2();
            Destroy(gameObject);
        }
        if (transform.position.x == target.transform.position.x && fifth)
        {
            FindObjectOfType<SceneManage>().GetComponent<SceneManage>().boss1process();
            Destroy(gameObject);
        }
    }

    public void look()
    {
        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ - 180));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<OldPlayer>())
        {

            //ParticleEffectMightBeUsed
            //Instantiate(effect, transform.position, transform.rotation);
            FindObjectOfType<OldPlayer>().GetComponent<OldPlayer>().magicStart();
            Destroy(gameObject);
        }


    }
}
