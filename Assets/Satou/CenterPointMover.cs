using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CenterPointMover : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(-7, 3.5f).SetLoops(-1, LoopType.Yoyo).SetRelative();
    }
}
