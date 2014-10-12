
public function PlayButton () {
	this.transform.position.y = -50 ;
}
   
public function PlaySettings () {
	this.animation.Play("Move_planesAnim");
}   
   
public function PlayCredits () {
	this.animation.Play("Credits");
}

public function QuitMenuPosition () {
	this.transform.position= new Vector3(0,0,20) ;
}   

public function QuitMenuPosition2 () {
	this.transform.position= new Vector3(0,-50,20) ;
}

public function QuitPanelPos() {
	this.transform.position= new Vector3(0,-50,20) ;
}
