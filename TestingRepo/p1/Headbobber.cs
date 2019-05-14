using UnityEngine;
using System.Collections;

public class Headbobber : MonoBehaviour
{

    private float timer = 0.0f;
    public float bobbingSpeed = 0.13f;
    public float bobbingAmount = 0.09f;
    public float midpoint = .5f;

    private void Start()
    {
        Time.timeScale = 1f;

    }

    void Update()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (horizontal != 0 || vertical != 0)
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }


            Vector3 v3T = transform.localPosition;
            if (waveslice != 0)
            {
                float translateChange = waveslice * bobbingAmount;
                float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                v3T.y = midpoint + translateChange;
            }
            else
            {
                v3T.y = midpoint;
            }
            transform.localPosition = v3T;

        }
    }
}