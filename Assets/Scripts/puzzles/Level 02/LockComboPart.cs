using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockComboPart : MonoBehaviour, IClickable
{
    public TextMeshPro text;
    public LockPuzzle.CardSuit Suit;

    private LockPuzzle _puzzle;

    public LockPuzzle Puzzle
    {
        get => _puzzle;
        set => _puzzle = value;
    }

    private void OnEnable()
    {
        _puzzle = FindObjectOfType<LockPuzzle>();
        if (!text) text = GetComponent<TextMeshPro>();
        text.text = _puzzle.GetUserSuitAnswer(Suit).ToString();
    }

    public void onClick()
    {
        _puzzle.CycleLock(Suit);
        text.text = _puzzle.GetUserSuitAnswer(Suit).ToString();
    }
}
