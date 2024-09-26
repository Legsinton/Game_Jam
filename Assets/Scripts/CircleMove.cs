using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public Vector2 startPosition = new Vector2(0, 0);
    public Vector2 launchDirection;
    public float maxLaunchForce = 10f;

    public float speed = 2;

    public Rigidbody2D rb;
    public LineRenderer lineRenderer;
    public float lineLengthMultiplier = 0.5f;
    public int HitsCount;
    public GameObject Djinn;
    public Vector2 endPosition;
    public float distance;
    public float launchForce;
    public float SlowDown = 0.8f;


    private Vector3 initialMousePos;
    private Vector3 finalMousePos;
    private bool isLaunched = false;

    //public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spinSprites;
    



    public float diameter = 0.2f;
    

    private void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = 1;
        rb.position = startPosition;
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

            endPosition = rb.position + launchDirection * Mathf.Min(launchForce, maxLineLength);

            if (Vector2.Distance(rb.position, endPosition) > maxLineLength)
            {
                endPosition = rb.position + (launchDirection * maxLineLength);
            }
            lineRenderer.SetPosition(1, endPosition);


            if (launchDirection.x < 0)
            {
                Djinn.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                Djinn.transform.localScale = new Vector3(1, 1, 1);
            }

            // Get the distance between the object and the mouse position
        

            // Map the distance to an index within the spriteArray
            // For example, you could divide distance by a factor to control sprite switching sensitivity
           

            

            // Set the MouseDistance parameter in the Animator
           // animator.SetFloat("Movement", distanceAni);



        }
        if (Input.GetMouseButtonUp(0) && lineRenderer.enabled == true && !isLaunched)
        {
            finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finalMousePos.z = 0f;
            launchDirection = (initialMousePos - finalMousePos).normalized;

            distance = Vector2.Distance(initialMousePos, finalMousePos);
            launchForce = Mathf.Clamp(distance, 0, maxLaunchForce);

            rb.AddForce(launchDirection * (launchForce * speed), ForceMode2D.Impulse);

            isLaunched = true;
            lineRenderer.enabled = false;

            Hit_Counter.Instance.AddCount();
            StartCoroutine(SpinBottle());

        }
        if (isLaunched && rb.velocity.magnitude == 0)
        {
            isLaunched = false;
        }


    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ResetStartPosition();
        }
    }*/



    public void ResetStartPosition()
    {
        rb.position = startPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    public void EnableDjinn()
    {
        if (isLaunched)
        {
            Djinn.SetActive(false);
        }
        if (!isLaunched)
        {
            Djinn.SetActive(true);
        }
    }




    // Update is called once per frame
    void Update()
    {

        Controls();
        EnableDjinn();
      
    }

    void OnMouseDrag()
    {

        //float distanceAni = Vector3.Distance(playerTransform.position, initialMousePos);

        // Set the MouseDistance parameter in the Animator
       // animator.SetFloat("Movement", distanceAni);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            rb.AddForce((-launchDirection * SlowDown) * (-launchForce * SlowDown), ForceMode2D.Impulse);
        }

    }

    private IEnumerator SpinBottle()
    {
        while (isLaunched && Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            // Loop through the sprites to simulate spinning
            for (int i = 0; i < spinSprites.Length; i++)
            {
                spriteRenderer.sprite = spinSprites[i]; // Set the current sprite
                yield return new WaitForSeconds(0.1f); // Wait a bit before switching to the next sprite
            }
        }
    }


}
