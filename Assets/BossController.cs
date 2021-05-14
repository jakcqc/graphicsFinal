using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class BossController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody _body;
    public Transform bossAttack;
    public Transform playerTransform;
    public TMP_Text textMain;

    // Start is called before the first frame update
    void Start()
    {   
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = _body.velocity;
        var attackPos = bossAttack.position;
        if(bossAttack.position.x < playerTransform.position.x){
            velocity.x++;
        }
        if(bossAttack.position.y < playerTransform.position.y){
            velocity.y++;
        }
        if(bossAttack.position.z < playerTransform.position.z){
            velocity.z++;
        }
        
        _body.velocity = velocity;
        
    }
    void FixedUpdate(){
        

    }
    private void OnCollisionEnter(Collision other)
    {
        var velocity = _body.velocity;
        var attackPos = bossAttack.position;
        if(other.gameObject.name == "playerObject"){
            textMain.text = "Nature does not hurry, yet everything is accomplished.";
            playerTransform.localScale = new Vector3(0,0,0);

        }
            attackPos.x = -6.5f;
            attackPos.y = 45.2f;
            attackPos.y = -22.1f;
            velocity.x = 0;
            velocity.z = 0;
            velocity.y = 0;
            
        
        

    }
}
