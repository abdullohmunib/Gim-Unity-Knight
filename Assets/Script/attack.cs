using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public static AudioClip attackSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        attackSound = Resources.Load<AudioClip>("attack");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        if (clip == "attack")
        {
            audioSrc.PlayOneShot(attackSound);
        }
    }
}
    