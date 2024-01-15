using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    

   public PlayerIdolState IdolState = new PlayerIdolState();
    public PlayerJumpState JumpState = new PlayerJumpState();

    public void Start()
    {
        
        currentState = JumpState;
        currentState.EnterState(this);
       
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

     void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
     
    }

    private void OnCollisionExit(Collision collision)
    {
        currentState.OncollisionExit(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTrigger(this,other);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
