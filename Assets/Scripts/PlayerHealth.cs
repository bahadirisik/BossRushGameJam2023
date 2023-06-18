using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerStartHealth = 100;
    [SerializeField] private int playerHealth;

    [SerializeField] private int playerStrength = 10;
    [SerializeField] private int startPlayerStrength = 10;

    private float startPlayerDamageTimer = 1f;
    private float playerDamageTimer;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private GameObject floatingTextRed;
    [SerializeField] private GameObject floatingTextGreen;
    [SerializeField] private ParticleSystem getsDamageEffect;

    [SerializeField] private GameObject restartPanel;

    private bool isDeath;
    void Start()
    {
        isDeath = false;
        playerStrength = startPlayerStrength;
        playerDamageTimer = startPlayerDamageTimer;
        playerHealth = playerStartHealth;

        healthBar.SetMaxHealth(playerStartHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0f)
		{
            PlayerDeath();
		}

        playerDamageTimer -= Time.deltaTime;
    }

    public void PlayerGetsDamage(int damage)
    {
        if (playerDamageTimer > 0f || isDeath)
        {
            return;
        }

        getsDamageEffect.Play();
        FindObjectOfType<AudioManager>().Play("TakingDamage");

        ShowFloatingText(floatingTextRed,damage);

        playerDamageTimer = startPlayerDamageTimer;
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
    }

    public void InstaDamage(int damage)
	{
        if (isDeath)
            return;

        FindObjectOfType<AudioManager>().Play("TakingDamage");
        ShowFloatingText(floatingTextRed, damage);
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
    }

    public void IncreasePlayerHealth(int amount)
	{
        playerHealth += amount;

        ShowFloatingText(floatingTextGreen,amount);

        if(playerHealth >= playerStartHealth)
		{
            playerHealth = playerStartHealth;
		}

        healthBar.SetHealth(playerHealth);
    }

    void PlayerDeath()
	{
        isDeath = true;
        restartPanel.SetActive(true);
        gameObject.SetActive(false);
	}

    public int GetPlayerStrength()
	{
        return playerStrength;
	}

    public void IncreasePlayerStrength(int amount)
	{
        StartCoroutine(StrengthBoost(amount));  
	}

    IEnumerator StrengthBoost(int amount)
	{
        playerStrength += amount;
        yield return new WaitForSeconds(5f);
        playerStrength = startPlayerStrength;
    }

    void ShowFloatingText(GameObject text,int amount)
	{
        GameObject textGO = Instantiate(text, transform.position, Quaternion.identity);
        textGO.GetComponent<TextMeshPro>().text = amount.ToString();
    }
}
