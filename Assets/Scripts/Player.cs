using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocidadMovimiento = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2f, -0.01f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //using GetAxisRaw to get the input from the keyboard
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //using the input to move the player
        transform.Translate(new Vector3(horizontal, vertical, 0) * velocidadMovimiento * Time.deltaTime);
        
        if(transform.position.x < -8.25f)
        {
            transform.position = new Vector3(-8.25f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 8.25f)
        {
            transform.position = new Vector3(8.25f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (transform.position.y < -4.15f)
        {
            transform.position = new Vector3(transform.position.x, -4.15f, transform.position.z);
        }
        
    }
}
