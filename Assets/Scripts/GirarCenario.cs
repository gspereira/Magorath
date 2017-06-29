using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarCenario : MonoBehaviour {

    Vector3 Rotation;
    Transform Trans;

	// Use this for initialization
	void Start () {
        Trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotation = Trans.eulerAngles;
        Rotation.y += 1.5f;
        Trans.eulerAngles = Rotation;
	}
}
