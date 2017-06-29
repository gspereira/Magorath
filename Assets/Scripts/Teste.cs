using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnConnectedToServer()
    {
        Debug.Log("Connected to server");
    }
}
