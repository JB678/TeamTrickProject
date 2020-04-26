using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public Sprite runSprite; 
    public Sprite runSprite2; 
    public Sprite jumpSprite;
    public Sprite crouchSprite;
    public Sprite idleSprite;
     public Sprite idleSprite2;

    public Collider2D platform;

    private float jumpTimer;
    private bool jumped; 
    private float animationTimer; 

    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        sr = GetComponent<SpriteRenderer>(); //Gets the spriterender (Needed to flip images for turning left)
        jumpTimer = 0.0f;
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer += Time.deltaTime; //Increasing the animation timer, needed for idle and walking animations 
        if(jumped){ //Jump timer to determine how long the character should float up/down dor
            jumpTimer += Time.deltaTime;
            if(jumpTimer < 0.5f){ //Going up
                rb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
            }
            else if(platform.IsTouching(GetComponent<Collider2D>())){ //Time for going up is over, jump is done and send character back down
                jumped = false;
                jumpTimer = 0.0f;
            }
            else{
                rb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
            }
        }
        



         //Makes character face the correct way. Only the rendering is affected. Use negative Transform.scale, if you want to affect all the other components (for example colliders).
        if(Input.GetKey(KeyCode.A)){
            sr.flipX = true;
        }
        else if(Input.GetKey(KeyCode.D)){
            sr.flipX = false;
        }


        //Main Sensing Input
        if(platform.IsTouching(GetComponent<Collider2D>()) && (Input.GetKeyDown(KeyCode.W))){ //Jumped on floor
              this.GetComponent<SpriteRenderer>().sprite = jumpSprite;
               jumped = true;
         }
         else if(Input.GetKey(KeyCode.A)){ //Move left
             if(jumped){ //Airborne, slight movment
             rb.AddForce(new Vector3(-4, 0, 0)); 
             }
             else{//Grounded, begin moving fast
             rb.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0.0f);
             //animate run
             if((int)(animationTimer % 2) == 0){
                 this.GetComponent<SpriteRenderer>().sprite = runSprite;
            }
            else if((int)(animationTimer % 2) == 1){
                this.GetComponent<SpriteRenderer>().sprite = runSprite2;
            }
             }
         }
        else if(Input.GetKey(KeyCode.D)){ //Move Right
             if(jumped){ //Airborne, slight movment
             rb.AddForce(new Vector3(4, 0, 0)); 
             }
             else{//Grounded, begin moving fast
             rb.GetComponent<Rigidbody2D>().velocity = new Vector2(4, 0.0f);
             //Animating walk 
            if((int)(animationTimer % 2) == 0){
                 this.GetComponent<SpriteRenderer>().sprite = runSprite;
            }
            else if((int)(animationTimer % 2) == 1){
                this.GetComponent<SpriteRenderer>().sprite = runSprite2;
            }
             }
         }
         else if(!jumped && Input.GetKey(KeyCode.S)){
             this.GetComponent<SpriteRenderer>().sprite = crouchSprite;
         }
         else if(!jumped && platform.IsTouching(GetComponent<Collider2D>())){ //Not airborne and no inputs, switch to idle animation
         rb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.0f); //Stop movement (Prevents momentum)
            
            //Animating idle 
            if((int)(animationTimer % 2) == 0){
                 this.GetComponent<SpriteRenderer>().sprite = idleSprite;
            }
            else if((int)(animationTimer % 2) == 1){
                this.GetComponent<SpriteRenderer>().sprite = idleSprite2;
            }
            else{//There's an issue preventing animation, check the console for logs
                Debug.Log("Animation Timer: " + animationTimer);
                Debug.Log("Animation Timer Mod 2: " + animationTimer % 2);
            }
         }


         if(Input.GetKey(KeyCode.Space)){
            //Need to Code here to fire attack from hero
        }
    }//End of Update
}//End of Script
