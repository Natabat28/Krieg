using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject card;
    //icons
    public Image bandMoney;
    public Image bandHappiness;
    public Image bandFans;
    public Image bandFaith;
    //impact
    public Image bandMoneyImpact;
    public Image bandHappinessImpact;
    public Image bandFansImpact;
    public Image bandFaithImpact;
    void Update()
    {
        bandMoney.fillAmount = (float)GameManager.bandMoney / GameManager.maxValue;
        bandHappiness.fillAmount = (float)GameManager.bandHappiness / GameManager.maxValue;
        bandFans.fillAmount = (float)GameManager.bandFans / GameManager.maxValue;
        bandFaith.fillAmount = (float)GameManager.bandFaith / GameManager.maxValue;

        //Right
        if (gameManager.direction == "right")
        {
            if(gameManager.currentCard.bMoneyR !=0)
                bandMoneyImpact.transform.localScale = new Vector2(1, 1);
            if (gameManager.currentCard.bHappinessR != 0)
                bandHappinessImpact.transform.localScale = new Vector2(1, 1);
            if (gameManager.currentCard.bFansR != 0)
                bandFansImpact.transform.localScale = new Vector2(1, 1);
            if (gameManager.currentCard.bFaithR != 0)
                bandFaithImpact.transform.localScale = new Vector2(1, 1);
            //Debug.Log("1");
        }
        else if (gameManager.direction == "left")
        {
            if (gameManager.currentCard.bMoneyL != 0)
                bandMoneyImpact.transform.localScale = new Vector2(1, 1);
            if (gameManager.currentCard.bHappinessL != 0)
                bandHappinessImpact.transform.localScale = new Vector2(1, 1);
            if (gameManager.currentCard.bFansL != 0)
                bandFansImpact.transform.localScale = new Vector2(1, 1);
            if (gameManager.currentCard.bFaithL != 0)
                bandFaithImpact.transform.localScale = new Vector2(1, 1);
            //Debug.Log("2");
        }
        else 
        {
            bandMoneyImpact.transform.localScale = new Vector2(0,0);
            bandHappinessImpact.transform.localScale = new Vector2(0, 0);
            bandFansImpact.transform.localScale = new Vector2(0, 0);
            bandFaithImpact.transform.localScale = new Vector2(0, 0);
            //Debug.Log("3");
        }
    }
}
