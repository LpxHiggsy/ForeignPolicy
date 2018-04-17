using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class TutorialManager : MonoBehaviour {
    
    public List<Tutorial> _tutorials;
	// Use this for initialization
	void Start () {
        
        _tutorials = new List<Tutorial>();
        //_tutorials.Add(new Tutorial("tutorial_CountrySelect", "Tut1"));
        //_tutorials.RemoveAll(x => x.Completed);
    }
	
	// Update is called once per frame
	void Update () {
        		
	}
}
