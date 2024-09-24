
using Unity.VisualScripting;
using UnityEngine;

public class Circle_Script : MonoBehaviour
{

    public Vector2 CirclePosition;
    public Vector2 velocity = Vector2.zero;
    public float speed = 2;
    public float deacceliration = 1.1f;
    public float gravity = 9.98f;
    public float MaxSpeed = 5;
    public float stopSpeed = 15f;
    public float groundCheckDistance = 0.05f;
    public int MaxJump = 0;

    float feetOffset;
    int currentJumps;

    Rigidbody2D rb2D;

    
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

        //setting so raycasts don't hit the object they start in.
        Physics2D.queriesStartInColliders = false;

        //Calculate player size based on our colliders, length of raycast
        feetOffset = GetComponent<Collider2D>().bounds.extents.y;// + 0.02f;


    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && currentJumps == MaxJump)
        {
           
                velocity = Vector2.zero;
                CirclePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // transform.position = CirclePosition;
            
       
        }

       

        if (Input.GetMouseButtonUp(0) && currentJumps == MaxJump)
        {
            currentJumps++;
            velocity =  (Vector3)CirclePosition.normalized - Camera.main.ScreenToWorldPoint(Input.mousePosition) * speed;
           
        }

     
   
        // Apply velocity to move the object
        //transform.position += (Vector3)velocity * Time.deltaTime;
        rb2D.velocity = velocity;
        velocity.y -= gravity * Time.deltaTime;

        // Gradually slow down the object over time
       
        
           
        //velocity.x /= deacceliration * Time.deltaTime;  // Apply deceleration
           
        

        velocity.x = Mathf.Clamp(velocity.x, -MaxSpeed, MaxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -MaxSpeed, MaxSpeed);






    }

    /*private void GroundCheck()
    {
        //Calculate our ray start position
        var rayPos = rb2D.velocity;
        rayPos.y -= feetOffset;

        //Fire a raycast
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.down, groundCheckDistance);

        //Debug draw our ray so we can see it.
        Debug.DrawRay(rayPos, Vector2.down * groundCheckDistance);

        // If it hits something...
        if (hit.collider != null)
        {
            currentJumps = 0;

        }
    }
    */
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            velocity.x = -velocity.x * 0.9f;
        }

        if (collision.gameObject.CompareTag("Roof"))
        {

            velocity.y = -velocity.y * 0.8f;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {

            velocity.x = velocity.x / stopSpeed;
            velocity.y = velocity.y / stopSpeed;
            currentJumps = 0;
            //velocity = Vector2.zero;
            if (velocity.x > 0 || velocity.x < 10 || velocity.y > 0 || velocity.y < 10)
            {
                velocity = Vector2.zero;

            }
        }

    }
}


