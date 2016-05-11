#pragma strict

var frames : Texture[];
var framesPerSecond = 10;

function Start () {

}
 
function Update() {
    var index : int = (Time.time * framesPerSecond) % frames.Length;
    GetComponent.<Renderer>().material.mainTexture = frames[index];
}
