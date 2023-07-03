using System.Collections.Generic;
using JetBrains.Annotations;

[System.Serializable]
public struct EventOptions
{
    public string optionText;

    public List<EventEffects> effectsList;
    
    [CanBeNull] public News triggeredNews;

    public EventOptions(string optionText, List<EventEffects> effectsList, News triggeredNews)
    {
        this.optionText = optionText;
        this.effectsList = effectsList;
        this.triggeredNews = triggeredNews;
    }
}