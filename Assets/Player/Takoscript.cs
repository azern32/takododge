using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Takoscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 mouseonScreenpos;
    public Vector3 transform2cursor;
    public float angle;
    public float gravityPower;
    [SerializeField] private float force;
    [SerializeField] private float x_speed = 0;
    [SerializeField] private float y_speed = 0;

    void Start()
    {
        Debug.Log("pos"+ transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        mouseonScreenpos = Input.mousePosition;
        mouseonScreenpos.z = 1;
        
        transform2cursor = Camera.main.ScreenToWorldPoint(mouseonScreenpos);


        transform.rotation = RotateObject(transform.position, transform2cursor);
        force = Force(transform.position, transform2cursor, gravityPower, 10);
        float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
        float sin = Mathf.Sin(angle * Mathf.Deg2Rad);

        if (Input.GetMouseButtonDown(0)) {
            x_speed += cos * Time.deltaTime * force;
            y_speed += sin * Time.deltaTime * force;
        }

        //transform.position = transform2cursor;
        transform.position = transform.position + new Vector3(x_speed, y_speed, 0);
    }

    Quaternion RotateObject(Vector3 objectposition, Vector3 towards) {
        float delta_x = towards.x - objectposition.x;
        float delta_y = towards.y - objectposition.y;
        angle = Mathf.Atan2(delta_y, delta_x ) * Mathf.Rad2Deg;

        return Quaternion.Euler(new Vector3(0, 0, angle));
    }

    float Force(Vector3 objectposition, Vector3 towards, float gConstant, float mass)
    {
        float distance = Vector3.Distance(objectposition, towards);
        return  gConstant * (mass/distance);
    }
}
 