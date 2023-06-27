using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
   public List<EventData> eventList = new List<EventData>();
   public GameObject eventContainer;
   [SerializeField] private GameObject eventPrefab;
   [SerializeField] private GameObject optionPrefab;

   public void SelectRandomEvent()
   {
      int randomEventNumber = Random.Range(0, eventList.Count);
      EventData selectedEvent = eventList[randomEventNumber];
      
      var contains = selectedEvent.eligibleCountries.Contains(GameManager.Instance.myCountry.countryName);
      
      if (contains)
      {
         eventList.RemoveAt(randomEventNumber);
         CreateRandomEvent(eventList[randomEventNumber]);
      }
      else
      {
         SelectRandomEvent();
      }
   }

   private void CreateRandomEvent(EventData selectedEvent)
   {
      GameObject instantiatedPrefab = Instantiate(eventPrefab, eventContainer.transform);
      foreach (var option in selectedEvent.eventsOptions)
      {
         GameObject instantiatedOption = Instantiate(optionPrefab, instantiatedPrefab.transform);
         Button optionButton = instantiatedOption.GetComponentInChildren<Button>();
         optionButton.onClick.AddListener(ButtonClick);
         var instantiatedOptionTransform = instantiatedOption.GetComponent<RectTransform>();
         var currentPosition = instantiatedOptionTransform.anchoredPosition;
         currentPosition.y += 50;
         instantiatedOptionTransform.anchoredPosition = currentPosition;
         void ButtonClick()
         {
            foreach (var effects in option.effectsList)
            {
               if (effects.affected == OptionEffect.Military)
               {
                  GameManager.Instance.myCountry.armyPower += effects.amountOfEffect;

               }
               else  if (effects.affected == OptionEffect.Economy)
               {
                  GameManager.Instance.myCountry.economy += effects.amountOfEffect;

               }
               else  if (effects.affected == OptionEffect.Vote)
               {
                  GameManager.Instance.myCountry.peopleSupport += effects.amountOfEffect;

               }
               else  if (effects.affected == OptionEffect.Welfare)
               {
                  GameManager.Instance.myCountry.welfareLevel += effects.amountOfEffect;
               }
            }
            if (option.triggeredNews != null)
            {
               NewsCreator.Instance.SetNewsToBePublished(option.triggeredNews);
            }
         }
         Text optionText = instantiatedOption.GetComponentInChildren<Text>();
         optionText.text = option.optionText;
         optionPrefab.transform.SetParent(instantiatedPrefab.transform, false);
      }
      instantiatedPrefab.transform.SetParent(eventContainer.transform, false);
   }
}
