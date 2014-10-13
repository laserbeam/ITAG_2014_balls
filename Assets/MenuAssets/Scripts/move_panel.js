   
public function PlaySettings () {
	this.animation.Play("Move_planesAnim");
}   
   
public function PlayCredits () {
	this.animation.Play("Credits");
}   

public function StartGame(){
  	Application.LoadLevel("Play");
}

public function NoQuit(){
  	this.transform.position.y = -100;
}

public function QuitPanel(){
  	this.transform.position.y = 10;
}

public function PlanesQuitMenu () {
	this.transform.position.y = -20;

}




