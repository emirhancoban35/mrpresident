using Zenject;
public class ManagerInstallers : MonoInstaller
{
  public EconomyManager economyManager;
  public NewsCreator newsCreator;

  public override void InstallBindings()
  {
    Container.BindInstance(economyManager);
    Container.BindInstance(newsCreator);
  }
}