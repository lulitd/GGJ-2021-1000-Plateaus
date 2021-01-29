using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogSystem : Singleton<DialogSystem>
{

    [SerializeField] private TextMeshProUGUI textDisplay;

    public UnityEvent<Dialog> PleasePlayDialog;
    public UnityEvent<Dialog,bool> PlayDialogImmediately;
    private Queue<Dialog> _dialogQue;

    private Coroutine PlayingText;
    private bool isCurrentlyPlaying = false;

    private Dialog currentDialog; 
    private void OnEnable()
    {
        PleasePlayDialog.AddListener(addToQue);
        PlayDialogImmediately.AddListener(PlayImmediately);
        _dialogQue = new Queue<Dialog>();
        textDisplay.text = "";
    }
    private void OnDisable()
    {
        PleasePlayDialog.RemoveListener(addToQue);
    }

    void PlayImmediately(Dialog setting, bool clearQue = false)
    {
        currentDialog = setting;
        if (clearQue)
        {
            _dialogQue.Clear();
        }

        if (PlayingText != null)
        {
            StopCoroutine(PlayingText);
        }
        PlayingText= StartCoroutine(typeText(setting));
    }
    void addToQue(Dialog settings)
    {
        if (isCurrentlyPlaying)
        {
            _dialogQue.Enqueue(settings);
        }
        else
        {
            currentDialog = settings;
            PlayingText= StartCoroutine(typeText(settings));
        }
    }

    IEnumerator typeText(Dialog settings)
    {
        isCurrentlyPlaying = true; 
        textDisplay.text = "";
        yield return new WaitForSeconds(settings.initalDelay);
        
        foreach (var c in settings.message)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(settings.timeBetweenCharacters);
        }

        if (settings.disappearAfterTime < 0)
        {  isCurrentlyPlaying = false;
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(settings.disappearAfterTime);
            textDisplay.text = "";
            isCurrentlyPlaying = false; 
        }

     

        if (_dialogQue.Count > 0)
        {
           currentDialog =  _dialogQue.Dequeue();
           PlayingText= StartCoroutine(typeText(currentDialog));
        }
    }

    [ContextMenu("Next")]
    public void Next()
    {
        if (isCurrentlyPlaying)
        {
            //stop text animation
            if (PlayingText!=null) StopCoroutine(PlayingText);
            // fast forward message. 
            textDisplay.text = currentDialog.message;
            isCurrentlyPlaying = false; 
            
        }
        else if(_dialogQue.Count>0)
        {
            currentDialog = _dialogQue.Dequeue();

            PlayingText = StartCoroutine(typeText(currentDialog));
        } else if (_dialogQue.Count == 0)
        {
            textDisplay.text = ""; 
        }
    }

    [ContextMenu("PlayNow")]
    public void Now()
    {
        PlayDialogImmediately.Invoke(new Dialog("PLAY NOW"),true);
    }


    public struct Dialog
    {
         public float initalDelay;
         public string message;
         public float timeBetweenCharacters;
         public bool canFastforward;
         public float disappearAfterTime;

         public Dialog(string message, float initalDelay = 0.1f , float timeBetweenCharacters = 0.05f, bool canFastforward = true , float disappearAfterTime=2)
         {
             this.initalDelay = initalDelay;
             this.message = message;
             this.timeBetweenCharacters = timeBetweenCharacters;
             this.canFastforward = canFastforward;
             this.disappearAfterTime = disappearAfterTime; 
         }
    }

}
