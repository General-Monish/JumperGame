using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJumpState : PlayerBaseState
{
    private Rigidbody rb;
     float JumpVale=13f;
    private bool canJump;


    public override  void EnterState(PlayerStateManager player)
    {
         rb = player.GetComponent<Rigidbody>();
    }
    public override  void UpdateState(PlayerStateManager player)
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.AddForce(Vector3.up * JumpVale, ForceMode.Impulse);
        }
        else
        {


        }
    }
    public override  void OnCollisionEnter(PlayerStateManager player,Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    public override  void OncollisionExit(PlayerStateManager player,Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    public override void OnTrigger(PlayerStateManager player, Collider collider)
    {
        if (collider.gameObject.tag == "Obs")
        {
            SceneManager.LoadScene("Game");
        }
    }

}
