using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class Cage : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer rendere;
    [SerializeField] GameObject takenDamageVFX, bird;
    private Color textcolor;
    private float rofl;
    private bool start;
    void Start()
    {
        rendere = GetComponent<SpriteRenderer>();
        textcolor = rendere.color;
        rofl = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            float disappearSpeed = 2f;
            textcolor.a -= disappearSpeed * Time.deltaTime;
            rendere.color = new Color(1f, 1f, 1f, rofl);
            rofl -= disappearSpeed * Time.deltaTime;
            if (rofl < 0)
            {
                bird.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                bird.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                Destroy(gameObject);
            }
        }
        
    }
     public void TakeDamage(Vector2 strike)
    {
        Instantiate(takenDamageVFX, new Vector2(strike.x, strike.y + 0.3f), transform.rotation);
        addGold();


    }
    public void addGold()
    {
        setRewardedCallback();
        bool isLoaded = Yodo1U3dMas.IsRewardedAdLoaded();
        if (isLoaded)
            Time.timeScale = 0f;
        Yodo1U3dMas.ShowRewardedAd();

    }
    private void setRewardedCallback()
    {
        Yodo1U3dMas.SetRewardedAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] RewardVideoDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Time.timeScale = 1f;
                    Debug.Log("[Yodo1 Mas] Reward video ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Reward video ad has shown successful.");
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Time.timeScale = 1f;
                    Debug.Log("[Yodo1 Mas] Reward video ad error, " + error);
                    break;
                case Yodo1U3dAdEvent.AdReward:
                    start = true;
                    Time.timeScale = 1f;
                    Debug.Log("[Yodo1 Mas] Reward video ad reward, give rewards to the player.");
                    break;
            }

        });

    }
}
