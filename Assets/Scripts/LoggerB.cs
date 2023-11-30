using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerB : ILogger
{
    public void Log()
    {
        Debug.Log("Log B");
    }
}