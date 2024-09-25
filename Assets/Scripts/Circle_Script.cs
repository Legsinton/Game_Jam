
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Circle_Script : MonoBehaviour
{

    public Vector2 CirclePosition;
    public Vector2 velocity = Vector2.zero;
    public float speed = 2;
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
        
        //When you press down the mouse button and set circleposition
        if (Input.GetMouseButtonDown(0) && currentJumps == MaxJump)
        {
           
                velocity = Vector2.zero;
                CirclePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // transform.position = CirclePosition;
            
       
        }

       
        // Launch the object and add to current jumps
        if (Input.GetMouseButtonUp(0) && currentJumps == MaxJump)
        {
            currentJumps++;
            velocity =  (Vector3)CirclePosition.normalized - Camera.main.ScreenToWorldPoint(Input.mousePosition) * speed;
           
        }

     
   
        // Apply velocity to move the object
        rb2D.velocity = velocity;
        // Apply gravity to y axis
        velocity.y -= gravity * Time.deltaTime;
       
        
        //Dont use   
        //velocity.x /= deacceliration * Time.deltaTime; 
           
        
        // Set Maxspeed to both axis
        velocity.x = Mathf.Clamp(velocity.x, -MaxSpeed, MaxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -MaxSpeed, MaxSpeed);

    }
    // Collision Tags for obsticoles
    void OnCollisionEnter2D(Collision2D collision)
    {
        //For the walls
        if (collision.gameObject.CompareTag("Wall"))
        {

            velocity.x = -velocity.x * 0.9f;
        }
        // For the game objects
        if (collision.gameObject.CompareTag("Roof"))
        {

            velocity.y = -velocity.y * 0.8f;
        }
        // And for the platforms
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


