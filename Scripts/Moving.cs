using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        gameObject.transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
    }
}
