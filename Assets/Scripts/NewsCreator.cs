using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsCreator : MonoBehaviour
{
    #region Varabiles
    public List<News> newsList = new List<News>();
    public GameObject newsPrefab;
    public List<GameObject> newsPrefabs = new List<GameObject>();
    #endregion

    #region Functions
    public void CreateNews()
    {
        int randomNewsNumber = Random.Range(0, newsList.Count);
        // if (newsList[randomNewsNumber] == null)
        //     return;
        
        News createdNews = newsList[randomNewsNumber];

        var contains = createdNews.newsOfWhichCountries.Contains(GameManager.Instance.myCountry.countryName);
        
        if (contains)
        {
            
            GameObject instantiatedPrefab = Instantiate(newsPrefab ,NewsPanelController.Instance.GetPanelLocation());
        
            foreach (var news in newsPrefabs)   
            {
                var newsTransform = news.GetComponent<RectTransform>();

                var currentPosition = newsTransform.anchoredPosition;

                currentPosition.y += 200;

                newsTransform.anchoredPosition = currentPosition;
            }
            newsPrefabs.Add(instantiatedPrefab);
        
            instantiatedPrefab.transform.parent = NewsPanelController.Instance.GetNewsPanelLocation();
        
            Text textComponent = instantiatedPrefab.GetComponentInChildren<Text>();
        
            textComponent.text = createdNews.newsText;  
            newsList.RemoveAt(randomNewsNumber);

        }
        else
        {
            CreateNews();
            return;
        }
        // NewsPanelController.Instance.SetSizePanel();
    }
    #endregion

}