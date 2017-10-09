using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerGameObject;
    private Vector3 _offset;

	// Use this for initialization
	void Start ()
	{
	    _offset = GetComponent<Transform>().position - PlayerGameObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
	    transform.position = PlayerGameObject.transform.position + _offset;
	}
}
