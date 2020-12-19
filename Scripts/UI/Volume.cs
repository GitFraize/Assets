using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public float volume=30;
    public Text text;
    public Sprite off;
    public Sprite on;
    bool isOn;
    bool isDown = false;
    private void Update()
    {
        if (isDown)
        {
            volume += Input.GetAxis("Mouse Y")*2;
            if (volume <= 0)
            {
                volume = 0;
                isOn = false;
                gameObject.GetComponent<Image>().sprite = off;
            }
            else if (!isOn)
            {
                isOn = true;
                gameObject.GetComponent<Image>().sprite = on;
            }
            if (volume > 100)
                volume = 100;
            text.text = (int)volume + " %";
        }
    }
    private void OnMouseDown()
    {
        isDown = true;
    }
    private void OnMouseUp()
    {
        isDown = false;
    }
}
