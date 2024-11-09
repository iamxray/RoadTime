using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyDrunk : EnemyMain
{
    [SerializeField]
    float moveSpeedHorizontalDrunk = 7.0f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    protected override void MoveForward() 
    {
        transform.Translate(Vector3.left * moveSpeedHorizontalDrunk * Time.deltaTime);
    }

}
