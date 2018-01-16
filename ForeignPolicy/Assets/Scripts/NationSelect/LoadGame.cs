using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadGame : MonoBehaviour {

    public Text PlayerIDSelection;
    public Text PlayerCountrySelection;

	// Use this for initialization
	void Start () {

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void LoadGameScene()
    {
        PlayerPrefs.SetString("ID", PlayerIDSelection.text);
        PlayerPrefs.SetString("Country", PlayerCountrySelection.text);
        SceneManager.LoadScene("Scenes/GameScene");  
    }

    public void Back()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

}
