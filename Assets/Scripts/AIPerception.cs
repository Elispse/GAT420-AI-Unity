using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPerception : MonoBehaviour
{
    [SerializeField] protected string tagName = "";
    [SerializeField] protected float distance = 1;
    [SerializeField] protected float maxAngle = 45;
    [SerializeField] protected LayerMask layerMask = Physics.AllLayers;
    public string TagName { get { return tagName; } }
    public float Distance { get { return distance; } private set { distance = Distance; } }
    public float MaxAngle { get { return maxAngle; } private set { maxAngle = MaxAngle; } }

    public abstract GameObject[] GetGameObjects();
}