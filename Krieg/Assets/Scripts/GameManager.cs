using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static int bandMoney = 10;
    public static int bandHappiness = 10;
    public static int bandFans;
    public static int bandFaith = 10;
    public static int maxValue = 100;
    public int minValue = 0;
    public GameObject cardGameObject;
    public SpriteRenderer cardRenderer;
    public CardController mainCardController;
    public ResourceManager resourceManager;
    public Vector2 defaultPositionCard;
    public float fMovingSpeed = 1f;
    public float fMargin;
    public float fTrigger;
    public float divideValue;
    float alphaText;
    public Color textColor;
    Vector2 pos;
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    public string direction;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;

    private int rollDice;
    private int previousRoll;

    [HideInInspector] public bool isGameRunning;
    [HideInInspector] public bool isGameStarted;
    [HideInInspector] public bool isGamePaused;
    [SerializeField] GameObject startMenu;
    void Start()
    {
        LoadCard(testCard);
        isGameRunning = false;
        isGameStarted = false;
        isGamePaused = true;
    }
    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else 
        { 
            actionQuote.text = rightQuote; 
        }

    }
    void Update()
    {
        if (isGameStarted)
        {
            if (!isGamePaused)
            {
                textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fMargin) / divideValue, 1);
                if (cardGameObject.transform.position.x > fTrigger)
                {
                    direction = "right";
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (isGameRunning)
                        {
                            currentCard.Right();
                            NewCard();
                        }
                        else
                        {
                            hardRestart();
                        }

                    }
                }
                else if (cardGameObject.transform.position.x > fMargin)
                {
                    direction = "right";
                }
                else if (cardGameObject.transform.position.x > -fMargin)
                {
                    direction = "none";
                    textColor.a = 0;
                }
                else if (cardGameObject.transform.position.x > -fTrigger)
                {
                    direction = "left";
                }
                else
                {
                    direction = "left";
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (isGameRunning)
                        {
                            currentCard.Left();
                            NewCard();
                        }
                        else
                        {
                            hardRestart();
                        }
                    }
                }
                UpdateDialogue();
                if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 pos = new Vector2(mousePos.x, cardGameObject.transform.position.y);
                    //Vector2 pos = mousePos;
                    cardGameObject.transform.position = pos;
                }
                else
                {
                    cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, new Vector2(0, 0), fMovingSpeed);

                }
                display.text = "" + textColor.a;
            }
        }
    }
    public void LoadCard(Card card)
    {
        cardRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;


    }
    public void NewCard()
    {
        if (isGameRunning)
        {
            checkResources();
        }
        if (isGameRunning)
        {
            do
            {
                rollDice = Random.Range(0, resourceManager.cards.Length);
            } while (rollDice == previousRoll);
            previousRoll = rollDice;
            LoadCard(resourceManager.cards[rollDice]);
        }
    }

    private void checkResources()
    {
        string code = "";

        if (bandMoney <= minValue)      { code += "Mon"; }
        if (bandHappiness <= minValue)  { code += "Hap"; }
        if (bandFaith <= minValue)      { code += "Fai"; }
        Debug.Log(code);
        if(code.Length > 0)
        {
            endingCheck(code, false);
        }

        if (bandMoney >= maxValue)      { code += "Mon"; }
        if (bandHappiness >= maxValue)  { code += "Hap"; }
        if (bandFans >= maxValue)       { code += "Fan"; }
        if (bandFaith >= maxValue)      { code += "Fai"; }
        Debug.Log(code);

        if(code.Length >= 12)
        {
            endingCheck(code, true);
        }
    }
    private void endingCheck(string code, bool victory)
    {
        if (victory)
        {
            switch (code)
            {
                case "MonHapFanFai":
                    LoadCard(resourceManager.endCards[1]);
                    break;

                case "MonHapFan":
                    LoadCard(resourceManager.endCards[1]);
                    break;

                case "MonHapFai":
                    LoadCard(resourceManager.endCards[1]);
                    break;

                case "MonFanFai":
                    LoadCard(resourceManager.endCards[1]);
                    break;

                case "HapFanFai":
                    LoadCard(resourceManager.endCards[1]);
                    break;

                default:
                    LoadCard(resourceManager.endCards[1]);
                    break;
            }
        }
        else
        {
            switch (code)
            {
                case "MonHapFai":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                case "MonHap":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                case "MonFai":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                case "Mon":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                case "HapFai":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                case "Hap":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                case "Fai":
                    LoadCard(resourceManager.endCards[0]);
                    break;

                default:
                    LoadCard(resourceManager.endCards[0]);
                    break;
            }
        }
        isGameRunning = false;
        Debug.Log("Game Ended");
    }

    public void restart()
    {
        isGameStarted = true;
        isGameRunning = true;
        bandMoney = 10;
        bandHappiness = 10;
        bandFans = 0;
        bandFaith = 10;
        LoadCard(testCard);
    }

    private void hardRestart()
    {
        restart();
        startMenu.SetActive(true);
        startMenu.GetComponent<StartMenu>().hardReset();
    }

}

