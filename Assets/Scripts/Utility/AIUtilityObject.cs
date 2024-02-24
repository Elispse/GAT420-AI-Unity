using System.Collections.Generic;
using UnityEngine;

// The following class represents an AIUtilityObject, which is a Unity MonoBehaviour.
public class AIUtilityObject : MonoBehaviour
{
    // Serializable class representing an Effector with need type and change value.
    [System.Serializable]
    public class Effector
    {
        public AIUtilityNeed.Type type;     // Type of AI utility need affected by this effector.
        [Range(-2, 2)] public float change;  // Change in the AI utility need value.
    }

    [Header("Parameters")]
    [SerializeField] public Effector[] effectors;  // Array of effectors affecting different AI utility needs.
    [SerializeField, Tooltip("Time to use object")] public float duration;  // Duration for which the object is used.
    [SerializeField, Tooltip("Animation to play when using")] public string animationName;  // Animation to play when using the object.

    [SerializeField] public Transform target;

    [Header("UI")]
    [SerializeField, Tooltip("Radius to detect agent")] float radius = 5;  // Radius to detect nearby agents.
    [SerializeField] LayerMask agentLayerMask;  // Layer mask for agents.
    [SerializeField] AIUIMeter meterPrefab;  // Prefab for the UI meter.
    [SerializeField] Vector3 meterOffset;  // Offset for positioning the UI meter.

    public float score { get; set; }  // Property to get or set the utility score of the object.

    AIUIMeter meter;  // UI meter for displaying the utility score.
    Dictionary<AIUtilityNeed.Type, float> registry = new Dictionary<AIUtilityNeed.Type, float>();  // Dictionary to store effectors by AI utility need type.

    void Start()
    {
        // Create and configure the UI meter at runtime.
        meter = Instantiate(meterPrefab, GameObject.Find("Canvas").transform);
        meter.name = name;
        meter.text = name;
        meter.position = transform.position + meterOffset;

        // Set effectors array into the dictionary.
        foreach (var effector in effectors)
        {
            registry[effector.type] = effector.change;
        }
    }

    private void Update()
    {
        meter.visible = false; // hide meter by default

        // show object meter if near agent
        var colliders = Physics.OverlapSphere(transform.position, radius, agentLayerMask);
        if (colliders.Length > 0)
        {
            // check colliders for utility agent 
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out AIUtilityAgent agent))
                {
                    // set meter alpha based on distance to agent (fade-in)
                    float distance = 1 - Vector3.Distance(agent.transform.position, transform.position) / radius;
                    score = agent.GetUtilityScore(this);
                    meter.alpha = distance;
                    meter.visible = true;
                }
            }
        }
    }

    void LateUpdate()
    {
        meter.value = score;  // Update the meter's value.
        meter.position = transform.position + meterOffset;  // Update the meter's position.
    }

    // Get the change in utility need value for a given type.
    public float GetNeedChange(AIUtilityNeed.Type type)
    {
        return registry.TryGetValue(type, out float value) ? value : 0f;
    }

    // Check if the object has a specific AI utility need type.
    public bool HasNeedType(AIUtilityNeed.Type type)
    {
        return registry.ContainsKey(type);
    }
}
