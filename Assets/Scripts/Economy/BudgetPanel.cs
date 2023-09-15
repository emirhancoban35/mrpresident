using UnityEngine;
using UnityEngine.UI;
using System;

public class BudgetPanel : MonoBehaviour
{
    [SerializeField] private Text panelNameText;
    [SerializeField] private Text budgetValueText;
    [SerializeField] private Button increaseButton;
    [SerializeField] private Button decreaseButton;
    public BudgetType budgetType;

    public Action<BudgetType> onIncreaseButtonClicked;
    public Action<BudgetType> onDecreaseButtonClicked;
    
    public void Initialize(BudgetType type)
    {
        budgetType = type;
        panelNameText.text = type.ToString();
        UpdateBudgetValue(0f);

        increaseButton.onClick.AddListener(OnIncreaseButtonClick);
        decreaseButton.onClick.AddListener(OnDecreaseButtonClick); 
    }

    public void UpdateBudgetValue(float value)
    {
        budgetValueText.text = value.ToString();
    }

    private void OnIncreaseButtonClick()
    {
        onIncreaseButtonClicked?.Invoke(budgetType);
    }

    private void OnDecreaseButtonClick()
    {
        onDecreaseButtonClicked?.Invoke(budgetType);
    }
}