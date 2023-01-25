using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public bool tripleDisparo = false;

    [SerializeField] private float _timeTripleDisparo= 10f;
    [SerializeField] private float _timeSpeedPoweUp= 15f;

    [SerializeField] private float _velocidadMovimiento = 5f;

    // laser prefab
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _laserVerdePrefab;
    [SerializeField] private GameObject _EnemiePrefab;

    [SerializeField] private float _fireRate = 0.10f;
    [SerializeField] private float _canFire = 0.0f;
    [SerializeField] private float _aumentedCreationEnemies = 10f;
    [SerializeField] private float _auxAumentedEnemies = 0f;

    [SerializeField] private float _enemieRate = 3f;
    [SerializeField] private float _canEnemie = 0.0f;

    [SerializeField] private int lifes = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2f, -0.01f);
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        //whem space is pressed, the player shoots

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            Shoot();
        }

        EnemieCreation();
        
    }

    private void EnemieCreation()
    {
        if(Time.time > _aumentedCreationEnemies)
        {
            _aumentedCreationEnemies += 15f;
            if(Time.time > _auxAumentedEnemies)
            {
                _enemieRate = _enemieRate - 0.1f;
            }
            else
            {
                _enemieRate = _enemieRate - 0.5f;
            }
           
        }
    
        if(Time.time > _canEnemie)
        {
            _canEnemie = Time.time + _enemieRate;
            Instantiate(_EnemiePrefab);
        }
    }

    void Shoot()
    {
        if(Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            
            if(tripleDisparo)
            {
                //instantiate the laser prefab
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
                Instantiate(_laserVerdePrefab, transform.position + new Vector3(-0.626f, -0.35f, 0), Quaternion.identity);
                Instantiate(_laserVerdePrefab, transform.position + new Vector3(0.626f, -0.35f, 0), Quaternion.identity);

            }
            else
            {
                //instantiate the laser prefab
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
            }
            
        }
    }

    private void PlayerMovement()
    {
        //using GetAxisRaw to get the input from the keyboard
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //using the input to move the player
        transform.Translate(new Vector3(horizontal, vertical, 0) * _velocidadMovimiento * Time.deltaTime);
        
        if(transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
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

    //OnTriggerEnter2D is called when the Collider2D other enters the trigger
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "TripleShotPowerUp")
        {
            tripleDisparo = true;
            StartCoroutine(NoPowerUp(_timeTripleDisparo, "TripleShotPowerUp"));
        }
        else if(other.tag == "SpeedPowerUp")
        {
            _velocidadMovimiento = 10f;
            StartCoroutine(NoPowerUp(_timeSpeedPoweUp, "SpeedPowerUp"));
        }
        else if(other.tag == "Enemy")
        {
            lifes--;
            if(lifes == 0)
            {
                Destroy(this.gameObject);
            }
        }

        Destroy(other.gameObject);
    
    }


    IEnumerator NoPowerUp(float time, string powerUp)
    {
        yield return new WaitForSeconds(time);
        if(powerUp == "TripleShotPowerUp")
        {
            tripleDisparo = false;
        }
        else if(powerUp == "SpeedPowerUp")
        {
            _velocidadMovimiento = 5f;
        }

    }
    
}
