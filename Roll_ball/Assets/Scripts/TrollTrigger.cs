using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrollTrigger : MonoBehaviour
{
    public GameObject TrollFace;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TrollFace.SetActive(true);
        }
    }
}
