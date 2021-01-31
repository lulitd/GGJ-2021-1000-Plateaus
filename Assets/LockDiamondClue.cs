using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDiamondClue : MonoBehaviour
{
    [SerializeField] private LockPuzzle.CardSuit suit = LockPuzzle.CardSuit.Diamond;
    private int value;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var lockPuzzle = FindObjectOfType<LockPuzzle>();
        value = lockPuzzle.GetSuitAnswer(suit);

        var totalOn = 0;


        while (totalOn<value)
        {

            var c = transform.GetChild(Random.Range(0, transform.childCount)).gameObject;

            if (!c.activeSelf)
            {
                c.SetActive(true);
                totalOn++;
            }
        }




    }
    
    
    
}
