using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	// Use this for initialization
    public float smoothing = 3;
    private Transform player;
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetPos = player.position + new Vector3(0.5f, 4, -7);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
	}
}
