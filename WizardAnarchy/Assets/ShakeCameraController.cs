using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraController : MonoBehaviour
{
    public float shakeDuration;
    public float shakeDurationCount;    //set it to public for debugging
    public float shakePower;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            StartShake(3f, 1f);
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
        }
    }

    public void StartShake(float duration, float power)
    {
        shakeDurationCount = duration;
        shakePower = power;
    }
}
