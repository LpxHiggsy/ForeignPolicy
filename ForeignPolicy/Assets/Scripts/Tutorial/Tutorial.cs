using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private static class TutComplete 
    {
        public const int True = 1;
        public const int False = 2;
    }

    public string Name { get; private set; }
    public bool Completed {get; private set;}
    private Canvas _canvas;

    public Tutorial(string name, string prefabLocation)
    {
        Name = name;
        Completed = false;
        _canvas = Instantiate(Resources.Load(prefabLocation,typeof(Canvas))) as Canvas;

        switch (PlayerPrefs.GetInt(name))
        {
            case (0):
                {
                    PlayerPrefs.SetInt(name, TutComplete.False);
                    break;
                }
            case (TutComplete.True):
                {
                    Completed = true;
                    break;
                }
            case (TutComplete.False):
                {
                    Completed = false;
                    break;
                }
        }
    }

    public void SetToComplete()
    {
        Completed = true;
        PlayerPrefs.SetInt(Name, TutComplete.True);
    }

    public void SetCanvas(Canvas canvas)
    {
        _canvas = canvas;
    }

    public void ShowCanvas()
    {
        _canvas.enabled = true;
    }

    public void HideCanvas()
    {
        _canvas.enabled = false;
    }
}

