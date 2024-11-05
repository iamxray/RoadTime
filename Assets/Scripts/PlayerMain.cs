using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    float moveSpeedHorizontal = 5.0f;

    [SerializeField]
    float moveSpeedVertical = 4.0f;

    float inputHorizontal;
    float inputVertical;

    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        gameManager = FindAnyObjectByType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal != 0) 
            {
            
                transform.Translate(Vector3.right * inputHorizontal * moveSpeedHorizontal * Time.deltaTime);
                
        }

        inputVertical = Input.GetAxis("Vertical");
        if (inputVertical != 0)
        {
            
            transform.Translate(Vector3.forward * inputVertical * moveSpeedVertical * Time.deltaTime);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.GameWin();
            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }



    }



}
