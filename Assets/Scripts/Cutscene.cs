using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneData", menuName = "ScriptableObjects/Cutscene", order = 1)]
public class Cutscene : ScriptableObject
{
    public Sprite background;
    public CharacterDialog[] _dialogs;
    public string LoadSceneInBackground; 
}

