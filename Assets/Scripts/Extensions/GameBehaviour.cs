using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected Game game => Game.Instance;
    protected Director director => Director.Instance;

    protected void DoInTime(Action pAction, float pTime)
    {
        StartCoroutine(DoInTimeC(pAction, pTime));
    }

    private IEnumerator DoInTimeC(Action pAction, float pTime)
    {
        yield return new WaitForSeconds(pTime);
        pAction.Invoke();
    }
}
