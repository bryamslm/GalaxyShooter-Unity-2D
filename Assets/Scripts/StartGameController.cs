using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private GameObject _startGameObject;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private TextMeshPro _startGameText;
    // Start is called before the first frame update
    void Start()
    {
        _startGameObject.SetActive(true);
        _playerGameObject.SetActive(false);
        StartCoroutine(TextBlink());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _startGameObject.SetActive(false);
            _playerGameObject.SetActive(true);
        }   
        
    }

    void FinishGame()
    {
        _startGameObject.SetActive(true);
        _playerGameObject.SetActive(false);
    }

    IEnumerator TextBlink()
    {
        while (true)
        {
            _startGameText.text = "Press Space to Start game";
            yield return new WaitForSeconds(0.5f);
            _startGameText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
