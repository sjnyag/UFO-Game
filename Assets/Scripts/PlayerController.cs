using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;             //プレイヤーの移動スピードを格納する Float 変数

	private Rigidbody2D rb2d;       // 2D Physics に必要な Rigidbody2D コンポーネントへの参照を格納します。

	// イニシャライライゼーションにこれを使います。
	void Start()
	{
		//Rigidbody2D コンポーネントへの参照を取得、格納して、 Rigidbody2D コンポーネントへアクセスできるようにします。
		rb2d = GetComponent<Rigidbody2D> ();
	}

	//FixedUpdate は決められた間隔で呼び出され、フレームレートとは関係ありません。物理演算のコードをここに置きます。
	void FixedUpdate()
	{
		//現在の水平入力を float moveHorizontal に格納します。
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//現在の垂直入力を float moveVertical に格納します。
		float moveVertical = Input.GetAxis ("Vertical");

		//2 つの格納 floats を使って新しい Vector2 変数の動きを作成します。
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		// movement に speed を乗じたものを伴う Rigidbody2D rb2d の AddForce 関数を呼び出します。
		rb2d.AddForce (movement * speed);
	}
}