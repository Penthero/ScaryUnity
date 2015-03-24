using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	public WeaponHandler weaponHandler;
	public MeleeAttack meleeAttack;
	public UnityEngine.UI.Slider durabilityBar;
	public float MaxDurability = 100.0f;
	public float DeteriorationRate = 5.0f;

	private float currentDurability;

	// Use this for initialization
	void Start () {
		currentDurability = MaxDurability;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		durabilityBar.value = currentDurability;
	}

	void OnTriggerEnter (Collider other)
	{
		alterDurability (-DeteriorationRate);
	}

	public void alterDurability(float amount) {
		currentDurability = Mathf.Clamp (currentDurability + amount, 0, MaxDurability);
		meleeAttack.currentDamage = (int)Mathf.Clamp((currentDurability / MaxDurability) * (float)meleeAttack.MaxDamage, 10.0f, (float)meleeAttack.MaxDamage);
	}
}
