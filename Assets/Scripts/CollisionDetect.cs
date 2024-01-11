using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public GameObject hitParticle;
    private HealthBar npchealth;

    private KarakterKontrol krk;
    [SerializeField] Animator animator;
    
    public bool hasenter=false;
    

   /* private void OnTriggerEnter(Collider other)
    {
        if(hasdamage)
        return;
        
        if(!hasenter ){
        
        
        
        if(other.tag == "Enemy" && krk.attackoynuyor)
        {
            // Instantiate(hitParticle, new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z),other.transform.rotation);
            npchealth.UpdateHealthBar(krk.atakgücü);
            hasenter = true;
            hasdamage=true;
        }
        }

        else if(!krk.attackoynuyor)
        {
            hasdamage=false;
            hasenter = false;
        }
        
        
    }
    */

    private void OnTriggerEnter(Collider collider)
    {
        if(krk.hasdamage)
        return;
        

        if(collider.tag=="Boss" && krk.attackoynuyor==true)
        {
            collider.GetComponent<Boss>().TakeDamage(krk.atakgücü);
            krk.hasdamage=true;
        }
        if(collider.tag=="Enemy" && krk.attackoynuyor==true)
        {
            npchealth.UpdateHealthBar(krk.atakgücü);
            krk.hasdamage=true;
        }
       

        
    }
    void Start()
    {
        npchealth = FindAnyObjectByType<HealthBar>();
        krk = FindAnyObjectByType<KarakterKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
