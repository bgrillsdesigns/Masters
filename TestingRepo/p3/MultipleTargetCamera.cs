using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour {

    public List<Transform> targets;
    public BattleController battleController;

    public Vector3 offset;
    public float smoothTime = 0f;


    public float minZoom = 64f;
    public float maxZoom = 38f;
    public float zoomLimiter = 20f;

    private Vector3 velocity;
    private Camera cam;

    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    public bool YMinEnabled = false;
    public float YMinValue = 0;

    public bool XMaxEnabled = true;
    public float XMaxValue = 4;

    public bool XMinEnabled = true;
    public float XMinValue = -3.7f;

    void Start()
    {
        targets = new List<Transform>();
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            //load in from scene
            targets.Add(battleController.Fighter1_Transform);
            targets.Add(battleController.Fighter2_Transform);
            return;
        }

        Zoom();
        Move();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        if(YMaxEnabled && YMaxEnabled)
        {
            centerPoint.y = Mathf.Clamp(centerPoint.y, YMinValue, YMaxValue);
        }
        else if(YMinEnabled)
        {
            centerPoint.y = Mathf.Clamp(centerPoint.y, YMinValue, centerPoint.y);
        
        }
        else if(YMaxEnabled)
        {
            centerPoint.y = Mathf.Clamp(centerPoint.y, centerPoint.y, YMaxValue);
        }

        if (XMaxEnabled && XMaxEnabled)
        {
            centerPoint.x = Mathf.Clamp(centerPoint.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            centerPoint.x = Mathf.Clamp(centerPoint.x, XMinValue, centerPoint.x);

        }
        else if (XMaxEnabled)
        {
            centerPoint.x = Mathf.Clamp(centerPoint.x, centerPoint.x, XMaxValue);
        }

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}