using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class EconomyManager : MonoBehaviour
{
    private Dictionary<BudgetType, float> budgetValues = new Dictionary<BudgetType, float>();
    private Dictionary<string, float> variableValues = new Dictionary<string, float>();
    private Transform panelParent;
    
    private const string EconomicPowerKey = "EconomicPower";

    private int economicPower;
    
    private CountryManager _countryManager;
    
    [Inject]
    public void Setup(CountryManager countryManager)
    {
        this._countryManager = countryManager;
        _countryManager.CountryManagerStateChanged();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(EconomicPowerKey))
        {
            economicPower = PlayerPrefs.GetInt(EconomicPowerKey);
        }
        else
        {
            economicPower = CalculateAndSaveEconomicPower();
        }
    }
    
    private void OnDestroy()
    {
        SaveBudgets();
    }
    
    private int CalculateAndSaveEconomicPower()
    {
        float economyLevel = _countryManager.myCountry.economy;

        int calculatedEconomicPower = Mathf.RoundToInt(economyLevel * 20f);

        PlayerPrefs.SetInt(EconomicPowerKey, calculatedEconomicPower);
        PlayerPrefs.Save();

        return calculatedEconomicPower;
    }
    
    
    private int GetEconomicPower()
    {
        return economicPower;
    }
    
    public void CreateBudgetPanelsAndSliders()
    {
        LoadBudgets();
        LoadVariableValues();
        CreateBudgetPanels();
        CreateSliderPanels();
    }
    
    private void LoadVariableValues()
    {
        variableValues["Income"] = _countryManager.myCountry.economyData.Income;
        variableValues["Expenses"] =  _countryManager.myCountry.economyData.Expenses;
        variableValues["Debt"] = _countryManager.myCountry.economyData.Debt;
        variableValues["TaxRate"] = _countryManager.myCountry.economyData.TaxRate;
        variableValues["UnemploymentRate"] = _countryManager.myCountry.economyData.UnemploymentRate;
        variableValues["PurchasingPower"] = _countryManager.myCountry.economyData.PurchasingPower;
    }
    
    public float GetVariableValue(string variableName)
    {
        if (variableValues.ContainsKey(variableName))
        {
            return variableValues[variableName];
        }
        return 0f;
    }
    
    public void UpdateVariable(string variableName, float newValue)
    {
        if (variableValues.ContainsKey(variableName))
        {
            variableValues[variableName] = newValue;
            UpdateVariablePanel(variableName, newValue);
        }
    }
    
    private void UpdateVariablePanel(string variableName, float variableValue)
    {
        EconomyPanelController panelController = FindObjectOfType<EconomyPanelController>();
        if (panelController != null)
        {
            panelController.UpdateVariableValue(variableName, variableValue);
        }
    }

    

    private void LoadBudgets()
    {
        foreach (BudgetType budgetType in System.Enum.GetValues(typeof(BudgetType)))
        {
            float budgetValue = PlayerPrefs.GetFloat(budgetType.ToString(), 0f);
            budgetValues[budgetType] = budgetValue;
        }
    }

    private void SaveBudgets()
    {
        foreach (KeyValuePair<BudgetType, float> budgetValue in budgetValues)
        {
            PlayerPrefs.SetFloat(budgetValue.Key.ToString(), budgetValue.Value);
        }
        PlayerPrefs.Save();
    }

    public void CreateBudgetPanels()    
    {
        EconomyPanelController panelController = FindObjectOfType<EconomyPanelController>();
        if (panelController != null)
        {
            panelController.CreateBudgetPanels(budgetValues);
        }
    }
    
    public void CreateSliderPanels()    
    {
        EconomyPanelController panelController = FindObjectOfType<EconomyPanelController>();
        if (panelController != null)
        {
            panelController.CreateSliderPanels(variableValues);
        }
    }

    public float GetBudgetValue(BudgetType budgetType)
    {
        if (budgetValues.ContainsKey(budgetType))
        {
            return budgetValues[budgetType];
        }
        return 0f;
    }

    public void IncreaseBudget(BudgetType budgetType)
    {
        if (budgetValues.ContainsKey(budgetType))
        {
            budgetValues[budgetType]++;
            UpdateBudgetPanel(budgetType);
        }
    }

    public void DecreaseBudget(BudgetType budgetType)
    {
        if (budgetValues.ContainsKey(budgetType) && budgetValues[budgetType] > 0f)
        {
            budgetValues[budgetType]--;
            UpdateBudgetPanel(budgetType);
        }
    }

    private void UpdateBudgetPanel(BudgetType budgetType)
    {
        EconomyPanelController panelController = FindObjectOfType<EconomyPanelController>();
        if (panelController != null)
        {
            panelController.UpdateBudgetPanel(budgetType, budgetValues[budgetType]);
        }
    }
}
