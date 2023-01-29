using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _speedPrefab;
    [SerializeField] private GameObject _triplePrefab;
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private GameObject _EnemiePrefab;

    [SerializeField] private float _peedTimeSpawn;
    [SerializeField] private float _tripleTimeSpawn;
    [SerializeField] private float _shieldTimeSpawn;

    [SerializeField] private float _auxAumentedEnemies = 50f;
    [SerializeField] private float _aumentedCreationEnemies = 5f;
    [SerializeField] private float _enemieRate = 3f;
    [SerializeField] private float _canEnemie = 0.0f;
    [SerializeField] private float _canSpeed = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //random spawn between 15 and 23 seconds
        _peedTimeSpawn = Random.Range(4, 23);
        _tripleTimeSpawn = Random.Range(4, 23);
        _shieldTimeSpawn = Random.Range(4, 23);

        StartCoroutine(SpeedSpawn());
        StartCoroutine(TripleSpawn());
        StartCoroutine(ShieldSpawn());
        
    }

    void Update()
    {
        EnemieCreation();   
    }
    
    private void EnemieCreation()
    {
        if(Time.time > _aumentedCreationEnemies)
        {
            _aumentedCreationEnemies += 5f;
            if(Time.time > _auxAumentedEnemies)
            {
                
                if(_enemieRate < 0.5f)
                {
                    _enemieRate -= 0.07f;
                    Debug.Log("Aqui");
                    if(_enemieRate <= 0.2f){
                        _enemieRate = 0.2f;
                    }
                }
                else
                {
                    _enemieRate = _enemieRate - 0.5f;
                }
            }
            else
            {
                if(_enemieRate <= 0.5f)
                {
                    _enemieRate -= 0.07f;
                    Debug.Log("Aqui");

                    if(_enemieRate <= 0.2f){
                        _enemieRate = 0.2f;
                    }
                }
                else
                
                {
                    _enemieRate = _enemieRate - 0.5f;
                }
               
                
                
                
            }
           
        }
    
        if(Time.time > _canEnemie)
        {
            _canEnemie = Time.time + _enemieRate;
            Instantiate(_EnemiePrefab);
        }
    }

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
