using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorldPositionToAllShaders : MonoBehaviour
{
    [Tooltip("Nombre la propiedad Vector3 en el shader. NO debe estar expuesta")]
    [Header("Nombre la propiedad Vector3 en el shader.NO debe estar expuesta")]

    public string shaderVectorName;
    [Tooltip("Si no colocas nada es el dueno del script")]
    [Header("Si no colocas nada se asume que es el dueno del script")]
    public Transform triggerTransform;



    private void OnEnable()
    {
        if (triggerTransform == null)
            triggerTransform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector(shaderVectorName, triggerTransform.position);
    }
}
