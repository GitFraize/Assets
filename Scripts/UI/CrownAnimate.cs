using UnityEngine;
using System.Collections;
public class CrownAnimate : MonoBehaviour
{
    public float maxScale = 2f;
    public float minScale = 1f;
    public float frequency=0.01f;
    public float speed = 1;
    public void startAnimate()
    {
        StopAllCoroutines();
        StartCoroutine(upScale());
    }
    private IEnumerator upScale()
    {
        while (true)
        {
            gameObject.transform.localScale += new Vector3(frequency*speed, frequency*speed, 0);
            if (gameObject.transform.localScale.y >= maxScale)
            {
                StopAllCoroutines();
                StartCoroutine(downScale());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
    private IEnumerator downScale()
    {
        while (gameObject.transform.localScale.y > minScale)
        {
            gameObject.transform.localScale -= new Vector3(frequency*speed, frequency*speed, 0);
            if (gameObject.transform.localScale.y <= minScale)
            {
                gameObject.transform.localScale = new Vector3(minScale, minScale, 0);
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(frequency);
        }
    }
}
