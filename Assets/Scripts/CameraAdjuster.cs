using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    [SerializeField]
    List<Transform> _targets = new List<Transform>();

    Transform cameraTransform;
    Camera cameraInstance;

    float margin = 1.0f;
    float cameraHeight = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        cameraInstance = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var total = new Vector3(0.0f, 0.0f, 0.0f);
        foreach (var target in _targets) {
            total += target.position;
        }

        var center = total / _targets.Count;
        transform.position = center;

        var radius = 0.0f;
        foreach (var target in _targets) {
            radius = Mathf.Max(radius, Vector3.Distance(center, target.position));
        }

        var distance = (radius + margin) / Mathf.Sin(cameraInstance.fieldOfView * 0.5f * Mathf.Deg2Rad);
        cameraTransform.localPosition = new Vector3(0.0f, cameraHeight, -distance);
        cameraTransform.LookAt(this.transform);
    }
}
