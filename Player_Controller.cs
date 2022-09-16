using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;
    public GameObject winTextObject;
    public GameObject lossTextObject;

    private Rigidbody rb;
    private int count;
    private int lives;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;

        SetCountText();
        winTextObject.SetActive(false);
        lossTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 22)
        {
            winTextObject.SetActive(true);
        }

        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            lossTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;

            SetCountText();
        }

        else if (count == 7)
        {
            transform.position = new Vector3(50.0f, 0.5f, 0.0f);
        }

        else if (count == 14)
        {
            transform.position = new Vector3(100.0f, 0.05f, 0.0f);
        }

        else if (count == 22)
        {
            transform.position = new Vector3 (146.693f, 0.5f, 0.0f);
        }

        else if (lives == 0)
        {
            transform.position = new Vector3 (146.693f, 0.5f, 0.0f);
        }
    }
}
