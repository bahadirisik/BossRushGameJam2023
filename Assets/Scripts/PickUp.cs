using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	[SerializeField] Vector2 offset;
	public int weaponNumber;

	[SerializeField] private GameObject portal;
	[SerializeField] private GameObject particalEffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			portal.SetActive(true);
			particalEffect.SetActive(false);

			if (collision.transform.GetChild(0).childCount <= 0)
			{
				GunSelect.weaponTags.Add(gameObject.tag);
				FirstWeapon(collision.gameObject);
			}
			else
			{
				GunSelect.weaponTags.Add(gameObject.tag);
				TakeWeapon(collision.gameObject);
			}
		}
	}

	public void FirstWeapon(GameObject collision)
	{
		weaponNumber = 0;
		transform.parent = collision.transform.GetChild(0).transform;
		transform.localPosition = new Vector3(offset.x, offset.y, 0f);
		gameObject.GetComponent<Shoot>().enabled = true;
		gameObject.GetComponent<LookAtMouse>().enabled = true;
		gameObject.GetComponent<Collider2D>().enabled = false;
	}

	public void TakeWeapon(GameObject collision)
	{
		weaponNumber = collision.transform.GetChild(1).childCount + 1;
		transform.parent = collision.transform.GetChild(1).transform;
		gameObject.SetActive(false);
		transform.localPosition = new Vector3(offset.x, offset.y, 0f);
		gameObject.GetComponent<Shoot>().enabled = true;
		gameObject.GetComponent<LookAtMouse>().enabled = true;
		gameObject.GetComponent<Collider2D>().enabled = false;
	}
}
