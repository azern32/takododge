using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeadly : MonoBehaviour
{
    public float fallingspeed = 2;
    public float deadzone = -140;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -fallingspeed, 0);

        if (transform.position.y < deadzone)
        {
            Destroy(gameObject);
        }
    }
}
