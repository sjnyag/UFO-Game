using UnityEngine;
using System.Collections;

/// <summary>
/// Input gesture.
/// </summary>
public interface InputGesture
{
	/// <summary>
	/// ジェスチャーの処理順番番号
	/// </summary>
	/// <value>0が一番速い、数値が大きくなると判定順番が遅くなる</value>
	int Order {
		get;
	}

	/// <summary>
	/// 指定ジェスチャーが処理する必要があるかどうかを取得します
	/// </summary>
	/// <returns>処理する必要があるならtrueを返す</returns>
	/// <param name="info">Info.</param>
	bool IsGestureProcess (GestureInfo info);

	/// <summary>
	/// Down時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	void OnGestureDown (GestureInfo info);

	/// <summary>
	/// Up時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	void OnGestureUp (GestureInfo info);

	/// <summary>
	/// Drag時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	void OnGestureDrag (GestureInfo info);

	/// <summary>
	/// Flick時に呼び出されます
	/// </summary>
	/// <param name="info">Info.</param>
	void OnGestureFlick (GestureInfo info);
}
