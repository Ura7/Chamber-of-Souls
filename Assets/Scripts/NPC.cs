using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{
   private Animator animator;
   private NavMeshAgent nma;
   private float horizontal, vertical;

   public float maxDistance;
   private float takipzamani;
   private bool tut = false;

    public int health = 100;
   [SerializeField] GameObject player;

   [HideInInspector] public float npcstate;

   
    void Start()
    {
        
        animator = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        stateDegis();
        animationNPC();
        npcGezinti();
        
        
    }
    void npcGezinti()
    {

        if(npcstate!=0) return;

        if(Time.time > takipzamani)
        {
            float c = UnityEngine.Random.Range(-1,1);
            float d = UnityEngine.Random.Range(-1,1);
            takipzamani = Time.time  +5;
            nma.SetDestination(new Vector3(transform.position.x + UnityEngine.Random.Range(maxDistance/2,maxDistance)*c,0,transform.position.z + UnityEngine.Random.Range(maxDistance/2,maxDistance)*d));
            
        }
       
    }
    void stateDegis()
    {
        // Buranın matematiğini optimize et
        if((Math.Abs(transform.position.x) - Math.Abs(player.transform.position.x))<4f && Math.Abs(transform.position.z) -(+ Math.Abs(player.transform.position.z)) <4f)
        {
            npcstate = 1;
        }

        else npcstate=0;
    }
    void animationNPC()
    {
        animator.SetFloat("Horizontal",horizontal);
        animator.SetFloat("Vertical",vertical);
        animator.SetFloat("State",npcstate);
        
    }
    
    string getNpcState()
    {
        switch(npcstate)
        {
        case 0:
        return "None";
        

        case 1:
        return "Saldır";
        
        }
        return "Out";
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
        if(health<=0)
        {
            //animator.SetTrigger("Die");
            GetComponent<Collider>().enabled=false;
           
        }
        else 
        {
            //animator.SetTrigger("Hit");
        }
    }
}
