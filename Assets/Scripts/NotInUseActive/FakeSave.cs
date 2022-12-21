using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Yodo1.MAS;
using Firebase;
using Firebase.Analytics;

public class FakeSave : MonoBehaviour
{
    public GameObject moneyText;

    [SerializeField] public CurrentLevel loadData;

    public float money;
    public float firstMoney;
    public float hp;
    public float damage;
    public float currentSceneIndex;
    private bool makeOnce;

    public bool vampire1;
    public bool skin1;
    public bool skin2;
    public bool skin3;
    public bool skin4;
    public bool skin5;
    public bool buySkin1;
    public bool buySkin2;
    public bool buySkin3;
    public bool buySkin4;
    public bool buySkin5;

    public bool weapon1;
    public bool weapon2;
    public bool weapon3;
    public bool weapon4;
    public bool weapon5;

    public bool buyWeapon1;
    public bool buyWeapon2;
    public bool buyWeapon3;
    public bool buyWeapon4;
    public bool buyWeapon5;

    public bool rate;



    private static FakeSave instance;
    private void Start()
    {
        rate = false;
        Yodo1U3dMas.InitializeSdk();
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( continuationAction: task =>
         {
             FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
         });

        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Load();




        skin1 = loadData.equipskin1;
        skin2 = loadData.equipskin2;
        skin3 = loadData.equipskin3;
        skin4 = loadData.equipskin4;
        skin5 = loadData.equipskin5;

        buySkin1 = loadData.buyskin1;
        buySkin2 = loadData.buyskin2;
        buySkin3 = loadData.buyskin3;
        buySkin4 = loadData.buyskin4;
        buySkin5 = loadData.buyskin5;

        weapon1 = loadData.equipweapon1;
        weapon2 = loadData.equipweapon4;
        weapon3 = loadData.equipweapon3;
        weapon4 = loadData.equipweapon2;
        weapon5 = loadData.equipweapon5;

        buyWeapon1 = loadData.buyweapon1;
        buyWeapon2 = loadData.buyweapon2;
        buyWeapon3 = loadData.buyweapon3;
        buyWeapon4 = loadData.buyweapon4;
        buyWeapon5 = loadData.buyweapon5;

        vampire1 = loadData.vampire1;

        damage = loadData.damage;
        hp = loadData.health;
        money = loadData.money; 
        currentSceneIndex = loadData.level;

        makeOnce = true;
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
       
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 2 &&makeOnce)
        {
            makeOnce = false;

            FindObjectOfType<Player>().GetComponent<Player>().health = (int)hp;
            FindObjectOfType<Player>().GetComponent<Player>().damage = (int)damage;
        }
        if(SceneManager.GetActiveScene().buildIndex >= 2)
        {

            moneyText = GameObject.Find("MoneyText");
            //Take From Save
            moneyText.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = money.ToString();
        }


    }
    public void scenemanage()
    {
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Load();
        money = loadData.money;
        FindObjectOfType<Player>().GetComponent<Player>().firstHealth = (int)hp;
        currentSceneIndex = loadData.level;
    }

    public void Set()
    {
        firstMoney = money;
        if (!loadData.firstPlay)
        {
            FindObjectOfType<Player>().GetComponent<Player>().health = 20;
            FindObjectOfType<Player>().GetComponent<Player>().damage = 5;
        }
        else
        {
            FindObjectOfType<Player>().GetComponent<Player>().health = (int)loadData.health;
            FindObjectOfType<Player>().GetComponent<Player>().damage = (int)loadData.damage;
        }

    }
    public void Basla()
    {

        loadData.firstPlay = true;
        loadData.damage = 5;
        loadData.health = 20;
        loadData.level = 0;
        loadData.music = true;
        loadData.sound = true;
        loadData.buyskin2 = false;
        loadData.buyskin3 = false;
        loadData.buyskin4 = false;
        loadData.buyskin5 = false;
        loadData.buyweapon2 = false;
        loadData.buyweapon3 = false;
        loadData.buyweapon4 = false;
        loadData.buyweapon5 = false;
        loadData.vampire1 = false;
        loadData.equipskin1 = true;
        loadData.equipskin2 = false;
        loadData.equipskin3 = false;
        loadData.equipskin4 = false;
        loadData.equipskin5 = false;
        loadData.equipweapon1 = true;
        loadData.equipweapon2 = false;
        loadData.equipweapon3 = false;
        loadData.equipweapon4 = false;
        loadData.equipweapon5 = false;
        loadData.money = 0;

        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();



        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Load();
        skin1 = loadData.equipskin1;
        skin2 = loadData.equipskin2;
        skin3 = loadData.equipskin3;
        skin4 = loadData.equipskin4;
        skin5 = loadData.equipskin5;

        buySkin1 = loadData.buyskin1;
        buySkin2 = loadData.buyskin2;
        buySkin3 = loadData.buyskin3;
        buySkin4 = loadData.buyskin4;
        buySkin5 = loadData.buyskin5;

        weapon1 = loadData.equipweapon1;
        weapon2 = loadData.equipweapon2;
        weapon3 = loadData.equipweapon3;
        weapon4 = loadData.equipweapon4;
        weapon5 = loadData.equipweapon5;

        buyWeapon1 = loadData.buyweapon1;
        buyWeapon2 = loadData.buyweapon2;
        buyWeapon3 = loadData.buyweapon3;
        buyWeapon4 = loadData.buyweapon4;
        buyWeapon5 = loadData.buyweapon5;

        vampire1 = loadData.vampire1;

        damage = loadData.damage;
        hp = loadData.health;
        money = loadData.money;
        currentSceneIndex = loadData.level;
    }

}
