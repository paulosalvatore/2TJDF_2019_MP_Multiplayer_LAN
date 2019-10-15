using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Cubo : NetworkBehaviour
{
    [SyncVar] public int creatorPlayerId;

    public Material materialVermelho;
    public Material materialAzul;

    // Start is called before the first frame update
    private void Start()
    {
        Material material =
            creatorPlayerId == 1
                ? materialVermelho
                : materialAzul;

        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}