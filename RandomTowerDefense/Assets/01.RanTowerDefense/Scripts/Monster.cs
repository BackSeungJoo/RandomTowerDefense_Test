using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public float StartHealth;
    public float Health;

    public GameObject DamageText;
    public GameObject TextPos;

    public GameObject HealthBar;

    public void GetDamage(int damage)
    {
        GameObject dmgText = Instantiate(DamageText, TextPos.transform.position, Quaternion.Euler(90f, 0f, 0f));
        dmgText.GetComponent<Text>().text = damage.ToString();

        Health -= damage;
        HealthBar.GetComponent<Image>().fillAmount = Health / StartHealth;


        Destroy(dmgText, 0.5f);
    }
}
