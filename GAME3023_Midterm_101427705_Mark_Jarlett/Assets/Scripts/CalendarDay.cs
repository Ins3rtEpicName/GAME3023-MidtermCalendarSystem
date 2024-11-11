using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CalendarDay : MonoBehaviour
{
    [SerializeField] List<CalenderEvent> events = new List<CalenderEvent>();
    public int date;
    public Image eventSprite;

#if UNITY_EDITOR
    // called in editor when things change on this object
    void OnValidate()
    {
        if (events.Count > 0)
        {
            foreach (CalenderEvent calenderEvent in events)
            {
                calenderEvent.ApplyEffects();
            }
        }
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
