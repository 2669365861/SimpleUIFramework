using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    private static bool origional = true;

    private void Awake()
    {
        if (origional)
        {
            Instance = this as GameManager;
            origional = false;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start () {
        SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //Debug.Log("场景加载了，场景名：" + arg0.name);
    }

    private void SceneManager_sceneUnloaded(Scene arg0)
    {
        //Debug.Log("场景卸载了，场景名：" + arg0.name);

        //注意：切换场景要清除掉 UIManager 中保存的 UI 数据
        UIManager.Instance.ClearAllPanel();
    }

    public void LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private GameManager() { }
}
