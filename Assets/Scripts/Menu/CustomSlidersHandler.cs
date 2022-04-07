using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomSlidersHandler : MonoBehaviour
{
    [SerializeField] private Slider sliderSpeed;
    [SerializeField] private Slider sliderDelay;
    [SerializeField] private TMP_InputField inputSpeed;
    [SerializeField] private TMP_InputField inputDelay;
    [SerializeField] private TMP_InputField inputScore;

    private float _speed;
    private float _delay;
    private int _score;

    private float maxSpeed = 20f;
    private float minSpeed = 0.5f;
    private float maxDelay = 2f;
    private float minDelay = 0.1f;
    private int minScore = 5;

    private void Start()
    {
        sliderSpeed.maxValue = maxSpeed;
        sliderSpeed.minValue = minSpeed;
        sliderDelay.maxValue = maxDelay;
        sliderDelay.minValue = minDelay;
        sliderDelay.onValueChanged.AddListener(delegate { SliderChanged(inputDelay, sliderDelay); });
        sliderSpeed.onValueChanged.AddListener(delegate { SliderChanged(inputSpeed, sliderSpeed); });
    }

    private void SliderChanged(TMP_InputField input, Slider slider)
    {
        input.text = slider.value.ToString();
    }
    void FixedUpdate()
    {
        _speed = float.Parse(inputSpeed.text.ToString());
        _delay = float.Parse(inputDelay.text.ToString());
        _score = int.Parse(inputScore.text.ToString());

        if (_speed <minSpeed)
        {
            _speed = minSpeed;
        }
        else if (_speed > maxSpeed)
        {
            _speed = maxSpeed;
        }
        
        sliderSpeed.value = _speed;

        if (_delay < minDelay)
        {
            _delay = minDelay;
        }
        else if (_delay > maxDelay)
        {
            _delay = maxDelay;
        }

        sliderDelay.value = _delay;

        if (_score < minScore)
        {
            _score = minScore;
        }

        inputScore.text = _score.ToString();
        inputSpeed.text = _speed.ToString();
        inputDelay.text = _delay.ToString();
    }
}
