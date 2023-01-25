using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _velocidadLaser = 14f;

    
    // Start is called before the first frame update
    void Start()
    {
        
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
}
