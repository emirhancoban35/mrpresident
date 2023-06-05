using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;
public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image image;   
    
    private CountryData _country;

    private GameManager _gameManager;
    
    [Inject]
    public void Setup(GameManager GameManager)
    {
        this._gameManager = GameManager;
        _gameManager.GameManagerStateChanged();

    }

    public void Populate(CountryData country)
    {
        _country = country;
        image.sprite = country.countryFlag;
    } 

    public void OnClick()
    {
        SceneManager.LoadScene(sceneBuildIndex: +1, LoadSceneMode.Single);
        _gameManager.SelectElement(_country);
    }
}
