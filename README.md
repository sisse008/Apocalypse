# Apocalypse



https://3d-simple-platformer-with-selection.netlify.app/



The Menu scene:

  The game manager:


  Drag your level configurations to the input field “All Game Levels”. For each configuration a button will appear in the menu.

  Drag default avatar to be used in case that no avatar is selected in the selection scene. The selected avatar and level are remembered      throughout the game.


  A level configuration holds references to an Enemy prefab, a Coin prefab, a bunch of platform prefabs, a key prefab, enemy damage float and height differences between platforms.

  Each platform prefabs holds the positions where the enemies, coins, and keys will be instantiated at runtime(with the damage configuration from the  level configuration scriptable object).


The avatar selection scene:

  The SelectionMenuGenerator holds reference to a scriptable object “Avatar selection data” which holds a list of “selection menu items.” each of which holds reference to the corresponding object to be selected. The game manager listens to the event that a SelectionMenuItem is selected and sets the selectedAvatar to the corresponding object.

  The path that the avatar selection menu items are on (SelectionPath) is calculated at runtime to correspond with the camera position and a given radius and offsets. The SelectionPath scripts holds all the calculations for placement of the selection items in the path (any number of items can be added) and the functions such as NextItem or LastItem (rotating the circular path clockwise or counter clockwise).







The Main Game Scene:



  Platforms, enemies, coins, key, and the Player body (avatar) are all instantiated at runtime.
  The PlatformGenerator is used to generate the platforms from the LevelConfiguration. 

  The player

  The player has a CharacterController component and the attached script GravitationalCharacter simulates gravity in FixedUpdate.

  The player can die by:
  Losing health
  Falling off platforms

  The game ends by:
  Getting to door and opening it
  Dying

  Once the game ends the player can choose to replay that level or to go back to main menu.


  RPGRuntimeInputHelper is used to control the player with input. 
  The initial position of the player is set according to the Transform initPosition in PlatformController.

