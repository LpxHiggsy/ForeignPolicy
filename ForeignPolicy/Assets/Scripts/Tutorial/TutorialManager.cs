using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    private bool _completed;
    private List<Tutorial> _tutorials;

	// Use this for initialization
	void Start () {

        _completed = CheckForCompletion();

        _tutorials = new List<Tutorial>();
        
	}
	
	// Update is called once per frame
	void Update () {
        		
	}

    private bool CheckForCompletion()
    {
        if (PlayerPrefs.GetString("tutorialCompleted") == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
