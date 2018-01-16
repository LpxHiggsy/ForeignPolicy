using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.GameWorldScripts.Classes;
using UnityEngine.SceneManagement;

public class PlayerDataGame : MonoBehaviour {

    public Text PlayerID;
    public string fileName;
    private CoreDataManager _coreDataManager;
    public string saveGameName;

	// Use this for initialization
	void Start () {

        PlayerID.text = PlayerPrefs.GetString("ID");
        fileName = PlayerPrefs.GetString("ID");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void LoadGame()
    {
        FPRepository.LoadFile(PlayerID.text, "Profiles/");
        SceneManager.LoadScene("Scenes/GameScene");
    }
}
