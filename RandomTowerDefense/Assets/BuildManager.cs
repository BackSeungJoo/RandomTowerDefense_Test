using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    

    public GameObject SelectNode;
    public GameObject Tower;

    public void BuildToTower()
    {
        Instantiate(Tower, SelectNode.transform.position, Quaternion.identity);
    }
}
