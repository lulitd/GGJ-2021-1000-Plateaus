using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDialog", menuName = "ScriptableObjects/Dialog", order = 1)]
public class CharacterDialog : ScriptableObject
{
    public Sprite CharacterPortrait;
    public Dialog[] lines;
    public bool leftSide;
}
