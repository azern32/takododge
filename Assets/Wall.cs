using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float wallWidth;
    public Collider2D theCollider;
    public float wallDivision;

    Usefull helper = new Usefull();


    // Start is called before the first frame update
    void Start()
    {
        float screenDivided = Screen.width / wallDivision;
        Debug.Log("Screen divided " + screenDivided);
        wallDivision = helper.ObjectPosOnCamera(new Vector3(screenDivided, 0, 0)).x - helper.ObjectPosOnCamera(new Vector3(0, 0, 0)).x;

        gameObject.transform.localScale = new Vector3(wallDivision, wallDivision, 1);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
