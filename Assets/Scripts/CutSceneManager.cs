using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneManager : MonoBehaviour
{
    public List<Cutscene> Cutscenes;
    private Queue<Cutscene> _cutsceneQue;

    [SerializeField] private Image background;
    private CanvasGroup imageGroup;

    public UnityEvent OnFinishCutscenes; 
    public UnityEvent OnStart;
    public UnityEvent OnFinishQueueing;

    private Cutscene current;

    public void OnEnable()
    {
        // create cute of cutscenes.. using list for inspector...
        _cutsceneQue = new Queue<Cutscene>(Cutscenes);
        imageGroup = background.gameObject.GetComponent<CanvasGroup>();
        DialogSystem.Instance.OnFinishedQueue.AddListener(StartCutscene);
        StartCutscene();
    }


    private void OnDisable()
    {
        if (DialogSystem.Instance != null)
        {
            DialogSystem.Instance.OnFinishedQueue.RemoveListener(StartCutscene);
        }
    }


    public void StartCutscene()
    {
        OnStart.Invoke();

        if (_cutsceneQue.Count == 0)
        {
            current = null;
            return;
        }
        current = _cutsceneQue.Dequeue();
        
        if (current ==null) return;

        StartCoroutine(ChangeBackground(current));
    }
    

    IEnumerator ChangeBackground(Cutscene cutscene)
    {
        // fade out current backgorund 
        while (imageGroup.alpha>0)
        {
            imageGroup.alpha -= (1f / 24f);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        if (cutscene.background != null)
        {
            background.sprite = cutscene.background; 
            while (imageGroup.alpha<1)
            {
                imageGroup.alpha += (1f / 24f)*0.5f;
                yield return null;
            }
        }
        
        SetupDialog(cutscene);
        
        OnFinishQueueing.Invoke();

        if (!String.IsNullOrEmpty(cutscene.LoadSceneInBackground))
        {
            yield return StartCoroutine(LoadYourAsyncScene(cutscene.LoadSceneInBackground));
        }
    }


    void SetupDialog(Cutscene scene)
    {
        if (scene._dialogs.Length == 0)
        {
            Debug.LogWarning(scene.name +" does not have any dialog");
            return;
        }
        // showdialog
        foreach (var dialog in scene._dialogs)
        {
            foreach (var line in dialog.lines)
            {
                DialogSystem.Instance.PleasePlayDialog.Invoke(line);
            }
        }
    }
    
    IEnumerator LoadYourAsyncScene(String scenename)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);
        
        asyncLoad.allowSceneActivation = false;
        
        while (asyncLoad.progress<0.9f)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
        }

        while (current != null) 
        {

            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
            
    }
    
    
   
}
