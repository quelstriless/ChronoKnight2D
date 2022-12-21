using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuMusic : MonoBehaviour
{
    AudioSource audioSource;
    public int startingPitch = 1;
    public float nextPitch = 0.5f;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = startingPitch;
    }
        // Update is called once per frame
        void Update()
    {

        
    }
    public void pitch()
    {
        audioSource.pitch = nextPitch;
    }
    public void pitch2()
    {
        audioSource.pitch = startingPitch;
    }
}
