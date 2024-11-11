using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CalendarDay : MonoBehaviour
{
    [SerializeField] List<CalenderEvent> events = new List<CalenderEvent>();
    private DayNightCycle dayNightCycle;
    public int date;

#if UNITY_EDITOR
    // called in editor when things change on this object
    void OnValidate()
    {
        
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle = GameObject.Find("Global Light 2D").GetComponent<DayNightCycle>();

        float spriteAnchorX = 0.0f; 
        float spriteAnchorY = 0.0f; 
        if (events.Count > 0)
        {
            foreach (CalenderEvent calenderEvent in events)
            {
                // add sprites to the calendar day
                if (calenderEvent.eventSprite != null)
                {
                    //GetComponentInChildren<Image>().sprite = calenderEvent.eventSprite;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (date == Mathf.FloorToInt(dayNightCycle.day))
        {
            foreach (CalenderEvent calenderEvent in events)
            {
                calenderEvent.ApplyEffects();
            }
        }
    }
}
