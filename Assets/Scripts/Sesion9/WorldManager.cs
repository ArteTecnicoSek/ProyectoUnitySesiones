using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public float bendX = 0;
    private float targetX;
    public float changeWorldTime = 5;

    [Header("Tween")]
    public float tweenTime = .5f;

    public LeanTweenType tweenType = LeanTweenType.pingPong;
    public LeanTweenType ease;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ChangeWorldTween());
    }

    private void BendWorldX()
    {
        bendX = Mathf.Lerp(bendX, targetX, Time.deltaTime);

        Shader.SetGlobalFloat("BendingX", bendX);
    }

    private IEnumerator ChangeWorld()
    {
        targetX = Random.Range(-4.0f, 4.0f);

        yield return new WaitForSeconds(changeWorldTime);
        StartCoroutine(ChangeWorld());
    }

    private IEnumerator ChangeWorldTween()
    {
        targetX = Random.Range(-4, 4);

        LeanTween.value(bendX, targetX, tweenTime).setOnUpdate(UpdateTargetx).setLoopType(tweenType).setEase(ease);

        yield return new WaitForSeconds(changeWorldTime);
        StartCoroutine(ChangeWorldTween());
    }

    private void UpdateTargetx(float bendxTween)
    {
        bendX = bendxTween;
        Shader.SetGlobalFloat("BendingX", bendX);
    }

    // Update is called once per frame
    /*Usar esto si no vas a usar tween
    private void Update()
    {
        BendWorldX();
    }
    */
}