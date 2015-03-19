var quit=false;


function OnMouseEnter()
{
	GUI.color = Color.red;
	//renderer.material.color = Color.red;		//Change Color to red!
	//CanvasRenderer.SetColor(Color.red);
}

function OnMouseExit()
{
	//renderer.material.color = Color.white;		//Change Color to white!

}

function OnMouseUp()
{

	if (quit == true)
	{
		Application.Quit();					    //If you click on quit aplication quits.
	}
	else
	{
		Application.LoadLevel(1);				//If you click on other button it loads game!
	}

}