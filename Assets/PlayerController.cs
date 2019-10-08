using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public Material materialVermelho;
    public Material materialAzul;

    public GameObject cuboPrefab;

    public float velocidade = 3f;
    public float velocidadeRotacao = 200f;

    private void Start()
    {
        Material material = null;

        if (isServer && isLocalPlayer)
        {
            material = materialVermelho;
        }
        else if (isServer && !isLocalPlayer)
        {
            material = materialAzul;
        }
        else if (!isServer && isLocalPlayer)
        {
            material = materialAzul;
        }
        else if (!isServer && !isLocalPlayer)
        {
            material = materialVermelho;
        }

        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            transform.Translate(
                Vector3.forward * (velocidade * v * Time.deltaTime)
            );

            transform.Rotate(
                Vector3.up * (velocidadeRotacao * h * Time.deltaTime)
            );

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdSpawnarCubo();
            }
        }
    }

    [Command]
    private void CmdSpawnarCubo()
    {
        var cubo = Instantiate(cuboPrefab);

        cubo.transform.position = transform.position + (transform.forward * 2);
        cubo.transform.rotation = transform.rotation;

        NetworkServer.Spawn(cubo);
    }
}