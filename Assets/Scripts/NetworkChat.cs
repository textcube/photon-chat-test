using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkChat : Photon.MonoBehaviour {
	public UILabel uiLabel;
	public UIInput uiInput;
	public Transform uiDisplay;
	
	void OnSubmit(string inputString){
		string uname = SystemInfo.deviceName;
		uname = uname.Length>=7 ? uname.Substring(0,6) : uname;
		string msg = "[" + uname + "] " + inputString;
		photonView.RPC("SendChatMessage", PhotonTargets.All, msg);
		uiInput.text = "";
#if UNITY_EDITOR || UNITY_STANDALONE
        StartCoroutine( FocusTextFied() );
#endif
	}
   
    IEnumerator FocusTextFied(){
        yield return new WaitForSeconds(0.5f);
        uiInput.selected = true;
    }

	[RPC]
	void SendChatMessage(string text, PhotonMessageInfo info){
		uiLabel.text += text + "\n";
		float y = (uiLabel.relativeSize.y < 1f) ? 0f : (uiLabel.relativeSize.y-8f) * uiLabel.transform.localScale.y;
		uiDisplay.localPosition =  new Vector3(0f, y , 0f);
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
