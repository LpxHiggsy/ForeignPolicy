using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsTicker : MonoBehaviour {

    public Text newsItemPrefab;
    GameObject canvas;
    Queue<QueueItem> newsQueue;

    struct QueueItem {
        public string text;
    }

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("NewsCanvas");
        newsQueue = new Queue<QueueItem>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (newsQueue.Count > 0)
        {
            for (int i = 0; i < newsQueue.Count; i++)
            {
                if (GameObject.Find("News(Clone)") == null)
                {
                    InstaniateNews(newsQueue.Dequeue().text);
                }
            }
        }
    }

    public void CreateNewsItem(string newsText)
    {

        QueueItem news = new QueueItem();
        news.text = newsText;
       
        newsQueue.Enqueue(news);
    }

    private void InstaniateNews(string newsText)
    {
        Text newsItemPrefabClone;
        newsItemPrefabClone = Instantiate(newsItemPrefab, transform.position, Quaternion.identity) as Text;
        newsItemPrefabClone.transform.SetParent(canvas.transform, false);
        newsItemPrefabClone.text = newsText;
        Canvas.ForceUpdateCanvases();

        newsItemPrefabClone.transform.position = new Vector3((Screen.width + (newsItemPrefabClone.rectTransform.sizeDelta.x / 2)), (int)(Screen.height * 0.25), 10);
    }


}
