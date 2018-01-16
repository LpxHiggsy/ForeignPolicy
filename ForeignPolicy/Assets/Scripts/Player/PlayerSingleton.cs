using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using Assets.Scripts.GameWorldScripts.Classes;

public class PlayerSingleton : MonoBehaviour {

    private string PlayerID;
    private string PlayerCountry;
    private int Score;
    private int PlayerBudget;
    private int PlayerPopulation;
    public GameObject Player;
    private List<string> PlayerTradingPartners;
    private List<string> PlayerAllies;
    private List<string> PlayerEnemies;
    public Text ScreenCountry;
    public Text ScreenBudget;
    public Text ScreenPopulation;
    public Text ScoreLabel;

    // Use this for initialization
    void Start () {
        
        // Saving the players enetered data in a string

        PlayerID = PlayerPrefs.GetString("ID");
        Debug.Log(PlayerID);
        PlayerCountry = PlayerPrefs.GetString("Country");
        Debug.Log(PlayerCountry);
        Score = Standings.GetScore();
        Player = GameObject.Find(PlayerCountry);


        CoreDataManager PlayerDataManger = new CoreDataManager();
        List<NationDataModel> nationList = new List<NationDataModel>();
        nationList = PlayerDataManger.GetCountries();
        //List<GameObject> gos = GameObject.FindGameObjectsWithTag("Country");

        //still cant get it to pass the countrys data into the script 
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Country"))
        {
            Debug.Log("Entering player Data");
            NationDataModel ndm = new NationDataModel();
            ndm.Name = go.GetComponent<CountryStanding>().Name;
            ndm.Population = go.GetComponent<CountryStanding>().Population;
            ndm.MapPosition = go.GetComponent<CountryStanding>().MapPosition;
            ndm.Budget = go.GetComponent<CountryStanding>().Budget;
            ndm.Allies = go.GetComponent<CountryStanding>().Allies;
            ndm.Enemies = go.GetComponent<CountryStanding>().Enemies;
            ndm.TradingPartners = go.GetComponent<CountryStanding>().TradingPartners;
            nationList.Add(ndm); 
        }

        foreach (NationDataModel nation in nationList)
        {
            if (nation.Name == Player.name)
            {
                PlayerBudget = nation.Budget;
                PlayerPopulation = nation.Population;
                PlayerAllies = nation.Allies;
                PlayerTradingPartners = nation.TradingPartners;
                PlayerEnemies = nation.Enemies;
                Debug.Log(PlayerBudget);
                Debug.Log(PlayerPopulation);
            }

        }
    }
	
	// Update is called once per frame
	void Update () {

        ScreenCountry.text = PlayerCountry;
        ScreenPopulation.text = PlayerPopulation.ToString();
        ScreenBudget.text = PlayerBudget.ToString();
        ScoreLabel.text = Score.ToString();

        if(Score <= 0)
        {
            Score = 0;
        }
		
	}

    // might want to put theses methods in a world manager
    //public void IncreaseScore(int increase)
    //{
    //    Score = Score + increase;
        
    //}
    //public void DecreaseScore(int decrease)
    //{
    //    Score = Score - decrease;
        
    //}
    //public void ResetScore()
    //{
    //    Score = 0;
        
    //}
    public void IncreaseBudget(int increase)
    {
        PlayerBudget = PlayerBudget + increase;
        SavePlayerData();
        
    }
    public void DecreaseBudget(int decrease)
    {
        PlayerBudget = PlayerBudget + decrease;
        SavePlayerData();
        
    }
    public void IncreasePopulation(int increase)
    {
        PlayerPopulation = PlayerPopulation + increase;
        SavePlayerData();

    }
    public void DecreasePopulation(int decrease)
    {
        PlayerPopulation = PlayerPopulation + decrease;
        SavePlayerData();

    }

    public void AddAlly(string add)
    {
        PlayerAllies.Add(add);
        SavePlayerData();
    }
    public void RemoveAlly(string remove)
    {
        PlayerAllies.Remove(remove);
        SavePlayerData();
    }
    public void AddTradingPartner(string add)
    {
        PlayerTradingPartners.Add(add);
        SavePlayerData();
    }
    public void RemoveTradingPartner(string remove)
    {
        PlayerTradingPartners.Remove(remove);
        SavePlayerData();
    }
    public void AddEnemy(string add)
    {
        PlayerEnemies.Add(add);
        SavePlayerData();
    }
    public void RemoveEnemy(string remove)
    {
        PlayerEnemies.Remove(remove);
        SavePlayerData();
    }

    void SavePlayerData()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Country"))
        {
            if (go.name == PlayerCountry)
            {
                go.GetComponent<CountryStanding>().Budget = PlayerBudget;
                go.GetComponent<CountryStanding>().Population = PlayerPopulation;
                go.GetComponent<CountryStanding>().Allies = PlayerAllies;
                go.GetComponent<CountryStanding>().TradingPartners = PlayerTradingPartners;
                go.GetComponent<CountryStanding>().Enemies = PlayerEnemies;

                Debug.Log("Player Data saved");
            }
        }

    }

}
