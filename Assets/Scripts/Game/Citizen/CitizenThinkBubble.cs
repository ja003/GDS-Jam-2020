using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CitizenThinkBubble : GameBehaviour
{
	[SerializeField] Sprite spriteTrigger;
	[SerializeField] Sprite spriteWhat;

	[SerializeField] SpriteRenderer content;

	private void Awake()
	{
		SetReaction(ECitizenReaction.None);
	}

	public void SetReaction(ECitizenReaction pReaction)
	{
		spriteRend.enabled = pReaction != ECitizenReaction.None;
		content.sprite = GetSprite(pReaction);
	}

	private Sprite GetSprite(ECitizenReaction pReaction)
	{
		switch(pReaction)
		{
			case ECitizenReaction.None:
				return null;
			case ECitizenReaction.Trigger:
				return spriteTrigger;
			case ECitizenReaction.What:
				return spriteWhat;
		}
		return null;
	}

}

public enum ECitizenReaction
{
	None,
	Trigger,
	What
}
