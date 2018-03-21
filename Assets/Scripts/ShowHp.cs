using UnityEngine;
using System.Collections;

public class ShowHp : MonoBehaviour {

    private const float hpLineLength = 155;
    private const float posX = 233;
    private PlayerHealth playerHealth;
    private RectTransform rectTransform;

	// Use this for initialization
	void Awake () {
        playerHealth = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
        rectTransform = this.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        rectTransform.sizeDelta = new Vector2(hpLineLength * playerHealth.hp / playerHealth.fullHp, rectTransform.sizeDelta.y);
        rectTransform.position = new Vector3(posX - (hpLineLength - rectTransform.sizeDelta.x) / 2, rectTransform.position.y, 0);
	}
}
