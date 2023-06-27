using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class NewsCreator : MonoBehaviour
{
    public List<News> newsList = new List<News>();
    public List<GameObject> newsPrefabs = new List<GameObject>();

    [SerializeField] private GameObject newsPrefab;
    [CanBeNull] private News _newsToBePublished;

    public void SetNewsToBePublished(News news)
    {
        _newsToBePublished = news;
    }
    
    public void AddNews(News news)
    {
        newsList.Add(news);
    }

    public void RemoveNews(News news)
    {
        newsList.Remove(news);
    }

    public void CreateNews()
    {
        if (_newsToBePublished != null)
        {
            PublishNews(_newsToBePublished);
            _newsToBePublished = null;
        }
        else
        {
            int randomNewsNumber = Random.Range(0, newsList.Count);
            News createdNews = newsList[randomNewsNumber];

            var contains = createdNews.newsOfWhichCountries.Contains(GameManager.Instance.myCountry.countryName);

            if (contains)
            {
                PublishNews(createdNews);
                newsList.RemoveAt(randomNewsNumber);
            }
        }
    }

    private void PublishNews(News selectedNews)
    {
        GameObject instantiatedPrefab = Instantiate(newsPrefab, NewsPanelController.Instance.GetPanelLocation());
        newsPrefabs.Add(instantiatedPrefab);

        foreach (var news in newsPrefabs)
        {
            var newsTransform = news.GetComponent<RectTransform>();
            var currentPosition = newsTransform.anchoredPosition;
            currentPosition.y += 200;
            newsTransform.anchoredPosition = currentPosition;
        }

        instantiatedPrefab.transform.SetParent(NewsPanelController.Instance.GetNewsPanelLocation(), false);
        Text textComponent = instantiatedPrefab.GetComponentInChildren<Text>();
        textComponent.text = selectedNews.newsText;
    }
}