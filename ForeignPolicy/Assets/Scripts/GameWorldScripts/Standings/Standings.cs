using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Assets.Scripts.GameWorldScripts.Classes;

public class Standings {
    
    static private Dictionary<string, List<Dictionary<string, int>>> _nationsStandings;
    static private int _standingScore;
    static private string _homeCountryName;
    static private List<string> _allies;
    static private List<string> _enemies;

    // Use this for initialization
    static public void Initalise(List<string> nations)
    {
        _nationsStandings = new Dictionary<string, List<Dictionary<string, int>>>();
        _standingScore = 0;

        List<Dictionary<string, int>> items = StringListToDictionary(nations);
        _allies = new List<string>();
        _enemies = new List<string>();

        foreach (string nation in nations)
        {
            _nationsStandings.Add(nation, new List<Dictionary<string, int>>(items));
        }

        Debug.Log("Pause");
    }

    static public void SetStandings(List<NationDataModel> nationList)
    {
        foreach(NationDataModel nation in nationList)
        {
            
            foreach(string allie in nation.Allies)
            {
                int index = _nationsStandings[nation.Name].FindIndex(x => x.ContainsKey(allie));
                if(index != -1)
                {
                    if (nation.Name == _homeCountryName)
                    {
                        _allies.Add(allie);
                    }

                    _nationsStandings[nation.Name][index] = new Dictionary<string, int> { { allie, 1 } };
                    _standingScore += 1;
                }
                

            }

            foreach (string enemy in nation.Enemies)
            {
                int index = _nationsStandings[nation.Name].FindIndex(x => x.ContainsKey(enemy));
                if (index != -1)
                {
                    if (nation.Name == _homeCountryName)
                    {
                        _enemies.Add(enemy);
                    }

                    _nationsStandings[nation.Name][index] = new Dictionary<string, int> { { enemy, -1 } };
                    _standingScore += -1;
                }
            }
        }
        
    }

    static public void SetHomeCountry(GameObject home)
    {
        _homeCountryName = home.name;
    }

    static public int GetScore()
    {
        return _standingScore;
    }

    static public string GetStandings(string country)
    {
        int index = _nationsStandings[_homeCountryName].FindIndex(x => x.ContainsKey(country));
       
        int value = _nationsStandings[_homeCountryName][index][country];

        switch (value)
        {
            case (-1):
                {
                    return "Enemy";
                }
            case (0):
                {
                    return "Neutral";
                }
            case (1):
                {
                    return "Allie";
                }
            default:
                {
                    return "Unknown";
                }
        }
    }

    static public void Attacked(string country)
    {
        AddEnemy(_homeCountryName, country);
    }

    static public void Helped(string country)
    {
        AddAllie(_homeCountryName, country);
    }

    static public void AddAllie(string country1, string country2)
    {
        int index = _nationsStandings[country1].FindIndex(x => x.ContainsKey(country2));
        if (index != -1 && _nationsStandings[country1][index][country2] != 1)
        {
            _nationsStandings[country1][index] = new Dictionary<string, int> { { country2, 1 } };
            _standingScore += 1;
        }


        int index2 = _nationsStandings[country2].FindIndex(x => x.ContainsKey(country1));
        if (index2 != -1 && _nationsStandings[country2][index2][country1] != 1)
        {
            _nationsStandings[country2][index2] = new Dictionary<string, int> { { country1, 1 } };
            _standingScore += 1;
        }
    }
    static public void AddEnemy(string country1, string country2)
    {
        int index = _nationsStandings[country1].FindIndex(x => x.ContainsKey(country2));
        if (index != -1 && _nationsStandings[country1][index][country2] != -1)
        {
            _nationsStandings[country1][index] = new Dictionary<string, int> { { country2, -1 } };
            _standingScore += -1;
        }


        int index2 = _nationsStandings[country2].FindIndex(x => x.ContainsKey(country1));
        if (index2 != -1 && _nationsStandings[country2][index2][country1] != -1)
        {
            _nationsStandings[country2][index] = new Dictionary<string, int> { { country1, -1 } };
            _standingScore += -1;
        }
    }
    static public void AddNeutral(string country1, string country2)
    {
        int index = _nationsStandings[country1].FindIndex(x => x.ContainsKey(country2));
        if (index != -1 && _nationsStandings[country1][index][country2] != 0)
        {
            if (_nationsStandings[country1][index][country2] == 1)
            {
                _standingScore += -1;
            }
            else
            {
                _standingScore += 1;
            }
            _nationsStandings[country1][index] = new Dictionary<string, int> { { country2, 0 } };

        }


        int index2 = _nationsStandings[country2].FindIndex(x => x.ContainsKey(country1));
        if (index2 != -1 && _nationsStandings[country2][index2][country1] != 0)
        {
            if(_nationsStandings[country2][index][country1] == 1)
            {
                _standingScore += -1;
            }
            else
            {
                _standingScore += 1;
            }
            _nationsStandings[country2][index] = new Dictionary<string, int> { { country1, 0 } };
        }
    }

    static private List<Dictionary<string, int>> StringListToDictionary(List<string> list)
    {
        List<Dictionary<string, int>> dicList = new List<Dictionary<string, int>>();

        foreach(string item in list)
        {
            Dictionary<string, int> newItem = new Dictionary<string, int> { { item, 0 } };
            dicList.Add(newItem);
        }

        return dicList;

    }
}
