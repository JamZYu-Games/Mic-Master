using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public GameObject ggameController;
    private Rigidbody rb;
    private GameController gameController;
    private AudioSource audioSource;
    bool moving;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moving = false;
        rb = GetComponent<Rigidbody>();
        gameController = ggameController.GetComponent<GameController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moving)
            {
                rb.velocity = Vector3.zero;
            }
            else
                rb.velocity = new Vector3(0f, 0f, -3f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spectrum"))
        {
            if (gameObject.CompareTag("Good"))
            {
                gameController.GetPoint();
                audioSource.Play(0);
                Debug.Log("Good");
            }
            if (gameObject.CompareTag("Bad"))
            {
                gameController.LosePoint();
                audioSource.Play(1);
                Debug.Log("Bad");
            }
            Destroy(gameObject);
        }
    }

}
