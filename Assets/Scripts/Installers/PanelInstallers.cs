using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelInstallers : MonoInstaller
{
    public RelationsPanelController relationsPanelController;
    public NewsPanelController newsPanelController;
    public GameObject newsPanelObject;
    public GameObject panelObject;
    public GameObject reloatinshipPanelObject;

    public override void InstallBindings()
    {
        Container.BindInstance(relationsPanelController);
        Container.BindInstance(newsPanelController);
        Container.Bind<RectTransform>().WithId("NewsPanel").FromInstance(newsPanelObject.GetComponent<RectTransform>());
        Container.Bind<RectTransform>().WithId("Panel").FromInstance(panelObject.GetComponent<RectTransform>());
        Container.Bind<RectTransform>().WithId("ReloatinshipPanel").FromInstance(reloatinshipPanelObject.GetComponent<RectTransform>());

    }
}

