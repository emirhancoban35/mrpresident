using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SliderController : MonoBehaviour
{
    private Slider _economySlider;
    private Slider _militarySlider;
    private Slider _voteSlider;
    private Slider _welfareSlider;
    
    private CountryManager _countryManager;
    [Inject]
    public SliderController(CountryManager countryManager)
    {
        this._countryManager = countryManager;
        _countryManager.CountryManagerStateChanged();
    }

    [Inject]
    private void Construct(
        [Inject(Id = "Economy")] Slider economySlider,
        [Inject(Id = "Military")] Slider militarySlider,
        [Inject(Id = "Vote")] Slider voteSlider,
        [Inject(Id = "Welfare")] Slider welfareSlider)
    {
        _economySlider = economySlider;
        _militarySlider = militarySlider;
        _voteSlider = voteSlider;
        _welfareSlider = welfareSlider;
    }

    private void Start()
    {
        UpdateSliderValues();
    }

    private void UpdateSliderValues()
    {
        if (_voteSlider != null && _militarySlider != null && _economySlider != null && _welfareSlider != null)
        {
            _voteSlider.value = _countryManager.myCountry.peopleSupport;
            _militarySlider.value = _countryManager.myCountry.armyPower;
            _economySlider.value = _countryManager.myCountry.economy;
            _welfareSlider.value = _countryManager.myCountry.welfareLevel;
        }
    }
}