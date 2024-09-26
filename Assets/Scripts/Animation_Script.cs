using UnityEngine;

public class AnimateScript : MonoBehaviour
{

    public Sprite[] spriteArray;  // Array containing your sprites
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer
    public Sprite[] spinSprites; // Array to hold all the frames from the sprite sheet
    public float spinSpeed = 0.1f; // How fast the sprites should change
    private SpriteRenderer spinRenderer;
    private Rigidbody2D rb;
    private int currentFrame;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spinRenderer = GetComponent<SpriteRenderer>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()


    {
        if (Input.GetMouseButton(0))

        {



            // Get the distance between the object and the mouse position
            float distance = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // Map the distance to an index within the spriteArray
            // For example, you could divide distance by a factor to control sprite switching sensitivity
            int spriteIndex = Mathf.Clamp((int)(distance / 2), 0, spriteArray.Length - 1);

            // Update the sprite
            spriteRenderer.sprite = spriteArray[spriteIndex];

        }

       
    }

    void SpinBottle()
    {
        timer += Time.deltaTime;
        if (timer >= spinSpeed)
        {
            currentFrame = (currentFrame + 1) % spinSprites.Length; // Loop through sprites
            spriteRenderer.sprite = spinSprites[currentFrame]; // Set the current sprite
            timer = 0f; // Reset timer
        }
    }
}
