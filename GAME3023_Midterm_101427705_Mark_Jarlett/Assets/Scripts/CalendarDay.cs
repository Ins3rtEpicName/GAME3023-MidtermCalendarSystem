using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CalendarDay : MonoBehaviour
{
    [SerializeField] List<CalenderEvent> events = new List<CalenderEvent>();
    private DayNightCycle dayNightCycle;
    public int date;

#if UNITY_EDITOR
    // called in editor when things change on this object
    void OnValidate()
    {
        if (events.Count > 0)
        {
            foreach (CalenderEvent calenderEvent in events)
            {
                // add sprites to the calendar day
            }
        }
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle = GameObject.Find("Global Light 2D").GetComponent<DayNightCycle>();
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
