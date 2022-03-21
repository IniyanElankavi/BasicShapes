using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float speed = -5f;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Collider>().enabled)
            transform.Rotate(Vector3.up * speed);
    }
}
