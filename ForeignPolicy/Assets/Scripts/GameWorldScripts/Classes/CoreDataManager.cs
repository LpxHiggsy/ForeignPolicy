using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.GameWorldScripts.Classes;

public class CoreDataManager {

    private CoreDataModel _coreDataModel;

    void CoreDataModel()
    {
        _coreDataModel = new CoreDataModel();
    }
    public void setNewCoreDataModel(string coreDataModel)
    {
        _coreDataModel = JsonUtility.FromJson<CoreDataModel>(coreDataModel);
    }
    public void setNationData(List<NationDataModel> countries)
    {
        _coreDataModel.NationData = countries;
    }

    public List<NationDataModel> GetCountries()
    {
        return _coreDataModel.NationData;
    }

    public NationDataModel GetCountry(string country)
    {
        return _coreDataModel.NationData.Where(x => x.Name == country) as NationDataModel;
    }

    public List<string> GetListCountriesList()
    {
        List<string> nations = new List<string>();

        foreach(NationDataModel nation in _coreDataModel.NationData)
        {
            nations.Add(nation.Name);
        }
        return nations;
    }

    public CoreDataModel getCoreDataModel()
    {
        return _coreDataModel;
    }
}
