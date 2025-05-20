using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //存储场景中的UI信息
    private Dictionary<string, UIBase> UIDic = new Dictionary<string, UIBase>();

    //当前场景的 Canvas 游戏物体
    private Transform CanvasTransform = null;

    //当前字典中UI的个数
    public int UICount
    {
        get { return UIDic.Count; }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }


    private void Update()
    {
        if (UIDic.Count > 0)
        {
            foreach (var key in UIDic.Keys)
            {
                if (UIDic[key] != null)
                    UIDic[key].Update();
            }
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public UIBase ShowUI<T>() where T : UIBase
    {
        Type t = typeof(T);
        string fullName = t.FullName;

        if (UIDic.ContainsKey(fullName))
        {
            Debug.Log("当前面板已经显示了，名字：" + fullName);
            return UIDic[fullName];
        }

        GameObject canvasObj = GameObject.Find("Canvas");
        if (canvasObj == null)
        {
            Debug.LogError("场景中没有Canvas组件，无法显示UI物体");
            return null;
        }
        CanvasTransform = canvasObj.transform;

        UIBase uiBase = Activator.CreateInstance(t) as UIBase;
        if (string.IsNullOrEmpty(uiBase.PrefabsPath))
        {
            Debug.LogError("Prefabs 路径不能为空");
            return null;
        }

        GameObject prefabs = Resources.Load<GameObject>(uiBase.PrefabsPath);
        GameObject uiGameOjbect = GameObject.Instantiate(prefabs, CanvasTransform);
        uiGameOjbect.name = uiBase.PrefabsPath.Substring(uiBase.PrefabsPath.LastIndexOf('/') + 1);

        uiBase.UIName = uiGameOjbect.name;
        uiBase.SceneName = SceneManager.GetActiveScene().name;
        uiBase.UIGameObject = uiGameOjbect;
        uiBase.FullName = fullName;
        uiBase.Start();

        UIDic.Add(fullName, uiBase);
        return uiBase;
    }

    /// <summary>
    /// 移除面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void RemoveUI<T>()
    {
        Type t = typeof(T);
        string fullName = t.FullName;

        if (UIDic.ContainsKey(fullName))
        {
            UIBase uIBase = UIDic[fullName];
            uIBase.Destroy();

            GameObject.Destroy(uIBase.UIGameObject);
            UIDic.Remove(fullName);
            return;
        }

        Debug.Log(string.Format("当前的UI物体未实例化，名字：{0}", fullName));
    }

    /// <summary>
    /// 清除所有的UI物体
    /// </summary>
    public void ClearAllPanel()
    {
        foreach (var key in UIDic.Keys)
        {
            UIBase uIBase = UIDic[key];
            if (uIBase != null)
            {
                uIBase.Destroy();
                GameObject.Destroy(uIBase.UIGameObject);
            }
        }

        UIDic.Clear();
    }

    /// <summary>
    /// 找到指定的UI面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetGameObject<T>(string name)
    {
        Type t = typeof(T);
        string fullName = t.FullName;

        UIBase uIBase = null;
        if (!UIDic.TryGetValue(fullName, out uIBase))
        {
            Debug.Log("没有找到对应的UI面板，名字：" + fullName);
            return null;
        }

        return uIBase.GetObject(name);
    }


    private UIManager() { }
}
