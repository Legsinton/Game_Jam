using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Line_Script : MonoBehaviour
{

    Vector3 StartPos;
    Vector3 EndPos;
   public LineRenderer Lr;
    Vector3 CamOffset = new Vector3(0, 0, 10);
    //[SerializeField] AnimationCurve ac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (Lr == null)

            {
                Lr = gameObject.AddComponent<LineRenderer>();
            } 

            Lr.enabled = true;
            Lr.positionCount = 2;
            StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + CamOffset;
            Lr.SetPosition(0, StartPos);
            Lr.useWorldSpace = true;
           // Lr.widthCurve = ac;
        }

        if (Input.GetMouseButton(0))

        {
            EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + CamOffset;
            Lr.SetPosition(1,EndPos);
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            Lr.enabled = false;
        
        }
    }
}

