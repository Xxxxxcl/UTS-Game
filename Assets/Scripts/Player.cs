using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public int Soldier = 0;
    private int soldierBox = 0;

    //private Rigidbody playerRigidbody;
    private Vector3 movement;


    private Vector3 velocity;
    // Use this for initialization
    void Start()
    {
        //playerRigidbody = this.GetComponent<Rigidbody>();
        movement = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        //this.transform.eulerAngles += new Vector3(h * 3, v * 3, 0);


        velocity = new Vector3(h * 0.5f, v * 0.5f, 0);

        velocity = transform.TransformDirection(velocity);


        transform.localPosition += velocity * Time.fixedDeltaTime;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Home"))
        {
            UIController._instance.DropSoldier();
            if (Soldier > 0)
            {
                SoundController._instance.PlaySound(0);
            }
            Soldier = 0;
            soldierBox = 0;
        }
        else if (collision.CompareTag("Solders") && Soldier < 3 + soldierBox)
        {
            UIController._instance.RescueSoldier();
            Soldier++;
            collision.gameObject.SetActive(false);
            SoundController._instance.PlaySound(2);
        }
        else if (collision.CompareTag("Tree"))
        {
            SoundController._instance.PlaySound(1);
            UIController._instance.GameOver();
        }
        else if (collision.CompareTag("Box"))
        {
            soldierBox++;
            Destroy(collision.gameObject);
        }
    }
}
