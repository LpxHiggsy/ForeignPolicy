using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendDefensiveTroopsButton : MonoBehaviour
{
    public GameObject misslePrefab;
    public GameObject Player;
    public Button yourButton;
	// Use this for initialization
	void Start ()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Player = GameObject.Find("Player");
    }

    void TaskOnClick()
    {
        if(Player.GetComponent<PlayerSingleton>().GetBudget() > 2000000)
        {
            GameObject.Find("MissionContainer").GetComponent<MissionContainer>().DisableMissionCanvas();
        
            GameObject clone = Instantiate(misslePrefab, new Vector3(200, 200, 0), Quaternion.identity) as GameObject;
        
            GameObject target = GameObject.Find("GameWorld").GetComponent<WorldManagement>().GetSelectedCountry();

            Standings.Helped(target.name);

			Player.GetComponent<PlayerSingleton>().DecreaseBudget(2000000);

        }
        else
        {
            GameObject.Find("GameWorld").GetComponent<WorldManagement>().NoMoney();
        }
        
    }
}
