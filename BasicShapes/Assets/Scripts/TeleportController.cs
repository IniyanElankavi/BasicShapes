using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject Player;
    float timeLeft = 1.0f;
    public bool isPointerIN = false;

    public void PointerIn()
    {
        isPointerIN = true;
    }

    public void PointerOut()
    {
        isPointerIN = false;
    }

    private void Update()
    {
        if (isPointerIN)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Picker"));
                Player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z);
            }
        }
        else
        {
            timeLeft = 1.0f;
        }
    }
}
