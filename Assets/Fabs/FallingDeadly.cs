using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeadly : MonoBehaviour
{
    [SerializeField] private float fallingspeed;
    [SerializeField] private float deadzone = -140;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        fallingspeed = Random.Range(120, 300);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -fallingspeed * Time.deltaTime, 0);

        if (transform.position.y < deadzone)
        {
            Destroy(gameObject);
        }
    }
}
