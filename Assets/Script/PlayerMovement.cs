using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float playerMoveSpeed = 5f;
    [SerializeField] private float jumpPower = 10f;

    private Animator anim;
    private float playerMoveX;
    private Rigidbody2D body;
    private bool isGrounded = true;
    private bool isDead = false;
    private SpriteRenderer sr;

    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        // sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        // pergerakkan player di x-axis
        playerMoveX = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector3(playerMoveX * playerMoveSpeed, body.velocity.y);
        PlayerJump();
        SetAnimation();
    }

    private void SetAnimation()
    {
        // 
        if (playerMoveX > 0)
        {
            anim.SetBool("isWalk", true);
            transform.localScale = new Vector3(1f, 1f, 1);
            // sr.flipX = false;
        }

        else if (playerMoveX < 0)
        {
            anim.SetBool("isWalk", true);
            transform.localScale = new Vector3(-1f, 1f, 1);
            // sr.flipX = true;
        }

        else
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // jika apakah player berada di tanah atau tidak
        // jika tidak maka dia sedang loncat
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        else if (col.gameObject.tag == "Pit")
        {
            SoundManager.PlaySound("playerDeath");
            GetComponent<PlayerAttack>().enabled = false;
            isDead = true;
            anim.SetBool("isDead", isDead);
            this.enabled = false;
            StartCoroutine("MoveToMainView");
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Enemy")
        {
            SoundManager.PlaySound("playerDeath");
            print("player dead");
            // player mati dan semua pergerakkan didisabled
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            isDead = true;
            anim.SetBool("isDead", isDead);
            this.enabled = false;
            StartCoroutine("MoveToMainView");
        }

        if (col.tag == "Finish")
        {
            // player win
            anim.SetTrigger("win");
            GetComponent<PlayerMovement>().enabled = false;
            SoundManager.PlaySound("complete");
        }
    }

    private void PlayerJump()
    {
        // player lompat dengan tekan tombol spasi dan berada pada tanah
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            SoundManager.PlaySound("jump");
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            isGrounded = false;
        }
    }

    IEnumerator MoveToMainView()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main View");

    }
}
