## Creating New Content

The Mission, Perk and Weapon are designed in a way that allow the designer or other team members to create new content without writing scripts by simply drag and drop and tweaking some values for each content type.

## Create

Open the **Project** window and right click to open up the menu and select **Create**. Select any new content you want to create on the top.

## Mission

 - **MissionId** - The Id used for the mission when game loads.
 - **Name** - The title of mission to display in lobby and in game.
 - **Type** - The type of mission the player has to complete. Mission Type includes Defend, Rescue, Sabotage and Assassination.
 - **Description** - The description of the mission to display in the lobby and in game.
 - **Reward Exp** - The amount of experience earned when complete the mission.
 - **Total Required** - Total amount of requirment needed to completed the mission.
 - **Mission Target Type** - The target type of the mission if it is related to killing or destroying.

## Perk

Each **Perk** has corresponding **PerkData** which is used to adjust perk status. Each perk has behaviour which can be added to the Behaviours list in the **Perk** object. This allow the designer to have unique perk with different behaviours.

 - **PerkId** - The Id used for the profile and saved to the database.
 - **Name** - The name of the perk to display in the lobby.
 - **Description** - The description of the perk to display in the lobby.
 - **Thumbnail** - The icon of the perk to display in the lobby and in game.
 - **PerkType** - Active / Passive
 - **BaseCooldown** - Base cooldown of the perk.
 - **Behaviours** - Attachable behaviours for the perk when is casted. Behaviours are predefined and can be implement by inherit from **PerkBehaviour** class.
 
## Weapon

Each **Weapon** has corresponding **WeaponData** which is used to adjust weapon status. Different weapon has different data.

 - **WeaponId** - The Id used for the profile and saved to the database.
 - **Name** - The name of the weapon to display in the lobby.
 - **Description** - The description of the weapon to display in the lobby.
 - **Thumbnail** - The icon of the weapon to display in the lobby and in game.
 - **Ammo Per Round** - The number of ammo in the current magazine.
 - **Total Carried Ammo** - The number of ammo in the current magazine.
 - **Range** - The distance the ammo travels.