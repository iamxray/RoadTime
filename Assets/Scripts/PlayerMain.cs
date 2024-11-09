using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    float moveSpeed = 5.0f;



    float inputHorizontal;
    float inputVertical;
    Vector3 direction;

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
        // Set the movement direction (e.g., randomly or towards a target)
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction != Vector3.zero)
        {
            // Normalize the direction vector
            direction.Normalize();

            // Rotate the GameObject to face the direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            // Move the GameObject in the direction
            transform.position += direction * moveSpeed * Time.deltaTime;
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
