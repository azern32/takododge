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


    // public Vector3 mouseOnScreenPos;
    // public Vector3 transform2Cursor;

    public GameObject gravitySource;
    public Vector3 gravitySourcePos;


    Usefull tesclass = new Usefull();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tes" + tesclass.Distance2D(gravitySourcePos, transform.position));



        radius = (int)Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 3 / 4, 0, 0)).x;
        Debug.Log("Test " + Mathf.Cos(Mathf.PI / 2));
        Debug.Log("Height " + Camera.main.pixelHeight);
        Debug.Log("Screen to world " + radius);
        max_speed = 10f;
        current_speed = 0;

        // float tes = Usefull.(transform.position, gravitySourcePos);
    }

    // Update is called once per frame
    void Update()
    {
        gravitySourcePos = gravitySource.transform.position;
        direction = transform.position.x >= gravitySourcePos.x ? 1 : -1;
        accel = 2 * direction * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accel -= 15 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            accel += 15 * Time.deltaTime;
        }

        current_speed += accel;
        transform.position += new Vector3(Mathf.Min(current_speed, max_speed), 0, 0);
    }

    // Untuk ubah posisi dari kamera ke posisi pixel perfect


}

