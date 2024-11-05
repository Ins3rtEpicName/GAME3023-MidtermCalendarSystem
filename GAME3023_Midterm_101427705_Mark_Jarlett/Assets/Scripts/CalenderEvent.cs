using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCalenderEvent", menuName = "CalenderEvent/NewCalenderEvent")]
public class CalenderEvent : ScriptableObject
{
    public Sprite eventSprite;
    public string description = "";
    public List<Effect> effects;
    public virtual void ApplyEffect()
    {
        foreach (Effect effect in effects)
        {
            effect.ApplyEffect();
        }
    }
}

