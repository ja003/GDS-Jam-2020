using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThinkBubble : GameBehaviour
{
	[SerializeField] Sprite spriteTrigger;
	[SerializeField] Sprite spriteWhat;
	[SerializeField] Sprite spriteCoffee;
	[SerializeField] Sprite spriteBuild;

	[SerializeField] SpriteRenderer content;

	private void Awake()
	{
		SetReaction(EReaction.None);
	}

	EReaction CurrentReaction;

	public void SetReaction(EReaction pReaction, float pDuration = -1)
	{
		spriteRend.enabled = pReaction != EReaction.None;
		content.sprite = GetSprite(pReaction);
		if(CurrentReaction == pReaction)
			return;
		CurrentReaction = pReaction;

		if(pDuration > 0)
			DoInTime(() => SetReaction(EReaction.None), pDuration);
	}

	private Sprite GetSprite(EReaction pReaction)
	{
		switch(pReaction)
		{
			case EReaction.None:
				return null;
			case EReaction.Trigger:
				return spriteTrigger;
			case EReaction.What:
				return spriteWhat;
			case EReaction.Coffee:
				return spriteCoffee;
			case EReaction.Build:
				return spriteBuild;
		}
		return null;
	}

}

public enum EReaction
{
	None,
	Trigger,
	What,
	Coffee,
	Build
}
