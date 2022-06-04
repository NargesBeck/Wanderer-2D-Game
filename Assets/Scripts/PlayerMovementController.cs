using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, Input.GetAxis("Vertical") * Time.deltaTime * 7, 0);
        transform.Rotate(0, 0, -(Input.GetAxis("Horizontal") * Time.deltaTime * 100));
    }
}
