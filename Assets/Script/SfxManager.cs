using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;
    public static SfxManager sfx;

    private void Awake()
    {
        if (sfx != null && sfx != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfx = this;
        DontDestroyOnLoad(this);
    }
}
