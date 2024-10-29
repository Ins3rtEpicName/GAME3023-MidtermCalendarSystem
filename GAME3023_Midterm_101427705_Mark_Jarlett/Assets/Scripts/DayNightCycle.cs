using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light2D sun;
    [SerializeField] private Gradient sunColor;
    [SerializeField] private float dayDurationSeconds;

    public float day = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / dayDurationSeconds;
        float normalizedTime = day % 1;

        sun.color = sunColor.Evaluate(normalizedTime);
    }
}
