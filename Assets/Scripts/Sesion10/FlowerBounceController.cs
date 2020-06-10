using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBounceController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 targetPosition;

    private bool isClose;

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        GrowLeanVector();
    }

    private void OnEnable()
    {
        SetWorldPositionToAllShaders.OnPositionchange += SetWorldPositionToAllShaders_OnPositionchange;
    }

    private void OnDisable()
    {
        SetWorldPositionToAllShaders.OnPositionchange -= SetWorldPositionToAllShaders_OnPositionchange;
    }

    private void SetWorldPositionToAllShaders_OnPositionchange(Vector3 objPos)
    {
        targetPosition = objPos;
        ///modifica todos
       // GrowLeanVector();

        ///modifica instancia
        GrowLeanVectorAll();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1f);
    }

    private void GrowLeanVector()
    {
        // LeanTween.value(gameObject, Vector3.zero, shakeVertex, 1f).setOnUpdateVector3(ShakeLean).setEase(LeanTweenType.easeOutBounce);
        Vector3 direction = targetPosition - transform.position;

        if (direction.magnitude <= 1)
        {
            if (isClose) return;
            isClose = true;
            LeanTween.value(0, 1, 1f).setOnUpdate(GrowLeanFloat).setEase(LeanTweenType.easeOutBounce);
        }
        else
        {
            if (!isClose) return;
            isClose = false;
            LeanTween.value(1, 0, 1f).setOnUpdate(GrowLeanFloat).setEase(LeanTweenType.easeOutBounce);
        }
    }

    private void GrowLeanVectorAll()
    {
        // LeanTween.value(gameObject, Vector3.zero, shakeVertex, 1f).setOnUpdateVector3(ShakeLean).setEase(LeanTweenType.easeOutBounce);
        Vector3 direction = targetPosition - transform.position;

        if (direction.magnitude <= 1)
        {
            if (isClose) return;
            isClose = true;
            LeanTween.value(0, 1, 1f).setOnUpdate(GrowLeanFloatAll).setEase(LeanTweenType.easeOutBounce);
        }
        else
        {
            if (!isClose) return;
            isClose = false;
            LeanTween.value(1, 0, 1f).setOnUpdate(GrowLeanFloatAll).setEase(LeanTweenType.easeOutBounce);
        }
    }

    /// <summary>
    /// este solo modifica la instancia
    /// </summary>
    /// <param name="floatValue"></param>
    private void GrowLeanFloatAll(float floatValue)
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        materialPropertyBlock.SetFloat("growAlpha", floatValue);

        GetComponent<MeshRenderer>().SetPropertyBlock(materialPropertyBlock);

        //GetComponent<MeshRenderer>().material.SetFloat("growAlpha", floatValue);
    }

    /// <summary>
    /// este modifica todos los materiales con el shader
    /// </summary>
    /// <param name="floatValue"></param>
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