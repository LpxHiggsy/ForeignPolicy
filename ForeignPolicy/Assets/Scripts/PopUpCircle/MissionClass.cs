using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionClass {

    private string _country;
    private string _missionDescription;
    private int _missionId;
    private bool _completed;
    private bool _accepted;

    public MissionClass(int id, string desc, string country)
    {
        _country = country;
        _missionId = id;
        _missionDescription = desc;
        _completed = false;
        _accepted = false;
    }

    public void AcceptMission()
    {
        _accepted = true;
    }

    public void CompleteMission()
    {
        _completed = true;
    }

    public string GetDescription()
    {
        return _missionDescription;
    }

    public int GetID()
    {
        return _missionId;
    }

    public bool IsCompleted()
    {
        return _completed;
    }

    public bool IsAccepted()
    {
        return _accepted;
    }
}
