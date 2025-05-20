using UnityEngine;
using UnityEngine.UI;

public class Panel_Affiche : UIBase
{
    public Panel_Affiche()
    {
        PrefabsPath = "Prefabs/UI/Panel_Affiche";
    }

    public override void Start()
    {
        GetOrAddCommonent<Button>("Button_Close").onClick.AddListener(() =>
        {
            GameManager.Instance.LoadScene("start");
        });
    }

    public override void Update()
    {
        //Debug.Log("我是 Panel_Affiche Update 方法");
    }

    public override void Destroy()
    {
        //Debug.Log("我是 Panel_Affiche Destroy 方法");
    }
}
