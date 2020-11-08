using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudEnergy : MonoBehaviour
{
    [SerializeField] public Text energyText;

	public float maxHp = 10;
	public float NumOfHp = 8;
	[SerializeField] private Image[] imageHps;
	[SerializeField] private Image imageHp;

	private void Start()
	{
		imageHps[0] = imageHp;
		//imageHps.
		for (int i = 1; i < maxHp; i++)
		{
			Image clone;
			clone = Instantiate(imageHp, transform);
			imageHps[i] = clone;

			imageHps[i].enabled = true;
		}
	}

	private void Update()
	{
		if (NumOfHp > maxHp)
			return;

		for (int i = 0; i < maxHp; i++)
		{

			if (i < NumOfHp)
			{
				if (imageHps[i])
				{
					imageHps[i].enabled = true;
					imageHps[i].GetComponent<CanvasGroup>().alpha = 1f;
				}
			}
			else
			{
				if (imageHps[i])
				{
					if(i == NumOfHp + 0.5f)
					{
						if (imageHps[i - 1])
						{
							imageHps[i - 1].enabled = true;
							imageHps[i - 1].GetComponent<CanvasGroup>().alpha = 0.5f;
						}
					}

					imageHps[i].enabled = false;
				}
			}
		}
	}
}
