using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class DialogSystem : Singleton<DialogSystem>
{

    [SerializeField] private TextMeshProUGUI textDisplay;
 
    public UnityEvent<Dialog> PleasePlayDialog;
    public UnityEvent<Dialog,bool> PlayDialogImmediately;
    public UnityEvent OnFinishedQueue; 
    private Queue<Dialog> _dialogQue;

    private Coroutine PlayingText;
    private bool isCurrentlyPlaying = false;

    private Dialog currentDialog;
    private Button _button; 
    private void OnEnable()
    {
        PleasePlayDialog?.AddListener(addToQue);
        PlayDialogImmediately?.AddListener(PlayImmediately);
        _dialogQue = new Queue<Dialog>();
        SceneManager.sceneLoaded += OnSceneLoaded;
       findDialog();
    }
    
    private void OnDisable()
    {  
        SceneManager.sceneLoaded -= OnSceneLoaded;
        PleasePlayDialog.RemoveListener(addToQue);
        _button?.onClick.RemoveListener(Next);
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       findDialog();
    }

    void findDialog()
    {
        var display = GameObject.FindWithTag("Dialog");
             textDisplay=display?.GetComponentInChildren<TextMeshProUGUI>();
             _button = display.GetComponentInChildren<Button>();
             _button?.onClick.AddListener(Next);

        if (textDisplay)
        {
            textDisplay.text = "";
        }
        

    }
    

    void PlayImmediately(Dialog setting, bool clearQue = false)
    {
        if (String.IsNullOrEmpty(setting.message)) return; 
        
        currentDialog = setting;
        if (clearQue)
        {
            _dialogQue.Clear();
        }
        
        StopAllCoroutines();

        PlayingText= StartCoroutine(typeText(setting));
    }
    void addToQue(Dialog settings)
    {
        if (String.IsNullOrEmpty(settings.message)) return; 
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
        if (_button) _button.interactable = true;
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
            if (_button) _button.interactable = false;
        }
        
        if (_dialogQue.Count > 0)
        {
           currentDialog =  _dialogQue.Dequeue();
           PlayingText= StartCoroutine(typeText(currentDialog));
        }
        else
        {
            OnFinishedQueue.Invoke();
        }

    }


    IEnumerator ClearText(float time )
    {
        isCurrentlyPlaying = true; 
        yield return new WaitForSeconds(time);
        textDisplay.text = "";
        isCurrentlyPlaying = false; 
        if (_button) _button.interactable = false;
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

            if (currentDialog.disappearAfterTime > 0)
            {
                StartCoroutine(ClearText(currentDialog.disappearAfterTime));
            }
            
        }
        else if(_dialogQue.Count>0)
        {
            currentDialog = _dialogQue.Dequeue();

            PlayingText = StartCoroutine(typeText(currentDialog));
        } else if (_dialogQue.Count == 0)
        {
            textDisplay.text = "";
            if (_button) _button.interactable = false; 
            OnFinishedQueue.Invoke();
        }
    }

    [ContextMenu("PlayNow")]
    public void Now()
    {
        PlayDialogImmediately.Invoke(new Dialog("PLAY NOW"),true);
    }
}
