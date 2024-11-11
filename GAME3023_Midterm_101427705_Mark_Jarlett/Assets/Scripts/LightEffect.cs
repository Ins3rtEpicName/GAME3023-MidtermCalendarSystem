using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLightEffect", menuName = "Effects/LightEffect")]
public class LightEffect : Effect
{
    [SerializeField] private Gradient lightGradient;
    public override void ApplyEffect()
    {
        
    }
}
