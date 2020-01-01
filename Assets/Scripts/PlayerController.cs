using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{    
    private Rigidbody rb;
    public float force = 1.0f;
    private int jumpState = 0;
    private float baseState;
    private Text countText;

    //TODO: mve this to a GameMetaData class
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.baseState = 0.5f;
        countText = GameObject.Find("/Canvas/CountText").GetComponent<Text>();
        this.updateCountText();


    }

    // Update is called once per frame
    //  called before rendering a frame
    //  seems to be more responsive to "single tap" keyboard input
    void Update() {

        //reset jump state
        if (this.rb.position.y <= baseState)
        {
            this.jumpState = 0;
        }

        if (Input.GetKeyDown("space") && jumpState < 1) {
            //unlimited jumps?
            this.jumpState++;
            this.rb.AddForce(0f, 250f, 0f);
        }
        else if (Input.GetKeyDown("p") && jumpState == 0)
        {
            Debug.Log("hello");
            this.rb.velocity = new Vector3(0f, this.rb.velocity.y, 0f);
            this.rb.angularVelocity = Vector3.zero;
        }

    }

    // Called before any physics calculations
    void FixedUpdate()
    {
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveH, 0.0f, moveV);

            this.rb.AddForce(movement * this.force);


        }


    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if( other.gameObject.CompareTag("pickup") )
        {
            count++;
            other.gameObject.SetActive(false);
            this.updateCountText();
        }
    }

    void updateCountText()
    {
        this.countText.text = "Count: " + count.ToString();
    }
}
