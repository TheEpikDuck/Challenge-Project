//player movement used for world 1-1 and 1-2
//used a tutorial for this

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Speeds { Slow = 0}

public class Movement : MonoBehaviour
{
    public Speeds CurrentSpeed;
    float[] SpeedValues = {8f};

    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    bool isGrounded = false;

    private Vector3 respawnPoint;
    public GameObject deathBarrier;
    public GameObject enemy;
    public int Respawn;

    private Animator anim;
    public AudioSource background;
    public AudioSource death;
    public AudioSource finish;
    

    Rigidbody2D rb;
    AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
        background.Play();
    }

    void Update()
    {
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;
        GroundCheck();

        if(Input.GetKeyDown(KeyCode.Space))
        {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 26f, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);  
        }  

        else
        anim.SetBool("isJumping", false);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Barrier")
            {
                
                background.Stop();
                death.Play();
                transform.position = respawnPoint;
            }

            if(collision.tag == "NextLevel")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                respawnPoint = transform.position;
            }
            if (collision.tag == "Enemy")
            {
                background.Stop();
                death.Play();
                transform.position = respawnPoint;
            }
            StartCoroutine(WaitBeforeRespawn());

        IEnumerator WaitBeforeRespawn()
        {
            background.Stop();
            
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(collision.tag == "End")
        {
           background.Stop();
           finish.Play();
           this.gameObject.SetActive(false);
        }
    }
    
    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
        if (colliders.Length > 0)
            isGrounded = true;
    }
}
