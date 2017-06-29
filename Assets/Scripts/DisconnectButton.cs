using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisconnectButton : MonoBehaviour {

    Button BTN;

    CustomNetworkHud CNH;

	// Use this for initialization
	void Start () {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(Clicked);

        CNH = GameObject.Find("NetworkManager").GetComponent<CustomNetworkHud>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Clicked()
    {
        CNH.DisconnectMatch();
    }
}
