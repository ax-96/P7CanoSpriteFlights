using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour

{
    public float thrustForce = 1f;
    private float elapsedTime = 0f;

    private float score = 0f;
    public float scoreMultiplier = 10f;
    public GameObject boosterFlame;
    Rigidbody2D rb;

    public UIDocument uiDocument;
    private Label scoreText;
    private Button restartButton;
    public GameObject explosionEffect;
    private static object GetDebuggerDisplay()
    {
        throw new NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }

        if (Mouse.current.leftButton.isPressed)
        {
            //Calculate Mouse Direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction =(mousePos - transform.position).normalized;
          
            // Move player in direction of mouse
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    }


    