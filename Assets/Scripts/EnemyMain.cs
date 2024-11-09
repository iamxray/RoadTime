using UnityEngine;

public class EnemyMain : MonoBehaviour


{
    Rigidbody rb;

    [SerializeField]
    float moveSpeedHorizontal = 5.0f;

    [SerializeField]

    Vector3 moveDirection;

    float endPointX = 25.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveForward();

        if (transform.position.x < -endPointX || transform.position.x > endPointX)
        {

            gameObject.SetActive(false);

        }


    }

    protected virtual void MoveForward() 
    {
        transform.Translate(moveDirection * moveSpeedHorizontal * Time.deltaTime);
    }

}
