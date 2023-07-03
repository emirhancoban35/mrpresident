using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public List<EventData> eventList = new List<EventData>();
    public GameObject eventContainer;
    [SerializeField] private GameObject eventPrefab;
    [SerializeField] private GameObject optionPrefab;
    [SerializeField] private Button forwardButton;

    private int _buttonPressCount = 0;

    private void Start()
    {
        forwardButton.onClick.AddListener(OnForwardButtonClick);
    }

    private void OnForwardButtonClick()
    {
        _buttonPressCount++;

        if (_buttonPressCount % Random.Range(3, 6) == 0)
        {
            SelectRandomEvent();
        }

        NewsCreator.Instance.CreateNews();
    }

    private void SelectRandomEvent()
    {
        if (eventList.Count == 0)
        {
            Debug.Log("Event list is empty.");
            return;
        }

        int randomEventNumber = Random.Range(0, eventList.Count);
        EventData selectedEvent = eventList[randomEventNumber];

        if (IsEventEligible(selectedEvent))
        {
            CreateRandomEvent(selectedEvent);
            eventList.RemoveAt(randomEventNumber);
        }
        else
        {
            SelectRandomEvent();
        }
    }

    private bool IsEventEligible(EventData selectedEvent)
    {
        return selectedEvent.eligibleCountries.Contains(GameManager.Instance.myCountry.countryName);
    }

    private void CreateRandomEvent(EventData selectedEvent)
    {
        GameObject instantiatedPrefab = Instantiate(eventPrefab, eventContainer.transform);
        Text eventText = instantiatedPrefab.GetComponentInChildren<Text>();
        eventText.text = selectedEvent.eventText;

        float yOffset = 0f; // Yükseklik için bir değişken tanımlıyoruz

        foreach (var option in selectedEvent.eventsOptions)
        {
            GameObject instantiatedOption = Instantiate(optionPrefab, instantiatedPrefab.transform);
            Text optionText = instantiatedOption.GetComponentInChildren<Text>();
            optionText.text = option.optionText;

            Button optionButton = instantiatedOption.GetComponentInChildren<Button>();
            optionButton.onClick.AddListener(() => ButtonClick(option));

            RectTransform optionTransform = instantiatedOption.GetComponent<RectTransform>();
            optionTransform.anchoredPosition = new Vector2(0f, -yOffset); // Yeni bir pozisyon belirliyoruz
            yOffset += optionTransform.sizeDelta.y; // Yüksekliği güncelliyoruz

            instantiatedOption.transform.SetParent(instantiatedPrefab.transform, false);
        }

        instantiatedPrefab.transform.SetParent(eventContainer.transform, false);
    }

    

    private void ButtonClick(EventOptions option)
    {
        foreach (var effect in option.effectsList)
        {
            ApplyEffect(effect);
        }

        if (option.triggeredNews != null)
        {
            NewsCreator.Instance.SetNewsToBePublished(option.triggeredNews);
        }

        Destroy(eventContainer);
        SelectRandomEvent();
    }

    private void ApplyEffect(EventEffects effect)
    {
        switch (effect.affected)
        {
            case OptionEffect.Military:
                GameManager.Instance.myCountry.armyPower += effect.amountOfEffect;
                break;
            case OptionEffect.Economy:
                GameManager.Instance.myCountry.economyData.GeneralEconomy += effect.amountOfEffect;
                break;
            case OptionEffect.Vote:
                GameManager.Instance.myCountry.peopleSupport += effect.amountOfEffect;
                break;
            case OptionEffect.Welfare:
                GameManager.Instance.myCountry.welfareLevel += effect.amountOfEffect;
                break;
        }
    }
}
