using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueNewsPopup : GameBehaviour
{
    [SerializeField] List<Sprite> news;
    [SerializeField] Vector3 offset;

	TrueNews newsObj;

	private void Update()
	{
		gameObject.SetActive(newsObj != null && newsObj.isActiveAndEnabled);
		if(newsObj == null)
			return;
		transform.position = Utils.WorldToUISpace(game.HUD.Canvas, newsObj.GetPosition()) + offset;
	}


	public void OnThrow(TrueNews pNewsObj)
    {
		newsObj = pNewsObj;
		gameObject.SetActive(true);

		image.sprite = GetNewsSprite();
	}

	int lastNewsIndex = -1;

	private Sprite GetNewsSprite()
	{
		int randomNewsIndex = Random.Range(0, news.Count);
		if(randomNewsIndex == lastNewsIndex)
			return GetNewsSprite();

		lastNewsIndex = randomNewsIndex;
		return news[randomNewsIndex];
	}
}
