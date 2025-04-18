using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private bool isAttacking;
    private bool jumpPressed = false;
    private bool Good = false;
    private bool Bad = false;
    public bool isInvincible = false;
    public GameObject attackObject;
    public GameObject over;
    public AudioSource audioSource;
    public AudioClip punchClip;
    public AudioClip jumpsClip;
    public AudioClip workClip;
    public AudioClip GameClip;
    public void PlayPunchSound()
    {
        audioSource.PlayOneShot(punchClip);
        Debug.Log("펀치 소리 재생 시도");
    }
   

    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
   


    // Update is called once per frame
    void Update()
    {
        if (Good)
        {
            jumpForce = 24f;
        }

        if (Bad)
        {
            moveSpeed = 7f;


        }





        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
        float moveInput = Input.GetAxisRaw("Horizontal");

        // 이동
        if (!isAttacking)
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        if (moveInput < 0)
        {

            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        // 캐릭터 방향 전환
        if (moveInput > 0)
        {

            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // 점프
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("스페이스 눌림!");
            audioSource.PlayOneShot(jumpsClip);
        }



        // 공격
        if (Input.GetKeyDown(KeyCode.K) && isGrounded && !isAttacking)
        {
            StartCoroutine(Attack());
        }

        // 애니메이션
        anim.SetBool("isRunning", moveInput != 0);
        anim.SetBool("isJumping", !isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);

    }


    System.Collections.IEnumerator Attack()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        attackObject.SetActive(true);
        PlayPunchSound(); // 🔊 소리 재생

        yield return new WaitForSeconds(0.4f);


        attackObject.SetActive(false);
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }







    void FixedUpdate()
    {

        if (jumpPressed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        jumpPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();


        }
        if (collision.CompareTag("Respawn"))
        {
            audioSource.PlayOneShot(GameClip);
            over.SetActive(true);
            Time.timeScale = 0f;




        }

        if (collision.CompareTag("Enemy"))
        {

            if (attackObject.activeSelf)
            {
                return;


            }
            if (isInvincible)
            {
                Debug.Log("무적 상태! 적 무시함");
                return; // 무적이면 씬 리셋 안 함
            }
            audioSource.PlayOneShot(GameClip);
            over.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("아야 아파요");
        }

            if (collision.CompareTag("Item"))
            {
                Good = true;
                Destroy(collision.gameObject);
            }
            if (collision.CompareTag("Bad"))
            {
                Bad = true;
                Destroy(collision.gameObject);
            }


        if (collision.CompareTag("InvincibleItem"))
        {
            Debug.Log("무적 아이템 먹음!");
            StartInvincibility();
            Destroy(collision.gameObject); // 아이템 사라짐
        }








    }
    public void StartInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        Debug.Log("무적 시작!");

        yield return new WaitForSeconds(5f);

        isInvincible = false;
        Debug.Log("무적 끝!");
    }

}





