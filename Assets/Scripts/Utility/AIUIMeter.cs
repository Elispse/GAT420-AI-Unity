using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// The following class represents an AIUIMeter, which is a Unity MonoBehaviour.
public class AIUIMeter : MonoBehaviour
{
    // Serialized field for the label, slider, and image components in the Unity Editor.
    [SerializeField] TMP_Text label;
    [SerializeField] Slider slider;
    [SerializeField] Image image;

    // Property to set the position of the AIUIMeter.
    public Vector3 position
    {
        set
        {
            // Draw a debug line from the specified position to a point above it.
            Debug.DrawLine(value, value + Vector3.up * 3);

            // Convert the world position to a viewport point relative to the camera.
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(value);

            // Set the anchor points of the RectTransform to match the converted viewport point.
            GetComponent<RectTransform>().anchorMin = viewportPoint;
            GetComponent<RectTransform>().anchorMax = viewportPoint;
        }
    }

    // Property to set the value of the slider component.
    public float value
    {
        set
        {
            slider.value = value;
        }
    }

    // Property to set the text of the label component.
    public string text
    {
        set
        {
            label.text = value;
        }
    }

    // Property to control the visibility of the AIUIMeter by setting its active state.
    public bool visible
    {
        set
        {
            gameObject.SetActive(value);
        }
    }

    // Property to set the alpha (transparency) of the image component.
    public float alpha
    {
        set
        {
            // Retrieve the current color of the image and update its alpha value.
            Color color = image.color;
            color.a = value;
            image.color = color;
        }
    }
}