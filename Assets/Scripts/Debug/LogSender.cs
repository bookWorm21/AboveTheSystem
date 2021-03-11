using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSender : MonoBehaviour
{
    [SerializeField] private Telegram _telegram;

    private string _caption { get => $"{Application.productName}\n{SystemInfo.deviceName} {SystemInfo.deviceModel} {SystemInfo.deviceUniqueIdentifier}"; }

#if !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        SendLogs();
    }

    private void OnApplicationQuit()
    {
        SendLogs();
    }

    private void SendLogs()
    {

        
            var log = "";
            foreach (var item in LogCollector.Instance.Logs)
            {
                log += $"{item}\n";
            }

            var bytes = System.Text.Encoding.UTF8.GetBytes(log);
            _telegram.SendFile(bytes, "logs.txt", _caption);

    }
#endif
}
