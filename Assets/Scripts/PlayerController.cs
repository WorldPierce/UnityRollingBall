using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countTxt;
    public Text winTxt;

    private void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        setCountTxt();
        winTxt.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountTxt();
            if(count == 12)
            {
                winTxt.text = "You Win!";
            }
        }
    }

    void setCountTxt()
    {
        countTxt.text = "Count " + count.ToString();
    }
}
