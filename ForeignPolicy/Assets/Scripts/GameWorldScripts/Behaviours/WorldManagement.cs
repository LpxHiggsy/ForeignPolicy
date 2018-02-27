using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using Assets.Scripts.GameWorldScripts.Classes;

public class WorldManagement : MonoBehaviour
{
    public GameObject countryPrefab;
    private string fileName;
    private CoreDataManager _coreDataManager;
    private NewsDataManager _newsDataManager;
    private GameObject _selectedCountry;
    private GameObject _homeCountry;
    public GameObject MoneyCanvas;

    void Start ()
    {
        FPMapper.Initialise();
        _selectedCountry = null;
        
        fileName = PlayerPrefs.GetString("ID");

        _coreDataManager = new CoreDataManager();
        _coreDataManager.setNewCoreDataModel(FPRepository.LoadJSONProfile(fileName +".json", "Profiles/", true));

        _newsDataManager = new NewsDataManager();
        _newsDataManager.setNewsDataModelJSON(FPRepository.LoadFile("News.json", "Config/"));
        
        NewsGenerator newGen = this.gameObject.AddComponent<NewsGenerator>();
        newGen.newsData = _newsDataManager;
        newGen.countries = _coreDataManager.GetListCountriesList().ToArray();

        List <NationDataModel> models = _coreDataManager.GetCountries();

        foreach (NationDataModel ndm in models)
        {
			GameObject country = new GameObject(ndm.Name);
			country.transform.parent = this.transform;
            country.tag = "Country";
            country.AddComponent<CountryTransform>();
			FPMapper.MapCountry (country, ndm);
        }
        
        
        _homeCountry = GameObject.Find(PlayerPrefs.GetString("Country"));
        Standings.Initalise(_coreDataManager.GetListCountriesList());
        Standings.SetHomeCountry(_homeCountry);
        Standings.SetStandings(models);
        
    }

	void Update ()
    {
        _homeCountry.GetComponent<SpriteRenderer>().color = new Color(0, 175, 175);
        if (Standings.GetScore() < 50)
        {
            //End Game;
        }
	}

    private void SaveGame()
    {
        if ((int)Time.timeSinceLevelLoad % 100 == 0)
        {
            Debug.Log("Saving: Test_ProfileAlpha.json");

            List<NationDataModel> ndms = new List<NationDataModel>();
            List<GameObject> gos = GameObject.FindGameObjectsWithTag("Country").ToList();

            foreach (GameObject go in gos)
            {
                NationDataModel ndm = new NationDataModel();
                ndm.Name = go.GetComponent<CountryStanding>().Name;
                ndm.Population = go.GetComponent<CountryStanding>().Population;
                ndm.MapPosition = go.GetComponent<CountryStanding>().MapPosition;
                ndm.Budget = go.GetComponent<CountryStanding>().Budget;
                ndm.Allies = go.GetComponent<CountryStanding>().Allies;
                ndm.Enemies = go.GetComponent<CountryStanding>().Enemies;
                ndm.TradingPartners = go.GetComponent<CountryStanding>().TradingPartners;
                ndms.Add(ndm);
            }
            
            _coreDataManager.setNationData(ndms);
            FPRepository.SaveProfile(fileName + ".json", _coreDataManager.getCoreDataModel());
        }
    }
    
	public void clickCallBack(string str)
	{
        if (_selectedCountry == null)
        {
            _selectedCountry = GameObject.Find(str);
            _selectedCountry.GetComponent<CountryStanding>().Select();
            _selectedCountry.tag = "Target";
        }
        else
        {
            _selectedCountry.GetComponent<CountryStanding>().Deselect();
            _selectedCountry = GameObject.Find(str);
            _selectedCountry.GetComponent<CountryStanding>().Select();
            _selectedCountry.tag = "Target";
        }
        
    }

    public GameObject GetSelectedCountry()
    {

        return _selectedCountry;
    }

    public GameObject GetHomeCountry()
    {

        return _homeCountry;
    }

    public NationDataModel GetCountry(string country)
    { 
        return _coreDataManager.GetCountry(country);
    }

    public void QuitGame()
    {
        SaveGame();
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    public void NoMoneyButton()
    {
        MoneyCanvas.SetActive(false);
    }
    public void NoMoney()
    {
        MoneyCanvas.SetActive(true);
    }

}
