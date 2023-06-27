using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour ,IGameManager
{
   public CountryData myCountry;

   public List<CountryData> otherCountries;

   #region Instance
   private static GameManager _instance;
   public static GameManager Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = FindObjectOfType<GameManager>();
            if (_instance == null)
            {
               GameObject obj = new GameObject();
               obj.name = "GameManager";
               _instance = obj.AddComponent<GameManager>();
            }
         }
         return _instance;
      }
   }
   private void Awake()
   {
      if (_instance == null)
      {
         _instance = this;
      }
      else if (_instance != this)
      {
         Destroy(gameObject);
      }

      DontDestroyOnLoad(gameObject);
   }
   
 
   public void SelectElement(CountryData country)
   {
      myCountry = country;
   }
   public void GameManagerStateChanged()
   {
      Debug.Log("Game Manager Created");
   }
   
   public CountryData GetSelectedCountry()
   {
      return myCountry;
   }
   #endregion
   
}