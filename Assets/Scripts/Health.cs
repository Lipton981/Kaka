using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float blya = 100;
    public string damageTag = "enemy";
    public float touchDamage = 10;
    public Text hp;
    public Text kill;

    public static int kills = 0;

    private bool canTakeDamage = true;

    public void TakeDamage(float damage)
    {
        blya -= damage;

        if (blya <= 0)
        {
            Die();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(damageTag) && canTakeDamage)
        {
            TakeDamage(touchDamage);
            StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }

    private void Die()
    {
        if (CompareTag("Player"))
        {
            kills = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            kills++;

            if (kills >= Slozhnost.winkills)
            {
                kills = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (CompareTag("Player"))
        {
            hp.text = "" + (int)blya;
            kill.text = "" + kills;
        }
    }

    void Start()
    {
        if (!CompareTag("Player"))
        {
            blya = Slozhnost.enemyHp;
            touchDamage = Slozhnost.enemyDamage;
        }
    }
}