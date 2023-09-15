using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SliderInstaller : MonoInstaller
{
    public Slider economySlider;
    public Slider militarySlider;
    public Slider voteSlider;
    public Slider welfareSlider;

    public override void InstallBindings()
    {
        Container.Bind<Slider>().WithId("Economy").FromInstance(economySlider);
        Container.Bind<Slider>().WithId("Military").FromInstance(militarySlider);
        Container.Bind<Slider>().WithId("Vote").FromInstance(voteSlider);
        Container.Bind<Slider>().WithId("Welfare").FromInstance(welfareSlider);
    }
}