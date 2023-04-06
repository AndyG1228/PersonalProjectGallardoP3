using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool fallen = false;
    private float doom;

    private Rigidbody playerRb;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float turnSpeed = 20.0f;

    private AudioSource playerAudio;
    public AudioClip fallSound;

    // Start is called before the first frame update
    void Start()
    {
        //Gather  components for later use
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //rotates the character around the y-axis through horizontal input (A and D)
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        //movess the character forward through vertical input (W and S)
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //Constantly changes "doom" status to the player's location each frame
        doom = transform.position.y;

        //only invvokes if you haven't fallen
        if (!fallen)
        {
            WhereAmI();
        }

    }

    void WhereAmI()
    {
        if (doom < -0.1f)
        {
            //if doom goes past a certain point, player has fallen (game over)
            playerAudio.PlayOneShot(fallSound, 1.0f);
            fallen = true;
        }
    }
}
