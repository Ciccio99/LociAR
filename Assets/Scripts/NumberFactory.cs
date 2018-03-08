using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberFactory : MonoBehaviour {

    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private GameObject _textPrefab;
    private bool _doneSpawningNums = false;
    private List<GameObject> _spawnedNumberObjects = new List<GameObject>();

    public void SpawnNumber(string number) {
        // If done spawning numbers, then return out of method
        if (_doneSpawningNums) return;

        var go = Instantiate(_textPrefab, GetSpawnLocation(), Quaternion.identity);
        go.GetComponent<TMP_Text>().text = number;
        _spawnedNumberObjects.Add(go);
    }

    public void Reset()
    {
        foreach (var go in _spawnedNumberObjects) {
            Destroy(go);
        }
        _spawnedNumberObjects = new List<GameObject>();
        _doneSpawningNums = false;
    }

    public void Undo() {
        if (_spawnedNumberObjects.Count == 0) return;

        Destroy(_spawnedNumberObjects[_spawnedNumberObjects.Count - 1]);
        _spawnedNumberObjects.RemoveAt(_spawnedNumberObjects.Count - 1);
    }

    public void Done()
    {
        _doneSpawningNums = true;
    }

    public void Continue() {
        _doneSpawningNums = false;
    }

    private Vector3 GetSpawnLocation() {
        RaycastHit rayHit;

        if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out rayHit))
        {
            return rayHit.point;
        }
        else {
            return _mainCamera.transform.position + _mainCamera.transform.forward * 5f;
        }
    }


}
