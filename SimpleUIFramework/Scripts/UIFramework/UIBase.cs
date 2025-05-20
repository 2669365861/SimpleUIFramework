using UnityEngine;

public class UIBase
{
    #region 字段
    
    /// <summary>
    /// Prefabs路径
    /// </summary>
    public string PrefabsPath { get; set; }
    /// <summary>
    /// UI面板的名字
    /// </summary>
    public string UIName { get; set; }
    /// <summary>
    /// 当前UI所在的场景名
    /// </summary>
    public string SceneName { get; set; }
    /// <summary>
    /// Type 的全名
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// 当前UI的游戏物体
    /// </summary>
    public GameObject UIGameObject { get; set; }


    #endregion






    /// <summary>
    /// 面板实例化时执行一次
    /// </summary>
    public virtual void Start() { }

    /// <summary>
    /// 每帧执行
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// 当前UI面板销毁之前执行一次
    /// </summary>
    public virtual void Destroy() { }


    /// <summary>
    /// 根据名称查找一个子对象
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetObject(string name)
    {
        Transform[] trans = UIGameObject.GetComponentsInChildren<Transform>();
        foreach (var item in trans)
        {
            if (item.name == name)
                return item.gameObject;
        }

        Debug.LogError(string.Format("找不到名为 {0} 的子对象", name));
        return null;
    }

    /// <summary>
    /// 根据名称获取一个子对象的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T GetOrAddCommonent<T>(string name) where T : Component
    {
        GameObject child = GetObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();
            return child.GetComponent<T>();
        }
        return null;
    }


    protected UIBase() { }
}
