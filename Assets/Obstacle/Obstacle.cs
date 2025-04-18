using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event Action OnObstacleDestroyed;
    public float ScrollSpeed = 0.1f;
    private bool outOfBounds = false;
    public GameObject pipeTop;
    public GameObject pipeBottom;
    private AudioSource pointAudio;
    private float easyDistance = 2.5f;
    private float hardDistance = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointAudio = GetComponent<AudioSource>();
        float randomY = UnityEngine.Random.Range(-0.5f, 0.5f);
        transform.Translate(0, randomY, 0);
        transform.Translate(0, randomY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - ScrollSpeed * Time.deltaTime, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        if (gameObject.transform.localPosition.x <  -0.75f && outOfBounds == false)
        {
            outOfBounds = true;
            //TODO: Grant Point
            pointAudio.Play();
            StartCoroutine(DestroyWhenDone());
        }
    }

    public void SetDifficulty(float difficulty)
    {
        var distance = math.lerp(easyDistance, hardDistance, difficulty);

        pipeTop.transform.localPosition = new Vector3(0, distance, 0);
        pipeBottom.transform.localPosition = new Vector3(0, -distance, 0);
    }

    private IEnumerator DestroyWhenDone()
    {
        if (pointAudio is not null)
        {
            while (pointAudio.isPlaying)
            {
                yield return null;
            }
        }
        OnObstacleDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
