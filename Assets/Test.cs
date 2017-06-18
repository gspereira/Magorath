using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : NetworkBehaviour {

    NetworkManager NM;

	// Use this for initialization
	void Start () {
        NM = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HostMatch()
    {
        NM.StartServer();
    }
}
