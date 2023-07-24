using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range;         // ���� ����
    public GameObject target;   // ����
    public Animator animator;
    public GameObject Splash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.2f);      // �ʴ� 5�� ���ð� ���� UpdateTarget �޼��带 �����Ŵ
    }

    private void OnDrawGizmosSelected()                 // ���� ������ ǥ�����ش�.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, Range);
    }

    private void UpdateTarget() // Ÿ�� ������Ʈ
    {
        if(target == null)
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");   // ���̾��Ű â�� �ִ� tag�� Monster�� ���ӿ�����Ʈ�� ��� �迭�� ����
            float shortestDistance = Mathf.Infinity;                                // ���� ª�� �Ÿ�
            GameObject nearestMonster = null;                                       // ���� ����� ����
            foreach(GameObject Monster in Monsters)                                 // ������ ���ӿ�����Ʈ �ȿ� �迭�� �ϳ��� �ְ� �Ʒ��� ������ ������
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position);        // Ÿ���� ������ �Ÿ� ���ϱ�

                if(DistanceToMonsters < shortestDistance)       // ���� ª�� �Ÿ� ���� ���� ������ �Ÿ��� ª�ٸ�
                {
                    shortestDistance = DistanceToMonsters;      // ���� ª�� �Ÿ��� ������ �ش� ���Ϳ��� �Ÿ��� �ǰ�
                    nearestMonster = Monster;                   // ���� ����� ���ʹ� �ش� ���Ͱ� �ȴ�.
                }
            }

            if (nearestMonster != null && shortestDistance <= Range)        // ���� ����� ���Ͱ� �����ϰ�, ���� �������� ���ʿ� �ִٸ�
            {
                target = nearestMonster;    // Ÿ���� ���� ����� ���Ͱ� �ǰ�
                ATTACK();                   // �����Ѵ�.
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
