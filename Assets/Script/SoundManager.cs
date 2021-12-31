using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static AudioClip walkSound, enemyDeathSound, jumpSound, playerDeathSound, sawSound, completeSound, cursor2;
    public static SoundManager instance { get; private set; }
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        walkSound = Resources.Load<AudioClip>("walk");

        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");
        jumpSound = Resources.Load<AudioClip>("jump");
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        sawSound = Resources.Load<AudioClip>("saw");
        completeSound = Resources.Load<AudioClip>("complete");
        cursor2 = Resources.Load<AudioClip>("cusror");

        audioSrc = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        /*else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "walk":
                audioSrc.PlayOneShot(walkSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "saw":
                audioSrc.PlayOneShot(sawSound);
                break;
            case "complete":
                audioSrc.PlayOneShot(completeSound);
                break;
            case "cursor":
                audioSrc.PlayOneShot(cursor2);
                break;

        }
    }
}
