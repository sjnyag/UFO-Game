using UnityEngine;
using System.Collections;

/// <summary>
/// Flickによるカメラの移動ジェスチャーを定義します
/// ※常に動作するので後で必要な場合のみ動くように実装する
/// </summary>
public class CameraMoveInputGesture : MonoBehaviour, InputGesture
{
	/// <summary>
	/// 移動対象のカメラ
	/// </summary>
	private Camera _camera = null;

	/// <summary>
	/// 物体までの距離
	/// </summary>
	private float _focus_distance = 10;

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

	/// <summary>
	/// 
	/// </summary>
	void OnEnable ()
	{
		InputGestureManager.Instance.RegisterGesture (this);
		this._camera = GameObject.FindObjectOfType<Camera> ();
	}

	/// <summary>
	/// 
	/// </summary>
	void OnDisable ()
	{
		InputGestureManager.Instance.UnregisterGesture (this);
	}

	/// <summary>
	/// 
	/// </summary>
	void Update ()
	{
		// 自動スクロール
		AutoScroll (Time.deltaTime);
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

	}

	/// <summary>
	/// Drag時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	public void OnGestureDrag (GestureInfo info)
	{
		// 上方向のカメラドラッグは無視します
		var pt = ScreenToWorld (info.DeltaPosition);
		DoMove (pt);
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

	/// <summary>
	/// カメラの移動を行います
	/// </summary>
	/// <param name="world_delta">World座標系</param>
	void DoMove (Vector3 world_delta)
	{
		this._camera.transform.position += new Vector3 (world_delta.x, 0, world_delta.z);
	}

	/// <summary>
	/// スクリーン座標からワールド座標に変換します
	/// </summary>
	/// <returns>The to world.</returns>
	/// <param name="delta">Delta.</param>
	Vector3 ScreenToWorld (Vector3 delta)
	{
		// 画面はXY、カメラはXYZなのでXZへ変換
		var screen_pt = delta;
		screen_pt.z = this._focus_distance;
		var p0 = this._camera.ScreenToWorldPoint (new Vector3 (0, 0, this._focus_distance));
		var p1 = p0 - this._camera.ScreenToWorldPoint (screen_pt);
		return p1;
	}

	/// <summary>
	/// Flickによる自動スクロールを行います
	/// </summary>
	/// <param name="delta_time">Delta_pos.</param>
	void AutoScroll (float delta_time)
	{
		if (this.AutoScrollDirection.magnitude <= 0.001) {
			return;
		}
    
		var pt = ScreenToWorld (this.AutoScrollDirection);

		// ドラッグ時間から自動スクロールする量を調整する
		const float factor = 1.0f;
		pt.x = pt.x * delta_time / this.FlickDeltaTime * factor;
		pt.y = pt.y * delta_time / this.FlickDeltaTime * factor;
		pt.z = pt.z * delta_time / this.FlickDeltaTime * factor;
    
		// カメラ移動
		DoMove (pt);

		// 減衰
		const float break_factor = 0.99f;
		var newDir = this.AutoScrollDirection;
		newDir.x *= break_factor;
		newDir.y *= break_factor;
		newDir.z *= break_factor;
		this.AutoScrollDirection = newDir;
	}

}
