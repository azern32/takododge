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

    public float initscore = 0;

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
        max_speed = 10f;
        current_speed = 0;

        logic = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        gravitySourcePos = gravitySource.transform.position;
        direction = transform.position.x >= gravitySourcePos.x ? 1 : -1;
        accel = 2 * direction * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            accel -= 20 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            accel += 20 * Time.deltaTime;
        }

        current_speed += accel;
        transform.position += new Vector3(Mathf.Min(current_speed, max_speed), 0, 0);

        initscore += Time.deltaTime;
        if ((int)initscore == 1)
        {
            initscore = 0;
            logic.Add1Score();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.GameOver();
        gameObject.SetActive(false);
    }


}

