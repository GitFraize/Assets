using UnityEngine;
using UnityEngine.UI;

public class CheckText : MonoBehaviour
{
    public Text text;
    public float speed = 1;
    public float maxScale = 12;
    bool oneCheck = false;

    private void Update()
    {
        if (gameObject.transform.localScale.y < maxScale && !oneCheck)
        {
            gameObject.transform.localScale += new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, 0);
        } else
            oneCheck = true;
        if (oneCheck && gameObject.transform.localScale.y > 1)
        {
            gameObject.transform.localScale -= new Vector3(Time.deltaTime * speed*2, Time.deltaTime * speed*2, 0);
        }else if(oneCheck)
            Destroy(gameObject);
    }
}
