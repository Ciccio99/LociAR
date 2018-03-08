using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraScript : MonoBehaviour {

    private Camera _mainCamera;

	// Use this for initialization
	void Start () {
        _mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        var lookPos = transform.position -_mainCamera.transform.position;
        lookPos.y = 0;

        transform.rotation = Quaternion.LookRotation(lookPos);
	}
}
