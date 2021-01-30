using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioMixer Mixer;
    private Animator MenuAnimator;
    
    public string scenename ="tester";
    private void Start()
    {
        MenuAnimator = GetComponent<Animator>();
    }

    public void BeginGame()
    {
        MenuAnimator.Play("BringDownCurtain");
        
    }

    public void LoadGame()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    
    

        IEnumerator LoadYourAsyncScene()
        {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);
        
        asyncLoad.allowSceneActivation = false;
        
            while (asyncLoad.progress<0.9f)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
        }
            yield return new WaitForSeconds(1.0f);
            MenuAnimator.Play("BringUpCurtain");
            yield return new WaitForSeconds(0.5f);
           
            asyncLoad.allowSceneActivation = true;
            
        }
    
        public void UnloadMenu()
        {    Debug.Log("bye");
          
        }

    public void ShowMenu()
    {
        MenuAnimator.SetTrigger("ShowMenu");
    }

    public void ShowCredits()
    {
        MenuAnimator.SetTrigger("ShowCredits");
    }

    public void ShowOptions()
    {
        MenuAnimator.SetTrigger("ShowOptions");
    }

    public void AdjustVolume(float vol)
    {
        Mixer.SetFloat("Music", Mathf.Log10(vol) * 20);
    }

    public void AdjustSFX(float vol)
    {
        Mixer.SetFloat("SFX", Mathf.Log10(vol) * 20);
    }
}
