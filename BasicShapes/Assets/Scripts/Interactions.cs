using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{

    public bool isPointerOnObjects = false;
    float timeOnShapes = 1.0f;
    bool ShapeGazed = false;
    public GameObject selectedShape;
    public Material selectedShapeMat, FadeMaterial;
    public Color selectedShapeColour;
    public GameObject picker;
    GameObject player;
    public GameObject[] allShapes, allTeleportPoints;
    List<Material> listOfRenderers = new List<Material>();

    public void GazeOnShapes()
    {
        ShapeGazed = true;
        selectedShapeMat = selectedShape.GetComponent<Material>();
        selectedShapeColour = selectedShape.GetComponent<Renderer>().material.color;
        FadeAllObjects(true);
        ColliderSwitch(false);
        selectedShape.GetComponent<Renderer>().material = selectedShapeMat;
        selectedShape.GetComponent<Renderer>().material.color = selectedShapeColour;

        if (GameObject.FindGameObjectWithTag("Picker") == null)
        {
            GameObject PickerCanvas = Instantiate(picker);
            PickerCanvas.GetComponentInChildren<Animator>().SetBool("Open", true);
            PickerCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
            PickerCanvas.transform.rotation = Camera.main.transform.rotation;
            PickerCanvas.GetComponentInChildren<ColourPicker>().SelectedObject = selectedShape;
        }
    }

    public void ApplySelection(Color m)
    {
        selectedShape.GetComponent<Renderer>().material.color = m;
    }

    public void ColliderSwitch(bool isON)
    {
        for (int i = 0; i < allShapes.Length; i++)
        {
            allShapes[i].GetComponent<Collider>().enabled = isON;
        }

        for (int i = 0; i < allTeleportPoints.Length; i++)
        {
            allTeleportPoints[i].GetComponent<Collider>().enabled = isON;
        }
    }

    public void FadeAllObjects(bool isFade)
    {
        if (isFade)
        {
            for (int i = 0; i < allShapes.Length; i++)
            {
                listOfRenderers.Add(allShapes[i].GetComponent<Renderer>().material);
                allShapes[i].GetComponent<Renderer>().material = FadeMaterial;
            }
        }
        else
        {
            for (int i = 0; i < allShapes.Length; i++)
            {
                allShapes[i].GetComponent<Renderer>().material = listOfRenderers[i];
            }
        }
    }
    
    public void PointerInObject(GameObject obj)
    {
        selectedShape = obj;
        isPointerOnObjects = true;
    }
    public void PointerOutObject()
    {
        isPointerOnObjects = false;
        ShapeGazed = false;
    }

    
    private void Update()
    {        
        if (isPointerOnObjects)
        {
            timeOnShapes -= Time.deltaTime;
            if (timeOnShapes < 0)
            {
                if(!ShapeGazed)
                 GazeOnShapes();
            }
        }
        else
        {
            timeOnShapes = 1.0f;
        }
    }

}
