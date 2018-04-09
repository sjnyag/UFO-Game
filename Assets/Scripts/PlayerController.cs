using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text winText;

	private int count;

	// イニシャライライゼーションにこれを使います。
	void Start()
	{
		count = 0;
		winText.text = "";
		SetCountText ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) {
			winText.text = "You win!";
		}
	}
}