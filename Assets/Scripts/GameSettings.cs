using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update
    private KeyCode escape = KeyCode.Escape;

    private GameObject quitMenu;
    private bool isMenuActive;

    private const string RETURN_TO_MENU = "RETURN TO MENU";
    private const string QUIT_MENU = "QUIT";

    public static GameSettings Instance = null; 

    [SerializeField]private TextMeshProUGUI gameLabel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Application.targetFrameRate = 24;
        quitMenu = transform.GetChild(0)?.gameObject;
        isMenuActive = quitMenu.activeSelf;
        
        SetMenuTextBasedOnScene();  
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        SetMenuTextBasedOnScene();
    }
    
    void SetMenuTextBasedOnScene()
    {
        if (gameLabel)
        gameLabel.text = SceneManager.GetActiveScene().buildIndex == 0 ? QUIT_MENU : RETURN_TO_MENU; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleMenu();
        }
    }
    
    public void toggleMenu()
    {
        quitMenu?.SetActive(!isMenuActive);
        isMenuActive = quitMenu.activeSelf;

        Time.timeScale = isMenuActive ? 0 : 1; 
    }


    public void ReturnOrQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) QuitGame();
        else ReturnToMenu();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        toggleMenu();
    }
}
