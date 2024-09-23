using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOnObject : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        //Debug.Log("instance id: " + this.gameObject.GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            Debug.Log("Scrol: " + Input.mouseScrollDelta.y + "___Id: " + this.gameObject.GetInstanceID());
        }
    }
}
