using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField] private float _velocidadPawer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the laser up
        transform.Translate(-Vector3.up * _velocidadPawer * Time.deltaTime);

        //destroy the laser when it goes out of the screen
        if (transform.position.y < -5.7f)
        {
            Destroy(gameObject);
        }
        
    }
}
