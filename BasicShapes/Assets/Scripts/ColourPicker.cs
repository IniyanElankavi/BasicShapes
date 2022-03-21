using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPicker : MonoBehaviour
{
    public Color[] Shades;
    public GameObject SelectedObject;
    public Color currentColour;
    public float startTime;
    public float speed = 0.5f;
    public float timeOnBlue, timeOnPurple, timeOnGreen, timeOnYellow, timeOnRed;
    public bool ColourGazed = false;

    public bool[] shadeSelected;

    void Start()
    {
        startTime = Time.time;
        currentColour = SelectedObject.GetComponent<Renderer>().material.color;
    }

    public void PointerInBlue()
    {
        DisableShades();
        shadeSelected[0] = true;
    }

    public void PointerInPurple()
    {
        DisableShades();
        shadeSelected[1] = true;
    }

    public void PointerInGreen()
    {
        DisableShades();
        shadeSelected[2] = true;
    }

    public void PointerInYellow()
    {
        DisableShades();
        shadeSelected[3] = true;
    }

    public void PointerInRed()
    {
        DisableShades();
        shadeSelected[4] = true;
    }

    public void PointerOut()
    {
        DisableShades();
        ColourGazed = false;
    }

    void DisableShades()
    {
        for (int i = 0; i < shadeSelected.Length; i++)
        {
            shadeSelected[i] = false;
        }
    }

    private void Update()
    {
        //BLUE
        if (shadeSelected[0] == true)
        {
            timeOnBlue -= Time.deltaTime;
            if (timeOnBlue < 0)
            {
                Debug.Log("BLUE");
                float t = (Time.time - startTime) * speed;
                SelectedObject.GetComponent<Renderer>().material.color = Color.Lerp(SelectedObject.GetComponent<Renderer>().material.color, Shades[0], Time.deltaTime * 1f);
            }
        }
        else
        {
            timeOnBlue = 1.0f;
        }

        //PURPLE
        if (shadeSelected[1] == true)
        {
            timeOnPurple -= Time.deltaTime;
            if (timeOnPurple < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                SelectedObject.GetComponent<Renderer>().material.color = Color.Lerp(SelectedObject.GetComponent<Renderer>().material.color, Shades[1], Time.deltaTime * 1f);
            }
        }
        else
        {
            timeOnPurple = 1.0f;
        }

        //GREEN
        if (shadeSelected[2] == true)
        {
            timeOnGreen -= Time.deltaTime;
            if (timeOnGreen < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                SelectedObject.GetComponent<Renderer>().material.color = Color.Lerp(SelectedObject.GetComponent<Renderer>().material.color, Shades[2], Time.deltaTime * 1f);
            }
        }
        else
        {
            timeOnGreen = 1.0f;
        }

        //YELLOW
        if (shadeSelected[3] == true)
        {
            timeOnYellow -= Time.deltaTime;
            if (timeOnYellow < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                SelectedObject.GetComponent<Renderer>().material.color = Color.Lerp(SelectedObject.GetComponent<Renderer>().material.color, Shades[3], Time.deltaTime * 1f);
            }
        }
        else
        {
            timeOnYellow = 1.0f;
        }

        //RED
        if (shadeSelected[4] == true)
        {
            timeOnRed -= Time.deltaTime;
            if (timeOnRed < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                SelectedObject.GetComponent<Renderer>().material.color = Color.Lerp(SelectedObject.GetComponent<Renderer>().material.color, Shades[4], Time.deltaTime * 1f);
            }
        }
        else
        {
            timeOnRed = 1.0f;
        }
    }

}
