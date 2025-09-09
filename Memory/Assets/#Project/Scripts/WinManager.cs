using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinManager : MonoBehaviour
{
    public bool isWon = false;

    public void Initialise()
    {
        isWon = false;
    }
    public IEnumerator ChangeScene(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Victory Scene");
    }
}
