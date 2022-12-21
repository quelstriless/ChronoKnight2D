using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yodo1.MAS;

public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject  nextLevel, sound, musicUI1,musicUI2,soundUI1,soundUI2, pauseGameUI, backgroundPanel, loadingScreen, chatBubble, jumpButton, attackButton, dashButton;
    private bool one,two, bossTimer,episodeBool;
    private float timer, timer2;
    int currentSceneIndex;
    private float episodeTimer;
    [SerializeField] GameObject episode,episode2;
    // Start is called before the first frame update
    void Start()
    {
        episodeTimer = 3f;

        /*
        jumpButton = GameObject.Find("Button (3)");
        attackButton = GameObject.Find("Button");
        dashButton = GameObject.Find("Button (5)");

        jumpButton.GetComponent<Transform>().position = new Vector2(-90f,86f);
        dashButton.GetComponent<Transform>().position = new Vector2(-225f,221f);
        attackButton.GetComponent<Transform>().position = new Vector2(-267f,84f);
        */

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().currentSceneIndex = currentSceneIndex+1;
        if (!FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.music)
        {
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().volume = 0f;
        }
        setRewardedCallback();
        setInter();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(episodeTimer > 0)
        {
            episodeTimer -= Time.deltaTime;
        }
        if(episodeTimer <= 0)
        {
            episodeBool = true;
        }
        if(episodeBool && episode != null)
        {
            episode.SetActive(false);
        }
        if(episodeBool && episode2 != null)
        {
            episode2.SetActive(false);
        }

        //music ve sound uıları aktif veya pasif yapma
        if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.music)
        {
            musicUI1.SetActive(true);
            musicUI2.SetActive(false);
        }
        else
        {
            musicUI1.SetActive(false);
            musicUI2.SetActive(true);
        }
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.sound)
        {
            soundUI1.SetActive(true);
            soundUI2.SetActive(false);
        }
        else
        {
            soundUI1.SetActive(false);
            soundUI2.SetActive(true);
        }





        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (!one && Mathf.Abs(nextLevel.GetComponent<Transform>().position.x - FindObjectOfType<Player>().GetComponent<Transform>().position.x) <= 10f && Mathf.Abs(nextLevel.GetComponent<Transform>().position.y - FindObjectOfType<Player>().GetComponent<Transform>().position.y) <= 4f)
        {
            timer = 5f;
            Instantiate(sound, transform.position, transform.rotation);
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().Pause();
            one = true;
        }
        if(timer <= 0 && one &&!two)
        {
            if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.music)
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().Play();
            two = true;
        }


        if (Mathf.Abs(nextLevel.GetComponent<Transform>().position.x - FindObjectOfType<Player>().GetComponent<Transform>().position.x) <= 1f && Mathf.Abs(nextLevel.GetComponent<Transform>().position.y - FindObjectOfType<Player>().GetComponent<Transform>().position.y) <= 0.5f)
        {
            if(FindObjectOfType<FakeSave>().loadData.level < currentSceneIndex + 1)
            FindObjectOfType<FakeSave>().loadData.level = currentSceneIndex + 1;

            FindObjectOfType<FakeSave>().loadData.money = (int)FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money;
            FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
            backgroundPanel.SetActive(false);
            loadingScreen.SetActive(true);
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().Pause();
            ////
            /// 
             int xcount = Random.Range(1, 4);
            if (Yodo1U3dMas.IsInterstitialAdLoaded())
                {
                    if (xcount == 1)
                    Yodo1U3dMas.ShowInterstitialAd();
                }
  

            SceneManager.LoadScene("UpgradeScreen");
        }
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
    private void setInter()
    {
        Yodo1U3dMas.SetInterstitialAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] InterstitialAdDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Debug.Log("[Yodo1 Mas] Interstital ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Interstital ad has been shown.");
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Debug.Log("[Yodo1 Mas] Interstital ad error, " + error.ToString());
                    break;
            }
        });
    }
    public void addGold()
    {
        setRewardedCallback();
        bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();
        if (isLoaded)
            Yodo1U3dMas.ShowRewardedAd();

    }
    public void nextevel()
    {
        FindObjectOfType<FakeSave>().loadData.level = currentSceneIndex + 1;
        FindObjectOfType<FakeSave>().loadData.money = (int)FindObjectOfType<FakeSave>().GetComponent<FakeSave>().money;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
        SceneManager.LoadScene("UpgradeScreen");
    }
    public void muteMusic()
    {
        if(FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.music)
        {
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            FindObjectOfType<GameplayMusic>().GetComponent<AudioSource>().volume =0.68f;
        }

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.music = !FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.music;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
    }
    public void muteSound()
    {
        if (FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.sound)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }

        FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.sound = !FindObjectOfType<FakeSave>().GetComponent<FakeSave>().loadData.sound;
        FindObjectOfType<FakeSave>().GetComponent<SaveManager>().Save();
    }
    public void pauseGame()
    {
        pauseGameUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseGameUI.SetActive(false);

    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void restartGame()
    {
        FindObjectOfType<FakeSave>().money = FindObjectOfType<FakeSave>().firstMoney;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void boss1process()
    {
        var speak4 = Instantiate(chatBubble, transform.position, transform.rotation);
        speak4.GetComponent<ChatBubble>().Speech13();

    }

}
