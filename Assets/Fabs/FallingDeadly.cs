using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeadly : MonoBehaviour
{
    public float fallingspeed;
    public float deadzone = -140;
    // Start is called before the first frame update
    void Start()
    {
        fallingspeed = Random.Range(40, 60);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -fallingspeed * Time.deltaTime, 0);

        if (transform.position.y < deadzone)
        {
            Debug.Log("ID: " + gameObject.GetInstanceID() + ", Current falling speed: " + fallingspeed);
            Destroy(gameObject);
        }
    }
}
