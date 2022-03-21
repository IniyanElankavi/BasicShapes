using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public Light[] _lights;
    bool lightSwitch = false;
    public Material[] TVMaterial;
    public Renderer TVRenderer;
    public int channel = 0;
    public bool isPointerOnLight, isPointerOnTV = false;
    float timeOnLight, timeOnTV = 1.0f;
    bool TVGazed, LightGazed = false;


    public void log()
    {
        Debug.Log("TEST BUTTON");
    }

    private void Start()
    {
        _lights = GameObject.Find("Interior").GetComponentsInChildren<Light>();
        TVRenderer.material = TVMaterial[0];
    }

    public void GazeOnTV()
    {
        TVGazed = true;
        channel += 1;

        switch (channel)
        {
            case 1:
                TVRenderer.material = TVMaterial[1];
                break;
            case 2:
                TVRenderer.material = TVMaterial[2];
                break;
            case 3:
                TVRenderer.material = TVMaterial[0];
                break;
            default:
                break;
        }

        if(channel == 3)
        {
            channel = 0;
        }
    }

    public void TurnOnOffLight()
    {
        LightGazed = true;
        lightSwitch =! lightSwitch;

        for (int i = 0; i < _lights.Length; i++)
        {
            if (lightSwitch)
            {
                _lights[i].enabled = false;
            }
            else
            {
                _lights[i].enabled = true;
            }
        }
    }

    public void PointerOnTV()
    {
        isPointerOnTV = true;
    }
    public void PointerOffTV()
    {
        isPointerOnTV = false;
        TVGazed = false;
    }

    public void PointerOnLight()
    {
        isPointerOnLight = true;
    }

    public void PointerOffLight()
    {
        isPointerOnLight = false;
        LightGazed = false;
    }

    private void Update()
    {
        if (isPointerOnLight)
        {
            timeOnLight -= Time.deltaTime;
            if (timeOnLight < 0)
            {
                if(!LightGazed)
                 TurnOnOffLight();
            }
        }
        else
        {
            timeOnLight = 1.0f;
        }


        if (isPointerOnTV)
        {
            timeOnTV -= Time.deltaTime;
            if (timeOnTV < 0)
            {
                if(!TVGazed)
                 GazeOnTV();
            }
        }
        else
        {
            timeOnTV = 1.0f;
        }
    }

}
