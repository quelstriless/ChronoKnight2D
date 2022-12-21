using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhenCloseOpenBlackS : MonoBehaviour
{
    [SerializeField]
    GameObject ads,Ponce,errorSound,sound,button,worldsUI,panel, text1,i1,i2,i3,w1,w2,w3,World1UI, World2UI,Sound,Weapon,Armor,buyButton, sellPanel, sellPanel2,w1button, w2button, w3button, w4button, w5button, a2button, a3button, a4button, a5button,
        w2Buybutton, w3Buybutton, w4Buybutton, w5Buybutton, a2Buybutton, a3Buybutton, a4Buybutton, a5Buybutton,w1equippedButton,w2equippedButton,w3equippedButton,w4equippedButton,w5equippedButton,a2equippedButton,a3equippedButton,a4equippedButton,a5equippedButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level < 11)
        {
            World2UI.GetComponent<Image>().color = new Color(0.3396226f, 0.3396226f, 0.3396226f, 1);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin2)
        {
            a2button.SetActive(true);
            a2Buybutton.SetActive(false);
        }
        else
        {
            a2button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin3)
        {
            a3button.SetActive(true);
            a3Buybutton.SetActive(false);

        }
        else
        {
            a3button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin4)
        {
            a4button.SetActive(true);
            a4Buybutton.SetActive(false);

        }
        else
        {
            a4button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin5)
        {
            a5button.SetActive(true);
            a5Buybutton.SetActive(false);

        }
        else
        {
            a5button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon2)
        {
            w4button.SetActive(true);
            w2Buybutton.SetActive(false);
        }
        else
        {
            w4button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon3)
        {
            w3button.SetActive(true);
            w3Buybutton.SetActive(false);

        }
        else
        {
            w3button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon4)
        {
            w2button.SetActive(true);
            w4Buybutton.SetActive(false);

        }
        else
        {
            w2button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon5)
        {
            w5button.SetActive(true);
            w5Buybutton.SetActive(false);

        }
        else
        {
            w5button.SetActive(false);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1)
        {
            a5equippedButton.SetActive(false);
            a3equippedButton.SetActive(false);
            a4equippedButton.SetActive(false);
            a2equippedButton.SetActive(false);
           
            if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin5)
            a5button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin3)
                a3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin4)
                a4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin2)
                a2button.SetActive(true);

        }
        else if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2)
        {
            a2equippedButton.SetActive(true);
            a3equippedButton.SetActive(false);
            a4equippedButton.SetActive(false);
            a5equippedButton.SetActive(false);
            
            a2button.SetActive(false);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin3)
                a3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin4)
                a4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin5)
                a5button.SetActive(true);

        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3 )
        {
            a3equippedButton.SetActive(true);
            a5equippedButton.SetActive(false);
            a4equippedButton.SetActive(false);
            a2equippedButton.SetActive(false);
            a3button.SetActive(false);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin5)
                a5button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin4)
                a4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin2)
                a2button.SetActive(true);

        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4 )
        {
            a4equippedButton.SetActive(true);
            a3equippedButton.SetActive(false);
            a5equippedButton.SetActive(false);
            a2equippedButton.SetActive(false);
            a4button.SetActive(false);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin3)
                a3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin5)
                a5button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin2)
                a2button.SetActive(true);

        }
        else if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5 )
        {
            a5equippedButton.SetActive(true);
            a3equippedButton.SetActive(false);
            a4equippedButton.SetActive(false);
            a2equippedButton.SetActive(false);
            a5button.SetActive(false);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin3)
                a3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin4)
                a4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin2)
                a2button.SetActive(true);

        }


        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1)
        {

            w1equippedButton.SetActive(true);
            w2equippedButton.SetActive(false);
            w3equippedButton.SetActive(false);
            w4equippedButton.SetActive(false);
            w5equippedButton.SetActive(false);
            w1button.SetActive(false);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon2)
                w4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon3)
                w3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon4)
                w2button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon5)
                w5button.SetActive(true);
        }
        else if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2)
        {

            w2equippedButton.SetActive(true);
            w1equippedButton.SetActive(false);
            w3equippedButton.SetActive(false);
            w4equippedButton.SetActive(false);
            w5equippedButton.SetActive(false);
            w2button.SetActive(false);
     
            w1button.SetActive(true);

            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon3)
                w3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon2)
                w4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon5)
                w5button.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3)
        {

            w3equippedButton.SetActive(true);
            w2equippedButton.SetActive(false);
            w1equippedButton.SetActive(false);
            w4equippedButton.SetActive(false);
            w5equippedButton.SetActive(false);
            w3button.SetActive(false);

            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon2)
                w4button.SetActive(true);
            w1button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon4)
                w2button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon5)
                w5button.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4)
        {

            w4equippedButton.SetActive(true);
            w2equippedButton.SetActive(false);
            w3equippedButton.SetActive(false);
            w1equippedButton.SetActive(false);
            w5equippedButton.SetActive(false);
            w4button.SetActive(false);

            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon4)
                w2button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon3)
                w3button.SetActive(true);

                w1button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon5)
                w5button.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5)
        {

            w5equippedButton.SetActive(true);
            w2equippedButton.SetActive(false);
            w3equippedButton.SetActive(false);
            w4equippedButton.SetActive(false);
            w1equippedButton.SetActive(false);
            w5button.SetActive(false);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon2)
                w4button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon3)
                w3button.SetActive(true);
            if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon4)
                w2button.SetActive(true);

            w1button.SetActive(true);
        }
    }
    public void clickBuy()
    {
        sellPanel.SetActive(true);
        Weapon.SetActive(false);
        Armor.SetActive(false);
        Ponce.SetActive(false);
        ads.SetActive(false);

        Instantiate(sound, transform.position, transform.rotation);
    }
    public void clickBuy2()
    {
        sellPanel2.SetActive(true);
        Weapon.SetActive(false);
        Armor.SetActive(false);
        Ponce.SetActive(false);
        ads.SetActive(false);
        Instantiate(sound, transform.position, transform.rotation);
    }
    public void closeClickBuy()
    {
        sellPanel.SetActive(false);
        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
    }
    public void weaponEquip1()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1 = true;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<Player>().GetComponent<Player>().damage = 5;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage = 5;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon1 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel.SetActive(false);
    }
    public void weaponEquip4()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2 = true;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage = 8;
        FindObjectOfType<Player>().GetComponent<Player>().damage = 8;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon4 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel.SetActive(false);
    }
    public void weaponEquip3()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3 = true;


        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);



        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage = 7;
        FindObjectOfType<Player>().GetComponent<Player>().damage = 7;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon3 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel.SetActive(false);
    }
    public void weaponEquip2()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4 = true;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage = 6;
        FindObjectOfType<Player>().GetComponent<Player>().damage = 6;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon2 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel.SetActive(false);
    }
    public void weaponEquip5()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().weapon5 = true;


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.damage = 10;
        FindObjectOfType<Player>().GetComponent<Player>().damage = 10;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipweapon5 = true;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();

        sellPanel.SetActive(false);
    }

    public void clickEquip2()
    {
         FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5 = false;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().hp = 20;
        FindObjectOfType<Player>().GetComponent<Player>().health = 20;
        FindObjectOfType<Player>().GetComponent<Player>().FullHP = 20;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.health = 20;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin2 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();

        sellPanel2.SetActive(false);
    }
    public void clickEquip1()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5 = false;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().hp = 20;

        FindObjectOfType<Player>().GetComponent<Player>().health = 20;
        FindObjectOfType<Player>().GetComponent<Player>().FullHP = 20;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.health = 20;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin1 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();


        sellPanel2.SetActive(false);
    }
    public void clickEquip3()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5 = false;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().hp = 25;

        FindObjectOfType<Player>().GetComponent<Player>().health = 25;
        FindObjectOfType<Player>().GetComponent<Player>().FullHP = 25;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.health = 25;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin3 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel2.SetActive(false);
    }
    public void clickEquip4()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().hp = 27;

        FindObjectOfType<Player>().GetComponent<Player>().health = 27;
        FindObjectOfType<Player>().GetComponent<Player>().FullHP = 27;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);


        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.health = 27;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin4 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin5 = false;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel2.SetActive(false);
    }
    public void clickEquip5()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin5 = true;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().skin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().hp = 30;

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.health = 30;
        FindObjectOfType<Player>().GetComponent<Player>().health = 30;
        FindObjectOfType<Player>().GetComponent<Player>().FullHP = 30;

        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
        Instantiate(Sound, transform.position, transform.rotation);

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin1 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin2 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin3 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin4 = false;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.equipskin5 = true;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        sellPanel2.SetActive(false);
    }

    public void Vampire1()
    {
        
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 80)
        {
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.vampire1 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().vampire1 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 80;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 80;
          
            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
    }
    public void armor2()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 1200)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin2 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buySkin2 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 1200;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 1200;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void armor3()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 2100)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin3 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buySkin3 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 2100;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 2100;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void armor4()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 3500)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin4 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buySkin4 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 3500;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 3500;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void armor5()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 4700)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyskin5 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buySkin5 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 4700;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 4700;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void weapon2()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 1120)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon2 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buyWeapon2 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 1120;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 1120;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void weapon3()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 2000)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon3 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buyWeapon3 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 2000;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 2000;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void weapon4()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 3100)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon4 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buyWeapon4 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 3100;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 3100;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void weapon5()
    {

        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money >= 4300)
        {
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.buyweapon5 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().buyWeapon5 = true;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money -= 4300;
            FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money -= 4300;

            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void closeWeapon()
    {
        Instantiate(sound, transform.position, transform.rotation);
        sellPanel.SetActive(false);
        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);
    }
    public void closeArmor()
    {
        Instantiate(sound, transform.position, transform.rotation);
        Weapon.SetActive(true);
        Armor.SetActive(true);
        Ponce.SetActive(true);
        ads.SetActive(true);

        sellPanel2.SetActive(false);
    }
    public void World1()
    {
        Instantiate(sound, transform.position, transform.rotation);
        button.SetActive(false);
        text1.SetActive(false);
        i1.SetActive(false);
        i2.SetActive(false);
        i3.SetActive(false);
        w1.SetActive(false);
        w2.SetActive(false);
        w3.SetActive(false);
        World1UI.SetActive(true);
    }
    public void World2()
    {
        if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level >= 11)
        {
            Instantiate(sound, transform.position, transform.rotation);
            button.SetActive(false);
            text1.SetActive(false);
            i1.SetActive(false);
            i2.SetActive(false);
            i3.SetActive(false);
            w1.SetActive(false);
            w2.SetActive(false);
            w3.SetActive(false);
            World2UI.SetActive(true);
        }
        else
        {
            Instantiate(errorSound, transform.position, transform.rotation);
        }
    }
    public void World1Back()
    {
        Instantiate(sound, transform.position, transform.rotation);
        World1UI.SetActive(false);
        text1.SetActive(true);
        i1.SetActive(true);
        i2.SetActive(true);
        i3.SetActive(true);
        w1.SetActive(true);
        w2.SetActive(true);
        w3.SetActive(true);
        button.SetActive(true);

    }
    public void World2Back()
    {
        Instantiate(sound, transform.position, transform.rotation);
        World2UI.SetActive(false);
        text1.SetActive(true);
        i1.SetActive(true);
        i2.SetActive(true);
        i3.SetActive(true);
        w1.SetActive(true);
        w2.SetActive(true);
        w3.SetActive(true);
        button.SetActive(true);

    }
    public void BackFromPortal()
    {
        Instantiate(sound, transform.position, transform.rotation);
        panel.SetActive(true);
        worldsUI.SetActive(false);
        FindObjectOfType<SceneManage2>().GetComponent<SceneManage2>().first = true;
    }
}
