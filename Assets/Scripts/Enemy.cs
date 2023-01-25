using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _velocidadMovimiento = 5f;

    private float leftBound = -8.147f;
    private float rightBound = 8.147f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(leftBound, rightBound), 5.94f, 0);
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _velocidadMovimiento * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(leftBound, rightBound);
            transform.position = new Vector3(randomX, 5.94f, 0);
        }
        
    }
}
