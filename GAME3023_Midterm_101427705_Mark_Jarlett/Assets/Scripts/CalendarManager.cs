using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> calendarDaysList;

    // Start is called before the first frame update
    void Start()
    {
        int numberOfDays = this.gameObject.transform.childCount;
        for (int i = 0; i < numberOfDays; i++)
        {
            calendarDaysList.Add(transform.GetChild(i).gameObject);
        }

        // setting each calendar date text and date variable
        int date = 1;
        foreach (GameObject o in calendarDaysList)
        {
            o.GetComponentInChildren<TMP_Text>().text = date.ToString();
            o.GetComponentInChildren<CalendarDay>().date = date;
            date++;
        }
    }

    private void OnEnable()
    {
        Movement2D.OnCalendarVisibilityChangeEvent += ToggleCalendarVisibility;
    }

    private void OnDisable()
    {
        Movement2D.OnCalendarVisibilityChangeEvent -= ToggleCalendarVisibility;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleCalendarVisibility()
    {
        if (GetComponentInParent<Canvas>().GetComponent<CanvasGroup>().alpha == 0)
        {
            GetComponentInParent<Canvas>().GetComponent<CanvasGroup>().alpha = 1;
            GetComponentInParent<Canvas>().GetComponent<CanvasGroup>().interactable = true;
        }
        else
        {
            GetComponentInParent<Canvas>().GetComponent<CanvasGroup>().alpha = 0;
            GetComponentInParent<Canvas>().GetComponent<CanvasGroup>().interactable = false;
        }
    }
}
