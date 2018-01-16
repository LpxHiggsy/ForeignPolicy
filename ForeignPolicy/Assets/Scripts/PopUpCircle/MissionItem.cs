using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionItem : MonoBehaviour {

    public MissionClass mission;
    public Canvas missionCanvas;

    // Use this for initialization
    void Start () {
        
        Text desc = this.GetComponentInChildren<Text>();
        desc.text = mission.GetDescription();

        Button[] buttons = this.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(DeclineMission);
        buttons[1].onClick.AddListener(AcceptMission);
    }

    void AcceptMission()
    {
        mission.AcceptMission();
        missionCanvas.enabled = true;
        this.transform.parent.parent.GetComponent<PopUpCircleBehaviour>().OpenPopUpCirclePanel();
        this.gameObject.SetActive(false);
        MissionContainer.AcceptMission(mission.GetID());
    }

    void DeclineMission()
    {
        this.gameObject.SetActive(false);
        MissionContainer.DeleteMissionByID(mission.GetID());
    }
}
