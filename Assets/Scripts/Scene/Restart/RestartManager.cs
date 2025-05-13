using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void RestartLevel()
    {
        ObjectPoolerV2.ClearPool();
        SceneManager.LoadScene(0);
    }
}
