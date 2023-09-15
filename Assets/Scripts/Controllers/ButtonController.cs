using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image image;
    
    private CountryData _country;
    [Inject] private CountryManager _countryManager;
    public void Populate(CountryData country)
    {
        _country = country;
        image.sprite = country.countryFlag;
    }
    
    public void OnClick()
    {
        _countryManager.SelectCountry(_country); 
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
}