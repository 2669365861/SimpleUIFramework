using UnityEngine;
using UnityEngine.UI;

public class Panel_Setting : UIBase
{
    public Panel_Setting()
    {
        PrefabsPath = "Prefabs/UI/Panel_Setting";
    }

    public override void Start()
    {
        //Debug.Log("我是 Panel_Setting Start 方法");

        GetOrAddCommonent<Button>("Button_Close").onClick.AddListener(() =>
        {
            //移除自己
            UIManager.Instance.RemoveUI<Panel_Setting>();
        });

        GetOrAddCommonent<Button>("Button_Test").onClick.AddListener(() =>
        {
            //访问其他的面板的游戏物体 
            GameObject obj = UIManager.Instance.GetGameObject<Panel_MainUI>("Button_Map");
            if (obj != null)
                obj.transform.Find("Text").GetComponent<Text>().text = "Map";
        });

        GetOrAddCommonent<Button>("Button_Test1").onClick.AddListener(() =>
        {
            Debug.Log("UIManager 中 UI 面板的个数：" + UIManager.Instance.UICount);
        });
    }

    public override void Update()
    {
        //Debug.Log("我是 Panel_Setting Update 方法");
    }

    public override void Destroy()
    {
        //Debug.Log("我是 Panel_Setting Destroy 方法");
    }
}
