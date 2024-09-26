using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGravitySource : MonoBehaviour
{
    Usefull helper = new Usefull();
    public float minx;
    public float maxx;


    // Start is called before the first frame update
    void Start()
    {
        maxx = helper.ObjectPosOnCamera(new Vector3(Screen.width - 10, 0, 0)).x;
        minx = helper.ObjectPosOnCamera(new Vector3(10, 0, 0)).x;

        StartCoroutine(NextSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            float rand = Random.Range(minx, maxx);
            Debug.Log("Terjadi sesuatu" + rand);
            transform.position = new Vector3(rand, transform.position.y, transform.position.z);
        }
    }
}
