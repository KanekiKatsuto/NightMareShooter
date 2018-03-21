using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
    public float speed = 5;
    public float jumpspeed = 5;
    private float timer = 0.5f;
    private Animator anim;
    private int groundLayerIndex = -1;

	void Start () {
        anim = this.GetComponent<Animator>();
        groundLayerIndex = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool jump = Input.GetKey(KeyCode.Space);
        GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (jump){
            GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(h, 0, v) * speed + Vector3.up * jumpspeed) * Time.deltaTime);
            timer = 0;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 200, groundLayerIndex)){
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }

        if (h==0&&v==0&&timer>=0.5f){
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            anim.SetBool("Move", false);
        }else{
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            anim.SetBool("Move", true);
        }
	}
}
