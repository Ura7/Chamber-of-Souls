using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollisionDetect : MonoBehaviour
{
    public float bosshasar=20;
    public GameObject sagkol;
    public GameObject solkol;
    
    public Animator animator;
    
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player")
        {
            collider.GetComponent<KarakterKontrol>().TakeDamage(bosshasar);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Start"))
        {
            sagkol.GetComponent<Collider>().enabled=true;
            solkol.GetComponent<Collider>().enabled=true;
           
        }
        else
        {
            sagkol.GetComponent<Collider>().enabled=false;
            solkol.GetComponent<Collider>().enabled=false;
        }
    }
}
