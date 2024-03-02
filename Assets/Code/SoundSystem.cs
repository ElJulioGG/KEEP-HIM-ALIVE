using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;
    public AudioSource audioClipCoin;
    public AudioSource audioClipJump;
    public AudioSource audioClipDead;




    private void Awake()
    {
        if (SoundSystem.instance == null) {
            SoundSystem.instance = this;
        }
        else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }



    }

    public void PlayCoin() {
        audioClipCoin.Play();
    }

    public void PlayJump()
    {
        audioClipJump.Play();
    }

    public void PlayDeath()
    {
        audioClipDead.Play();

    }



    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }

}
