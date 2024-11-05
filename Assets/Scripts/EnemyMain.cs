using UnityEngine;

public class EnemyMain : MonoBehaviour


{
    Rigidbody rb;

    [SerializeField]
    float moveSpeedHorizontal = 5.0f;

    [SerializeField]

    Vector3 moveDirection;

    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(moveDirection * moveSpeedHorizontal * Time.deltaTime);

              
    }
}
