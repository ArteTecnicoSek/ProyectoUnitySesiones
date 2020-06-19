using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void FPlayerNotify(Vector3 velocityChange);

    public static event FPlayerNotify OnPlayerMove;

    private Vector3 direction;
    public MeshRenderer sailMeshRenderer;
    public float navigationSpeed = 4f;
    private bool isMoving;

    public float bouyancyHeight = 0.2f;
    public float bouyancyTime = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        LeanTween.moveLocalY(gameObject, bouyancyHeight, bouyancyTime).setLoopPingPong();
    }

    private void MoveWorld()
    {
        direction.z = Input.GetAxis("Vertical");
        isMoving = direction.sqrMagnitude > 0;

        if (isMoving)
        {
            OnPlayerMove?.Invoke(direction * Time.deltaTime * navigationSpeed);
        }
    }

    private void UpdateSail()
    {
        //aqui usted hace flamear la vela si se esta moviendo
    }

    // Update is called once per frame
    private void Update()
    {
        MoveWorld();
    }
}