using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneClickLoader : MonoBehaviour
{
    public string SceneName = "null";
    void Start()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(SceneName);
    }
}