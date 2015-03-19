#pragma strict

var flashlightLightSource : Light;
var lightOn : boolean = true;
var lightDrain : float = 0.1;
var maxBatteryLife : float = 2.0;
var maxLightIntensity : float = 5.0;

private static var batteryLife : float = 0.0;
private static var batteryPower : float = 1;

var batteryBar : UnityEngine.UI.Slider;

var soundTurnOn : AudioClip;
var soundTurnOff : AudioClip;


function Start()
{
	batteryLife = maxBatteryLife;
	flashlightLightSource = GetComponent(Light);
}


static function AlterEnergy (amount : int)
{
	batteryLife = Mathf.Clamp(batteryLife+batteryPower, 0, 100);

}



function Update()
{

//BATTERY LIFE BRIGHTNESS//////////
	if(lightOn) {
		if(batteryLife >= 0) {
			batteryLife -= Time.deltaTime * lightDrain;
		}
		
		flashlightLightSource.intensity = maxLightIntensity * Mathf.Clamp((batteryLife / maxBatteryLife + 0.3), 0, 1);
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
	
	/////// PIC  ///////////
function OnGUI()
{
 	batteryBar.value = batteryLife;
} 
 	
function toggleFlashlight()
{
	lightOn = !lightOn;
	flashlightLightSource.enabled = lightOn;
}

function toggleFlashlightSFX()
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

	@script RequireComponent(AudioSource)
	
		
				
	
	