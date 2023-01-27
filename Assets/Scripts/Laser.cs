using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _velocidadLaser = 14f;
     [SerializeField] private GameObject _ExplosionPrefab;
     [SerializeField] private UIManager _uiManager;

    
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the laser up
        transform.Translate(Vector3.up * _velocidadLaser * Time.deltaTime);

        //destroy the laser when it goes out of the screen
        if (transform.position.y > 5.5f)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            Debug.Log("Enemy hit");
            Instantiate(_ExplosionPrefab, other.transform.position, Quaternion.identity);
            
            Destroy(other.gameObject);
            _uiManager.UpdateScore();
            Destroy(this.gameObject);
           
        }
    }

    
}
