using UnityEngine;

public class StartSceneRoot : MonoBehaviour {	
	void Start () {
		UIManager.Instance.ShowUI<Panel_MainUI>();
    }
}
