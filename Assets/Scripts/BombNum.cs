using UnityEngine;
using System.Collections;

public class BombNum : MonoBehaviour {

    private PlayerShoot playerShoot;

	// Use this for initialization
	void Awake () {
        playerShoot = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<PlayerShoot>();
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<GUIText>().text = "number of bombs : " + playerShoot.bombNum;
	}
}
