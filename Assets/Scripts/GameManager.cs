using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float secondsStart = 30.0f ;

    [SerializeField]
    float secondsLeft;


    public float SecondsLeft { get { return secondsLeft; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsLeft = secondsStart - Time.timeSinceLevelLoad;
        

        
    }
  
}
