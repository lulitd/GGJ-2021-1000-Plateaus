using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameAudioManager : MonoBehaviour
{
    public  static GameAudioManager Instance; 

    public AudioSource loopSource;
    public AudioSource SfxSource;
    public AudioSource dialog;
    [SerializeField] AudioMixer _audioMixer;

    public AudioClip MainMenu;
    public AudioClip MainSong;
    
    [Header("UI SOUNDS")]
    public AudioClip ButtonClick;
    private bool isUISfxOnCooldown = false;
    public float uisfxCooldown;
    private bool isDialogOnCooldown = false;
  
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
            dialog.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("Dialog")[0];
            loopSource.outputAudioMixerGroup = _audioMixer.FindMatchingGroups("Music")[0];
        }

        loopSource.clip = MainMenu;
        loopSource.loop = true;
        dialog.loop = false; 
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name.Contains("Menu"))
        {
            Instance.loopSource.clip = MainMenu;
            Instance.loopSource.Play();
        }
        else if (Instance.loopSource.clip != MainSong) {
                Instance.loopSource.clip = MainSong;
                Instance.loopSource.Play();
        }

        setupUISFX();
    }

    private void setupUISFX()
    {
        
        
       //FIND ALL BUTTONS
       var buttons = GameObject.FindObjectsOfType<Button>();
       
       for (var i = 0; i < buttons.Length; i++)
       {
           var b = buttons[i];
           b.onClick.AddListener(PlayUISFX);
       }
       
    
    }

    public void PlayUISFX()
    {
        if (isUISfxOnCooldown) return; 
            SfxSource.PlayOneShot(ButtonClick);
            isUISfxOnCooldown = true;
        Invoke(nameof(ResetUISoundCooldown),uisfxCooldown);
    }

    private void ResetUISoundCooldown()
    {
        isUISfxOnCooldown = false; 
    }
    
    private void ResetUIDialogCooldown()
    {
        isDialogOnCooldown = false; 
    }


    public void PlayOneShotSFX(AudioClip sfx)
    {  
        SfxSource.PlayOneShot(sfx);
    }
    
    public void PlayDialog (Character character)
    {   
        if (!character || isDialogOnCooldown) return;
        //StartCoroutine(FadeMixerGroup.StartFade( _audioMixer, "Dialog",  0.01F, 1));
        var clip = character.soundbits[Random.Range(0, character.soundbits.Length)];
        dialog.PlayOneShot(clip);
        isDialogOnCooldown = true;
        Invoke(nameof(ResetUIDialogCooldown),clip.length*0.9f);
    
    }
    public void StopDialog ()
    {
     //   StartCoroutine(FadeMixerGroup.StartFade( _audioMixer, "Dialog",  0.04F, 0));
    }
}


 
