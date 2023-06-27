[System.Serializable]
public class EventEffects
{
    public OptionEffect affected;

    public int amountOfEffect;

    public EventEffects(OptionEffect affected, int amountOfEffect)
    {
        this.affected = affected;
        this.amountOfEffect = amountOfEffect;
    }
}

