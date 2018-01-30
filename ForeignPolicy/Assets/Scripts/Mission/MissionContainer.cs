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

        NewMission("Attack", "Brazil", "France");
    }

    void Update()
    {
        if(allMissionList.Count > 0)
        {
            foreach(MissionItem item in allMissionList)
            {
                if(item.timeLeft < 0)
                {
                    DeleteMissionByID(item.mission.id);
                    break;
                }
                else
                {
                    item.Update();
                }
            }
        }
    }

    public void TestMethodForButton()
    {
        NewMission("Test", "Button", "Works");
    }

    public void NewMission(string missionDesc, string requestingCountry, string targetCountry = null)
    {
        string desc;
        if(targetCountry != null)
        {
            desc = string.Format("{0} {1} {2}", requestingCountry, missionDesc, targetCountry);
        }
        else
        {
            desc = string.Format("{0}  {1}", requestingCountry, missionDesc);
        }

        MissionClass missionClass = new MissionClass(idCounter, desc, requestingCountry, targetCountry);

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
        return allMissionList.Find(item => item.mission.id == id);
    }

    public static MissionItem GetCurrentActiveMission()
    {
        return GetMissionByID(currentActiveMisison);
    }

    public void DisableMissionCanvas()
    {
        missionActionCanvas.enabled = false;
    }

    public static void AcceptMission(int id)
    {
        acceptedMissionList.Add(GetMissionByID(id));
        DeleteMissionByID(id);
    }

    public static void DeleteMissionByID(int id)
    {
        var prefab = GetMissionByID(id);
        allMissionList.Remove(prefab);
        Destroy(prefab.gameObject);
        UpdateMissionCounterText();
    }

    private static void UpdateMissionCounterText()
    {
        Text counter = GameObject.Find("MissionCounterText").GetComponent<Text>();
        counter.text = allMissionList.Count.ToString();
    }
}