# Goomba's Returnal
## _An tower defense game college project._


[![](https://media.discordapp.net/attachments/1259254041280643072/1259266987175968899/madewithunity_pixelart.png?ex=668b0f45&is=6689bdc5&hm=958a5ac34e0c83a09176a21b513f9c1856f1eacb906f1f5d992e11c76aeaa44c&=&format=webp&quality=lossless )](https://www.unity.com)


Goomba's Returnal is a tower defense game inspired by Mario Tower Defense flash games.


## Features

- 3D Movement!
- Spawn 3D Towers ingame!
- Nintendo Assets (please nintendo don't sue me :pray:)
- Pretty cool copyrighted music
- and more!

## Contents
- Gameplay
- Mechanics
- Scripts
- Requirements check
- Dev Notes / Version Control
- Conclusion

## Gameplay

This game is largely inspired by the Bloons TD series made by Ninja Kiwi. It also takes a large inspiration from old school tower defense flash games.
You are a creeper, who can fly around in a "spectator mode" Point of view to stop the goombas and its allies to attack your home. Will this go as planned? Place towers, and upgrade them (strategically), while also trying to get rid of goomba and its friends!

## Mechanics

The game uses a script which allows you to fly just like in View Mode in Unity, with Q and E you can adjust your views and R you can reset your view to start, incase it breaks.

The game makes use of a Pathfinding script which works as following.


##### Enemyscript - Visual Example


There are nodes layed on the map.
![](https://images-ext-1.discordapp.net/external/UkiNfzdLdJhJEXkARdI1K8o6ZdtdyX8bgK0N8_ugaqI/https/i.ibb.co/dGStbwZ/image.png?format=webp&quality=lossless&width=596&height=592)

The enemy will spawn with help of the wavescript (explained in the Scripts section.)
![](https://images-ext-1.discordapp.net/external/0-0LvoLg2wkD83fRt9TITWUHkqj1HhEGsWfdPLhqUus/https/i.ibb.co/F4NHNvt/image.png?format=webp&quality=lossless&width=588&height=592)

Eventually, the so called "Pathfinding script" (explained later aswell) will read the so called nodes locations on the map, it will make the enemy move towards the invisible nodes (they aren't invisible but use your imagination.)
It will turn to them aswell, and check the object is nearby the checkpoint with a if statement,
if that is true it will advance into the next checkpoint.
![](https://images-ext-1.discordapp.net/external/xiURPaVq7Du6Tfd5GOpF7j17Krs9XcnOKonmL00CP7A/https/i.ibb.co/3RzYZ1L/image.png?format=webp&quality=lossless&width=594&height=591)


##### Towerscript- Visual Example
This had to be one of the hardest ones, not only did i put the wrong attack code on the object, there were so many things done wrong. I managed to figure it out eventually.

The first things done is the laying of a so called invisible floor called Buildables. Those are checks to see if the game is allowed to place a tower at so called locations.
![](https://media.discordapp.net/attachments/1259254041280643072/1259254421335048332/image.png?ex=668b0391&is=6689b211&hm=ed215066fb3f9f34062777ae952592b07843c7b8ef5948c161e0d9ad68ee8e6b&=&format=webp&quality=lossless&width=354&height=350)

To do so, it runs a simple raycast, which shoots to your Crosshair. If it collides with the Buildables (which are tagged MayBuild) it may place a tower there doing so but only after running a check that the player has a equal balance of the money needed for its tower.
![](https://media.discordapp.net/attachments/1259254041280643072/1259254062398967980/image.png?ex=668b033c&is=6689b1bc&hm=5b10807d682b92246bef4e8ca58594a4e95963394ddf004c272b5a4951db54e2&=&format=webp&quality=lossless&width=593&height=592)

Next, the tower runs off a towerscript, where it will shoot a so called gizmo for the player to see the collision circle ingame, how big the range of the tower is. The enemies are tagged with enemy, and a timer will run. If the timer reaches zero and the goomba collides with the range it will call anohter function in the project which will summon a particle that will shoot to the enemy to deal damage.
![](https://media.discordapp.net/attachments/1259254041280643072/1259255786320691230/image.png?ex=668b04d7&is=6689b357&hm=d787e90b6078a43bb6505e94eb605bebe2ac289512b7a3283ea688b24f679782&=&format=webp&quality=lossless&width=700&height=700)

Here, this so called particle will take trhe direction of the enemy and move towards it. Once it triggers the collision with the enemy it will make the enemy take damage and destroy itself.
![](https://media.discordapp.net/attachments/1259254041280643072/1259261281622294578/image.png?ex=668b09f5&is=6689b875&hm=cbf06b385a2cfb4bc45cd518b9b53b200c29c7c35c6d80dcb24b63a582878f1b&=&format=webp&quality=lossless&width=600&height=600)

## Scripts 
The game uses a ton of scripts which will all be summarized below.

##### EnemyScript.cs


```C
// This is the enemy script! Enemys will be getting instancieerd with this.
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyScript : MonoBehaviour
{
// 3 Values will be made to be used later on.
    public int HP = 5; 
    public int CoinReward = 1;
    public static int kills = 0;

    private void Start()
    {
    // So, everytime a enemy will spawn, it will give the player a kill. This might look unlogic, but the name choice wasn't done right. 
    // This has to do with the wave script, 
        kills++;
    }
    private void Update()
    {
    // This was used for debugging reasons.
        //Debug.Log($"{gameObject.name} HP: {HP}"); 
    }

    public void TakeDamage(int damage)
    {
    // Another script will be calling this function, hence the **public** function.
        HP -= damage;
        if (HP <= 0)
        {
            godie();
        }
    }

    private void godie()
    {
    // If the hp reaches zero, give player a coin reward and destroy.
        Money.coins = Money.coins + CoinReward;
        Destroy(gameObject);
    }
}

```
## Requirements check
![](https://cdn.discordapp.com/attachments/1176615300830089266/1239578494195728426/image.png?ex=668a9fef&is=66894e6f&hm=c3d0afdc61571bafa540cc38fd0629bbe64b612742c54ffa4134c77d4964aed6&)

*This is a check for the developer to see if it qualifes for the college project.*

Level = Goed, er zijn 3 verschillende levels.
Towers = Goed, ik denk dat het duidelijk is wat het verschil is.
Kogels = Voldoende. Er is geen variate, maar er is wel verschil in het vertraging. (delay)
Vijanden = Voldoende? een baas moet nog komen
Padvinden = eh jawel is wel goeie toch. werkt met nodes.
Speldoestellingen = voldoende
Codekwaliteit = voldoende
Planning = voldoende. kon beter imo
Documentatie = maak ik nu, denk je wel dat ie goed is of niet ouleh
Versiebeheer = Goed, er werd gebruik gemaakt van cloned repo's, en het mergen en solven van merge conflicts.

## Dev Notes / Version Control
Nothing yet here to see..

## Conclusion
I hope you have enjoyed my documentation on this project and i hope to have informed you well enough. Especially hope you liked the Visual explanation i did as well.