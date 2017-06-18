using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class NetworkInfoPanel : MonoBehaviour {

    [SerializeField]
    NetworkInfo NI;
    [SerializeField]
    Text PlayersConnected;
    [SerializeField]
    Text PlayersReady;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayersReady.text = NI.PlayersReady.ToString();
        PlayersConnected.text = NI.PlayersConnected.ToString();
	}
}
