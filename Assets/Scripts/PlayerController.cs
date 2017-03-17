using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    // 这两个东西将在 Unity 中手动设置引用.
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rigidBody;
    private int pickedUpCount = 0;

	// Use this for initialization
	void Start () {
        this.rigidBody = GetComponent<Rigidbody>();
        this.setCountText();
        this.winText.text = "";
    }
	
	// Update 方法在每帧都会调取.
    // 游戏多数逻辑在这里.
	void Update () {
		
	}

    // FixUpdated 只会在物理运算和 Performing 之前被调取.（不兹道 Performing 的意思）
    // 物理相关的逻辑在这里.
    void FixedUpdate() {
        // 获取用户输入.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        this.rigidBody.AddForce(movement * this.speed);
    }

    void OnTriggerEnter (Collider other) {
        // 碰撞到 Tag 为 Pickup 的物体.
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            this.pickedUpCount++;
            this.setCountText();
        }
    }

    private void setCountText () {
        this.countText.text = "Count: " + this.pickedUpCount.ToString();
        if (this.pickedUpCount >= 12) {
            this.winText.text = "You Win!";
        }
    }
}
