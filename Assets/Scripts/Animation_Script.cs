using UnityEngine;

public class AnimateScript : MonoBehaviour
{

    public Sprite[] spriteArray;  // Array containing your sprites
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer
    public Sprite[] spinSprites; // Array to hold all the frames from the sprite sheet
    public float spinSpeed = 0.1f; // How fast the sprites should change
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))

        {
            // Get the distance between the object and the mouse position
            float distance = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // Map the distance to an index within the spriteArray
            // For example, you could divide distance by a factor to control sprite switching sensitivity
            int spriteIndex = Mathf.Clamp((int)(distance / 2.5f), 0, spriteArray.Length - 1);

            // Update the sprite
            spriteRenderer.sprite = spriteArray[spriteIndex];
        }

       
    }

}
