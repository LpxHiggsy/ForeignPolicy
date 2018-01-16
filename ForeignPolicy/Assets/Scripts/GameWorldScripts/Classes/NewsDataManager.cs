using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsDataManager {

    private NewsDataModel _newsDataModel;

	public NewsDataManager()
    {
        _newsDataModel = new NewsDataModel();
    }

    public void setNewsDataModelJSON(string data)
    {
        _newsDataModel = JsonUtility.FromJson<NewsDataModel>(data);
    }

    public string GetWarNews(string type, string[] countries)
    {
        string news = "";

        switch (type)
        {
            case "Aid":
                {
                    int randNum = Random.Range(0, _newsDataModel.War.Aid.Length);
                    news  =_newsDataModel.War.Aid[randNum];
                    
                    break;
                }

            case "Started":
                {
                    int randNum = Random.Range(0, _newsDataModel.War.Started.Length);
                    news = _newsDataModel.War.Started[randNum];
                    break;
                }

            case "Finished":
                {
                    int randNum = Random.Range(0, _newsDataModel.War.Finished.Length);
                    news = _newsDataModel.War.Finished[randNum];
                    break;
                }
        }

        news = System.String.Format(news, countries);
        return news;
    }

    public string GetHealthNews(string type, string[] countries)
    {
        string news = "";

        switch (type)
        {
            case "Aid":
                {
                    news = _newsDataModel.Health.Aid[0];
                    break;
                }

            case "Recovered":
                {
                    news = _newsDataModel.Health.Recovered[0];
                    break;
                }

            case "Dying":
                {
                    news = _newsDataModel.Health.Dying[0];
                    break;
                }
        }

        news = System.String.Format(news, countries);
        return news;
    }

    public string GetFinanceNews(string type, string[] countries)
    {
        string news = "";

        switch (type)
        {
            case "Aid":
                {
                    news = _newsDataModel.Finance.Aid[0];
                    break;
                }

            case "Richer":
                {
                    news = _newsDataModel.Finance.Richer[0];
                    break;
                }

            case "Poorer":
                {
                    news = _newsDataModel.Finance.Poorer[0];
                    break;
                }
        }

        news = System.String.Format(news, countries);
        return news;
    }

    public string GetStatusNews(string type, string[] countries)
    {
        string news = "";

        switch (type)
        {
            case "Likes":
                {
                    news = _newsDataModel.Status.Likes[0];
                    break;
                }

            case "Hates":
                {
                    news = _newsDataModel.Status.Hates[0];
                    break;
                }
        }

        news = System.String.Format(news, countries);
        return news;
    }
}
