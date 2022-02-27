using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collect : MonoBehaviour
{

public Text pickUpText;

private bool pickUpAllowed;

private void Start () {
    pickUpText.gameObject.SetActive(false);
}

private void Update() {

if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
PickUp();
}

}
void OnTriggerEnter (Collider other) {
    pickUpText.gameObject.SetActive(true);
    pickUpAllowed = true;
}

void OnTriggerExit (Collider other) {
    pickUpText.gameObject.SetActive(false);
    pickUpAllowed = false;
}
void PickUp(){
    ScoringSystem.theScore +=1;
    pickUpText.gameObject.SetActive(false);
    pickUpAllowed = false;
    Destroy(gameObject);
} 
}
