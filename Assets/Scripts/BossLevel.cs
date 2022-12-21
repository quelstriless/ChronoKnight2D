using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevel : MonoBehaviour
{
    // Start is called before the first frame update
    int currentSceneIndex;
    [SerializeField] GameObject loadingScreen, panel, chatBubble, timeMagic;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().currentSceneIndex = currentSceneIndex + 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void load()
    {
        ///// Make Process Here
       if(FindObjectOfType<FakeSave>().loadData.level < currentSceneIndex + 1)
        FindObjectOfType<FakeSave>().loadData.level = currentSceneIndex + 1;


        FindObjectOfType<FakeSave>().loadData.money = (int)FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money;

        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();


       var buyu = Instantiate(timeMagic, transform.position, transform.rotation);
        buyu.GetComponent<MagicTime>().fifth = true;
    }
}
