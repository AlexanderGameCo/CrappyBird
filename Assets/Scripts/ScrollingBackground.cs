using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float ScrollSpeed = 1f;
    public GameObject bg1;
    public GameObject bg2;
    private float spriteWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteWidth = bg1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Move both backgrounds to the left
        bg1.transform.position += Vector3.left * ScrollSpeed * Time.deltaTime;
        bg2.transform.position += Vector3.left * ScrollSpeed * Time.deltaTime;

        // If a part has moved completely off-screen, reposition it to the right
        if (bg1.transform.position.x <= -spriteWidth)
        {
            bg1.transform.position += Vector3.right * spriteWidth * 2f;
        }

        if (bg2.transform.position.x <= -spriteWidth)
        {
            bg2.transform.position += Vector3.right * spriteWidth * 2f;
        }
    }
}
