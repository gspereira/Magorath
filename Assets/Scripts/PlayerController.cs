using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    TopDownController TDC;
    private void Start()
    {
        TDC = GetComponent<TopDownController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            TDC.HorizontalAxis = Input.GetAxis("Horizontal");
            TDC.VerticalAxis = Input.GetAxis("Vertical");
        }
    }
}
