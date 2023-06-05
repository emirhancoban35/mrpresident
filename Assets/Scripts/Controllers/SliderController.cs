using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{  
    private Slider _economySlider;
    private Slider _militarySlider;
    private Slider _voteSlider;
    private Slider _welfareSlider;
     
    private void Start()
    {
        _voteSlider.value = GameManager.Instance.myCountry.peopleSupport;
        _militarySlider.value = GameManager.Instance.myCountry.armyPower;
        _economySlider.value = GameManager.Instance.myCountry.economy;
        _welfareSlider.value = GameManager.Instance.myCountry.welfareLevel;

    }
    private void Awake()
    {
        _economySlider = GameObject.Find("Economy").GetComponent<Slider>();
        _militarySlider = GameObject.Find("Military").GetComponent<Slider>();
        _voteSlider = GameObject.Find("Vote").GetComponent<Slider>();
        _welfareSlider = GameObject.Find("Welfare").GetComponent<Slider>();

    }
}
