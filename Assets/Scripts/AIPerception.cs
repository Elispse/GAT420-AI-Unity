using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPerception : MonoBehaviour
{
    [SerializeField] private string tagName = "";
    [SerializeField] private float distance = 1;
    [SerializeField] private float maxAngle = 45;
    public string TagName { get { return tagName; } }
    public float Distance { get { return distance; } private set { distance = Distance; } }
    public float MaxAngle { get { return maxAngle; } private set { maxAngle = MaxAngle; } }

    public abstract GameObject[] GetGameObjects();
}