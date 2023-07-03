using UnityEngine;
using System.Collections.Generic;

public class EconomyPanelController : MonoSingleton<EconomyPanelController>
{
    public BudgetPanel budgetPanelPrefab;
    public EconomyDataPanel sliderPanelPrefab;
    public Transform panelParent;

    private BudgetPanel[] _budgetPanels;
    private EconomyDataPanel[] _sliderPanels;

    public void CreateBudgetPanels(Dictionary<BudgetType, float> budgetValues)
    {
        _budgetPanels = new BudgetPanel[System.Enum.GetValues(typeof(BudgetType)).Length];

        float _startY = panelParent.transform.position.y - 55f;
    
        float _panelGap = 55f; 
            
        int index = 0;
        foreach (BudgetType budgetType in System.Enum.GetValues(typeof(BudgetType)))
        {
            if (!budgetValues.ContainsKey(budgetType))
            {
                budgetValues[budgetType] = 0f;
            }
        
            BudgetPanel budgetPanel = Instantiate(budgetPanelPrefab);
            budgetPanel.transform.SetParent(panelParent.transform, false);
        
            float panelHeight = budgetPanel.GetComponent<RectTransform>().rect.height;
            float panelY = _startY - (index * (panelHeight + _panelGap)); 
            budgetPanel.transform.localPosition = new Vector3(0f, panelY, 0f);
            budgetPanel.transform.localScale = Vector3.one;

            budgetPanel.Initialize(budgetType);
            budgetPanel.UpdateBudgetValue(budgetValues[budgetType]);

            budgetPanel.onIncreaseButtonClicked += EconomyManager.Instance.IncreaseBudget;
            budgetPanel.onDecreaseButtonClicked += EconomyManager.Instance.DecreaseBudget;

            _budgetPanels[index] = budgetPanel;
            index++;
        }
    }


    public void UpdateBudgetPanel(BudgetType budgetType, float budgetValue)
    {
        foreach (BudgetPanel budgetPanel in _budgetPanels)
        {
            if (budgetPanel != null && budgetPanel.budgetType == budgetType)
            {
                budgetPanel.UpdateBudgetValue(budgetValue);
                break;
            }
        }
    }

    public void CreateSliderPanels(Dictionary<string, float> variableValues)
    {
        _sliderPanels = new EconomyDataPanel[variableValues.Count];

        float _startY = panelParent.transform.position.y - 50f;
        float _panelGap = 60f;

        int index = 0;
        foreach (KeyValuePair<string, float> variable in variableValues)
        {
            EconomyDataPanel sliderPanel = Instantiate(sliderPanelPrefab);
            sliderPanel.transform.SetParent(panelParent.transform, false);

            float panelHeight = sliderPanel.GetComponent<RectTransform>().rect.height;
            float panelY = _startY - ((index + _budgetPanels.Length) * (panelHeight + _panelGap));

            sliderPanel.transform.localPosition = new Vector3(0f, panelY, 0f);
            sliderPanel.transform.localScale = Vector3.one;

            sliderPanel.Initialize(variable.Key, variable.Value, (newValue) => OnSliderValueChanged(variable.Key, newValue));

            _sliderPanels[index] = sliderPanel;
            index++;
        }
    }

    public void UpdateVariableValue(string variableName, float variableValue)
    {
        foreach (EconomyDataPanel sliderPanel in _sliderPanels)
        {
            if (sliderPanel != null && sliderPanel.VariableName == variableName)
            {
                sliderPanel.UpdateSliderValue(variableValue);
                break;
            }
        }
    }

    private void OnSliderValueChanged(string variableName, float newValue)
    {
        EconomyManager.Instance.UpdateVariable(variableName, newValue);
    }
}
