using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CustomNetworkHud : MonoBehaviour {


    NetworkManager NM;
    [SerializeField]
    InputField IF;


    // Use this for initialization
    void Start()
    {
        NM = GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        NM.networkAddress = IF.text;
    }

    public void HostMatch()
    {
        NM.StartHost();
    }

    public void DisconnectMatch()
    {
        SceneManager.LoadScene(0);
        Network.Disconnect();
        NM.StopClient();
        
    }



    public void ConnectToMatch()
    {
        NM.StartClient();
    }
}

