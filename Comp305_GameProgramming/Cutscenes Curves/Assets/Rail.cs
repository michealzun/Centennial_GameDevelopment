using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rail : MonoBehaviour {

    public Transform[] nodes;

    private void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }

    public Vector3 linearPosition(int seg,float ratio) {
        Vector3 pos1 = nodes[seg].position;
        Vector3 pos2;
        if (seg + 1 < nodes.Length)
        {
            pos2 = nodes[seg + 1].position;
        }
        else
        {
            pos2 = nodes[0].position;
        }
        return Vector3.Lerp(pos1, pos2, ratio);
    }
    
    public Vector3 catmullPosition(int seg, float ratio)
    {
        Vector3 p1, p2, p3, p4;
        if (seg == 0)
        {
            p1 = nodes[nodes.Length-1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg + 1].position;
            p4 = nodes[seg + 2].position;
        }
        else if (seg == nodes.Length - 2)
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg+1].position;
            p4 = nodes[0].position;
        }
        else if (seg == nodes.Length - 1)
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[0].position;
            p4 = nodes[1].position;
        }
        else
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg + 1].position;
            p4 = nodes[seg + 2].position;
        }

        float t2 = ratio * ratio;
        float t3 = t2 * ratio;
        float x = 0.5f * ((2 * p2.x) + 
            (p3.x-p1.x)*ratio +
            (2*p1.x-5*p2.x +4*p3.x-p4.x)*t2 +
            (-p1.x+3*p2.x-3*p3.x+p4.x) * t3);
        float y = 0.5f * ((2 * p2.y) +
         (p3.y - p1.y) * ratio +
         (2 * p1.y - 5 * p2.y + 4 * p3.y - p4.y) * t2 +
         (-p1.y + 3 * p2.y - 3 * p3.y + p4.y) * t3);
        float z = 0.5f * ((2 * p2.z) +
         (p3.z - p1.z) * ratio +
         (2 * p1.z - 5 * p2.z + 4 * p3.z - p4.z) * t2 +
         (-p1.z + 3 * p2.z - 3 * p3.z + p4.z)*t3);

        return new Vector3(x, y, z);
    }

    public Vector3 BeizierPosition(int seg, float ratio)
    {
        Vector3 p1, p2, p3, p4;
        if (seg == nodes.Length - 3)
        {
            p1 = nodes[seg].position;
            p2 = nodes[seg + 1].position;
            p3 = nodes[seg + 2].position;
            p4 = nodes[0].position;
        }
        else if (seg == nodes.Length - 2)
        {
            p1 = nodes[seg].position;
            p2 = nodes[seg + 1].position;
            p3 = nodes[0].position;
            p4 = nodes[1].position;
        }
        else if (seg == nodes.Length - 1)
        {
            p1 = nodes[seg].position;
            p2 = nodes[0].position;
            p3 = nodes[1].position;
            p4 = nodes[2].position;
        }
        else
        {
            p1 = nodes[seg].position;
            p2 = nodes[seg+1].position;
            p3 = nodes[seg+2].position;
            p4 = nodes[seg + 3].position;
        }

        float t2 = ratio * ratio;
        float t3 = t2 * ratio;
        float x = (1 - ratio) * (1 - ratio) * (1 - ratio) * p1.x + 3 * (1 - ratio) * (1 - ratio) * ratio * p2.x + 3 * (1 - ratio) * t2 * p3.x + t3 * p4.x;
        float y = (1 - ratio) * (1 - ratio) * (1 - ratio) * p1.y + 3 * (1 - ratio) * (1 - ratio) * ratio * p2.y + 3 * (1 - ratio) * t2 * p3.y + t3 * p4.y;
        float z = (1 - ratio) * (1 - ratio) * (1 - ratio) * p1.z + 3 * (1 - ratio) * (1 - ratio) * ratio * p2.z + 3 * (1 - ratio) * t2 * p3.z + t3 * p4.z;
        return new Vector3(x, y, z);
    }

    public Vector3 hermitePosition(int seg, float ratio)
    {
        Vector3 p0, p1, m0, m1;
        if (seg == 0)
        {
            p0 = nodes[seg].position;
            p1 = nodes[seg + 2].position;
            m0 = nodes[nodes.Length - 1].position;
            m1 = nodes[seg + 1].position;

        }else if (seg == nodes.Length - 2)
        {
            p0 = nodes[seg].position;
            p1 = nodes[0].position;
            m0 = nodes[seg - 1].position;
            m1 = nodes[seg + 1].position;
        }
        else if (seg == nodes.Length - 1)
        {
            p0 = nodes[seg].position;
            p1 = nodes[1].position;
            m0 = nodes[seg - 1].position;
            m1 = nodes[0].position;
        }
        else
        {
            p0 = nodes[seg].position;
            p1 = nodes[seg + 2].position;
            m0 = nodes[seg - 1].position;
            m1 = nodes[seg + 1].position;
        }
        float x = (2.0f * ratio * ratio * ratio - 3.0f * ratio * ratio + 1.0f) * p0.x
        + (ratio * ratio * ratio - 2.0f * ratio * ratio + ratio) * m0.x
        + (-2.0f * ratio * ratio * ratio + 3.0f * ratio * ratio) * p1.x
        + (ratio * ratio * ratio - ratio * ratio) * m1.x;
        float y = (2.0f * ratio * ratio * ratio - 3.0f * ratio * ratio + 1.0f) * p0.y
        + (ratio * ratio * ratio - 2.0f * ratio * ratio + ratio) * m0.y
        + (-2.0f * ratio * ratio * ratio + 3.0f * ratio * ratio) * p1.y
        + (ratio * ratio * ratio - ratio * ratio) * m1.y;
        float z = (2.0f * ratio * ratio * ratio - 3.0f * ratio * ratio + 1.0f) * p0.z
        + (ratio * ratio * ratio - 2.0f * ratio * ratio + ratio) * m0.z
        + (-2.0f * ratio * ratio * ratio + 3.0f * ratio * ratio) * p1.z
        + (ratio * ratio * ratio - ratio * ratio) * m1.z;
        return new Vector3(x, y, z);
    }
    /*
    private void OnDrawGizmos()
    {
        nodes = GetComponentsInChildren<Transform>();
        for (int i = 0; i < nodes.Length-1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position,2);
        }
        Handles.DrawDottedLine(nodes[0].position, nodes[nodes.Length-1].position, 2);

    }
    */

}
