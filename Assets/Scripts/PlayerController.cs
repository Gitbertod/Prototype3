using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem particleSystem;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crash;
    public AudioSource playerSound;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    
    void Start()
    {
        playerSound = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            playerSound.PlayOneShot(jumpSound,1);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
            dirtParticles.Play();
            
        }else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
            particleSystem.Play();
            dirtParticles.Stop();
            playerSound.PlayOneShot(crash,1);
            
        } 
    }

}
