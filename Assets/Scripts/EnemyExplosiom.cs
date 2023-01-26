using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosiom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyExplosion());
        
    }

 
    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(1.7f);
        Destroy(gameObject);
   
    }
}
