using UnityEngine;

public class ScriptTest : MonoBehaviour
{
    public int b = 5;
    public float m = 5;
    private void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            for(int i = 0; i < 20; i++)
            {
               float value = CalculateInitialSpeed(i);
            }
        }
        
    }
    public float CalculateInitialSpeed(int value)
    {        
        float speedModifier = -m * value + b;
        Debug.Log("para el level " + value + " speed es " + speedModifier);
        float speed = speedModifier * Mathf.Sin(Time.time);
        Debug.Log("para el level " + value + " speed es " + speed);
        return speedModifier;
    }
}
