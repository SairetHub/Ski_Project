using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration = 100, turnSpeed = 100,
        minSpeed = 0, maxSpeed = 500, minAcceleration = -100, maxAcceleration = 300;
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float knockBackForce = 300, knockUpForce = 400;

    [Header("Audio")]
    [SerializeField] private AudioClip skiingSound;
    private AudioSource audioSource;

    private float speed = 0;
    private Rigidbody rb;
    private Animator animator;
    private bool isHurt = false;

    private void OnEnable()
    {
        GameEvents.TakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        GameEvents.TakeDamage -= TakeDamage;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = skiingSound;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    private void TakeDamage()
    {
        Debug.Log("Player was hurt");
        rb.AddForce(-transform.forward * knockBackForce);
        rb.AddForce(transform.up * knockUpForce);
        isHurt = true;
        if (audioSource.isPlaying)
            audioSource.Pause();

        Invoke("Recover", 1.5f);
    }

    private void Recover()
    {
        isHurt = false;
    }

    private void FixedUpdate()
    {
        if (isHurt)
            return;

        float angle = Mathf.Abs(transform.eulerAngles.y - 180);
        acceleration = Remap(0, 90, maxAcceleration, minAcceleration, angle);
        speed += acceleration * Time.fixedDeltaTime;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        Vector3 velocity = speed * transform.forward * Time.fixedDeltaTime;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        animator.SetFloat("playerSpeed", speed);

        HandleSkiingSound();
    }

    private void HandleSkiingSound()
    {
        bool isGrounded = Physics.Linecast(transform.position, groundPoint.position, groundLayer);

        if (!isHurt && isGrounded && speed > 5f) 
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
    }

    private void Update()
    {
        bool isGrounded = Physics.Linecast(transform.position, groundPoint.position, groundLayer);
        if (isGrounded && !isHurt)
        {
            if (Input.GetKey(leftInput) && transform.eulerAngles.y < 269)
            {
                transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0), Space.Self);
            }
            if (Input.GetKey(rightInput) && transform.eulerAngles.y > 91)
            {
                transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0), Space.Self);
            }
        }
    }

    private float Remap(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }
}




