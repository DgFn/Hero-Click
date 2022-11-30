using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Scene;
    Animator m_Animator;
    void Start()
    {
       m_Animator = this.transform.GetComponent<Animator>();
    }
    //Запуск и остановка анимации врага
    public void GetDamage()
    {
        StartAnim();
        if (Scene == 1)
        {
            FindObjectOfType<WoodDoll_Mgr>().Sword_Hitted();
        }

    }

    public void StartAnim()
    {
        m_Animator.Play("Hit");
    }

    public void DeathAnim()
    { 
            m_Animator.Play("Die"); 
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
