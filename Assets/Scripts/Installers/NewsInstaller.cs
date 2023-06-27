using UnityEngine;
using Zenject;

public class NewsInstaller : ScriptableObjectInstaller<NewsInstaller>
{
    // public NewsList newsListPrefab;
    //
    // public override void InstallBindings()
    // {
    //     Container.Bind<NewsList>().FromComponentInNewPrefab(newsListPrefab).AsSingle();
    //     Container.Bind<List<News>>().FromMethod(CreateNewsList).AsSingle();
    // }
    //
    // private List<News> CreateNewsList(InjectContext context)
    // {
    //     var newsList = context.Container.Resolve<NewsList>();
    //     return newsList.GetNewsList();
    // }
}