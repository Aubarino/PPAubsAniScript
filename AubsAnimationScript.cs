using UnityEngine;
using System.Collections.Generic;


///░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░///
///░░Aubarino's Animation Script░░///
///░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░///
///░░░░░▄▄▄▄▀▀▀▀▀▀▀▀▄▄▄▄▄▄░░░░░░░░///
///░░░░░█░░░░▒▒▒▒▒▒▒▒▒▒▒▒░░▀▀▄░░░░///
///░░░░█░░░▒▒▒▒▒▒░░░░░░░░▒▒▒░░█░░░///
///░░░█░░░░░░▄██▀▄▄░░░░░▄▄▄░░░░█░░///
///░▄▀▒▄▄▄▒░█▀▀▀▀▄▄█░░░██▄▄█░░░░█░///
///█░▒█▒▄░▀▄▄▄▀░░░░░░░░█░░░▒▒▒▒▒░█///
///█░▒█░█▀▄▄░░░░░█▀░░░░▀▄░░▄▀▀▀▄▒█///
///░█░▀▄░█▄░█▀▄▄░▀░▀▀░▄▄▀░░░░█░░█░///
///░░█░░░▀▄▀█▄▄░█▀▀▀▄▄▄▄▀▀█▀██░█░░///
///░░░█░░░░██░░▀█▄▄▄█▄▄█▄████░█░░░///
///░░░░█░░░░▀▀▄░█░░░█░█▀██████░█░░///
///░░░░░▀▄░░░░░▀▀▄▄▄█▄█▄█▄█▄▀░░█░░///
///░░░░░░░▀▄▄░▒▒▒▒░░░░░░░░░░▒░░░█░///
///░░░░░░░░░░▀▀▄▄░▒▒▒▒▒▒▒▒▒▒░░░░█░///
///░░░░░░░░░░░░░░▀▄▄▄▄▄░░░░░░░░█░░///
///░░░░░░░░░░░░░░░░░░░░▀▀▀▀▀▀▀▀░░░///
///░░Welcome to my dogshit code░░░///
///░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░///

//read the txt that comes with this.

//the namespace of the mod...
namespace Mod
{
    public class AubsAnimationScript : MonoBehaviour
    {
        private int AniMax = 10;
        private float AniDelay = 5;
        private float AniClock = 99999;
        private int AniFrame = 0;
        private Sprite[] AniFramePort;        
        private GameObject AniInstance;

        //function to set the animation data
        //format is The Last Frame, Delay inbetween frames, the Texture Rescale to devide by, The Gameobject carry-over...
        public void AnimationData(int maxFrame, float Delay, GameObject instanceport)
        {
        AniMax = maxFrame;
        AniDelay = Delay;
        AniInstance = instanceport;
        }

        //function to import the frame data
        public void FrameData(Sprite[] FramePort)
        {
        AniFramePort = FramePort;        
        }        

        private void FixedUpdate()
        {
        AniClock += 1;
        //checks if clock is outside delay range, then resets and checks if the max frame is hit, then it restarts the animation
        if (AniClock >= AniDelay){
            AniClock = 0;
            if (AniFrame > (AniMax - 1)){
                AniFrame = 0;
                AniClock = AniDelay;
                }else{
                    AniInstance.GetComponent<SpriteRenderer>().sprite = (AniFramePort[AniFrame]);                    
                    Debug.Log("AniFrame " + AniFrame);
                    AniFrame += 1;
                    //sets the frame
                    }
            }
        }
    }
}
