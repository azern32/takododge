using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGravitySource : MonoBehaviour
{
    Usefull helper = new Usefull();
    [SerializeField] AnimationCurve curve;
    public float minx;
    public float maxx;
    public float newlocation_x;

    // Start is called before the first frame update
    void Start()
    {
        maxx = helper.ObjectPosOnCamera(new Vector3(Screen.width - 10, 0, 0)).x;
        minx = helper.ObjectPosOnCamera(new Vector3(10, 0, 0)).x;

        StartCoroutine(NextSpawn());

        Debug.Log("Curve val: " + curve.Evaluate(.4f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            newlocation_x = Random.Range(minx, maxx);
            transform.position = new Vector3(newlocation_x, transform.position.y, transform.position.z);
        }
    }
}
