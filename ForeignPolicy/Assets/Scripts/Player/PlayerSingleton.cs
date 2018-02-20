using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerSingleton : MonoBehaviour 
{

    private string PlayerID;
    private string PlayerCountry;
    private int Score;
    private GameObject Player;
    public Text ScreenCountry;
    public Text ScreenBudget;
    public Text ScreenPopulation;
    public Text ScoreLabel;

    // Use this for initialization
    void Start ()
    {
        // Saving the players enetered data in a string
        PlayerID = PlayerPrefs.GetString("ID");
        PlayerCountry = PlayerPrefs.GetString("Country");
		ScreenCountry.text = PlayerCountry;
    }
	
	// Update is called once per frame
	void Update()
    {
        Player = GameObject.Find(PlayerCountry);
        ScreenPopulation.text = Player.GetComponent<CountryStanding>().Population.ToString();
        ScreenBudget.text = Player.GetComponent<CountryStanding>().Budget.ToString();
        ScoreLabel.text = Score.ToString();
        Score = Standings.GetScore();
        if(Score <= 0)
        {
            Score = 0;
        }
		
	}
    public void IncreaseBudget(int increase)
    {
        Player.GetComponent<CountryStanding>().Budget = Player.GetComponent<CountryStanding>().Budget + increase;
    }
    public void DecreaseBudget(int decrease)
    {
        Player.GetComponent<CountryStanding>().Budget = Player.GetComponent<CountryStanding>().Budget - decrease;
    }
    public void IncreasePopulation(int increase)
    {
        Player.GetComponent<CountryStanding>().Population = Player.GetComponent<CountryStanding>().Population + increase;
    }
    public void DecreasePopulation(int decrease)
    {
        Player.GetComponent<CountryStanding>().Population = Player.GetComponent<CountryStanding>().Population - decrease;
    }
    public int GetPopulation()
    {
        return Player.GetComponent<CountryStanding>().Population;
    }
    public int GetBudget()
    {
        return Player.GetComponent<CountryStanding>().Budget;
    }
	public void MonthlyRewards()
	{
		int TotalRewards;
		TotalRewards = (Player.GetComponent<CountryStanding>().Allies.Count * Score) + Player.GetComponent<CountryStanding>().Population;
		Debug.Log(TotalRewards);
		IncreasePopulation(66000);
		IncreaseBudget(TotalRewards);
	}

}