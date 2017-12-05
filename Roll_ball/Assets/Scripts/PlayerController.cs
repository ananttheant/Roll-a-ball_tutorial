using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody _player;
    private int _count;

    void Start()
    {
        _player = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);


        _player.AddForce(movement*Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + _count.ToString();
        if (_count >= 16)
        {
            WinText.text = "You Win!";
        }
    }

}
