using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range;         // ���� ����
    public GameObject target;   // ����
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void UpdateTarget() // Ÿ�� ������Ʈ
    {
        if(target == null)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
            float shortestDistance = Mathf.Infinity;    // ���� ª�� �Ÿ�
            GameObject nearestMonster = null;           // ���� ����� ����
            foreach(GameObject Monster in Monsters)
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position);

                if(DistanceToMonsters < shortestDistance)
                {
                    shortestDistance = DistanceToMonsters;
                    nearestMonster = Monster;
                }
            }

            if (nearestMonster != null && shortestDistance <= Range)
            {
                target = nearestMonster;
                ATTACK();
            }
            else
            {
                IDLE();
                target = null;
            }
        }
        
    }

    private void ATTACK()
    {
        animator.SetBool("isShoot", true);
    }

    private void IDLE()
    {
        animator.SetBool("isShoot", false);
    }
}
