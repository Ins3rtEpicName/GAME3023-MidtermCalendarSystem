using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CalendarDay : MonoBehaviour
{
    [SerializeField] private List<CalenderEvent> events = new List<CalenderEvent>();
    [SerializeField] private List<GameObject> eventIcons = new List<GameObject>(2);
    private DayNightCycle dayNightCycle;
    public int date;
    private bool bStartEvent = true;

#if UNITY_EDITOR
    // called in editor when things change on this object
    void OnValidate()
    {
        eventIcons[0] = this.transform.Find("EventImage").gameObject;
        eventIcons[1] = this.transform.Find("EventImage (1)").gameObject;
        eventIcons[0].GetComponent<Image>().sprite = null;
        eventIcons[1].GetComponent<Image>().sprite = null;
        int i = 0;
        if (events.Count > 0)
        {
            for (; i < 2; i++)
            {
                if (events[i] != null && events[i].eventSprite != null)
                {
                    eventIcons[i].GetComponent<Image>().sprite = events[i].eventSprite;
                }
                else
                {
                    eventIcons[i].GetComponent<Image>().sprite = null;
                }
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
        if (date == Mathf.FloorToInt(dayNightCycle.day) && bStartEvent)
        {
            bStartEvent = false;
            foreach (CalenderEvent calenderEvent in events)
            {
                calenderEvent.ApplyEffects();
            }
        }
    }
}
