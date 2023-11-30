using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Inputter : MonoBehaviour
{
    LoggerA loggerA;
    ILogger loggerB;
    LoggerC loggerC;

    List<LoggerC> loggerCs = new();
    
    IFactory Factory;

    [Inject]
    public void Init(LoggerA logA, ILogger logB, LoggerC logC, IFactory factory)
    {
        loggerA = logA;
        loggerB = logB;
        loggerC = logC;
        Factory = factory;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            loggerA.Log();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            loggerB.Log();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            loggerC.Log();

            if (loggerCs.Count > 0)
            {
                foreach (var logC in loggerCs)
                {
                    logC.Log();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            var obj = Factory.Create();
            loggerCs.Add(obj.GetComponent<LoggerC>());
        }
    }
}
