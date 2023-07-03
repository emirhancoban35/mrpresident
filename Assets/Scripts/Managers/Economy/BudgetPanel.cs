using UnityEngine;
using UnityEngine.UI;
using System;

public class BudgetPanel : MonoBehaviour
{
    public Text panelNameText;
    public Text budgetValueText;
    public Button increaseButton;
    public Button decreaseButton;
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