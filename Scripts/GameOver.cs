using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button restartButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<King>() != null)
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            restartButton.gameObject.SetActive(true);
        }
        if(other.gameObject.GetComponent<Pattern>() != null)
        {
            other.gameObject.GetComponentInParent<Board>().deleteOldPattern(other.gameObject);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        restartButton.gameObject.SetActive(false);
    }
}
