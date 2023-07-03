using UnityEngine;
using UnityEngine.UI;
using System;

public class EconomyDataPanel : MonoBehaviour
{
    public Text variableNameText;
    public Slider variableValueSlider;
    public Text variableValueText;

    private Action<float> onSliderValueChanged;

    public string VariableName { get; private set; }

    public void Initialize(string variableName, float initialValue, Action<float> onValueChanged)
    {
        VariableName = variableName;
        variableNameText.text = variableName;
        variableValueSlider.value = initialValue;
        variableValueText.text = initialValue.ToString();

        onSliderValueChanged = onValueChanged;
        variableValueSlider.onValueChanged.AddListener(OnSliderValueChange);
    }

    public void UpdateSliderValue(float value)
    {
        variableValueSlider.value = value;
        variableValueText.text = value.ToString();
    }

    private void OnSliderValueChange(float newValue)
    {
        variableValueText.text = newValue.ToString();
        onSliderValueChanged?.Invoke(newValue);
    }
}