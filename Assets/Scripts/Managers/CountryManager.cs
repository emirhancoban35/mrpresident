using System.Collections.Generic;
using UnityEngine;

public class CountryManager : MonoBehaviour
{
    public CountryData myCountry;
    public List<CountryData> otherCountries;
    
    public void SelectCountry(CountryData country)
    {
        myCountry = country;
    }
    
    public void CountryManagerStateChanged()
    {
        Debug.Log("Country Manager Created");
    }
}