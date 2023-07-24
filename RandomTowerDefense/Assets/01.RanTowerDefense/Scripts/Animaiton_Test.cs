using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaiton_Test : MonoBehaviour
{
    public GameObject testObj;

    public void AttackButtonClick()
    {
        testObj.GetComponent<Tower>().ATTACK();
    }

    public void IdleButtonClick()
    {
        testObj.GetComponent<Tower>().IDLE();
    }
}
