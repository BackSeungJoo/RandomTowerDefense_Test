using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range;         // 공격 범위
    public GameObject target;   // 몬스터
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void UpdateTarget() // 타겟 업데이트
    {
        if(target == null)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
            float shortestDistance = Mathf.Infinity;    // 가장 짧은 거리
            GameObject nearestMonster = null;           // 가장 가까운 몬스터
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
