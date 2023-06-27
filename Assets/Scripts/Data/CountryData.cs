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
    
    [System.Serializable]   
    public class CountryRelationship
    {
        public Countries country;
        public int relationship;

        public CountryRelationship(Countries country, int relationship)
        {
            this.country = country;
            this.relationship = relationship;
        }
    }

    public List<CountryRelationship> relationships = new List<CountryRelationship>();

    public void SetRelationship(Countries otherCountry, int relationship)
    {
        CountryRelationship existingRelationship = relationships.Find(r => r.country == otherCountry);
        if (existingRelationship != null)
        {
            existingRelationship.relationship = Mathf.Clamp(relationship, 0, 100);
        }
        else
        {
            relationships.Add(new CountryRelationship(otherCountry, Mathf.Clamp(relationship, 0, 100)));
        }
    }

    public int GetRelationship(Countries otherCountry)
    {
        CountryRelationship existingRelationship = relationships.Find(r => r.country == otherCountry);
        if (existingRelationship != null)
        {
            return existingRelationship.relationship;
        }
        return 0;
    }
}