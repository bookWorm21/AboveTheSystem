using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LogCollector : MonoBehaviour
{
    private static LogCollector _instance;

    public static LogCollector Instance { get { return _instance != null ? _instance : _instance = FindObjectOfType<LogCollector>(); } }

    private List<Log> _logList = new List<Log>();

    public IEnumerable<Log> Logs => _logList;

    public void Start()
    {
        Application.logMessageReceived += HandleLog;
    }

    public IEnumerable<Log> GetLogByType(params LogType[] types)
    {
        return _logList.Where(x => types.Contains(x.Type));
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        _logList.Add(new Log() { Type = type, Message = logString, StackTrace = stackTrace });
    }
}

[Serializable]
public class Log
{
    public LogType Type;
    public string Message;
    public string StackTrace;

    public override string ToString() => $"{Type.ToString()} : {Message}\n{StackTrace}";
}
