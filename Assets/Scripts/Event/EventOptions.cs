using System.Collections.Generic;
using JetBrains.Annotations;

[System.Serializable]
public class EventOptions
{
    public string optionText;

    public List<EventEffects> effectsList = new List<EventEffects>();
    
    [CanBeNull] public News triggeredNews;

    public EventOptions(string optionText, List<EventEffects> effectsList, News triggeredNews)
    {
        this.optionText = optionText;
        this.effectsList = effectsList;
        this.triggeredNews = triggeredNews;
    }
}