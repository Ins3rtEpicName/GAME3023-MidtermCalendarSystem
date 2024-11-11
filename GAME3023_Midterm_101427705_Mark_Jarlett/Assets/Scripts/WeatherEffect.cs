using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeatherEffect", menuName = "Effects/WeatherEffect")]
public class WeatherEffect : Effect
{
    [SerializeField] private GameObject weatherGameObject;
    private bool bIsInstantiated = false;
    public override void ApplyEffect()
    {
        if (!bIsInstantiated)
        {
            Instantiate(weatherGameObject);
            bIsInstantiated = true;
        }
        weatherGameObject.SetActive(true);
        weatherGameObject.GetComponent<ParticleSystem>().Play(withChildren: true);
    }
}
