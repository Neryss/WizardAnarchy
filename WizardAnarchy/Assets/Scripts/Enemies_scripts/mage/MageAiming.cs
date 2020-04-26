using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAiming : MonoBehaviour
{
    public DistEnemyController mageController;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = mageController.target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector2 lookDir = target.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
