using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create EventData",fileName = "EventData",order = 1),]
public class EventData : ScriptableObject
{
    public string eventText;

    public List<EventOptions> eventsOptions = new List<EventOptions>();
    
    public List<Countries> eligibleCountries = new List<Countries>();

}
