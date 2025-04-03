1. Make sure to add following folders to assets folder:
  -- Art
  -- Prefabs
  -- ScriptableObjects
  -- Scripts

2. Add following prefabs to scene:
 - Player
  -- Or if you have a different player add all prefabs on the folder: Assets/Prefabs/Health System/PlayerHealthComponents
  -- Set Playr object tag to Player

  -- Your PlayerController Script should have following code:
-------------------------------------------------------------
	Public variables declared in class:
    		public GameEventListener hurtListener;
    		public GameEventListener healListener;

	Enabling of the listeners, for example in Start() Method:
        	healListener.enabled = true;
        	hurtListener.enabled = true;

-------------------------------------------------------------      

  -- remember to add the HurtListener and HealListener objects from the hierarchy to the fields on the PlayerController Script component of your player

 - Add HealthBarHearts prefab
 - Add LowHealthAdmin prefab
 
 *- Asign the HealthBarHearts object from hierarchy to the Heaart Beat field of Player HPManager Script component, which is a child of player

 *- Also look for the object LowHealthBorders which is a child of LowHealthAnim, and asign the LowHealthBorders object to the Player HP Manager field "Low Health Borders"

3. Add damage zone prefab as children of your spikes and other damage zones

  - UnCheck the box continous damage if you don't want to keep doing damage continously while player is on the zone. Adjust frequency of damage.

4. Use enemy prefab as an enemy (Enemy not updated for movement yet)

5. LowHealthBorders has a fixed size and it must be adjusted for changes on the screen size

