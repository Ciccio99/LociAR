using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReticle : MonoBehaviour {

    [SerializeField]
    private GameObject _reticlePrefab;
    private GameObject _reticleGO;
    private Camera _mainCamera;

	// Use this for initialization
	void Start () {
        _mainCamera = Camera.main;
        _reticleGO = Instantiate(_reticlePrefab, Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit rayHit;

        if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out rayHit))
        {
            _reticleGO.transform.position = rayHit.point;
        }
        else {
            _reticleGO.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward * 5f;
        }
	}
}
