using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 TRA = transform.position;
        TRA.x = Target.position.x;
        TRA.z = Target.position.z;
        transform.position = TRA;

        
	}
}
