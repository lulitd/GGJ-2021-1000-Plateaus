using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockHeartClue : MonoBehaviour
{
    private const LockPuzzle.CardSuit suit = LockPuzzle.CardSuit.Heart;
    private int value;

    [SerializeField] private TextMeshPro text;

    private string[] morseNumbers =
    {   
            "XXXXX",
            "OXXXX",
            "OOXXX",
            "OOOXX",
            "OOOOX",
            "OOOOO",
            "XOOOO",
            "XXOOO",
            "XXXOO",
            "XXXXO",
    };
    
    // Start is called before the first frame update
    void Start()
    {
        var lockPuzzle = FindObjectOfType<LockPuzzle>();
        value = lockPuzzle.GetSuitAnswer(suit);

        text.text += morseNumbers[value]+" Fran";
        
        Debug.Log(value +morseNumbers[value]);
    }
}
