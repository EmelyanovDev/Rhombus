using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDestroyEffect : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject, 1f);
    }
}
