using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockClueDisplay : MonoBehaviour
{
    [SerializeField]private LockPuzzle.CardSuit suit;
    private int value;
    private TextMeshPro _textMeshPro;
    [SerializeField] private int  modifify = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        var lockPuzzle = FindObjectOfType<LockPuzzle>();
        value=lockPuzzle.GetSuitAnswer(suit);
        _textMeshPro = GetComponentInChildren<TextMeshPro>();

        if (_textMeshPro) _textMeshPro.text = (value + modifify).ToString() ;
    }

}
