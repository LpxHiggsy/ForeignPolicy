using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WarNews
{

    public string[] Aid;
    public string[] Started;
    public string[] Finished;

    public WarNews()
    {
        Aid = new string[0];
        Started = new string[0];
        Finished = new string[0];
    }
}

[System.Serializable]
public class HealthNews
{

    public string[] Aid;
    public string[] Recovered;
    public string[] Dying;

    public HealthNews()
    {
        Aid = new string[0];
        Recovered = new string[0];
        Dying = new string[0];
    }
}

[System.Serializable]
public class StatusNews
{

    public string[] Likes;
    public string[] Hates;

    public StatusNews()
    {
        Likes = new string[0];
        Hates = new string[0];
    }
}


[System.Serializable]
public class FinanceNews
{

    public string[] Aid;
    public string[] Richer;
    public string[] Poorer;

    public FinanceNews()
    {
        Aid = new string[0];
        Richer = new string[0];
        Poorer = new string[0];
    }
}



[System.Serializable]
public class NewsDataModel {

    public WarNews War;
    public HealthNews Health;
    public FinanceNews Finance;
    public StatusNews Status;

    public NewsDataModel()
    {
        War = new WarNews();
        Health = new HealthNews();
        Finance = new FinanceNews();
        Status = new StatusNews();

    }
}
