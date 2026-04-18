using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class C_Controller : MonoBehaviour{
    
    [SerializeField]bool CursorIsvisble;
    
    [Header ("Movement")]
    [SerializeField]float Speed;
    [SerializeField]string Horizontal,Vertical,Button_Attake="Fire1";


    private CharacterController _controller;
    GameManager gameManager;
    private float Axis_Horizontal, Axis_Vertical;    
    private Vector3 _move;    
    private Animator _anim;
    private bool Attake;

    private void Start() {
        _anim=gameObject.GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        gameManager=FindObjectOfType<GameManager>();
    }
    void Update(){
        Axis_Horizontal=CrossPlatformInputManager.GetAxisRaw(Horizontal);
        Axis_Vertical=CrossPlatformInputManager.GetAxisRaw(Vertical);
        Attake = CrossPlatformInputManager.GetButton(Button_Attake);
        
        _move=new Vector3(Axis_Vertical,0,Axis_Horizontal);
        Cursor.visible = CursorIsvisble;

        Atake();
        Rotate(_move);
        Movement(_move);       
    } 

        void Movement(Vector3 Moverse){ 
        _controller.Move(Moverse * Time.deltaTime * Speed);       
          if (Axis_Horizontal!=0){           
                 _anim.SetBool("IsRunning",true);             
        }if (Axis_Horizontal==0){                 
             _anim.SetBool("IsRunning",false);             
        }if (Axis_Vertical>=0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }if (Axis_Vertical==0){                 
             _anim.SetFloat("Speed",0.0f);             
        }if (Axis_Vertical<=-0.1f){                 
             _anim.SetFloat("Speed",1.0f);             
        }
        
    
    } 
    private void Atake() {
        if (Attake==true && gameManager.IsCoin==true){             
        _anim.SetBool("Ataque",true);
        }else{             
        _anim.SetBool("Ataque",false);
        }
    } 
      

void Rotate(Vector3 move){
        Vector3 Rotation=new Vector3 (move.x,0, move.z);        
         if (Axis_Horizontal!=0 || Axis_Vertical!=0){
          transform.rotation= Quaternion.LookRotation(Rotation);
        }
    }
    
}
