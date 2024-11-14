using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CalendarDay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<CalenderEvent> events = new List<CalenderEvent>();
    [SerializeField] private List<GameObject> eventIcons = new List<GameObject>(2);
    [SerializeField] private GameObject eventsUIHoverGameObject;
    private List<GameObject> eventsUIHoverList = new List<GameObject>();
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Cursor Entering " + name + " GameObject");

        // display all the events on that day when hovering over it with mouse cursor
        float yOffset = eventsUIHoverGameObject.GetComponent<RectTransform>().rect.height;
        foreach (CalenderEvent calenderEvent in events)
        {
            GameObject eventInfo = Instantiate(eventsUIHoverGameObject, 
                new Vector3(this.transform.position.x, this.transform.position.y - yOffset , 0.0f), 
                Quaternion.identity, this.transform.parent);
            yOffset += eventsUIHoverGameObject.GetComponent<RectTransform>().rect.height;
            eventInfo.GetComponent<EventsListUIHover>().SetContent(calenderEvent.eventSprite, calenderEvent.description);
            eventsUIHoverList.Add(eventInfo);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Exiting " + name + " GameObject");
        for (int i = 0; i < eventsUIHoverList.Count; i++)
        {
            Destroy(eventsUIHoverList[i]);
        }
    }
}
