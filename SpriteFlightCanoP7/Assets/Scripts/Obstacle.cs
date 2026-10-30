using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
  public float minSize = 0.8f;
   public float maxSize = 2.0f;
   Rigidbody2D rb;
   public float minSpeed = 175f;
    float maxSpeed = 300f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 2);

        rb = GetComponent<Rigidbody2D>();

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
