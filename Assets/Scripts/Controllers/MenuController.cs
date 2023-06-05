using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<CountryData> listCountries = new List<CountryData>();

    public List<ButtonController> listCountryButtons = new List<ButtonController>();
   
    private void Start() 
    {
        for (int i = 0; i < listCountryButtons.Count; i++)
        {
            var button = listCountryButtons[i];
            var country = listCountries[i];
         
            button.Populate(country);
            
        }
    }
}
