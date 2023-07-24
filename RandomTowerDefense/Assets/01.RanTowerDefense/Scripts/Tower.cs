using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range;         // 공격 범위
    public GameObject target;   // 몬스터
    public Animator animator;
    public GameObject Splash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.2f);      // 초당 5번 대기시간 없이 UpdateTarget 메서드를 실행시킴
    }

    private void OnDrawGizmosSelected()                 // 공격 범위를 표시해준다.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, Range);
    }

    private void UpdateTarget() // 타겟 업데이트
    {
        if(target == null)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");   // 하이어라키 창에 있는 tag가 Monster인 게임오브젝트를 모두 배열에 넣음
            float shortestDistance = Mathf.Infinity;                                // 가장 짧은 거리
            GameObject nearestMonster = null;                                       // 가장 가까운 몬스터
            foreach(GameObject Monster in Monsters)                                 // 임의의 게임오브젝트 안에 배열을 하나씩 넣고 아래의 내용을 실행함
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position);        // 타워와 몬스터의 거리 구하기

                if(DistanceToMonsters < shortestDistance)       // 가장 짧은 거리 보다 현재 몬스터의 거리가 짧다면
                {
                    shortestDistance = DistanceToMonsters;      // 가장 짧은 거리는 몬스터의 해당 몬스터와의 거리가 되고
                    nearestMonster = Monster;                   // 가장 가까운 몬스터는 해당 몬스터가 된다.
                }
            }

            if (nearestMonster != null && shortestDistance <= Range)        // 가장 가까운 몬스터가 존재하고, 공격 범위보다 안쪽에 있다면
            {
                target = nearestMonster;    // 타겟은 가장 가까운 몬스터가 되고
                ATTACK();                   // 공격한다.
            }
            else
            {
                target = null;
                IDLE();
            }
        }
        
    }

    public void ATTACK()
    {
        animator.SetBool("isShoot", true);

    }

    public void IDLE()
    {
        animator.SetBool("isShoot", false);
    }

    public void SplashDamage()
    {
        Instantiate(Splash,transform.position, Quaternion.identity);
    }
}
