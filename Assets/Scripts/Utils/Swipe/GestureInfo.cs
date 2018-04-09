using UnityEngine;
using System.Collections;

/// <summary>
/// ジェスチャーパラメータ
/// </summary>
public class GestureInfo
{
	/// <summary>
	/// mouse/touch位置を取得します
	/// </summary>
	/// <value>The position.</value>
	public Vector3 ScreenPosition {
		get;
		set;
	}

	/// <summary>
	/// 前回からの移動量を取得します
	/// </summary>
	/// <value>The delta position.</value>
	public Vector3 DeltaPosition {
		get;
		set;
	}

	/// <summary>
	/// mouse/touch downステータスを取得します
	/// </summary>
	/// <value>押された時にtrueになります</value>
	public bool IsDown {
		get;
		set;
	}

	/// <summary>
	/// mouse/touch upステータスを取得します
	/// </summary>
	/// <value>離れた時にtrueになります</value>
	public bool IsUp {
		get;
		set;
	}

	/// <summary>
	/// mouse/touch dragステータスを取得します
	/// </summary>
	/// <value>ドラッグ移動した時にtrueになります</value>
	public bool IsDrag {
		get;
		set;
	}

	/// <summary>
	/// 経過時間を取得します
	/// </summary>
	/// <value></value>
	public double DeltaTime {
		get;
		set;
	}

	/// <summary>
	/// 経過時間で移動した距離を取得します
	/// </summary>
	/// <value></value>
	public Vector3 DragDistance {
		get;
		set;
	}
}
