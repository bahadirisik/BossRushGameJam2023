using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject floatingText;
    [SerializeField] private GameObject floatingImmuneText;
    [SerializeField] private GameObject deathEffect;

    [SerializeField] private int enemyStartHealth = 100;
    [SerializeField] private int enemyHealth;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameMaster gameMaster;

    [SerializeField] private string deathSound;



    public bool enemyCanTakeDamage = true;
    [SerializeField] private bool isBoss;
    [SerializeField] private bool isClownBossBalloon;
    void Start()
    {
        enemyHealth = enemyStartHealth;

        if(isBoss)
            healthBar.SetMaxHealth(enemyStartHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
		{
            EnemyDeath();
		}
    }

    public void EnemyTakeDamage(int damage)
	{
        if (!enemyCanTakeDamage)
        {
            ShowFloatingImmuneText(floatingImmuneText);
            return;
        }

        ShowFloatingText(floatingText,damage);

        enemyHealth -= damage;

        if(isBoss)
            healthBar.SetHealth(enemyHealth);
	}

    public int GetEnemyHealth()
	{
        return enemyHealth;
	}

    void ShowFloatingText(GameObject text,int amount)
	{
        GameObject textGO = Instantiate(text,transform.position,Quaternion.identity);
        textGO.GetComponent<TextMeshPro>().text = amount.ToString();
	}

    void ShowFloatingImmuneText(GameObject text)
    {
        GameObject textGO = Instantiate(text, transform.position, Quaternion.identity);
    }

    void EnemyDeath()
    {
        if (isBoss || isClownBossBalloon)
        {
            gameMaster.UpdateEnemyCount(-1);
        }
        FindObjectOfType<AudioManager>().Play(deathSound);
        GameObject deathEffectGO = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectGO, 3f);
        Destroy(gameObject);
    }
}
