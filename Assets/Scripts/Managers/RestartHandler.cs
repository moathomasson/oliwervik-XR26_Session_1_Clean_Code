using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHandler : MonoBehaviour
{
    private bool canRestart = false;

    public void EnableRestart()
    {
        canRestart = true;
        Invoke(nameof(Restart), 2f);
    }

    void Update()
    {
        if (canRestart && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
