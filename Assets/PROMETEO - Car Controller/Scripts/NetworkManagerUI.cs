using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;

    public string ip;
    
    private void Awake()
    {
        serverBtn.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip, 7777);
            NetworkManager.Singleton.StartServer();
        }
            ));
        
        hostBtn.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip, 7777);
            NetworkManager.Singleton.StartHost();
        }
            ));
        
        clientBtn.onClick.AddListener((() =>
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip, 7777);
            NetworkManager.Singleton.StartClient();
        }
            ));
    }
    
    public void OnIpValueChanged(string value)
    {
        ip = value;
    }
}
