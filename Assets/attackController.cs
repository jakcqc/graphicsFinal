using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class attackController : MonoBehaviour
{
    public TMP_Text textMain;
    public Transform attackTransform;
    public Transform playerTransform;
    public Transform bossTransform;
    private Rigidbody _attack; 
    public int bossHP = 100;
    private bool flipper = false; 
    public Light crown; 
    // Start is called before the first frame update
    void Start()
    {
        _attack = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("space") || Input.GetKey(KeyCode.LeftShift) && bossHP != 0){
            textMain.text = "Life is a series of natural and spontaneous changes. Don't resist them; that only creates sorrow. Let reality be reality. Let things flow naturally forward in whatever way they like.";
        }
        if(bossHP == 0){
            bossTransform.localScale = new Vector3(0,0,0);
            textMain.text = "A seed grows with no sound but a tree falls with huge noise. Destruction has noise, but creation is quiet. This is the power of silence. Grow silently.";
            
        }
        var velocity = _attack.velocity;
        var attackPos = attackTransform.position;
        if(!flipper){
            attackPos.x = playerTransform.position.x - 3;
            attackPos.y = playerTransform.position.y;
            attackPos.z = playerTransform.position.z - 2;
            
        }

        if(Input.GetKey("space") && !flipper && !Input.GetKey(KeyCode.LeftShift)){
            attackTransform.localScale = new Vector3(10,10,10);
            attackPos.y = -30;
            velocity.z = -250;
            velocity.y = 15;
            flipper = true;
            
        }
        
        
        attackTransform.position = attackPos;
        _attack.velocity = velocity;
        
    }
    private void OnCollisionEnter(Collision other)
    {
        var velocity = _attack.velocity;
        if(other.gameObject.name == "bossObject"){
            bossHP = bossHP - 20;
            
            crown.intensity = crown.intensity - 100;
            crown.range = crown.range - 2;
            attackTransform.localScale = new Vector3(0,0,0);
            velocity.z = 0;
            velocity.y = 0;
            flipper = false;

        }
        if(other.gameObject.name != "cube"){
            attackTransform.localScale = new Vector3(0,0,0);
            velocity.z = 0;
            velocity.y = 0;
            flipper = false;
        }
        
        Debug.Log(other.gameObject.name);

    }
}
