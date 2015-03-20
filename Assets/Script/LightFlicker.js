var flickerSpeed : float = 0.07;
private var randomizer : int = 0;
while (true) {
    if (randomizer == 0) {
        light.enabled = true;
    }
    else light.enabled = false;
    randomizer = Random.Range (0, 1.1);
    yield WaitForSeconds (flickerSpeed);
}