using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    private float jumpForce = 10;
    public float gravityModifier = 1;

    public bool gameOver;

    public AudioClip jumpClip;
    public AudioClip explosionClip;

    private float lowerLimY = 4f;
    private float maxLimY = 6f;

    public ParticleSystem explosionParticleSystem;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

          
            playerAudioSource.PlayOneShot (jumpClip, 1);
        }

        if (transform.position.y < -lowerLimY)
        {
            Destroy(gameObject);
            Debug.Log("GAME OVER");
        }

        if (transform.position.y > maxLimY)
        {
            transform.position = new Vector3(transform.position.x, maxLimY, transform.position.z);
        }


    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Bomb"))
        {
            explosionParticleSystem.Play();

            playerAudioSource.PlayOneShot (explosionClip, 1);

            gameOver = true;
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
}
