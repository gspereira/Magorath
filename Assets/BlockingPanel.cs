using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(NetworkInfo.NI.PlayersConnected == 4)
        {
            gameObject.SetActive(false);
        }
	}
}
