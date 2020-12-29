using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressDetector : MonoBehaviour
{

    public Animator menuAnimator;
    public AudioSource buttonSoundPlayer;
    public AudioClip buttonPressSound;
    public AudioClip buttonRejectSound;
    public GameObject pikachuSprite;

    public Button fightButton;
    public Button bagButton;
    public Button runButton;
    public Button pokemonButton;

    public Button cancelButton;
    public Button tackleButton;

    public GameObject inputIndicator;
    private bool inputIndicatorShouldBlink = true;
    private bool inputIndicatorVisible = true;

    private const string BATTLE_EVENT_TYPE_DISPLAY_MESSAGE = "BATTLE_EVENT_TYPE_DISPLAY_MESSAGE";
    private const string BATTLE_EVENT_TYPE_PLAY_ANIMATION = "BATTLE_EVENT_TYPE_PLAY_ANIMATION";

    private struct BattleEvent
    {
        string type;
        string message;
        string animationName;
    }

    // Start is called before the first frame update
    void Start()
    {
        toggleMenu1Buttons(true);
        toggleMenu2Buttons(false);
        StartCoroutine("InputIndicatorBlinker");
        
        IEnumerator initialMessage = DisplayMessage("What will PIKACHU do?");
        StartCoroutine(initialMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableMenu(int menuNum)
    {
        if (menuNum == -1)
        {
            toggleMenu1Buttons(false);
            toggleMenu2Buttons(false);
            inputIndicatorShouldBlink = false;
        }
        else if (menuNum == 1)
        {
            toggleMenu1Buttons(true);
            toggleMenu2Buttons(false);
            inputIndicatorShouldBlink = true;
        }
        else if (menuNum == 2)
        {
            toggleMenu1Buttons(false);
            toggleMenu2Buttons(true);
            inputIndicatorShouldBlink = true;
        }
    }

    public void toggleMenu1Buttons(bool enabled)
    {
        fightButton.gameObject.SetActive(enabled);
        bagButton.gameObject.SetActive(enabled);
        runButton.gameObject.SetActive(enabled);
        pokemonButton.gameObject.SetActive(enabled);
    }

    public void toggleMenu2Buttons(bool enabled)
    {
        cancelButton.gameObject.SetActive(enabled);
        tackleButton.gameObject.SetActive(enabled);
    }

    // Menu 1 buttons
    //*******************************************//
    public void FightButtonPressed()
    {
        Debug.Log("Fight button pressed.");
        menuAnimator.Play("FightPressing");
        buttonSoundPlayer.PlayOneShot(buttonPressSound);
        pikachuSprite.GetComponent<SpriteRenderer>().enabled = false;
        enableMenu(2);
    }
    public void BagButtonPressed()
    {
        Debug.Log("Bag button pressed.");
        buttonSoundPlayer.PlayOneShot(buttonRejectSound);
    }
    public void RunButtonPressed()
    {
        Debug.Log("Run button pressed.");
        buttonSoundPlayer.PlayOneShot(buttonRejectSound);
    }
    public void PokemonButtonPressed()
    {
        Debug.Log("Pokemon button pressed.");
        buttonSoundPlayer.PlayOneShot(buttonRejectSound);
    }
    //*******************************************//

    // Menu 2 buttons
    //*******************************************//
    public void TackleButtonPressed()
    {
        Debug.Log("Tackle button pressed.");
        menuAnimator.Play("TacklePressing");
        buttonSoundPlayer.PlayOneShot(buttonPressSound);
        IEnumerator tackleMessageDisplay = DisplayMessage("PIKACHU used-Tackle!");
        StartCoroutine(tackleMessageDisplay);
    }
    public void CancelButtonPressed()
    {
        Debug.Log("Cancel button pressed.");
        menuAnimator.Play("CancelPressing");
        buttonSoundPlayer.PlayOneShot(buttonPressSound);
        IEnumerator unhidePikachu = UnhidePikachu(.35f);
        StartCoroutine(unhidePikachu);
    }
    private IEnumerator UnhidePikachu(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        pikachuSprite.GetComponent<SpriteRenderer>().enabled = true;
        enableMenu(1);
    }
    //*******************************************//

    public IEnumerator InputIndicatorBlinker()
    {
        while (true)
        {
            if (inputIndicatorVisible)
            {
                yield return new WaitForSeconds(.75f);
            }
            else
            {
                yield return new WaitForSeconds(.25f);
            }
            
            if (inputIndicatorShouldBlink)
            {
                inputIndicatorVisible = !inputIndicatorVisible;
                inputIndicator.SetActive(inputIndicatorVisible);
            }
            else
            {
                inputIndicatorVisible = false;
                inputIndicator.SetActive(inputIndicatorVisible);
            }
        }
    }

    public void DisableBattleMenu()
    {
        menuAnimator.Play("BattleEventsPlaying");
        enableMenu(-1);
    }

    public void EnableBattleMenu()
    {
        menuAnimator.Play("BattleEventsPlayed");
        enableMenu(2);
    }

    IEnumerator DisplayMessage(string message)
    {
        for (int i = 1; i < 50 + 1; i++)
        {
            GameObject.Find("text" + i).GetComponent<SpriteRenderer>().sprite = null;
        }
        int textPosition = 1;
        for (int i = 1; i < message.Length + 1; i++)
        {
            yield return new WaitForSeconds(.05f);
            string symbolFileName = "";
            char symbol = message[i - 1];
            switch (symbol)
            {
                case 'a':
                    symbolFileName = "al";
                    break;
                case 'b':
                    symbolFileName = "bl";
                    break;
                case 'c':
                    symbolFileName = "cl";
                    break;
                case 'd':
                    symbolFileName = "dl";
                    break;
                case 'e':
                    symbolFileName = "el";
                    break;
                case 'f':
                    symbolFileName = "fl";
                    break;
                case 'g':
                    symbolFileName = "gl";
                    break;
                case 'h':
                    symbolFileName = "hl";
                    break;
                case 'i':
                    symbolFileName = "il";
                    break;
                case 'j':
                    symbolFileName = "jl";
                    break;
                case 'k':
                    symbolFileName = "kl";
                    break;
                case 'l':
                    symbolFileName = "ll";
                    break;
                case 'm':
                    symbolFileName = "ml";
                    break;
                case 'n':
                    symbolFileName = "nl";
                    break;
                case 'o':
                    symbolFileName = "ol";
                    break;
                case 'p':
                    symbolFileName = "pl";
                    break;
                case 'q':
                    symbolFileName = "ql";
                    break;
                case 'r':
                    symbolFileName = "rl";
                    break;
                case 's':
                    symbolFileName = "sl";
                    break;
                case 't':
                    symbolFileName = "tl";
                    break;
                case 'u':
                    symbolFileName = "ul";
                    break;
                case 'v':
                    symbolFileName = "vl";
                    break;
                case 'w':
                    symbolFileName = "wl";
                    break;
                case 'x':
                    symbolFileName = "xl";
                    break;
                case 'y':
                    symbolFileName = "yl";
                    break;
                case 'z':
                    symbolFileName = "zl";
                    break;
                case 'A':
                    symbolFileName = "A";
                    break;
                case 'B':
                    symbolFileName = "B";
                    break;
                case 'C':
                    symbolFileName = "C";
                    break;
                case 'D':
                    symbolFileName = "D";
                    break;
                case 'E':
                    symbolFileName = "E";
                    break;
                case 'F':
                    symbolFileName = "F";
                    break;
                case 'G':
                    symbolFileName = "G";
                    break;
                case 'H':
                    symbolFileName = "H";
                    break;
                case 'I':
                    symbolFileName = "I";
                    break;
                case 'J':
                    symbolFileName = "J";
                    break;
                case 'K':
                    symbolFileName = "K";
                    break;
                case 'L':
                    symbolFileName = "L";
                    break;
                case 'M':
                    symbolFileName = "M";
                    break;
                case 'N':
                    symbolFileName = "N";
                    break;
                case 'O':
                    symbolFileName = "O";
                    break;
                case 'P':
                    symbolFileName = "P";
                    break;
                case 'Q':
                    symbolFileName = "Q";
                    break;
                case 'R':
                    symbolFileName = "R";
                    break;
                case 'S':
                    symbolFileName = "S";
                    break;
                case 'T':
                    symbolFileName = "T";
                    break;
                case 'U':
                    symbolFileName = "U";
                    break;
                case 'V':
                    symbolFileName = "V";
                    break;
                case 'W':
                    symbolFileName = "W";
                    break;
                case 'X':
                    symbolFileName = "X";
                    break;
                case 'Y':
                    symbolFileName = "Y";
                    break;
                case 'Z':
                    symbolFileName = "Z";
                    break;
                case '!':
                    symbolFileName = "!";
                    break;
                case '?':
                    symbolFileName = "questionmark";
                    break;
                case ' ':
                    symbolFileName = "";
                    break;
                case '-':
                    textPosition = 26;
                    continue;
                default:
                    symbolFileName = "!";
                    break;
            }
            string textSlotName = "text" + textPosition;
            string symbolFilePath = "font/" + symbolFileName;
            Debug.Log("Setting text slot " + textSlotName + " to symbol path " + symbolFilePath);
            GameObject.Find(textSlotName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(symbolFilePath);
            textPosition += 1;
        }
    }
}
