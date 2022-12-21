using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yodo1.MAS;

public class SceneManage2 : MonoBehaviour
{
    [SerializeField] GameObject ADS,panel,nextLevel,worldsUI, e1, e2, e3, e4, e5, e6, e7, e8, e9, w1, w2, w3, w4, w5, w6, w7, w8,w9, loadingScreen,background,sound, rate;
    public bool first;
    private void Start()
    {

        first = true;
        setRewardedCallback();
    }
    


    void Update()
    {
        if (!Yodo1U3dMas.IsRewardedAdLoaded())
        {
            ADS.GetComponent<Image>().color = new Color(1, 1, 1, 0.6588235f);
            ADS.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0.4745098f);
            ADS.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6392157f);
        }
        else
        {
            ADS.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            ADS.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0.96f);
            ADS.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if ( first && Mathf.Abs(nextLevel.GetComponent<Transform>().position.x - FindObjectOfType<Player>().GetComponent<Transform>().position.x) <= 1.6f && Mathf.Abs(nextLevel.GetComponent<Transform>().position.y - FindObjectOfType<Player>().GetComponent<Transform>().position.y) <= 0.3f)
        {
            lastLevel();
            first = false;
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.rate || FindObjectOfType<FakeSave>().GetComponent<FakeSave>().rate)
        {
            rate.SetActive(false);
        }
    }
    public void addGold()
    {

        bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();
        if(isLoaded)
        Yodo1U3dMas.ShowRewardedAd();


    }
    private void setRewardedCallback()
    {
        Yodo1U3dMas.SetRewardedAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] RewardVideoDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Debug.Log("[Yodo1 Mas] Reward video ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Reward video ad has shown successful.");
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Debug.Log("[Yodo1 Mas] Reward video ad error, " + error);
                    break;
                case Yodo1U3dAdEvent.AdReward:
                    FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money += 350;
                    FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.money += 350;
                    FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
                    Debug.Log("[Yodo1 Mas] Reward video ad reward, give rewards to the player.");
                    break;
            }

        });

    }
    public void lastLevel()
    {
        panel.SetActive(false);
        worldsUI.SetActive(true);
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 3)
        {
            e1.SetActive(true);
            e2.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 4)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
        }

        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 5)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 6)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
        }

        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 7)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
        }

        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 8)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 9)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 10)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 11)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 12)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 13)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 14)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
            w4.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 15)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
            w4.SetActive(true);
            w5.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 16)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
            w4.SetActive(true);
            w5.SetActive(true);
            w6.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 17)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
            w4.SetActive(true);
            w5.SetActive(true);
            w6.SetActive(true);
            w7.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 18)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
            w4.SetActive(true);
            w5.SetActive(true);
            w6.SetActive(true);
            w7.SetActive(true);
            w8.SetActive(true);
        }
        else if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.level == 19)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            e9.SetActive(true);
            w1.SetActive(true);
            w2.SetActive(true);
            w3.SetActive(true);
            w4.SetActive(true);
            w5.SetActive(true);
            w6.SetActive(true);
            w7.SetActive(true);
            w8.SetActive(true);
            w9.SetActive(true);
        }
    }
    public void b1()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(2);

    }
    public void b2()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(3);
 
    }
    public void b3()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(4);

    }
    public void b4()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(5);

    }
    public void b5()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(6);
    }
    public void b6()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(7);
    }
    public void b7()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(8);
    }
    public void b8()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(9);
    }
    public void b9()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(10);
    }
    public void b10()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(11);
    }
    public void b11()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(12);
    }
    public void b12()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(13);
    }
    public void b13()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(14);
    }
    public void b14()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(15);
    }
    public void b15()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(16);
    }
    public void b16()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(17);
    }
    public void b17()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(18);
    }
    public void b18()
    {
        loadingScreen.SetActive(true);
        background.SetActive(false);
        sound.SetActive(false);
        SceneManager.LoadScene(19);
    }
    public void rateGame()
    {
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.rate = true;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        rate.SetActive(false);
        Application.OpenURL("market://details?id=com.QuelTalas.ChronoKnights");
    }
    public void later()
    {
        rate.SetActive(false);
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().rate = true;

    }
    public void never()
    {
        rate.SetActive(false);
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.rate = true;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
    }
}
