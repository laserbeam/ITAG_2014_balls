#pragma strict

function VolumeContr (x:int) {
	AudioListener.volume = AudioListener.volume - AudioListener.volume * x / 100;
}
