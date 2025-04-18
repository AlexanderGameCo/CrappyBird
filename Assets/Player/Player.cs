using System;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDied;

    private static Vector3 StartingPosition;
    public float JumpForce { get; set; } = 5f;
    public float MaxVelocity { get; set; } = 5f;
    public float MaxAngle { get; set; } = 45f;
    private Rigidbody2D rigidBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetKeyUp(KeyCode.Space) && transform.position.y < 2.5f)
        {
            rigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
        }

        // Clamp Y
        rigidBody.linearVelocityY = math.clamp(rigidBody.linearVelocityY, -MaxVelocity, MaxVelocity);

        // Rotate Sprite as function of velocity
        float zRatio = rigidBody.linearVelocityY / MaxVelocity;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, zRatio * MaxAngle);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            OnPlayerDied?.Invoke();
        }
    }

    public void Reset()
    {
        transform.position = StartingPosition;
    }
}
