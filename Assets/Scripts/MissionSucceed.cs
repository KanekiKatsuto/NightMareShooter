using UnityEngine;
using System.Collections;

public class MissionSucceed : MonoBehaviour {

    private PlayerShoot playerShoot;
    private PlayerMove playerMove;
    private PlayerHealth playerHealth;
    private Rigidbody rigid;
    private GUIText missionSucceed;
    private GUIText missionFailed;

    void Awake(){
        playerShoot = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<PlayerShoot>();
        playerMove = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerMove>();
        playerHealth = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
        rigid = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Rigidbody>();
        missionSucceed = GameObject.FindGameObjectWithTag(Tags.missionSucceed).GetComponent<GUIText>();
        missionFailed = GameObject.FindGameObjectWithTag(Tags.missionFailed).GetComponent<GUIText>();
    }

	// Update is called once per frame
	void Update () {
        if (playerShoot.totalClearedNum >= playerShoot.targetNum){
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(Tags.enemy)){
                Destroy(obj);
            }
            playerMove.enabled = false;
            playerShoot.enabled = false;
            rigid.isKinematic = true;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            missionSucceed.enabled = true;
            Invoke("ReturnMenu", 5);
        }
        if (playerHealth.hp <= 0){
            missionFailed.enabled = true;
            Invoke("ReturnMenu", 5);
        }
	}

    void ReturnMenu(){
        Application.LoadLevel(0);
    }
}
