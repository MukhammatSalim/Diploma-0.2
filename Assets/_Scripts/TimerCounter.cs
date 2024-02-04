using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TimerCounter : MonoBehaviour
{
    public TextMeshProUGUI _TimerText;
    public float _remainingTime;
    public bool _TimeEnable;
    public UnityEvent Act;


    private void Start()
    {
        _remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        _TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void TimeEnableEvent(bool CheckMark)
    {
        _TimeEnable = CheckMark;
    }
    private void Update()
    {
        if (_TimeEnable == true)
        {
            if (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(_remainingTime / 60);
                int seconds = Mathf.FloorToInt(_remainingTime % 60);
                _TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                Act?.Invoke();
            }

        }
    }

}
