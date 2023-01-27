using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

    private Player player;
    private float _timeShield;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        _timeShield = player.timeShieldPoweUp;
        StartCoroutine(Shield());
        
    }

    IEnumerator Shield()
    {
        yield return new WaitForSeconds(_timeShield);
        Destroy(this.gameObject);
    }
}
