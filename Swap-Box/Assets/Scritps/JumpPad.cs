using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    Animator anim;
    public bool playerHasTochedJumpPad = false;

    [SerializeField] private float jumpForce = 15f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player") || other.gameObject.tag == "Box")
        {
            anim.SetBool("isSpringUp", true);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerHasTochedJumpPad = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isSpringUp", false);
    }


}
