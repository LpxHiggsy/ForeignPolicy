using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MissionContainer : MonoBehaviour
{

    public Canvas missionActionCanvas;
    public GameObject container;
    public MissionItem missionPrefab;

    private static List<MissionItem> allMissionList;
    private static List<MissionItem> acceptedMissionList;

    private static int idCounter;
    private static int currentActiveMisison;

    // Use this for initialization
    void Start()
    {
        idCounter = 0;
        currentActiveMisison = 0;
        allMissionList = new List<MissionItem>();
        acceptedMissionList = new List<MissionItem>();
        missionActionCanvas.enabled = false;

        NewMission("Attack France");
    }

    public void NewMission(string missionDesc)
    {
        MissionClass missionClass = new MissionClass(idCounter, missionDesc, "France");
        MissionItem missionItem = (MissionItem)Instantiate(missionPrefab);
        missionItem.transform.SetParent(container.transform);
        missionItem.mission = missionClass;
        missionItem.missionCanvas = missionActionCanvas;

        allMissionList.Add(missionItem);
        idCounter++;
        UpdateMissionCounterText();
    }

    public static MissionItem GetMissionByID(int id)
    {
       
        return allMissionList.Find(item => item.mission.GetID() == id);
    }

    public static MissionItem GetCurrentActiveMission()
    {
        return GetMissionByID(currentActiveMisison);
    }

    public static void AcceptMission(int id)
    {
        acceptedMissionList.Add(GetMissionByID(id));
        DeleteMissionByID(id);
    }

    public static void DeleteMissionByID(int id)
    {
        allMissionList.Remove(GetMissionByID(id));
        Debug.Log("DeleteMisison");
        UpdateMissionCounterText();
    }

    private static void UpdateMissionCounterText()
    {
        Text counter = GameObject.Find("MissionCounterText").GetComponent<Text>();

        counter.text = allMissionList.Count.ToString();
    }

    public void DisableMissionCanvas()
    {
        
        missionActionCanvas.enabled = false;
    } 
}