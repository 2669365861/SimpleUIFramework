using UnityEngine;
using UnityEngine.UI;

public class Panel_MainUI : UIBase
{
    public Panel_MainUI()
    {
        PrefabsPath = "Prefabs/UI/Panel_MainUI";
    }

    public override void Start()
    {
        GetOrAddCommonent<Button>("Button_Setting").onClick.AddListener(() =>
        {
            //显示设置面板
            UIManager.Instance.ShowUI<Panel_Setting>();
        });

        GetOrAddCommonent<Button>("Button_Task").onClick.AddListener(() =>
        {
            //清除所有的面板
            //UIManager.Instance.ClearAllPanel();  

            //跳转到 main 场景
            GameManager.Instance.LoadScene("main");
        });

        GetOrAddCommonent<Button>("Button_Equipage").onClick.AddListener(() =>
        {
            Debug.Log("UIManager 中 UI 面板的个数：" + UIManager.Instance.UICount);
        });
    }

    public override void Update()
    {
        //Debug.Log("我是 Panel_MainUI Update 方法");
    }

    public override void Destroy()
    {
        //Debug.Log("我是 Panel_MainUI Destroy 方法");
    }
}
