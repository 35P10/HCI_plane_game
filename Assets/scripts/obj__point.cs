using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj__point : MonoBehaviour
{
    void Update () {
        transform.Rotate (Vector3.forward * 50 * Time.deltaTime, Space.Self);
    }
}