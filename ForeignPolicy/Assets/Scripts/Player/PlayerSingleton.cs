using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerSingleton : MonoBehaviour
{

    private string PlayerID;
    private string PlayerCountry;
    private int Score;
    private int localMonth;
    private int totalMonths;
    private int totalYear;
    private GameObject Player;
    public GameObject World;
    public Text ScreenCountry;
    public Text ScreenBudget;
    public Text ScreenPopulation;
    public Text ScoreLabel;


    // Use this for initialization
    void Start()
    {
        // Saving the players enetered data in a string
        PlayerID = PlayerPrefs.GetString("ID");
        PlayerCountry = PlayerPrefs.GetString("Country");
        StartCoroutine("FindCountry");
        ScreenCountry.text = PlayerCountry;
        localMonth = 0;
        totalMonths = 0;
        totalYear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (World.GetComponent<Calendar>().GetMonth() != localMonth)
        {
            localMonth = World.GetComponent<Calendar>().GetMonth();
            IncreaseTime();
            MonthlyRewards();
        }

        ScoreLabel.text = Score.ToString();
        Score = Standings.GetScore();

        if (Score <= 0)
        {
            Score = 0;
        }

    }
    public void IncreaseBudget(int increase)
    {
        Player.GetComponent<CountryStanding>().Budget = Player.GetComponent<CountryStanding>().Budget + increase;
        ScreenBudget.text = Player.GetComponent<CountryStanding>().Budget.ToString();

    }
    public void DecreaseBudget(int decrease)
    {
        Player.GetComponent<CountryStanding>().Budget = Player.GetComponent<CountryStanding>().Budget - decrease;
        ScreenBudget.text = Player.GetComponent<CountryStanding>().Budget.ToString();
    }
    public void IncreasePopulation(int increase)
    {
        Player.GetComponent<CountryStanding>().Population = Player.GetComponent<CountryStanding>().Population + increase;
        ScreenPopulation.text = Player.GetComponent<CountryStanding>().Population.ToString();

    }
    public void DecreasePopulation(int decrease)
    {
        Player.GetComponent<CountryStanding>().Population = Player.GetComponent<CountryStanding>().Population - decrease;
        ScreenPopulation.text = Player.GetComponent<CountryStanding>().Population.ToString();
    }
    public int GetPopulation()
    {
        return Player.GetComponent<CountryStanding>().Population;
    }
    public long GetBudget()
    {
        return Player.GetComponent<CountryStanding>().Budget;
    }

    public void IncreaseTime()
    {
        if (totalMonths == 11)
        {
            totalMonths = 0;
            totalYear++;
        }
        else
        {
            totalMonths++;
        }
        PlayerPrefs.SetInt("Year", totalYear);
        PlayerPrefs.SetInt("Month", totalMonths);

    }
    public void MonthlyRewards()
    {
        int TotalRewards;
        TotalRewards = (Player.GetComponent<CountryStanding>().Allies.Count * Score) + Player.GetComponent<CountryStanding>().Population;
        Debug.Log(TotalRewards);
        IncreasePopulation(66000);
        IncreaseBudget(TotalRewards);
    }

    IEnumerator FindCountry()
    {
        yield return new WaitForSeconds(1.0f);
        Player = GameObject.Find(PlayerCountry);
        ScreenBudget.text = Player.GetComponent<CountryStanding>().Budget.ToString();
        ScreenPopulation.text = Player.GetComponent<CountryStanding>().Population.ToString();
    }

    public void DestroyTheWorld()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }

}