using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public Light flashlightLightSource;
	public bool lightOn = true;
	public float lightDrain  = 1.0f;
	public float maxBatteryLife  = 60.0f;
	public float maxLightIntensity = 5.0f;
	
	public UnityEngine.UI.Slider batteryBar;
	public AudioClip soundTurnOn;
	public AudioClip soundTurnOff;
	
	private float batteryLife = 60.0f;
	private float batteryPower  = 1.0f;

	// Use this for initialization
	void Start () {
		batteryLife = maxBatteryLife;
		batteryBar.maxValue = maxBatteryLife;
		//flashlightLightSource = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		//BATTERY LIFE BRIGHTNESS//////////
		if(lightOn) {
			if(batteryLife >= 0) {
				batteryLife -= Time.deltaTime * lightDrain;
			}
			
			flashlightLightSource.intensity = maxLightIntensity * Mathf.Clamp((batteryLife / maxBatteryLife + 0.3f), 0.0f, 1.0f);
			//Debug.Log(flashlightLightSource.intensity);
			/*if(batteryLife <= maxBatteryLife * 0.5) {
			flashlightLightSource.intensity = maxBatteryLife * 0.8;
		}else if(batteryLife <= maxLightIntensity * 0.3) {
			flashlightLightSource.intensity = maxBatteryLife * 0.6;
		}else if(batteryLife <= maxLightIntensity * 0.15) {
			flashlightLightSource.intensity = maxBatteryLife * 0.3;
		}else if(batteryLife <= 0){
			flashlightLightSource.intensity = 0;
		}else {
			flashlightLightSource.intensity = maxLightIntensity;
		}*/
			
			if(batteryLife <= 0)
			{
				batteryLife = 0;
				toggleFlashlight();	
			}
		}
		
		if(Input.GetKeyUp(KeyCode.F) && batteryLife > 0)
		{
			toggleFlashlight();
			toggleFlashlightSFX();
		}
	}

	public void AlterEnergy (int amount)
	{
		batteryLife = Mathf.Clamp(batteryLife+batteryPower, 0, maxBatteryLife);
		
	}

	public void OnGUI ()
	{
		batteryBar.value = batteryLife;
	} 

	public void toggleFlashlight()
	{
		lightOn = !lightOn;
		flashlightLightSource.enabled = lightOn;
	}
	
	public void toggleFlashlightSFX()
	{
		if(flashlightLightSource.enabled)
		{
			audio.clip = soundTurnOn;
		}
		else
		{
			audio.clip = soundTurnOff;
		}
		audio.Play();
		
	}
}
	
	
	
	
