using UnityEngine;

public class EnemyMain : MonoBehaviour


{
    Rigidbody rb;

    [SerializeField]
    float moveSpeedHorizontal = 5.0f;

    

    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.left * moveSpeedHorizontal * Time.deltaTime);

              
    }
}
