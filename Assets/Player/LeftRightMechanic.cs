using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LeftRightMechanic : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float speed_x;
    [SerializeField] private float accel_x;
    [SerializeField] private int radius;
    //[SerializeField] private float speed_y;
    //[SerializeField] private float accel_y;

    public Vector3 mouseOnScreenPos;
    public Vector3 transform2Cursor;
    public float gravityPower = 10;
    public float mass = 1;

    public GameObject gravitySource;
    public Vector3 gravitySourcePos;

    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        radius = (int)Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 3 / 4, 0, 0)).x;
        Debug.Log("Test "+ Mathf.PI/2 );
        Debug.Log("Width "+ Camera.main.pixelWidth);
        Debug.Log("Screen to world " + radius );
    }

    // Update is called once per frame
    void Update()
    {
        mouseOnScreenPos = Input.mousePosition;
    }


    float Force(Vector3 objectposition, Vector3 towards, float gConstant, float mass)
    {
        float distance = Distance2D(objectposition, towards);
        return gConstant * (mass / Mathf.Max(10, (distance * distance)));
    }

    Vector3 MousePosOnCamera()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 1;
        return Camera.main.ScreenToWorldPoint(pos);
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

