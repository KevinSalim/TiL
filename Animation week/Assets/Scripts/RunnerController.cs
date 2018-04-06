using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RunnerController : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public AudioSource myAudioSource;
    public AudioClip shootSound;
    public AudioClip deathSound;

    [Header("Move Controls")]
    public float speed = 5f;
    public float jumpforce = 8f;
    public bool IsFacingRight = true;
    public bool IsGrounded = false;

    [Header("Shooting")]
    public Transform ShootPoint;
    public GameObject ProjectilePrefab;
    public float ShootSpeed = 10f;
    public float ShootInterval = 0.2f;

    private float ShootTimer = 0f;

    [Header("Health")]
    public float CurrentHealth = 100f;
    public float MaxHealth = 100f;
    public bool IsDead = false;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDeath;

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        float horz = Input.GetAxis("Horizontal");
        myRigidbody.velocity = new Vector2(horz * speed, myRigidbody.velocity.y);

        myAnimator.SetFloat("Speed", Mathf.Abs(horz));

        if (horz > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            IsFacingRight = true;
        }
        else if (horz < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            IsFacingRight = false;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            myRigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetTrigger("Shoot");
        }
        else if (Input.GetButton("Fire1"))
        {
            ShootTimer += Time.deltaTime;
            if (ShootTimer >= ShootInterval)
            {
                myAnimator.SetTrigger("Shoot");
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            ShootTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            myAnimator.SetBool("IsGrounded", IsGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = false;
            myAnimator.SetBool("IsGrounded", IsGrounded);
        }
    }

    public void ShootGun()
    {
        Debug.Log("Shooting Gun!");
        GameObject bullet = GameObject.Instantiate(ProjectilePrefab);
        bullet.transform.position = ShootPoint.position;

        if(myAudioSource && shootSound)
            myAudioSource.PlayOneShot(shootSound);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (IsFacingRight)
        {
            bullet.transform.localScale = new Vector3(1f, 1f, 1f);
            rb.velocity = ShootPoint.right * ShootSpeed;
        }
        else
        {
            bullet.transform.localScale = new Vector3(-1f, 1f, 1f);
            rb.velocity = ShootPoint.right * -ShootSpeed;
        }

        Destroy(bullet, 2f);
    }

    public void TakeDamage(float damage)
    {
        if (!IsDead)
        {
        Debug.Log("Taking Damage: " + damage);
            CurrentHealth -= damage;
            //myAnimator.Play("Damaged");
            OnTakeDamage.Invoke();
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Die();
            }
        }
    }

    public void Die()
    {
        Debug.Log("Dead");
        CurrentHealth = 0f;
        IsDead = true;
        //myAnimator.Play("Death"); 
        OnDeath.Invoke();

        Invoke("ResetLevel", 1f);

        if (myAudioSource && deathSound)
            myAudioSource.PlayOneShot(deathSound);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
