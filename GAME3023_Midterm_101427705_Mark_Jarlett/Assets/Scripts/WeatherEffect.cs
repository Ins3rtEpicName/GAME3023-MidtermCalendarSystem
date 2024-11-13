using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeatherEffect", menuName = "Effects/WeatherEffect")]
public class WeatherEffect : Effect
{
    private float effectDuration;
    [SerializeField] private GameObject weatherGameObject;
    [System.NonSerialized] private bool bIsInstantiated = false; // nonserialized so that it is reset to false whenever exiting play mode, otherwise
                                                                 // the particle effect would only work once and then not again on next play without restarting the editor
    public override void ApplyEffect()
    {
        effectDuration = FindFirstObjectByType<DayNightCycle>().dayDurationSeconds;
        if (!bIsInstantiated)
        {
            Debug.Log("applying weather effect");
            Instantiate(weatherGameObject);
            weatherGameObject.GetComponent<ParticleSystem>().Stop(true);
            ParticleSystem.MainModule particleSystemMainModule = weatherGameObject.GetComponent<ParticleSystem>().main;
            particleSystemMainModule.duration = effectDuration;
            weatherGameObject.SetActive(false);
            bIsInstantiated = true;
        }
        weatherGameObject.SetActive(true);
        weatherGameObject.GetComponent<ParticleSystem>().Play(withChildren: true);
    }

    private void OnDestroy()
    {
        bIsInstantiated = false;
    }

}
