using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageHandler
{
	void OnReceivedDamage(float pDamage);

	Vector3 GetPosition();
}
