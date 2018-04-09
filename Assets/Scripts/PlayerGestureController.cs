using UnityEngine;
using System.Collections;

public class PlayerGestureController : MonoBehaviour, InputGesture
{
	public float speed;             //プレイヤーの移動スピードを格納する Float 変数
	private Rigidbody2D rb2d;       // 2D Physics に必要な Rigidbody2D コンポーネントへの参照を格納します。
	private Vector2 movement = new Vector2 (0F, 0F);


	/// <summary>
	/// 
	/// </summary>
	/// <value>The flick delta time.</value>
	private float FlickDeltaTime {
		get;
		set;
	}

	/// <summary>
	/// 自動スクロール量
	/// </summary>
	/// <value>The flick direction.</value>
	private Vector3 AutoScrollDirection {
		get;
		set;
	}

	// イニシャライライゼーションにこれを使います。
	void Start()
	{
		//Rigidbody2D コンポーネントへの参照を取得、格納して、 Rigidbody2D コンポーネントへアクセスできるようにします。
		rb2d = GetComponent<Rigidbody2D> ();
	}

	//FixedUpdate は決められた間隔で呼び出され、フレームレートとは関係ありません。物理演算のコードをここに置きます。
	void FixedUpdate()
	{
		rb2d.AddForce (movement * speed);
		movement = new Vector2 (0F, 0F);
	}

	/// <summary>
	/// 
	/// </summary>
	void OnEnable ()
	{
		InputGestureManager.Instance.RegisterGesture (this);
	}

	/// <summary>
	/// 
	/// </summary>
	void OnDisable ()
	{
		InputGestureManager.Instance.UnregisterGesture (this);
	}

	/// <summary>
	/// ジェスチャーの処理順番番号
	/// </summary>
	/// <value>0が一番速い、数値が大きくなると判定順番が遅くなる</value>
	public int Order {
		get { return 9999; }
	}

	/// <summary>
	/// 指定ジェスチャーが処理する必要があるかどうかを取得します
	/// </summary>
	/// <returns>処理する必要があるならtrueを返す</returns>
	/// <param name="info">Info.</param>
	public bool IsGestureProcess (GestureInfo info)
	{
		return true;  // 常に処理する(仮)
	}

	/// <summary>
	/// Down時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	public void OnGestureDown (GestureInfo info)
	{
		// 自動スクロールの停止
		this.AutoScrollDirection = new Vector3 ();
	}

	/// <summary>
	/// Up時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	public void OnGestureUp (GestureInfo info)
	{
		movement = new Vector2 (info.DragDistance.x, info.DragDistance.y);
	}

	/// <summary>
	/// Drag時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	public void OnGestureDrag (GestureInfo info)
	{
	}

	/// <summary>
	/// Flick時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	public void OnGestureFlick (GestureInfo info)
	{
		this.FlickDeltaTime = (float)info.DeltaTime;
		this.AutoScrollDirection = info.DragDistance;
	}


}
