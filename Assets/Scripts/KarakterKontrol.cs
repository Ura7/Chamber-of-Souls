using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Unity;
using UnityEditor;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class KarakterKontrol : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody1;
    [SerializeField] private FixedJoystick joystick1;
    [SerializeField] private Animator animator1;
    [SerializeField] private float move=5;

    [SerializeField] private float taklamove;
    [SerializeField] private float walkmove;
    private bool taklaoynuyor = false;
    public bool attackoynuyor = false;
    private float attackCD=0;
    private float taklaCD =0;

    public float health=100;

    public Slider hpbar;

    public bool hasdamage=false;
    
    public int atakgücü = 25;
    private GameObject NPC;
    private CollisionDetect colli;
     private HealthBar npchealth;
   
    void Start()
    {
        NPC.GetComponent<GameObject>();
        colli = FindAnyObjectByType<CollisionDetect>();
        npchealth = FindAnyObjectByType<HealthBar>();
    }

    private void FixedUpdate()
    {
            float yatay = joystick1.Horizontal;
            float dikey = joystick1.Vertical;
            
            UnityEngine.Vector3 ilerle = new UnityEngine.Vector3(yatay,0,dikey).normalized;
            if(ilerle.magnitude>=0.1f && taklaoynuyor==false)
            {
                float aci = Mathf.Atan2(ilerle.x,ilerle.z) * Mathf.Rad2Deg;
                aci += Camera.main.transform.eulerAngles.y;
                UnityEngine.Vector3 yon =  UnityEngine.Quaternion.Euler(0,aci,0) * UnityEngine.Vector3.forward;

                transform.rotation = UnityEngine.Quaternion.LookRotation(yon);
                transform.Translate(yon * move * Time.deltaTime, Space.World);
                animator1.SetBool("isRunning",true);
                /*
                float aci = Mathf.Atan2(ilerle.x,ilerle.z) * Mathf.Rad2Deg;
                aci += Camera.main.transform.eulerAngles.y;
                UnityEngine.Vector3 yon =  UnityEngine.Quaternion.Euler(0,aci,0) * UnityEngine.Vector3.forward;

                transform.rotation = UnityEngine.Quaternion.LookRotation(yon);
                transform.Translate(yon * walkmove * Time.deltaTime, Space.World);
                animator1.SetBool("isWalking",true);
                */
            }
            else{animator1.SetBool("isRunning",false);}

            
            


            
    }

    public void Tıkladetect()
    {
        if(Time.time>taklaCD)
        {
            animator1.SetBool("isRolling",true);
            taklaoynuyor=true;
            taklaCD = 1.2f+Time.time;
            Invoke("taklaDurdur",1.2f);
        }
    }
    public void taklaDurdur()
    {
        taklaoynuyor=false;
        animator1.SetBool("isRolling",false);
    }
     public void atackdetect()
    {
           if(Time.time > attackCD)
           {
            move = 0;
            transform.Translate(new UnityEngine.Vector3(0,0,0)*move,0);
            animator1.SetBool("isAttacking",true);
            attackoynuyor=true;
            attackCD = 1f+Time.time;
            Invoke("attackDurdur",1f);
           }
    }
    public void attackDurdur()
    {
        move =5;
        animator1.SetBool("isAttacking",false);
        attackoynuyor=false;
        hasdamage=false;
    }
    public void TakeDamage(float hasar)
    {
        if(animator1.GetBool("isRolling")==false)
        {
            health-=hasar;
        }
        
        if(health<=0)
        {
            animator1.SetTrigger("playerDie");
            Invoke("Death",4f);

        }
        else
        {
            //animator1.SetTrigger("playerHit");
            //Invoke("Hitreset",1f);
        }
    }

    private void Hitreset()
    {
        animator1.ResetTrigger("playerHit");
    }
    private void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
       
    }
    private void Respawn()
    {
         
    }

    

    void Update()
    {
        hpbar.value = health;
    }


    
}
