using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    [SerializeField] private CountryManager m_countryManager;
    public override void InstallBindings()
    {
        Container.BindInstance(m_countryManager).AsSingle().NonLazy();
    }
}