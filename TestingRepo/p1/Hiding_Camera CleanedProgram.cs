using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding_Camera : MonoBehaviour {
    Vector2 m_look;
    Vector2 smoothV;
    public float sensitivity = 4.0f;
    public float smoothing = 2.2f;
    public float minAngle_y = -50f;
    public float maxAngle_y = 90f;
    public float minAngle_x = -115f;
    public float maxAngle_x = -5f;
//commented out code was ommited here 
    bool isPaused = false;
    Vector2 last_pos;


    // Use this for initialization
    void Start()
    {
//commented out code was ommited here 
    }

    public void Cam_Stop()
    {
        sensitivity = 0.0f;
    }

    public void Cam_Start()
    {
        sensitivity = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var mouse_dir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        if (isPaused == false)
        {
            mouse_dir = Vector2.Scale(mouse_dir, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        }
        else
        {
            mouse_dir = last_pos;
        }
        smoothV.x = Mathf.Lerp(smoothV.x, mouse_dir.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouse_dir.y, 1f / smoothing);
        m_look += smoothV;
        m_look.y = Mathf.Clamp(m_look.y, minAngle_y, maxAngle_y);
        m_look.x = Mathf.Clamp(m_look.x, minAngle_x, maxAngle_x);
        isPaused = PauseMenu.PauseCam();
        if (isPaused == false)
        {
            transform.localRotation = Quaternion.AngleAxis(-m_look.y, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(m_look.x, Vector3.up);
            last_pos = mouse_dir;
        }
        else
        {

        }
    }
}
