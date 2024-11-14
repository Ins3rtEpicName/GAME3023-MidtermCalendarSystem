using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventsListUIHover : MonoBehaviour
{
    public void SetContent(Sprite image, string text)
    {
        this.gameObject.GetComponent<Image>().sprite = image;
        this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }
}
