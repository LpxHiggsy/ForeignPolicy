using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private float _systemTime;
	private float _changeInTime;
	private bool _newDay;
	private CalenderContainer _calender;

	Dictionary<int,int> monthData = new Dictionary<int, int>{
		{ 0 = 31}, { 1 = 28}, { 2 = 31}, { 3 = 30},
		{ 4 = 31}, { 5 = 30}, { 6 = 31}, { 7 = 31},
		{ 8 = 30}, { 9 = 31}, { 10 = 30}, { 11 = 31}
	};

	void Start () {
		_systemTime = 0.0f;
		_changeInTime = 0.0f;
		_newDay = false;

	}
	
	void Update () {
		_systemTime += Time.deltaTime;


		if (passTime < (_systemTime - _changeInTime)) {
			UpdateDay ();
			_changeInTime = _systemTime;
		}

	}

	void UpdateDay(){

		if (_calender.weekday == 6) {
			_calender = 0;
			UpdateWeek ();
		} else {
			_calender.weekday++;
		}

		if (_calender.day == monthData[monthData[_calender.month]]) {
			_calender.day = 1;
			UpdateMonth ();
		} else {
			_calender.day++;
		}
	}

	void UpdateWeek(){
		_calender.week++;
	}

	void UpdateMonth(){

		if (_calender.month == 11) {
			_calender.month = 0;
			UpdateYear ();
		} else {
			_calender.month++;		
		}
	}

	void UpdateYear(){
		_calender.year++;	
	}

	public string GetTimeFormat()
	{
		string month = _calender.month.ToString ();
		return string.Format ("{0}/{1}/{2}", _calender.day,month,_calender.year);
	}
}
