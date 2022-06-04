# Wanderer
## 2D game


_Time spent: 4-5 hours_
<br/> <br/>
No plugins used.
<br/>
##### My personal purpose for this project was to manually implement everything and avoid using any method I didn't write myself. However, I won't necessarily be faithful to this approach when writing big scaled games. where the goal is optimized polished output. That being said, here's anything you might need for this project...<br/><br/>

Features:<br/>
###
1. Top-down 2D game, where a triangle wanders through objects it shouldn't collide with  
2. A simplistic player movement controller (with GetAxis - Works with ArrowKeys)
3. A simplistic camera movement controller (to follow player with a smooth delay)
4. Collision OnTrigger Detection

Implementation (Classes discussed alphabetically):<br/>
1. Camera Color Changer: When damage is caused, this class will be notified through an Action implemented in Player.cs. Changes the Camera.backgroundColor value changes through white and pale red.
2. Camera Movement Controller: To implement the smooth delay, I calculate the direction vector on Update(), so that every time it's multiplied by a <1 number, the closer the target pos gets, the smaller the dir vector becomes. To achieve a constant speed, now you know which line to play with.
3. Level Manager: Adds itself to 2 actions on Player.cs, where both refer to the same method with a bool parameter. Lambda was used to make this easier.
4. Player: Has 3 actions in total (OnBeingDamaged, OnLevelWon, OnLevelLost). Disables damage detector for half a second to give player time to flee (with a mini coroutine). This is where collision On Trigger is detected.
5. Player Movement Controller: could be merged with the Player class, however, I personally prefer to not have one class do more than one task. This code is mapped into arrowkeys. If you don't want to have the player rotate, apply line #13 to Translate and you'd be good to go.
6. UI Manager: Also added to the damage action on Player. The rest is straight-forward.

<br/><br/>
Final notes:<br/>
1. Almost all classes have some version of Singleton implemented.
2. The only art file in this project is the sprite of the player and I drew it on MS Paint. That's why it's not transparent, and i did a trick to visually hide it. Don't tell anyone. :)