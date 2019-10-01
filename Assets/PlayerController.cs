using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            var h = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.left * (h * Time.deltaTime));
        }
    }
}