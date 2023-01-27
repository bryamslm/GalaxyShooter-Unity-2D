using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite _oneLive;
    [SerializeField] private Sprite _twoLives;
    [SerializeField] private Sprite _threeLives;
    [SerializeField] private Sprite _zeroLives;
    [SerializeField] private TextMeshProUGUI _scoreCount;
    private int _score = 0;
    //image
    [SerializeField] private Image _livesImage;
    

    public void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 3:
                _livesImage.sprite = _threeLives;
                break;
            case 2:
                _livesImage.sprite = _twoLives;
                break;
            
            case 1:
                _livesImage.sprite = _oneLive;
                break;
 
            default:
                _livesImage.sprite = _zeroLives;
                break;
        }

    }

    public void UpdateScore()
    {
        _score += 1;
        _scoreCount.text = _score.ToString();
    }
}
