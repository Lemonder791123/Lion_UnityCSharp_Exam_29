using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Back();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Next();
        }
    }
}
