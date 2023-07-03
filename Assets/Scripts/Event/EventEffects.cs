[System.Serializable]
public struct EventEffects
{
    public OptionEffect affected;

    public int amountOfEffect;

    public EventEffects(OptionEffect affected, int amountOfEffect)
    {
        this.affected = affected;
        this.amountOfEffect = amountOfEffect;
    }
}

