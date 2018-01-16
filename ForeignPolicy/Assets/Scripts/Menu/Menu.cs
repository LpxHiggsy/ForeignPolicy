using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.GameWorldScripts.Classes;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject helpMenuHolder;
    public GameObject optionsMenuHolder;
    public GameObject playMenuHolder;
    public GameObject loadGameHolder;
    public GameObject newGameHolder;
    public Slider[] volumeSliders;
    public Text LoadGameFile;
    public Text LoadGameCountry;
    public GameObject Help1;
    public GameObject Help2;
    public GameObject Help3;
    public GameObject Help4;
    public GameObject Help5;
    private int HelpTrans;


    void Start()
    {
        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[0].value = AudioManager.instance.sfxVolumePercent;
        HelpTrans = 1;
    }

    public void Continue()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Scenes/Nation Selection");
    }
    public void LoadGame()
    {
        PlayerPrefs.SetString("ID", LoadGameFile.text);
        PlayerPrefs.SetString("Country", LoadGameCountry.text);
        SceneManager.LoadScene("Scenes/GameScene");
    }
    public void MainMenu()
    {
        mainMenuHolder.SetActive(true);
        helpMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        playMenuHolder.SetActive(false);
        newGameHolder.SetActive(false);
        loadGameHolder.SetActive(false);
    }
    public void HelpMenu()
    {
        mainMenuHolder.SetActive(false);
        helpMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
        playMenuHolder.SetActive(false);
        newGameHolder.SetActive(false);
        loadGameHolder.SetActive(false);
    }
    public void OptionsMenu()
    {
        mainMenuHolder.SetActive(false);
        helpMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
        playMenuHolder.SetActive(false);
        newGameHolder.SetActive(false);
        loadGameHolder.SetActive(false);
    }
    public void PlayMenu()
    {
        mainMenuHolder.SetActive(false);
        helpMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        playMenuHolder.SetActive(true);
        newGameHolder.SetActive(false);
        loadGameHolder.SetActive(false);
    }
    public void NewGameMenu()
    {
        mainMenuHolder.SetActive(false);
        helpMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        playMenuHolder.SetActive(false);
        newGameHolder.SetActive(true);
        loadGameHolder.SetActive(false);
    }
    public void LoadGameMenu()
    {
        mainMenuHolder.SetActive(false);
        helpMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
        playMenuHolder.SetActive(false);
        newGameHolder.SetActive(false);
        loadGameHolder.SetActive(true);
    }

    public void HelpScreen()
    {
        HelpTrans++;

        if(HelpTrans == 6)
        {
            HelpTrans = 1;
        }

        if(HelpTrans == 1)
        {
            Help1.SetActive(true);
            Help2.SetActive(false);
            Help3.SetActive(false);
            Help4.SetActive(false);
            Help5.SetActive(false);
        }
        if(HelpTrans == 2)
        {
            Help1.SetActive(false);
            Help2.SetActive(true);
            Help3.SetActive(false);
            Help4.SetActive(false);
            Help5.SetActive(false);
        }
        if(HelpTrans == 3)
        {
            Help1.SetActive(false);
            Help2.SetActive(false);
            Help3.SetActive(true);
            Help4.SetActive(false);
            Help5.SetActive(false);
        }
        if(HelpTrans == 4)
        {
            Help1.SetActive(false);
            Help2.SetActive(false);
            Help3.SetActive(false);
            Help4.SetActive(true);
            Help5.SetActive(false);
        }
        if (HelpTrans == 5)
        {
            Help1.SetActive(false);
            Help2.SetActive(false);
            Help3.SetActive(false);
            Help4.SetActive(false);
            Help5.SetActive(true);
        }

    }

    public void SetMasterVolume(float value)
    {
       AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }
    public void SetMusicVolume(float value)
    {
       AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }
    public void SetSfxVolume(float value)
    {
       AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}
