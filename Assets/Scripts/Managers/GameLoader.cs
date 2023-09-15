using UnityEngine;
using Zenject;

public class GameLoader : MonoBehaviour
{
    private CountryManager _countryManager;

    [Inject]
    public void Construct(CountryManager countryManager)
    {
        this._countryManager = countryManager;
    }

    private void Start()
    { 
        var selectedCountry = _countryManager.myCountry;
        if (selectedCountry != null)
        {
            Debug.Log("Selected Country: " + selectedCountry.countryName);
        }
        else
        {
            Debug.Log("No Country Selected!");
        }
    }
}