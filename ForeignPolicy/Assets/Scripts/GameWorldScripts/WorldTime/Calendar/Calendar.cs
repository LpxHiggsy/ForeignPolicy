using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Weekday{
	Monday,
	Tuesday,
	Wednesday,
	Thursday,
	Friday,
	Saturday,
	Sunday
}

public enum Month{
	January,
	Febuary,
	March,
	April,
	May,
	June,
	July,
	August,
	September,
	October,
	November,
	December
}


public struct CalenderContainer
{
	public int day;
	public Weekday weekday;
	public int week;
	public Month month;
	public int year;
}

public class Calendar : MonoBehaviour
{
	public float passTime;
    public Text dateHolder;

	private float _systemTime;
	private float _changeInTime;
	private CalenderContainer _calender;

	Dictionary<int,int> monthData = new Dictionary<int, int>{
		{ 0,31}, { 1 ,28}, { 2 , 31}, { 3 , 30},
		{ 4 , 31}, { 5 , 30}, { 6 , 31}, { 7 , 31},
		{ 8 , 30}, { 9 , 31}, { 10 , 30}, { 11 , 31}
	};

    private void Start () {
		_systemTime = 0.0f;
		_changeInTime = 0.0f;
        _calender.year = 2000;

	}

    private void Update () {
		_systemTime += Time.deltaTime;


		if (passTime < (_systemTime - _changeInTime)) {
			UpdateDay ();
			_changeInTime = _systemTime;
            dateHolder.text = GetTimeFormat();

        }

	}

    private void UpdateDay(){

		if ((int)_calender.weekday == 6) {
			_calender.weekday = 0;
			UpdateWeek ();
		} else {
			_calender.weekday++;
		}
        
        if (_calender.day == monthData[(int)_calender.month]) {
			_calender.day = 1;
			UpdateMonth ();
		} else {
			_calender.day++;
		}
	}

    private void UpdateWeek(){
		_calender.week++;
	}

    private void UpdateMonth(){

		if ((int)_calender.month == 11) {
			_calender.month = 0;
			UpdateYear ();
		} else {
			_calender.month++;		
		}
	}

	private void UpdateYear(){
		_calender.year++;	
	}

	public string GetTimeFormat()
	{
		string month = _calender.month.ToString ();
		return string.Format ("{0}/{1}/{2}", _calender.day,month,_calender.year);
	}

    public void SetDate(int day, int weekday, int month, int year)
    {
        _calender.day = day;
        _calender.month = (Month)4;
        _calender.year = year;
        _calender.weekday = (Weekday)4;

    }

    public string GetDate()
    {
        return string.Format("{0},{1},{2}", _calender.day, _calender.month, _calender.year);
    }

    public int GetDay()
    {
        return _calender.day;
    }
}
