using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Sprite spriteMute, spriteUnmute;
    public GameObject muteButton;
    private void Awake (){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1){
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void MuteButton (bool muted) {
        if (muted){
            AudioListener.volume = 0;
            muteButton.GetComponent<Image>().sprite = spriteMute;
        } else {
            AudioListener.volume = 1;
            muteButton.GetComponent<Image>().sprite = spriteUnmute;
        }
    }
    
}
