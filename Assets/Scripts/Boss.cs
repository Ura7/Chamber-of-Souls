using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health = 100;

    public float bosshasar=20;
    public Animator animator;

    public GameObject boss;

    public Slider hpBar;

    void Update()
    {
        hpBar.value = health;
        if(animator.GetBool("isGetUp")==true)
        {
            hpBar.gameObject.SetActive(true);
        }
        else if(health<=0)
        {
            hpBar.gameObject.SetActive(false);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health-=damage;
        if(health<=0)
        {
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled=false;
            Invoke("Destroy",3f);
            
        }
        else 
        {
            animator.SetTrigger("Hit");
            
        }
    }

    
    private void Destroy()
    {
        Destroy(boss);
    }
}
