using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFirstRoom : MonoBehaviour
{
    [SerializeField] GameObject openChest, magic;
    Animator m_Animator;
    public bool opened;
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(FindObjectOfType<OldPlayer>().GetComponent<Transform>().position.x - transform.position.x) < 4f && !opened)
        {
            openChest.SetActive(true);
        }
        else
        {
            openChest.SetActive(false);
        }
    }
    public void anim()
    {
        m_Animator.SetBool("Open", true);
        opened = true;
       var mag = Instantiate(magic, transform.position, transform.rotation);
        mag.GetComponent<MagicTime>().second = false;
    }
}
