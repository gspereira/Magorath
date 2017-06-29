using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EScButton : MonoBehaviour {

    [SerializeField]
    GameObject ESCPanel;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            if (!ESCPanel.activeSelf)
            {
                ESCPanel.SetActive(true);
            } else
            {
                ESCPanel.SetActive(false);
            }
        }
	}
}
