using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public MonsterMovement monsterMovement;
	public AudioSource audioSource;
	public Transform chest;
	public Transform shield;
	public Transform weapon;
	public Transform lefthandpos;
	public Transform righthandpos;
	public Transform chestposshield;
	public Transform chestposweapon;
	public AudioClip equip1sound;
	public AudioClip equip2sound;
	public AudioClip holster1sound;
	public AudioClip holster2sound;

	private bool wasAttacking = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (monsterMovement.isAttacking && !wasAttacking) {
			wasAttacking = true;
			grabWeapon();
			grabShield();
		}else if(!monsterMovement.isAttacking && wasAttacking) {
			wasAttacking = false;
			holsterWeapon();
			holsterShield();
		}
	}

	private void grabShield()
	{
		shield.parent = lefthandpos;
		shield.position = lefthandpos.position;
		shield.rotation = lefthandpos.rotation;
		audioSource.clip = equip2sound;
		audioSource.loop = false;
		audioSource.pitch = 0.9f + 0.2f*Random.value;
		audioSource.Play();
	}
	private void grabWeapon()
	{
		weapon.parent = righthandpos;
		weapon.position = righthandpos.position;
		weapon.rotation = righthandpos.rotation;
		audioSource.clip = equip1sound;
		audioSource.loop = false;
		audioSource.pitch = 0.9f + 0.2f*Random.value;
		audioSource.Play();
		
		
	}
	private void holsterShield()
	{
		shield.parent = chestposshield;
		shield.position = chestposshield.position;
		shield.rotation = chestposshield.rotation;
		audioSource.clip = holster1sound;
		audioSource.loop = false;
		audioSource.pitch = 0.9f + 0.2f*Random.value;
		audioSource.Play();
		
	}
	private void holsterWeapon()
	{
		weapon.parent = chestposweapon;
		weapon.position = chestposweapon.position;
		weapon.rotation = chestposweapon.rotation;
		audioSource.clip = holster2sound;
		audioSource.loop = false;
		audioSource.pitch = 0.9f + 0.2f*Random.value;
		audioSource.Play();
	}
}
