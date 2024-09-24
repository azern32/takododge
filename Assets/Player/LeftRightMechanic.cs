using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LeftRightMechanic : MonoBehaviour
{
    [SerializeField] private float playerDistance;
    [SerializeField] private int radius;
    [SerializeField] private float accel;
    [SerializeField] private float current_speed;
    [SerializeField] private float max_speed;
    [SerializeField] private int direction = 1;
    //[SerializeField] private float speed_y;
    //[SerializeField] private float accel_y;

    public Vector3 mouseOnScreenPos;
    public Vector3 transform2Cursor;

    public GameObject gravitySource;
    public Vector3 gravitySourcePos;



    // Start is called before the first frame update
    void Start()
    {
        radius = (int)Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 3 / 4, 0, 0)).x;
        Debug.Log("Test " + Mathf.Cos(Mathf.PI / 2));
        Debug.Log("Width " + Camera.main.pixelWidth);
        Debug.Log("Screen to world " + radius);
        max_speed = 10f;
        current_speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gravitySourcePos = gravitySource.transform.position;
        // mouseOnScreenPos = ObjectPosOnCamera(Input.mousePosition);
        // playerDistance = Distance2D(transform.position, gravitySourcePos);

        direction = transform.position.x >= gravitySourcePos.x ? 1 : -1;
        accel = 2 * direction * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accel -= 10 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            accel += 10 * Time.deltaTime;
        }


        current_speed += accel;
        transform.position += new Vector3(Mathf.Min(current_speed, max_speed), 0, 0);
    }


    float Force(Vector3 objectposition, Vector3 towards, float gConstant, float mass)
    {
        float distance = Distance2D(objectposition, towards);
        return gConstant * (mass / Mathf.Max(10, distance * distance));
    }

    // Untuk ubah posisi dari kamera ke posisi pixel perfect
    Vector3 ObjectPosOnCamera(Vector3 objectPos)
    {
        return Camera.main.ScreenToWorldPoint(objectPos);
    }

    float Distance2D(Vector3 objectA, Vector3 objectB)
    {
        objectA.z = 0;
        objectB.z = 0;

        float a = Mathf.Abs(objectB.y - objectA.y);
        float b = Mathf.Abs(objectB.x - objectA.x);
        return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
    }


}

