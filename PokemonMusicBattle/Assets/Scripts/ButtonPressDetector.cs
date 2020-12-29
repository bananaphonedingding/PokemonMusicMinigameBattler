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

    private bool readyForNextAction = false;

    // Start is called before the first frame update
    void Start()
    {
        toggleMenu1Buttons(true);
        toggleMenu2Buttons(false);
        StartCoroutine("InputIndicatorBlinker");

        readyForNextAction = false;
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
        DisableBattleMenu();
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
        for (int i = 1; i < message.Length + 1; i++)
        {
            GameObject.Find("text" + i).GetComponent<SpriteRenderer>().sprite = null;
        }
        for (int i = 1; i < message.Length + 1; i++)
        {
            yield return new WaitForSeconds(.05f);
            string symbolFileName = "";
            char symbol = message[i - 1];
            switch (symbol)
            {
                case 'a':
                    symbolFileName = "al";//.gif";";
                    break;
                case 'b':
                    symbolFileName = "bl";//.gif";";
                    break;
                case 'c':
                    symbolFileName = "cl";//.gif";";
                    break;
                case 'd':
                    symbolFileName = "dl";//.gif";";
                    break;
                case 'e':
                    symbolFileName = "el";//.gif";";
                    break;
                case 'f':
                    symbolFileName = "fl";//.gif";";
                    break;
                case 'g':
                    symbolFileName = "gl";//.gif";";
                    break;
                case 'h':
                    symbolFileName = "hl";//.gif";";
                    break;
                case 'i':
                    symbolFileName = "il";//.gif";";
                    break;
                case 'j':
                    symbolFileName = "jl";//.gif";";
                    break;
                case 'k':
                    symbolFileName = "kl";//.gif";";
                    break;
                case 'l':
                    symbolFileName = "ll";//.gif";";
                    break;
                case 'm':
                    symbolFileName = "ml";//.gif";";
                    break;
                case 'n':
                    symbolFileName = "nl";//.gif";";
                    break;
                case 'o':
                    symbolFileName = "ol";//.gif";";
                    break;
                case 'p':
                    symbolFileName = "pl";//.gif";";
                    break;
                case 'q':
                    symbolFileName = "ql";//.gif";";
                    break;
                case 'r':
                    symbolFileName = "rl";//.gif";";
                    break;
                case 's':
                    symbolFileName = "sl";//.gif";";
                    break;
                case 't':
                    symbolFileName = "tl";//.gif";";
                    break;
                case 'u':
                    symbolFileName = "ul";//.gif";";
                    break;
                case 'v':
                    symbolFileName = "vl";//.gif";";
                    break;
                case 'w':
                    symbolFileName = "wl";//.gif";";
                    break;
                case 'x':
                    symbolFileName = "xl";//.gif";";
                    break;
                case 'y':
                    symbolFileName = "yl";//.gif";";
                    break;
                case 'z':
                    symbolFileName = "zl";//.gif";";
                    break;
                case 'A':
                    symbolFileName = "A";//.gif";";
                    break;
                case 'B':
                    symbolFileName = "B";//.gif";";
                    break;
                case 'C':
                    symbolFileName = "C";//.gif";";
                    break;
                case 'D':
                    symbolFileName = "D";//.gif";";
                    break;
                case 'E':
                    symbolFileName = "E";//.gif";";
                    break;
                case 'F':
                    symbolFileName = "F";//.gif";";
                    break;
                case 'G':
                    symbolFileName = "G";//.gif";";
                    break;
                case 'H':
                    symbolFileName = "H";//.gif";";
                    break;
                case 'I':
                    symbolFileName = "I";//.gif";";
                    break;
                case 'J':
                    symbolFileName = "J";//.gif";";
                    break;
                case 'K':
                    symbolFileName = "K";//.gif";";
                    break;
                case 'L':
                    symbolFileName = "L";//.gif";";
                    break;
                case 'M':
                    symbolFileName = "M";//.gif";";
                    break;
                case 'N':
                    symbolFileName = "N";//.gif";";
                    break;
                case 'O':
                    symbolFileName = "O";//.gif";";
                    break;
                case 'P':
                    symbolFileName = "P";//.gif";";
                    break;
                case 'Q':
                    symbolFileName = "Q";//.gif";";
                    break;
                case 'R':
                    symbolFileName = "R";//.gif";";
                    break;
                case 'S':
                    symbolFileName = "S";//.gif";";
                    break;
                case 'T':
                    symbolFileName = "T";//.gif";";
                    break;
                case 'U':
                    symbolFileName = "U";//.gif";";
                    break;
                case 'V':
                    symbolFileName = "V";//.gif";";
                    break;
                case 'W':
                    symbolFileName = "W";//.gif";";
                    break;
                case 'X':
                    symbolFileName = "X";//.gif";";
                    break;
                case 'Y':
                    symbolFileName = "Y";//.gif";";
                    break;
                case 'Z':
                    symbolFileName = "Z";//.gif";";
                    break;
                case '!':
                    symbolFileName = "!";//.png";
                    break;
                case '?':
                    symbolFileName = "questionmark";//.png";
                    break;
                case ' ':
                    symbolFileName = "";
                    break;
                default:
                    symbolFileName = "!";//.png";
                    break;
            }
            string textSlotName = "text" + i;
            string symbolFilePath = "font/" + symbolFileName;
            Debug.Log("Setting text slot " + textSlotName + " to symbol path " + symbolFilePath);
            GameObject.Find(textSlotName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(symbolFilePath);
        }
        readyForNextAction = true;
    }
}
