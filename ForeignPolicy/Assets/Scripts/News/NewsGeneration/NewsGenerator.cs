using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsGenerator : MonoBehaviour {

    // Use this for initialization

    public string[] countries;
    public NewsDataManager newsData;

    private int time;
    public NewsGenerator()
    {

    }
	void Start () {
        time = 0;
    }

    void Update()
    {
        time++;
        if (time > 100)
        {
            RandomMessage();
            time = 0;
        }
        
    }

    private void RandomMessage()
    {
        int num = Random.Range(0, 4);
        num = 0;
        string message = System.String.Empty;
        string[] randArray = ShuffleArray(countries);

        switch (num)
        {
            case 0:
                {
                    int type = Random.Range(0, 3);
                    switch (type)
                    {
                        case 0:
                            {
                                message = newsData.GetWarNews("Aid", countries);
                                break;
                            }
                        case 1:
                            {
                                message = newsData.GetWarNews("Started", countries);
                                break;
                            }
                        case 2:
                            {
                                message = newsData.GetWarNews("Finished", countries);
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    int type = Random.Range(0, 3);
                    switch (type)
                    {
                        case 0:
                            {
                                message = newsData.GetHealthNews("Aid", countries);
                                break;
                            }
                        case 1:
                            {
                                message = newsData.GetHealthNews("Recovered", countries);
                                break;
                            }
                        case 2:
                            {
                                message = newsData.GetHealthNews("Dying", countries);
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    int type = Random.Range(0, 3);
                    switch (type)
                    {
                        case 0:
                            {
                                message = newsData.GetFinanceNews("Aid", countries);
                                break;
                            }
                        case 1:
                            {
                                message = newsData.GetFinanceNews("Richer", countries);
                                break;
                            }
                        case 2:
                            {
                                message = newsData.GetFinanceNews("Poorer", countries);
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    int type = Random.Range(0, 2);
                    switch (type)
                    {
                        case 0:
                            {
                                message = newsData.GetStatusNews("Likes", countries);
                                break;
                            }
                        case 1:
                            {
                                message = newsData.GetStatusNews("Hates", countries);
                                break;
                            }
                    }
                    break;
                }
        }

        GameObject newsTicker = GameObject.Find("NewsTicker");
        if (newsTicker != null)
        {
            newsTicker.GetComponent<NewsTicker>().CreateNewsItem(message);
        }
        
    }

    public static string[] ShuffleArray(string[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            string tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }

        return arr;
    }

}
