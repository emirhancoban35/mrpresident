using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RelationsController : MonoBehaviour
{
    private RelationsPanelController _relationsPanelController;
    
    [Inject]
    private void InjectRelationsPanelController(RelationsPanelController relationsPanelController)
    {
        _relationsPanelController = relationsPanelController;
    }
    
    public void GetOurRelations()
    {
        foreach (var country in GameManager.Instance.otherCountries)
        {
            var relationshipLevel =country.GetRelationship(GameManager.Instance.myCountry.countryName);
            
            var countryName =country.name;
            var countryFlag = country.countryFlag;
            
            _relationsPanelController.CreateNewPanel(relationshipLevel,countryFlag,countryName);
        } 
    }
}
