using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float JumpVale;
    private bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.AddForce(Vector3.up * JumpVale, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag== "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obs")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
