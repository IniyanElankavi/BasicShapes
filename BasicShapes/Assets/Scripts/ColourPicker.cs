using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPicker : MonoBehaviour
{
    public Color[] Shades;
    public GameObject SelectedObject;
    int SelectedShade;
    public Color currentColour;
    public float startTime;
    public float speed = 0.5f;
    public float timeOnBlue, timeOnPurple, timeOnGreen, timeOnYellow, timeOnRed;
    public bool ColourGazed = false;
    Image imgToLoad;
    public bool[] shadeSelected;
    Interactions interactions;

    void Start()
    {
        startTime = Time.time;
        currentColour = SelectedObject.GetComponent<Renderer>().material.color;
        interactions = FindObjectOfType<Interactions>();
    }

    public void PointerInBlue(Image argImg)
    {
        DisableShades();
        imgToLoad = argImg;
        shadeSelected[0] = true;
    }

    public void PointerInPurple(Image argImg)
    {
        DisableShades(); imgToLoad = argImg;
        imgToLoad = argImg;
        shadeSelected[1] = true;
    }

    public void PointerInGreen(Image argImg)
    {
        DisableShades(); imgToLoad = argImg;
        imgToLoad = argImg;
        shadeSelected[2] = true;
    }

    public void PointerInYellow(Image argImg)
    {
        DisableShades(); imgToLoad = argImg;
        imgToLoad = argImg;
        shadeSelected[3] = true;
    }

    public void PointerInRed(Image argImg)
    {
        DisableShades(); imgToLoad = argImg;
        imgToLoad = argImg;
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

    IEnumerator destroyPicker()
    {
        yield return new WaitForSeconds(1.0f);
        if (GameObject.FindGameObjectWithTag("Picker"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Picker"));
            interactions.FadeAllObjects(false);
            interactions.ApplySelection(Shades[SelectedShade]);
            interactions.ColliderSwitch(true);

        }
    }

    private void Update()
    {
        //BLUE
        if (shadeSelected[0] == true)
        {
            SelectedShade = 0;
            imgToLoad.fillAmount = 0f;
            timeOnBlue -= Time.deltaTime;
            imgToLoad.fillAmount = Mathf.Abs(timeOnBlue);
            if (timeOnBlue < 0)
            {
                float t = (Time.time - startTime) * speed;
                StartCoroutine(destroyPicker());
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
            SelectedShade = 1;
            timeOnPurple -= Time.deltaTime;
            imgToLoad.fillAmount = Mathf.Abs(timeOnPurple);
            if (timeOnPurple < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                StartCoroutine(destroyPicker());
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
            SelectedShade = 2;
            timeOnGreen -= Time.deltaTime;
            imgToLoad.fillAmount = Mathf.Abs(timeOnGreen);
            if (timeOnGreen < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                StartCoroutine(destroyPicker());
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
            SelectedShade = 3;
            timeOnYellow -= Time.deltaTime;
            imgToLoad.fillAmount = Mathf.Abs(timeOnYellow);
            if (timeOnYellow < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                StartCoroutine(destroyPicker());
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
            SelectedShade = 4;
            timeOnRed -= Time.deltaTime;
            imgToLoad.fillAmount = Mathf.Abs(timeOnRed);
            if (timeOnRed < 0)
            {
                ColourGazed = true;
                float t = (Time.time - startTime) * speed;
                StartCoroutine(destroyPicker());
                SelectedObject.GetComponent<Renderer>().material.color = Color.Lerp(SelectedObject.GetComponent<Renderer>().material.color, Shades[4], Time.deltaTime * 1f);
            }
        }
        else
        {
            timeOnRed = 1.0f;
        }
    }

}
