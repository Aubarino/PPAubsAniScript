# Aubarino's Animation Script
A Universally Decent Animation Script Base for People Playground, To make Gif-like animations.


<h2> How to setup and use Aubarino's Animation System... </h2>

You may use this in any way you want, Just give Credit in the Mod Description that you used my system,
These rules do not apply to Me Aubarino when i use my own system obviously.
Try and steal credit of creating this addition in your code and I will findout... you're going to have a Skill Issue B)
aka i'll down your mod and mock you on the internet.
You can modify this however you want, But to share a modified version of this you'll need to get in contact with me (read below).


* 1. put AubsAnimationScript.cs into your mod
* 2. add AubsAnimationScript.cs to your mod.json file
* 3. Open the main c# file of your mod, place the following inside the mod class but NOT inside the Main function!

        //function that loads animation frames to be used in an animation
        public static void AniFramesLoad(string TextureLoc, int maxFrame, int Rescale, GameObject LodInstance)
        {
        int internalmaxframe = maxFrame;
        string internaltextureloc = TextureLoc;
        int internalrescale = Rescale;
        GameObject internalinstance = LodInstance;

        Sprite[] aniarray = new Sprite[] {};
        for(int i = 1; i <= (internalmaxframe + 1); i++){
            aniarray = aniarray.Concat(new Sprite[] { ModAPI.LoadSprite(internaltextureloc + i + ".png", internalrescale) }).ToArray();
            }
        
        internalinstance.GetComponent<AubsAnimationScript>().FrameData(aniarray);
        }

* 4. in your object, in the AfterSpawn area add the following like you would Any Other element of your object...

                        //animation script stuff
                        Instance.AddComponent<AubsAnimationScript>();
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("assets2/thedog/dogdoin1.png", 4);                        
                        Instance.FixColliders();                        
                        AniFramesLoad("assets2/thedog/dogdoin", 11, 4, Instance);
                        Instance.GetComponent<AubsAnimationScript>().AnimationData(11, 2, Instance);

This is a Template on the structuring of the animation system...

* 5. Format the textures/frames of your animation as something such as... idk... "myanimation#.png" in a folder location in
your mod, The (#) would instead be an increasing number from 1 to the total amount of frames.
Such as "myanimation1.png, myanimation2.png, myanimation3.png" individually for a 3 frame animation. MUST BE PNG FORMAT

* 6. Edit the AniFramesLoad parameters in the above template in your object,
the format is the following ("the texture location and their name without the number or .png", total amount of frames,
the rescale DEVIDED BY, The Instance DO NOT EDIT).

* 7. Edit the .AnimationData parameters, following the following format
(the total amount of frames... again, The Delay, The Instance DO NOT EDIT).

* 8.
edit the "Instance.GetComponent<SpriteRenderer>().sprite" parameter to be the path of the first frame... i guess? ...

* 9. Done

Talk to Aubarino#8007 on discord for more help 'n contact with me.

