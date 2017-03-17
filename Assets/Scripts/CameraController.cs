using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        this.offset = this.transform.position - this.player.transform.position;
	}
	
	// LateUpdate 保证所有物件更新完毕后再执行.
	void LateUpdate () {
        this.transform.position = this.player.transform.position + this.offset;
	}
}
