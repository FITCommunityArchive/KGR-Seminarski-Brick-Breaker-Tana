using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip rocketClip, gameOverClip,powerUpClip,hitClip,menuClip;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    public void RocketSoundFX()
    {
        soundFX.clip = rocketClip;
        soundFX.Play();
    }

    public void GameOverSoundFX()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
    public void PowerUpSoundFX()
    {
        soundFX.clip = powerUpClip;
        soundFX.Play();
    }
    public void HitSoundFX()
    {
        soundFX.clip = hitClip;
        soundFX.Play();
    }
    public void MenuSoundFX()
    {
        soundFX.clip = menuClip;
        soundFX.Play();
    }
}
