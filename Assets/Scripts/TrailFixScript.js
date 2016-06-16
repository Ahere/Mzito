#pragma strict

function Start () 
{

     var tr : TrailRenderer = GetComponent(TrailRenderer);
     tr.sortingLayerName = "Player";


}

function Update () {

}