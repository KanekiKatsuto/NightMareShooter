using UnityEngine;
using System.Collections;

public class TargetClearedNum : MonoBehaviour {

    private PlayerShoot playerShoot;

    // Use this for initialization
    void Awake(){
        playerShoot = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<PlayerShoot>();
    }

    // Update is called once per frame
    void Update(){
        this.GetComponent<GUIText>().text = "number of targets cleared : " + playerShoot.totalClearedNum;
    }
}
