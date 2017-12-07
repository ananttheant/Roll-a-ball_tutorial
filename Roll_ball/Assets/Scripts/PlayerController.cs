using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody _player;
    private int _count;
    private int _level;

    void Start()
    {
        _player = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.text = "";
        _level = 1;
    }

    void Update()
    {

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }

    void Main()
    {
        // Preventing mobile devices going in to sleep mode 
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void FixedUpdate()
    {
       if (GameStates.isGrounded)
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);


                _player.AddForce(movement * Speed * Time.deltaTime);
            }
            else
            {
                // Player movement in mobile devices
                // Building of force vector 
                Vector3 movement = new Vector3(Input.acceleration.x*2, 0.0f, Input.acceleration.y*2);
                // Adding force to rigidbody
                _player.AddForce(movement * Speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Level Up"))
        {
            other.gameObject.SetActive(false);
            _level = _level + 1;
            //Debug.Log("level: " +_level);
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + _count.ToString();
        /*if (_count >= 16)
        {
            WinText.text = "You Win!";
        }*/
    }

}
