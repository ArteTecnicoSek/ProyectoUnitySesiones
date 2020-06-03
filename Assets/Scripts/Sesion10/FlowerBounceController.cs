using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBounceController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnMouseDown()
    {
        ShakeTree();
    }

    private void ShakeTree()
    {
        // LeanTween.value(gameObject, Vector3.zero, shakeVertex, 1f).setOnUpdateVector3(ShakeLean).setEase(LeanTweenType.easeOutBounce);

        //print(gameObject.name);

        LeanTween.value(0, 1, 1f).setOnUpdate(GrowLeanFloat).setEase(LeanTweenType.easeOutBounce).setLoopPingPong(1);
    }

    //este si
    private void GrowLeanFloat(float floatValue)
    {
        GetComponent<MeshRenderer>().material.SetFloat("growAlpha", floatValue);
    }

    /// <summary>
    /// esto no
    /// </summary>
    /// <param name="vectorValue"></param>
    private void ShakeLeanVector(Vector3 vectorValue)
    {
        GetComponent<MeshRenderer>().material.SetFloat("ShakeForce", 1f);

        GetComponent<MeshRenderer>().material.SetVector("VertexShake", vectorValue);
    }
}