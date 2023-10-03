using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterController character;
    private Vector3 inputX;

    public float moduloDaVelocidade = 2.0f;
    public float gravity = 5.0f;
    public float force = 4.0F;
    public float jumpHeight = 8.0f;

    //public Animator animator;

    public bool estaNoChao = false;
    [SerializeField] private Transform GroundDetection;
    [SerializeField] private LayerMask cenarioMask;

void Start() 
{
    character = GetComponent<CharacterController>();
}
    void Update()
    {
        estaNoChao = Physics.CheckSphere(GroundDetection.position, 0.3f, cenarioMask);
        if (estaNoChao && inputX.y < 0)
        {
            inputX.y = 0f;
        }

        //inputX.Set(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        character.Move(Input.GetAxis("Vertical")* Time.deltaTime * moduloDaVelocidade * Camera.main.transform.forward);
        character.Move(Input.GetAxis("Horizontal")* Time.deltaTime * moduloDaVelocidade * Camera.main.transform.right);

        
        if(inputX != Vector3.zero)
        {
            //character.transform.forward = Vector3.Slerp(transform.forward, inputX, Time.deltaTime * 10);
        }

        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            inputX.y += Mathf.Sqrt(jumpHeight * force * gravity);
        }

        inputX.y += gravity * Time.deltaTime;
        character.Move(inputX * Time.deltaTime);
    }  
  
}