using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraController : MonoBehaviour
{
    public float shakeDuration;
    private float shakeDurationCount;    //set it to public for debugging
    public float shakeFadeAway;
    public float shakePower;
    public float rotation;
    
    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            StartShake(.1f, .2f);
        }
    }

    void LateUpdate()
    {
        if(shakeDurationCount > 0)
        {
            shakeDurationCount -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;
            //Can add another value for the zoom level and rotation
            transform.position += new Vector3(xAmount, yAmount, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeAway * Time.deltaTime);
        }
    }

    public void StartShake(float duration, float power)
    {
        shakeDurationCount = duration;
        shakePower = power;
        shakeFadeAway = power / duration;
    }
}
