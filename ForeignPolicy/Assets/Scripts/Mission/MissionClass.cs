using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionClass {

    public string requestCountry { get; }
    public string targetCountry { get; }
    public string missionDescription { get; }
    public int id { get; }
    public bool completed { get; set; }
    public bool accepted { get; set; }

    public MissionClass(int id, string desc, string request, string target)
    {
        requestCountry = request;
        targetCountry = target;
        this.id = id;
        missionDescription = desc;
        completed = false;
        accepted = false;

    }

    public void AcceptMission()
    {
        accepted = true;
    }

    public void CompleteMission()
    {
        completed = true;
    }
}
