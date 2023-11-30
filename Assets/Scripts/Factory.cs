using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Factory : IFactory
{
    readonly DiContainer diContainer;

    Object prefab;

    const string loggerC = "LoggerC";

    public Factory(DiContainer diContainer)
    {
        this.diContainer = diContainer;
        Load();
    }

    public void Load()
    {
        prefab = Resources.Load(loggerC);
    }

    public Object Create()
    {
        var instance = diContainer.InstantiatePrefab(prefab);
        return instance;
    }
}
