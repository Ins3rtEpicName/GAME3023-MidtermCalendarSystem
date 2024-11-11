using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light2D sun;
    [SerializeField] private Gradient sunColor;
    [SerializeField] private float dayDurationSeconds;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float normalizedTime;

    public float day = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / dayDurationSeconds;
        normalizedTime = day % 1;
        sun.color = sunColor.Evaluate(normalizedTime);

        int hour = Mathf.FloorToInt(normalizedTime * 24.0f);
        int min = Mathf.FloorToInt((normalizedTime - hour / 24.0f) * 1500.0f);
        string timeString = "Time: " + $"{hour:00}:{min:00}";
        timeText.text = timeString;
    }

    public void ChangeSunGradient(Gradient gradient)
    {
        sunColor = gradient;
    }

}
