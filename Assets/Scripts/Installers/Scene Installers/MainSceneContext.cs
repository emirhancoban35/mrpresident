using UnityEngine;
using Zenject;

public class MainSceneContext : MonoInstaller
{
    public override void InstallBindings()
    {
        // CountryManager'ı MainScene için NonLazy olarak bağladık
        Container.Bind<CountryManager>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}