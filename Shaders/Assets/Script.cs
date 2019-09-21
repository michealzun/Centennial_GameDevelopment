using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public Material material;
    Vector3 pos1;
    Vector3 pos2;
    int textureSize=3;
    int textureSelection=0;
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 30))
        {
            material.SetVector("_Mouse", hit.point);
        }

        if (Input.GetMouseButtonDown(0))
        {
            pos1=Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            pos2= Input.mousePosition;
        }
        material.SetVector("_Flow", (pos2-pos1).normalized);

        if(Input.GetMouseButtonDown(1))
        {
            textureSelection++;
            if (textureSelection >= textureSize) textureSelection = 0;
            material.SetInt("_TextureSelection", textureSelection);
        }
   
    }
}
