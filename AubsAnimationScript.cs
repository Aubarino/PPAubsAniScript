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
        public int AniFrame = 0;
        private Sprite[] AniFramePort;
        private GameObject AniInstance;
        public bool ExperimentalColCyc = false;
        public bool PauseAnimation = false;
        public bool ResetWhenPause = false;

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

        //internal function of setting the frame
        public void InternalSetFrame(Sprite[] InternalAniFramePort, int InternalFrameSet)
        {
        AniInstance.GetComponent<SpriteRenderer>().sprite = (InternalAniFramePort[InternalFrameSet]);
        // ^ ^ ^ sets the frame sprite itself
        // v v v experimental 'n extra options
            if (ExperimentalColCyc) {
            AniInstance.FixColliders(); //resets the colliders per frame, making the collider update with the animation!
            }
        }        

        private void FixedUpdate()
        {

        if (PauseAnimation && (AniClock == 0)) {
        
        }else{
            AniClock += 1;
                //checks if clock is outside delay range, then resets and checks if the max frame is hit, then it restarts the animation
                if (AniClock >= AniDelay){
                    AniClock = 0;
                    if (AniFrame > (AniMax - 1)){
                        AniFrame = 0;
                        AniClock = AniDelay;
                        }else{
                            if (PauseAnimation) {
                                    if (ResetWhenPause) {
                                    AniFrame = 0;
                                    }                                
                                InternalSetFrame(AniFramePort, AniFrame);
                                AniClock = 0;
                                }else{
                                    InternalSetFrame(AniFramePort, AniFrame);
                                    
                                    //debug function (debug only)
                                    //Debug.Log("AniFrame " + (AniFrame + 1));
                                    AniFrame += 1;
                                }
                            }
                }
            }
        }
    }
}
