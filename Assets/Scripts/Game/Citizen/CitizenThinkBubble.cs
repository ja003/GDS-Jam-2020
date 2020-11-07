using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CitizenThinkBubble : GameBehaviour
{
	[SerializeField] Sprite spriteTrigger;

	[SerializeField] SpriteRenderer content;

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
		}
		return null;
	}

}

public enum ECitizenReaction
{
	None,
	Trigger
}
