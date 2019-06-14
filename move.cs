// JA：
// 自機の操作と弾の発射。
// 弾はプレハブで生成しているので別途プレハブを用意すること

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gc_move : MonoBehaviour {

	// ビームガン等のプレハブ呼び出しを宣言する
	// 装備変更時はxxPrefabなど別変数も必要
	public GameObject Prefab;
 	float intervalTime;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 左に行きます
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-16f, 0, 0);
		}
		// 右に行きます
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate ( 16f, 0, 0);
		}
		// 前に移動
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate ( 0, 0, 16f);
		}
		// 下に移動
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate ( 0, 0, -16f);
		}

		// 荷電粒子砲(弾)を発射
		// ※弾はプレハブで生成し、弾の移動や着弾、消滅はプレハブ側で処理しています。
		intervalTime += Time.deltaTime;
		if (Input.GetKey("space")) {
			if (intervalTime >= 0.1f) {
		 		intervalTime = 0.0f;
		 		Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		 	}
		}

