using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

public class PanelInstallers : MonoInstaller
{
    public RelationsPanelController relationsPanelController;
    public NewsPanelController newsPanelController;
    public RectTransform newsPanel;
    public RectTransform panel;
    public Transform economyParent;
    public GameObject reloatinshipPanelObject;

    public override void InstallBindings()
    {
        Container.BindInstance(relationsPanelController);
        Container.BindInstance(newsPanelController);
        Container.Bind<RectTransform>().WithId("NewsPanel").FromInstance(newsPanel);
        Container.BindInstance(economyParent).WithId("EconomyParent").AsSingle();
        Container.Bind<EconomyPanelController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RectTransform>().WithId("Panel").FromInstance(panel);
        Container.Bind<RectTransform>().WithId("ReloatinshipPanel").FromInstance(reloatinshipPanelObject.GetComponent<RectTransform>());

    }
}

