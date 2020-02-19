# cs302-game
Collection of C# scripts I wrote for a Unity game. Final Project of CS302, Spring 2019.

Game was a top-down perspective hide-and-seek/cat-and-mouse game.

User manual with how the controls/interactions work:

     There are two players, the hider and the seeker. Both are spawned in the same maps, but see different viewpoints.

     Game contains multiple rounds, with each player having their own conditions of winning the round. Only one player can win each round.
     The first player to win 3 rounds wins the game. Each round is 3 minutes. Each round has a new random map, with the objectives reset.

     Game requires a dual monitor setup, mouse and keyboard, and a wired Xbox 360 controller connected to the same computer.

     Seeker:
          Controls: Wired Xbox 360 controller connected to the computer and will look at one monitor.
               Left Stick: movement
               Right Stick: aiming
               Right Trigger: shooting
          Viewpoint: Room is completely dark to the seeker, apart from the flashlight.
          Tools: A flashlight (cannot see past walls), a gun (1 second cooldown)
          Round Win Conditions: Collect 2 coins (white-looking stars) throughout the map before time expires, or shoot the hider.
          Special Notes: Seeker is frozen for the first 15 seconds of each round to allow the hider time to setup.
     
     Hider: 
          Control: Mouse and keyboard and looking at a different monitor, or laptop screen if playing on laptop.
               W, A, S, D: movement
               E: transform into any prop in view (hover over with mouse cursor)
               R: revert to original form
          Viewpoint: Room is completely lit to the hider.
          Tools: Can transform into props within the room and also revert back.
          Round Win Conditions: Tag the seeker while not a prop, or seeker does not complete either win condition and round time expires.
          Special Notes: If the hider gets too close to the seeker during the 15 second freeze-time, the seeker is given the round win.
               (this prevents camping the seeker)
     

     Using Network Test:

     To test the networking demo of the project, two computers on the same network are needed. One should open the game and click network demo,
     and then in the top left click LAN Host. The other computer should repeat the steps but then replace the localhost with ip address of
     the first computer and click LAN Client.

     
     Known bugs:
     
     When the hider transforms into another object he also takes that objects colider box. The collider boxes of the environment aren't
     very accurate and this causes the hider to not be able to move inbetwen some props even though it looks like he can. Revert back to original
     character using R to move inbetween these props.

     You can go out of bounds in the map, though it doesn't crash the game or have any adverse effects.

     Transforming into a couch only transforms you into part of the couch, since couches are made of multiple tiles and the hider can only
     transform into one tile at a time. I would recommend against transforming into couches.


     Disclosure about outside assets:
     
     Lighting system was created using an asset package called "Light2D" by Alexander Penkin. It is free and open-source on GitHub.
     The maps were created by using a tileset called "Topdown Shooter" by Kenney. It is free for any project, personal or commercial.
     The hider sprite, Kirby, was from Nintendo. It is copyrighted.
     Many Unity tutorials were used in the making of this game.
