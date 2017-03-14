using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;
    public AudioSource SFX;

    public AudioClip timeslow;

    public AudioClip cooked;

    public AudioClip split;

    public AudioClip pew;

    void Start()
    {
        Instance = this;
    }
    public void slomo()
    {
        SFX.PlayOneShot(timeslow);
    }


    public void phase2()
    {
        SFX.PlayOneShot(cooked);
    }


    public void explode()
    {
        SFX.PlayOneShot(split);

    }

    public void shitfire()
    {
        SFX.PlayOneShot(pew);
    }
}
