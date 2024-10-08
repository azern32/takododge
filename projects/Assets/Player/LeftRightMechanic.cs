using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public float initscore = 0;
    public float force;


    public GameObject gravitySource;
    public Vector3 gravitySourcePos;
    public Rigidbody2D rig2d;

    public Stats logic;

    // Start is called before the first frame update
    void Start()
    {
        radius = (int)Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 3 / 4, 0, 0)).x;
        Debug.Log("Test " + Mathf.Cos(Mathf.PI / 2));
        Debug.Log("Height " + Camera.main.pixelHeight);
        Debug.Log("Screen to world " + radius);
        max_speed = 10;
        current_speed = 0;

        logic = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        gravitySourcePos = gravitySource.transform.position;
        direction = transform.position.x >= gravitySourcePos.x ? 1 : -1;
        accel = 2 * direction;
        // direction *= 2;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            accel -= force;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            accel += force;
        }

        // current_speed += accel * Time.deltaTime / 2;
        // transform.position += new Vector3(current_speed, 0, 0);

        initscore += Time.deltaTime;
        if ((int)initscore == 1)
        {
            initscore = 0;
            logic.Add1Score();
        }
    }

    void FixedUpdate()
    {
        current_speed += accel * Time.deltaTime;
        transform.position += new Vector3(current_speed, 0, 0);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.GameOver();
        gameObject.SetActive(false);
    }

}

