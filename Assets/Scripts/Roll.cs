using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Roll : MonoBehaviour
{
    bool isPressed;
    public GameObject player;
    public float force;

    [SerializeField] private Animator animator11;
    [SerializeField] private Rigidbody rigid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        
        
        
        /*if(isPressed)
        {
            
            rigid.velocity = player.transform.position * force * Time.deltaTime;
            animator11.SetBool("isRolling",true);
            
        }
        else {
            animator11.SetBool("isRolling",false);
        }
        */

    }
    

    



    /*public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
     public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
          */
   
}
