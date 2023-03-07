using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;
    //Left
    public int bMoneyL;
    public int bHappinessL;
    public int bFansL;
    public int bFaithL;
    //Right
    public int bMoneyR;
    public int bHappinessR;
    public int bFansR;
    public int bFaithR;
    public void Left()
    {
        Debug.Log(cardName + "swiped left");
        GameManager.bandMoney += bMoneyL;
        GameManager.bandHappiness += bHappinessL;
        GameManager.bandFans += bFansL;
        GameManager.bandFaith += bFaithL;
    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
        GameManager.bandMoney += bMoneyR;
        GameManager.bandHappiness += bHappinessR;
        GameManager.bandFans += bFansR;
        GameManager.bandFaith += bFaithR;

    }
}
