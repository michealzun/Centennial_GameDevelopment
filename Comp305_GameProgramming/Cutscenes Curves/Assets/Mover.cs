using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Rail rail;
    public int type = 0;
    public int curSeg;
    float ratio;

	void Update () {
        if (!rail)
        {
            return;
        }
        Play();
	}

    private void Play()
    {
        switch (type)
        {
            case 0:
                ratio += Time.deltaTime*3;
                if (ratio > 1)
                {
                    ratio = 0;
                    if (curSeg < rail.nodes.Length - 1)
                    {
                        curSeg++;
                    }
                    else
                    {
                        curSeg = 0;
                    }
                }
                this.transform.position = rail.linearPosition(curSeg, ratio);
                break;
            case 1:
                ratio += Time.deltaTime*3;
                if (ratio > 1)
                {
                    ratio = 0;
                    if (curSeg < rail.nodes.Length - 1)
                    {
                        curSeg++;
                    }
                    else
                    {
                        curSeg = 0;
                    }
                }
                this.transform.position = rail.catmullPosition(curSeg, ratio);
                break;
            case 2:
                ratio += Time.deltaTime;
                if (ratio > 1)
                {
                    ratio = 0;
                    if (curSeg < rail.nodes.Length - 3)
                    {
                        curSeg+=3;
                    }
                    else if(curSeg < rail.nodes.Length - 2)
                    {
                        curSeg = 0;
                    }
                    else if (curSeg < rail.nodes.Length - 1)
                    {
                        curSeg = 1;
                    }
                    else { curSeg = 2; }
                }
                this.transform.position = rail.BeizierPosition(curSeg, ratio);
                break;
            case 3:
                ratio += Time.deltaTime * 2;
                if (ratio > 1)
                {
                    ratio = 0;
                    if (curSeg < rail.nodes.Length - 2)
                    {
                        curSeg +=2;
                    }
                    else
                    {
                        curSeg = 0;
                    }
                }
                this.transform.position = rail.hermitePosition(curSeg, ratio);
                break;
            default:
                break;
        }
    }
}
