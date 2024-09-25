using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{

    public Vector2 launchDirection;
    public float maxLaunchForce = 10f;
    public Rigidbody2D rb;
    public LineRenderer lineRenderer;
    public float lineLengthMultiplier = 0.5f;

    
    private Vector3 initialMousePos;
    private Vector3 finalMousePos;
    private bool isLaunched = false;
    

    
    public float diameter = 0.2f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;

        
    }

    private void Controls()
    {
        if (Input.GetMouseButtonDown(0) && !isLaunched)
        {
            initialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialMousePos.z = 0f;



            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, rb.position);



        }
        if (Input.GetMouseButton(0) && !isLaunched)
        {
            Vector3 finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finalMousePos.z = 0f;

            launchDirection = (initialMousePos - finalMousePos).normalized;
            float distance = Vector2.Distance(initialMousePos, finalMousePos);
            float launchForce = Mathf.Clamp(distance, 0, maxLaunchForce);
            float maxLineLength = maxLaunchForce;

            Vector2 endPosition = rb.position + (launchForce * lineLengthMultiplier * launchDirection);

            if (Vector2.Distance(rb.position, endPosition) > maxLineLength)
            {
                endPosition = rb.position + (launchDirection * maxLineLength);
            }
            lineRenderer.SetPosition(1, endPosition);

        }
        if (Input.GetMouseButtonUp(0) && lineRenderer.enabled == true && !isLaunched)
        {
            finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finalMousePos.z = 0f;
            launchDirection = (initialMousePos - finalMousePos).normalized;

            float distance = Vector2.Distance(initialMousePos, finalMousePos);
            float launchForce = Mathf.Clamp(distance, 0, maxLaunchForce);

            rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            isLaunched = true;
            lineRenderer.enabled = false;
        }
        if (isLaunched && rb.velocity.magnitude == 0)
        {
            isLaunched = false;
        }
    }




    // Update is called once per frame
    void Update()
    {

        Controls(); 

    }
}
