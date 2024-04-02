using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{ 
    //definimos las interface/contratos
    /*el juego va tener moviento horizontal y salto
     * y solo 1 velocidad horizontal (O sea no camina y corre)
     * asi que el contrato ser move.run(float speed)
     * y el de salto move.jump(bool isJump)*/

    void Start()
    {
        
    }
        
    void Update()
    {
        Input.GetAxisRaw("Horizontal");
        Input.GetButtonDown("Jump");
        
    }
}
