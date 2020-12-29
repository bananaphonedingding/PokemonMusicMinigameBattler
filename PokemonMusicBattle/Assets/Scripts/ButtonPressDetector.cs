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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenu1Buttons(bool enabled)
    {
        fightButton.enabled = enabled;
        bagButton.enabled = enabled;
        runButton.enabled = enabled;
        pokemonButton.enabled = enabled;
    }

    public void toggleMenu2Buttons(bool enabled)
    {
    }

    // Menu 1 buttons
    //*******************************************//
    public void FightButtonPressed()
    {
        Debug.Log("Fight button pressed.");
        menuAnimator.Play("FightPressing");
        buttonSoundPlayer.PlayOneShot(buttonPressSound);
        pikachuSprite.GetComponent<SpriteRenderer>().enabled = false;
        toggleMenu1Buttons(false);
        toggleMenu2Buttons(true);
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

}
