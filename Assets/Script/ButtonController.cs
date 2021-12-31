using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public void moveScene(string pageName)
    {

        SceneManager.LoadScene(pageName);
        if (pageName == "Control Intro1" || pageName == "Intro" || pageName == "Main View")
        {
            SfxManager.sfx.Audio.PlayOneShot(SfxManager.sfx.Click);
        }

        else
        {
            SfxManager.sfx.Audio.Stop();
        }
    }
    public void QuitGame()
    {
        SfxManager.sfx.Audio.PlayOneShot(SfxManager.sfx.Click);
        Application.Quit();
    }
}
