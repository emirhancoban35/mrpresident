using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create CountryData",fileName = "CountryData",order = 0)]
public class CountryData : ScriptableObject
{
    public Countries countryName;
    
    public GovernmentStyles governmentType;

    public string presidentName;

    public Sprite countryFlag;
    
    public float armyPower;

    public float economy;

    public float peopleSupport;
    
    public float welfareLevel;

    public List<Alliances> alliances = new List<Alliances>();

    public List<Countries> allies = new List<Countries>();
    
    public List<Countries> enemies = new List<Countries>();
}