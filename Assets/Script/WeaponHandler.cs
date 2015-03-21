using UnityEngine;
using System.Collections;

public class WeaponHandler : MonoBehaviour {

	public GameObject[] Weapons;
	public bool isAttacking = false;

	public GameObject[] HUDElements;

	private Animator[] anims;
	private int currentWeapon = 1;



	// Use this for initialization
	void Start () {

		anims = new Animator[Weapons.Length];
		for (int i = 0; i < anims.Length; ++i)
			if (Weapons[i])
				anims [i] = Weapons [i].GetComponent<Animator> ();

		for (int i = 0; i < anims.Length; ++i)
			if (Weapons[i])
				if (i == currentWeapon)
					Weapons [i].SetActive (true);
				else
					Weapons [i].SetActive (false);

		for (int i = 0; i < HUDElements.Length; ++i)
			if (HUDElements[i])
				if (i == currentWeapon)
					HUDElements [i].SetActive (true);
				else
					HUDElements [i].SetActive (false);

	}

	void ChangeWeapons(int weaponId) {
		if (weaponId >= 0 && weaponId < Weapons.Length && Weapons[weaponId] && (weaponId != currentWeapon)) {
			Weapons [weaponId].SetActive (true);
			Weapons [currentWeapon].SetActive (false);

			if(HUDElements.Length > weaponId && HUDElements [weaponId]) {
				HUDElements [weaponId].SetActive (true);
			}
			if(HUDElements.Length > currentWeapon && HUDElements [currentWeapon])
				HUDElements [currentWeapon].SetActive (false);

			currentWeapon = weaponId;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			isAttacking = true;
			anims [currentWeapon].ResetTrigger ("Idle");
			anims [currentWeapon].SetTrigger ("Attack");
		} else if (Input.GetMouseButtonUp (0)) {
			isAttacking = false;
			anims [currentWeapon].ResetTrigger ("Attack");
			anims [currentWeapon].SetTrigger ("Idle");
		} else {
			int weaponId;
			bool isNumeric = int.TryParse(Input.inputString, out weaponId);

			if(isNumeric)
				ChangeWeapons(weaponId);
		}
	}
}
