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

    // Start is called before the first frame update
    void Start()
    {
        toggleMenu1Buttons(true);
        toggleMenu2Buttons(false);
        StartCoroutine("InputIndicatorBlinker");
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
}
