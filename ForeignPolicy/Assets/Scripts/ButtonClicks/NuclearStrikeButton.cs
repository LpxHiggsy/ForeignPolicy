using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NuclearStrikeButton : MonoBehaviour
{
    public GameObject misslePrefab;
    public Button yourButton;
	// Use this for initialization
	void Start ()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick()
    {
        GameObject.Find("MissionContainer").GetComponent<MissionContainer>().DisableMissionCanvas();
        GameObject clone = Instantiate(misslePrefab, new Vector3(200, 200, 0), Quaternion.identity) as GameObject;

        GameObject target = GameObject.Find("GameWorld").GetComponent<WorldManagement>().GetSelectedCountry();

        Standings.Attacked(target.name);
    }
}
