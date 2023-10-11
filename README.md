# thebestLiam
Add a short description of the intended behavior, how the game mechanic should work. I need to know what were you trying to achieve.

When you start the game you are meet with a little main menu where you can ether play the game or quit. If you click the play button the first map starts and the two players race (Green is player 1) and (orange is player two). On the first map there are power ups that make you faster and respawn every 3 seconds. The map change when one of the players have completed the map (3 laps) and the second one starts and after you have completed that map the last map will start and once you have finished the last map, a thanks for playing screen will play and then take you back to the main menu where you can choose if you wanna play again or quit.  

Add a short set of instructions for me, as a developer, about what do I need do to in order to take a look at your project - what scene I need to load in order to play? Do I need any additional packages to install?

You first need to go in the assets folder and select scenes then you vlick on the one called main menu and then you just start
Describe quickly the structure of your code and the thinking behind design.

To start we have the car movment that are built on three functions first one is ApplyEngineForce and it is what controlls the speed and acceleration. Then whe have the ApplySteering and that one handels the rotation of the car so you for example cant turn when the car is stoped. Lastly we have the killOrthogonalVelocity that removes the side forces of the car. Sadly becuse if felt like I was behind on time I made two diffrent scripts for the diffrent cars and that is a decision I regret. 

My CarLapCounter works becuase I put multipule checkpoints on the map when you pass the check point in the right order from 1 to 11. the checkpoints are counted so you get the passed check point number plus one and so if you have driven through all of them and then drive in to the finish line you get plus one lap and when you have done that three times the map ends and the next one plays. It also tells the player who is in first place when you drive though the checkpoints.

Add a short list if instructions about how to play the game like, for example, the key mappings and what do they do.

My tips are that when you play the first map there are power ups that give you a higher acceleration speed and they respawn at the exact same place so when you are close to the spawn point taking it a bit slower then usual would not hurt since they are pretty easy to miss. When it comes to game play over all maps the best way is to not turn to much since that brings down the speed and the acceleration speed is slower. You can also gref the enemy by shoving them in to a wall with your hit box making it hard for them to miss the walls and keeping thier max speed. 

Add a list of sources of inspiration - you don't need to cover all of them, just the ones that helped.

Helped with the car movment 
https://www.youtube.com/watch?v=DVHcOS1E5OQ&t=2s

Helped with my laps 
https://www.youtube.com/watch?v=bA8CDIQiiP4&list=PLyDa4NP_nvPfmvbC-eqyzdhOXeCyhToko&index=6

Helped with the maps 
https://www.youtube.com/watch?v=i2R9zVvQp8c

Helped with most of my problems 
https://docs.unity3d.com/2023.3/Documentation/ScriptReference/Pool.ObjectPool_1.html 

Unity 2022.3.9f1
by Liam Anderberg 
