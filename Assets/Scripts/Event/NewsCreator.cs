using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

public class NewsCreator : MonoBehaviour
{
    public List<News> newsList = new List<News>();
    public List<GameObject> newsPrefabs = new List<GameObject>();

    [SerializeField] private GameObject newsPrefab;
    [CanBeNull] private News _newsToBePublished;

    [Inject] private CountryManager _countryManager;
    
    [Inject] private NewsPanelController _newsPanelController;

    private void Setup(NewsPanelController newsPanelController)
    {
        this._newsPanelController = newsPanelController;
    }

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
            if (newsList.Count == 0)
            {
                Debug.Log("Haber kalmadı.");
                return;
            }

            int randomNewsNumber = Random.Range(0, newsList.Count);
            News createdNews = newsList[randomNewsNumber];

            var contains = createdNews.newsOfWhichCountries.Contains(_countryManager.myCountry.countryName);

            if (contains)
            {
                PublishNews(createdNews);
                newsList.RemoveAt(randomNewsNumber);
            }
        }
    }

    private void PublishNews(News selectedNews)
    {
        GameObject instantiatedPrefab = Instantiate(newsPrefab, _newsPanelController.GetPanelLocation());
        newsPrefabs.Add(instantiatedPrefab);

        foreach (var news in newsPrefabs)
        {
            var newsTransform = news.GetComponent<RectTransform>();
            var currentPosition = newsTransform.anchoredPosition;
            currentPosition.y += 200;
            newsTransform.anchoredPosition = currentPosition;
        }

        instantiatedPrefab.transform.SetParent(_newsPanelController.GetNewsPanelLocation(), false);
        Text textComponent = instantiatedPrefab.GetComponentInChildren<Text>();
        textComponent.text = selectedNews.newsText;
    }
}
