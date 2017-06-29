using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class TestButton : MonoBehaviour {

    public NetworkLobbyManager Test;
    public Button yourButton;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
    }
}
