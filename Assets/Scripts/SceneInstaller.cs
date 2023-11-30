using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] LoggerA loggerA;

    const string loggerC = "LoggerC";

    public override void InstallBindings()
    {
        BindFromInstance();
        BindByInterface();
        BindByPrefab();
        BindFactory();
    }

    void BindFromInstance()
    {
        Container.Bind<LoggerA>().FromInstance(loggerA).AsSingle();
    }

    void BindByInterface()
    {
        Container.Bind<ILogger>().To<LoggerB>().FromNew().AsTransient();
    }

    void BindByPrefab()
    {
        Container.Bind<LoggerC>().FromComponentInNewPrefabResource(loggerC).AsSingle();
    }

    void BindFactory()
    {
        Container.Bind<IFactory>().To<Factory>().AsSingle();
    }
}