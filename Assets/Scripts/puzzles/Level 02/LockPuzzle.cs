
using System;
using UnityEngine;

public class LockPuzzle : MonoBehaviour
{
    //Gets
    public int HeartItem => GetSuitAnswer(CardSuit.Heart);
    public int ClubItem => GetSuitAnswer(CardSuit.Club);
    public int SpadeItem =>GetSuitAnswer(CardSuit.Spade);
    public int DiamondItem => GetSuitAnswer(CardSuit.Diamond);

    private int[] userAnswers = new int[4];
    private int[] correctAnswer= new int[4];


    public GameObject closed;
    public GameObject open;

    private void OnEnable()
    {
        var isCorrect = this.isCorrect();
        
        closed.SetActive(!isCorrect);
        open.SetActive(isCorrect);
    }

    void GeneratePuzzleCode()
    {
        //heart postcard [1-9]
        SetSuitRandomValue(CardSuit.Heart,1,10);
        // diamond sail [1-9]
         SetSuitRandomValue(CardSuit.Diamond,1,10);
         // club page [2-9]
         SetSuitRandomValue(CardSuit.Club,2,10);
         // spade clock [1-9]
         SetSuitRandomValue(CardSuit.Spade,1,10);
    }

    public int GetSuitAnswer(CardSuit suit)
    {
    return    correctAnswer[(int) suit];
    }

    public int GetUserSuitAnswer(CardSuit suit)
    {
        return    userAnswers[(int) suit];  
    }

    bool CheckSuit(CardSuit suit)
    {
        return GetSuitAnswer(suit) == GetUserSuitAnswer(suit);
    }

    private void SetSuitRandomValue(CardSuit suit,int minInc, int maxEx)
    {
        correctAnswer[(int) suit] = UnityEngine.Random.Range(minInc,maxEx);
    }
    
    private void SetUserValue(CardSuit suit,int value)
    {
        userAnswers[(int) suit] = value;
    }
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        GeneratePuzzleCode();
        Debug.Log(string.Join(" ", correctAnswer));
    }
    
    
    bool isCorrect()
    {
        return CheckSuit(CardSuit.Heart) &&
               CheckSuit(CardSuit.Club) && 
               CheckSuit(CardSuit.Diamond) &&
               CheckSuit(CardSuit.Spade);
    }
    
    // Button listeners
    

    public void SubmitAnswer()
    {
        if (isCorrect())
        {
            open.SetActive(true);
            closed.SetActive(false);
        }
        
    }

     public void CycleLock(CardSuit suit)
     { const int start = 0;
        const int max = 10;
        var val = GetUserSuitAnswer(suit) + 1;
        val = wrap(val, start, max);
        SetUserValue(suit, val);
    }
     
    


 

    int wrap(int val , int minInc, int maxExc)
    {
        return minInc + (val - minInc) % (maxExc - minInc);
    }

    public enum CardSuit
    {
        Diamond=0,
        Club=1,
        Heart=2, 
        Spade=3
    }
}
