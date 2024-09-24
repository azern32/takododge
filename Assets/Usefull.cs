using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Usefull : MonoBehaviour
    {
        public Vector3 ObjectPosOnCamera(Vector3 objectPos)
        {
            return Camera.main.ScreenToWorldPoint(objectPos);
        }

        public float Distance2D(Vector3 objectA, Vector3 objectB)
        {
            objectA.z = 0;
            objectB.z = 0;

            float a = Mathf.Abs(objectB.y - objectA.y);
            float b = Mathf.Abs(objectB.x - objectA.x);
            return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        }
    }

}
