using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountryStanding : MonoBehaviour
{
    public string Name = string.Empty;
    public int Budget = 0;
	public int Population = 0;
	public Vector3 MapPosition = new Vector3(0.0f, 0.0f, 0.0f);
    public List<string> TradingPartners = new List<string>();
    public List<string> Allies = new List<string>();
    public List<string> Enemies = new List<string>();

    private bool _selected;

    private Color c_Select;
    private Color c_Original;

    void Start()
    {
        _selected = false;

        c_Select = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        c_Original = new Color(0.90f, 0.90f, 0.90f, 1.0f);

        GetComponent<SpriteRenderer>().color = c_Original;
    }
    void Update()
    {
    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = c_Select;

        //Debug.Log(Standings.GetScore());
        GameObject.Find("CountryStanding").GetComponent<Text>().text = Standings.GetStandings(Name).ToString();
        
    }

    void OnMouseExit()
    {
        if(!_selected)
        {
            GetComponent<SpriteRenderer>().color = c_Original;
        }
            
    }

    public void Select()
    {
        _selected = true;
        GetComponent<SpriteRenderer>().color = c_Select;
    }

    public void Deselect()
    {
        _selected = false;
        GetComponent<SpriteRenderer>().color = c_Original;
    }
}
