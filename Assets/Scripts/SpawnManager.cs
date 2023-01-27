using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _speedPrefab;
    [SerializeField] private GameObject _triplePrefab;
    [SerializeField] private GameObject _shieldPrefab;

    [SerializeField] private float _peedTimeSpawn;
    [SerializeField] private float _tripleTimeSpawn;
    [SerializeField] private float _shieldTimeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //random spawn between 15 and 23 seconds
        _peedTimeSpawn = Random.Range(15, 23);
        _tripleTimeSpawn = Random.Range(15, 23);
        _shieldTimeSpawn = Random.Range(15, 23);

        StartCoroutine(SpeedSpawn());
        StartCoroutine(TripleSpawn());
        StartCoroutine(ShieldSpawn());
        
    }

    // void SpeedController()
    // {

    // }

    // void TripleController()
    // {

    // }

    // void ShieldController()
    // {

    // }

    IEnumerator SpeedSpawn()
    {
        yield return new WaitForSeconds(_peedTimeSpawn);
        Instantiate(_speedPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0), Quaternion.identity);
        _peedTimeSpawn = Random.Range(15, 23);
        StartCoroutine(SpeedSpawn());
    }

    IEnumerator TripleSpawn()
    {
        yield return new WaitForSeconds(_tripleTimeSpawn);
        Instantiate(_triplePrefab, new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0), Quaternion.identity);
        _tripleTimeSpawn = Random.Range(15, 23);
        StartCoroutine(TripleSpawn());
    }

    IEnumerator ShieldSpawn()
    {
        yield return new WaitForSeconds(_shieldTimeSpawn);
        Instantiate(_shieldPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0), Quaternion.identity);
        _shieldTimeSpawn = Random.Range(15, 23);
        StartCoroutine(ShieldSpawn());
    }
    
}
