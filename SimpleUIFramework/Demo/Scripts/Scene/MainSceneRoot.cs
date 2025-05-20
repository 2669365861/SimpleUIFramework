using UnityEngine;

public class MainSceneRoot : MonoBehaviour {
	void Start () {
		UIManager.Instance.ShowUI<Panel_Affiche>();
	}
}
