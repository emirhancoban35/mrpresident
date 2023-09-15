// AdditiveSceneManager.cs

using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class AdditiveSceneManager : MonoBehaviour
{
    private bool _isMainMenuLoaded = false;

    private Scene _mainMenuScene;

    [Inject]
    public void Construct([InjectOptional] MainMenuContext mainMenuContext)
    {
        if (mainMenuContext != null)
        {
            _mainMenuScene = mainMenuContext.gameObject.scene;
        }
    }

    private void Update()
    {
        if (!_isMainMenuLoaded)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            _isMainMenuLoaded = true;
        }
        else
        {
            if (_mainMenuScene.IsValid() && _mainMenuScene.isLoaded && _mainMenuScene.GetRootGameObjects().Length > 0)
            {
                var countryManager = _mainMenuScene.GetRootGameObjects()[0].GetComponent<CountryManager>();

                if (countryManager != null && countryManager.myCountry != null)
                {
                    SceneManager.UnloadSceneAsync("MainMenu");
                    SceneManager.LoadScene("Game", LoadSceneMode.Additive);
                    _isMainMenuLoaded = false;
                }
            }
        }
    }
}