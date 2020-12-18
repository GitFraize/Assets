using UnityEngine;

public class ButtonMainMenu : MonoBehaviour
{
    public float MinSpeed;
    float speed;
    public float MaxSpeed;
    bool isToMax = true;
    private void Start()
    {
        speed = Random.Range(MinSpeed, MaxSpeed);
    }
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
        if (isToMax)
            if (speed < MaxSpeed)
                speed += MaxSpeed * Time.deltaTime;
            else
                isToMax = false;
        else
            if (speed > MinSpeed)
                speed -= MaxSpeed * Time.deltaTime;
            else
                isToMax = true;
    }
}