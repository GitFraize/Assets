using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightsColor : MonoBehaviour
{
    public float frequency=0.005f;
    Image image;
    public float r=255, g=0, b=0;
    public float minR = 0, minG = 0, minB = 0;
    public float maxR = 255, maxG = 255, maxB = 255;

    private void Update()
    {
        image.color=new Color(r/255,g/255,b/255);
    }
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        if (r == 255)
        {
            r = maxR;
            StartCoroutine(S1());
        }
        else if (g == 255)
        {
            g = maxG;
            StartCoroutine(S5());
        }
        else if (b == 255)
        {
            b = maxB;
            StartCoroutine(S3());
        }
    }
    IEnumerator S1()
    {
        while (b != maxB)
        {
            b++;
            if (b == maxB)
            {
                StartCoroutine(S2());
                StopCoroutine(S1());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
    IEnumerator S2()
    {
        while (r != minR)
        {
            r--;
            if (r == minR)
            {
                StartCoroutine(S3());
                StopCoroutine(S2());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
    IEnumerator S3()
    {
        while (g != maxG)
        {
            g++;
            if (g == maxG)
            {
                StartCoroutine(S4());
                StopCoroutine(S3());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
    IEnumerator S4()
    {
        while (b != minB)
        {
            b--;
            if (b == minB)
            {
                StartCoroutine(S5());
                StopCoroutine(S4());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
    IEnumerator S5()
    {
        while (r != maxR)
        {
            r++;
            if (r == maxR)
            {
                StartCoroutine(S6());
                StopCoroutine(S5());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
    IEnumerator S6()
    {
        while (g != minG)
        {
            g--;
            if (g == minG)
            {
                StartCoroutine(S1());
                StopCoroutine(S6());
            }
            yield return new WaitForSeconds(frequency);
        }
    }
}
