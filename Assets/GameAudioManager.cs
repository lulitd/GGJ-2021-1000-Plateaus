using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    public  static GameAudioManager Instance = null; 

    public AudioSource loopSource;
    public AudioSource SfxSource;
    public AudioSource dialog;
    [SerializeField] AudioMixer _audioMixer;

    public AudioClip MainMenu;
    public AudioClip MainSong;



    void SetupSingleton()
    {
        if (Instance != null)
        {
            Destroy(this);
        } else
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        SetupSingleton();
        Init();
    }

    private void Init()
    {
        loopSource = gameObject.AddComponent<AudioSource>();
        SfxSource = gameObject.AddComponent<AudioSource>();
        dialog = gameObject.AddComponent<AudioSource>();

        if (_audioMixer != null)
        {
            SfxSource.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("SFX")[0];
            dialog.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("SFX")[0];
            loopSource.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("Music")[0];
        }

        loopSource.clip = MainMenu;
        loopSource.loop = true;
        dialog.loop = true; 
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        

        if (arg0.name.Contains("Menu"))
        {
            GameAudioManager.Instance.loopSource.clip = MainMenu;
            GameAudioManager.Instance.loopSource.Play();
        }
        else
        {
              if (GameAudioManager.Instance.loopSource.clip != MainSong)
            {
                GameAudioManager.Instance.loopSource.clip = MainSong;
                GameAudioManager.Instance.loopSource.Play();
            }
        }
    }


    public void PlayOneShotSFX(AudioClip sfx)
    {
        SfxSource.PlayOneShot(sfx);
    }
    
    public void PlayDialog ()
    {
        // dialog.clip = gertieTalk; 
        // dialog.Play();
        // StartCoroutine(FadeMixerGroup.StartFade( _audioMixer, "SFX",  0.1F, 1));
    }
    public void StopDialog ()
    {
        // dialog.clip = gertieTalk; 
        // StartCoroutine(FadeMixerGroup.StartFade( _audioMixer, "SFX",  0.1F, 0));
    }
}


 
