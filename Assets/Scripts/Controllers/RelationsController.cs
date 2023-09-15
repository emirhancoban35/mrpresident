using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RelationsController : MonoBehaviour
{
    private RelationsPanelController _relationsPanelController;
    
    private CountryManager _countryManager;
    [Inject]
    public RelationsController(CountryManager countryManager)
    {
        this._countryManager = countryManager;
        _countryManager.CountryManagerStateChanged();
    
    }
    
    [Inject]
    private void InjectRelationsPanelController(RelationsPanelController relationsPanelController)
    {
        _relationsPanelController = relationsPanelController;
    }
    
    public void GetOurRelations()
    {
        foreach (var country in _countryManager.otherCountries)
        {
            var relationshipLevel =country.GetRelationship(_countryManager.myCountry.countryName);
            
            var countryName =country.name;
            var countryFlag = country.countryFlag;
            
            _relationsPanelController.CreateNewPanel(relationshipLevel,countryFlag,countryName);
        } 
    }
}
