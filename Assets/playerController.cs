using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{   public float speed = 1;
    private Rigidbody _body;
    Animator animator;
    public float floater = 0;
    // Start is called before the first frame update
    void Start()
    {   
        _body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        var velocity = _body.velocity;
        _body.velocity = _body.velocity.normalized;
        
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            if(!Input.GetKey(KeyCode.LeftShift)){
                animator.SetBool("isWalking",true);
                animator.SetBool("isFull",false);
            }
            
            animator.SetBool("isIdle",false);
            velocity.x = 0;
            velocity.y = 0;
            velocity.z = 0;
            if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("Torus_002|TorusAction")){
                speed = 30;
            }else{
                speed = 20;
            }
            if(Input.GetKey("w")){
                velocity.z = -speed;
            }
            if(Input.GetKey("a")){
                velocity.x = speed;
            }
            if(Input.GetKey("s")){
                velocity.z = speed;
            }
            if(Input.GetKey("d")){
                velocity.x = -speed;
            }
            
        
        }else{
            velocity.x = 0;
            velocity.y = 0;
            velocity.z = 0;
            animator.SetBool("isWalking",false);
            animator.SetBool("isIdle",true);
            animator.SetBool("isFull",false);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("isFull",true);
            velocity.x = velocity.x * 4;
            velocity.z = velocity.z * 4;
        }
        _body.velocity = velocity;
        

    }
    private void FixedUpdate()
    {   
        // var velocity = _body.velocity;
        // print(speed);
        // velocity.y = speed;
        // _body.velocity = velocity;
        // if(speed == -10){
        //         speed = 1;
        //     }
        // if(speed == 10){
        //         speed = -1;
        // }
        
        // if(speed < 0){
        //     speed = speed - 1;
        // }
        // if(speed > 0){
        //     speed = speed + 1;
            
        // }
        
    }
    
}
