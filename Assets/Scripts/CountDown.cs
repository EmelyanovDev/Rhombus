using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private GameObject _countDownText;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _pauseButton;
    
    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_joystick.activeInHierarchy)
        {
            Destroy(_countDownText);
            _pauseButton.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
