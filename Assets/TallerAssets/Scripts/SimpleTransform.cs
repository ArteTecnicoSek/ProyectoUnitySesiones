using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransform : MonoBehaviour
{
    public Vector3 axisRot;
    public float addedAngle = 1;
    public float rotaDuration = 1;
    public int numberLoops = 0;
    public LeanTweenType loopType = LeanTweenType.once;
    public LeanTweenType ease = LeanTweenType.linear;

    // Start is called before the first frame update
    private void Start()
    {
        LeanTween.rotateAround(gameObject, axisRot, addedAngle, rotaDuration).setLoopType(loopType).setEase(ease).setLoopCount(numberLoops);
    }
}