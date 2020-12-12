using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckText : MonoBehaviour
{
    public Text text;
    public float speed = 1;
    public float maxScale = 12;

    void Start()
    {
        StartCoroutine(animationUp());
    }
    private IEnumerator animationUp()
    {
        while (gameObject.transform.localScale.y < maxScale)
        {
            gameObject.transform.localScale += new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, 0);
            if (gameObject.transform.localScale.y >= maxScale)
            {
                StopCoroutine(animationUp());
                StartCoroutine(animationDown());
            }
            yield return new WaitForEndOfFrame();
        }
    }
    private IEnumerator animationDown()
    {
        while (gameObject.transform.localScale.y > 1)
        {
            gameObject.transform.localScale -= new Vector3(Time.deltaTime * speed * 2, Time.deltaTime * speed * 2, 0);
            if (gameObject.transform.localScale.y <= 1)
            {
                StopCoroutine(animationDown());
                Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
