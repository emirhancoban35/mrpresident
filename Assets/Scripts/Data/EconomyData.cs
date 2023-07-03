using UnityEngine;

[CreateAssetMenu(menuName = "Create EconomyData", fileName = "EconomyData", order = 0)]
public class EconomyData : ScriptableObject
{
    [SerializeField] private float income;
    [SerializeField] private float expenses;
    [SerializeField] private float debt;
    [SerializeField] private float taxRate;
    [SerializeField] private float unemploymentRate;
    [SerializeField] private float purchasingPower;
    [SerializeField] private float generalEconomy;

    public float EconomyLevel
    {   
        get
        { 
            float economyLevel = ((income - expenses) + ((purchasingPower * 1.5f) - (taxRate / 2.5f)) + (((generalEconomy * 0.5f) - debt) - (unemploymentRate * 0.5f))) / 2.5f;
            return economyLevel;
        }
    }

    public float Income
    {
        get { return income; }
        set { income = Mathf.Clamp(value, 0f, 100f); }
    }

    public float Expenses
    {
        get { return expenses; }
        set { expenses = Mathf.Clamp(value, 0f, 100f); }
    }

    public float Debt
    {
        get { return debt; }
        set { debt = Mathf.Clamp(value, 0f, 100f); }
    }

    public float TaxRate
    {
        get { return taxRate; }
        set { taxRate = Mathf.Clamp(value, 0f, 100f); }
    }

    public float UnemploymentRate
    {
        get { return unemploymentRate; }
        set { unemploymentRate = Mathf.Clamp(value, 0f, 100f); }
    }

    public float PurchasingPower
    {
        get { return purchasingPower; }
        set { purchasingPower = Mathf.Clamp(value, 0f, 100f); }
    }

    public float GeneralEconomy
    {
        get { return generalEconomy; }
        set { generalEconomy = Mathf.Clamp(value, 0f, 100f); }
    }
}