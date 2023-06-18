using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorBoss : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform[] totemPositions;

    [SerializeField] private GameObject gladiatorWeapon;
    [SerializeField] private GameObject gladiatorBossAttack2;
    [SerializeField] private GameObject gladiatorBossAttack3;
    [SerializeField] private GameObject bossTotem;
    [SerializeField] private GameObject scorpionEnemy;

    [SerializeField] private GladiatorBossMovement gladiatorBossMovement;

    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;

    [SerializeField] private float gladiatorWeaponSpeed = 20f;
    private float gladiatorWeaponSpeedMultiplier = 2f;
    private float bossAttack2Rotation = 0f;
    private int bossFirstAttackCount = 5;

    [SerializeField] private bool isPhase3 = false;
    void Start()
    {
        isPhase3 = false;
        bossAttack2Rotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		if (isPhase3)
		{
            if(GameObject.FindGameObjectsWithTag("EnemyTotem").Length <= 0)
			{
                GetComponent<EnemyHealth>().enemyCanTakeDamage = true;
                gladiatorBossMovement.isAttacking = false;
                gladiatorBossMovement.bossAttack2 = false;
                anim1.SetBool("bossAttack3",false);
			}
		}
    
    }

    public IEnumerator BossAttack1()
    {
        isPhase3 = false;
        gladiatorBossMovement.isAttacking = true;

        yield return new WaitForSeconds(0.3f);
        anim2.SetBool("isAttacking",true);
        bossFirstAttackCount -= 1;
        GameObject gladiatorWeaponGO = Instantiate(gladiatorWeapon,firePoint.position,Quaternion.identity);
        Vector2 playerDir = target.position - gladiatorWeaponGO.transform.position;
        gladiatorWeaponGO.transform.right = playerDir;
        gladiatorWeaponGO.GetComponent<Rigidbody2D>().AddForce(gladiatorWeaponGO.transform.right.normalized * gladiatorWeaponSpeed * gladiatorWeaponSpeedMultiplier,ForceMode2D.Impulse);
        Destroy(gladiatorWeaponGO,3f);

        yield return new WaitForSeconds(0.5f);
        anim2.SetBool("isAttacking", false);
        gladiatorBossMovement.isAttacking = false;
        yield return new WaitForSeconds(1f);

        if(bossFirstAttackCount > 0)
		{
            StartCoroutine(BossAttack1());
		}
		else
		{
            bossFirstAttackCount = Random.Range(5,7);
        }
    }

    public IEnumerator BossAttack2()
	{
        gladiatorBossMovement.isAttacking = true;
        gladiatorBossMovement.bossAttack2 = true;
        yield return new WaitForSeconds(2f);

        GameObject bossAttack2GO = Instantiate(gladiatorBossAttack2,transform.position,Quaternion.Euler(0f,0f,bossAttack2Rotation));
		for (int i = 0; i < bossAttack2GO.transform.childCount; i++)
		{
            GameObject bullet = bossAttack2GO.transform.GetChild(i).gameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 15f,ForceMode2D.Impulse);
		}

        bossAttack2Rotation += 15f;
        yield return new WaitForSeconds(0.5f);

        bossAttack2GO = Instantiate(gladiatorBossAttack2, transform.position, Quaternion.Euler(0f, 0f, bossAttack2Rotation));
        for (int i = 0; i < bossAttack2GO.transform.childCount; i++)
        {
            GameObject bullet = bossAttack2GO.transform.GetChild(i).gameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 15f, ForceMode2D.Impulse);
        }

        bossAttack2Rotation += 15f;
        yield return new WaitForSeconds(0.5f);

        bossAttack2GO = Instantiate(gladiatorBossAttack2, transform.position, Quaternion.Euler(0f, 0f, bossAttack2Rotation));
        for (int i = 0; i < bossAttack2GO.transform.childCount; i++)
        {
            GameObject bullet = bossAttack2GO.transform.GetChild(i).gameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 15f, ForceMode2D.Impulse);
        }

        bossAttack2Rotation += 25f;
        yield return new WaitForSeconds(0.5f);
        gladiatorBossMovement.isAttacking = false;
        gladiatorBossMovement.bossAttack2 = false;
    }

    public void BossAttack3()
	{
        GameObject gladiatorWeaponGO = Instantiate(gladiatorBossAttack3, transform.position, Quaternion.identity);
        Vector2 playerDir = target.position - gladiatorWeaponGO.transform.position;
        gladiatorWeaponGO.transform.right = playerDir;
        gladiatorWeaponGO.GetComponent<Rigidbody2D>().AddForce(gladiatorWeaponGO.transform.right.normalized * gladiatorWeaponSpeed, ForceMode2D.Impulse);
        Destroy(gladiatorWeaponGO, 3f);
	}

    public void ScorpionAttack()
	{
		for (int i = 0; i < 4; i++)
		{
            Vector3 randomPosition = new Vector3(Random.Range(-16,16), Random.Range(-8, 8),0f);
            Instantiate(scorpionEnemy,randomPosition,Quaternion.identity);
		}
	}

    public void Phase3()
	{
        FindObjectOfType<AudioManager>().Play("EvilLaugh");
        GetComponent<EnemyHealth>().enemyCanTakeDamage = false;
        isPhase3 = true;
        gladiatorBossMovement.isAttacking = true;
        gladiatorBossMovement.bossAttack2 = true;
        for (int i = 0; i < 4; i++)
		{
            Instantiate(bossTotem,totemPositions[i].position,Quaternion.identity);
		}
        anim1.SetBool("bossAttack3",true);
	}
}
