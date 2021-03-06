﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WorldReader {
    public class Item {

        public void SetDefaults(String _name) {
            name = _name;
        }

        public static int potionDelay = 720;
        public int ownIgnore = -1;
        public int createTile = -1;
        public int createWall = -1;
        public float scale = 1f;
        public int headSlot = -1;
        public int bodySlot = -1;
        public int legSlot = -1;
        public int owner = 8;
        public bool wet;
        public byte wetCount;
        public bool lavaWet;
        //public Vector2 position;
        //public Vector2 velocity;
        public int width;
        public int height;
        public bool active;
        public int noGrabDelay;
        public bool beingGrabbed;
        public int spawnTime;
        public bool wornArmor;
        public int ownTime;
        public int keepTime;
        public int type;
        public string name;
        public int holdStyle;
        public int useStyle;
        public bool channel;
        public bool accessory;
        public int useAnimation;
        public int useTime;
        public int stack;
        public int maxStack;
        public int pick;
        public int axe;
        public int hammer;
        public int tileBoost;
        public int damage;
        public float knockBack;
        public int healLife;
        public int healMana;
        public bool potion;
        public bool consumable;
        public bool autoReuse;
        public bool useTurn;
        public Color color;
        public int alpha;
        public int useSound;
        public int defense;
        public string toolTip;
        public int rare;
        public int shoot;
        public float shootSpeed;
        public int ammo;
        public int useAmmo;
        public int lifeRegen;
        public int manaRegen;
        public int mana;
        public bool noUseGraphic;
        public bool noMelee;
        public int release;
        public int value;
        public bool buy;


        public static ArrayList ItemList {
            get {

                var al = new ArrayList();
                al.Add("Anvil");
                al.Add("Workbench");
                al.Add("Furnace");
                al.Add("Alchemy Station");
                al.Add("Chains");
                al.Add("Torch");
                al.Add("Candle");
                al.Add("Copper Chandelier");
                al.Add("Gold Chandelier");
                al.Add("Lesser Healing Potion");
                al.Add("Healing Potion");
                al.Add("Lesser Mana Potion");
                al.Add("Mushroom");
                al.Add("Glowing Mushroom");
                al.Add("Wooden Hammer");
                al.Add("Wooden Axe");
                al.Add("Wooden Pickaxe");
                al.Add("Copper Hammer");
                al.Add("Copper Axe");
                al.Add("Copper Pickaxe");
                al.Add("Iron Hammer");
                al.Add("Iron Axe");
                al.Add("Iron Pickaxe");
                al.Add("Gold Hammer");
                al.Add("Gold Axe");
                al.Add("Gold Pickaxe");
                al.Add("War Axe of the Night");
                al.Add("Nightmare Pickaxe");
                al.Add("Meteor Hamaxe");
                al.Add("Wooden Sword");
                al.Add("Wooden Bow");
                al.Add("Copper Shortsword");
                al.Add("Copper Broadword");
                al.Add("Copper Bow");
                al.Add("Iron Shortsword");
                al.Add("Iron Broadsword");
                al.Add("Iron Bow");
                al.Add("Silver Bow");
                al.Add("Silver Broadsword");
                al.Add("Gold Bow");
                al.Add("Gold Shortsword");
                al.Add("Gold Broadsword");
                al.Add("Demon Bow");
                al.Add("Light's Bane");
                al.Add("Yellow Phase Blade");
                al.Add("Minishark");
                al.Add("Star Cannon");
                al.Add("Musket");
                al.Add("Flintlock Pistol");
                al.Add("Blade of Grass");
                al.Add("Enchanted Boomerang");
                al.Add("Muramasa");
                al.Add("Vilethorn");
                al.Add("Aqua Scepter");
                al.Add("Magic Missile");
                al.Add("Space Gun");
                al.Add("Wooden Arrow");
                al.Add("Flaming Arrow");
                al.Add("Unholy Arrow");
                al.Add("Jester's Arrow");
                al.Add("Musket Ball");
                al.Add("Bones");
                al.Add("Bomb");
                al.Add("Grenade");
                al.Add("Dynamite");
                al.Add("Shuriken");
                al.Add("Vile Powder");
                
                al.Add("Miner's Helmet");
                al.Add("Googles");
                al.Add("Gray Brick");
                al.Add("Copper Brick");
                al.Add("Red Brick");
                al.Add("Silver Brick");
                al.Add("Gold Brick");
                al.Add("Obsidian Brick");
                al.Add("Blue Brick");
                al.Add("Green Brick");
                al.Add("Pink Brick");
                al.Add("Wooden Wall");
                al.Add("Dirt Wall");
                al.Add("Stone Wall");
                al.Add("Gray Brick Wall");
                al.Add("Blue Brick Wall");
                al.Add("Green Brick Wall");
                al.Add("Pink Brick Wall");
                al.Add("Copper Ore");
                al.Add("Iron Ore");
                al.Add("Silver Ore");
                al.Add("Gold Ore");
                al.Add("Demonite Ore");
                al.Add("Meteorite Ore");
                al.Add("Copper Bar");
                al.Add("Iron Bar");
                al.Add("Silver Bar");
                al.Add("Gold Bar");
                al.Add("Demonite Bar");
                al.Add("Meteorite Bar");
                al.Add("Chest");
                al.Add("Wooden Chair");
                al.Add("Wooden Table");
                al.Add("Wooden Door");
                al.Add("Copper Coin");
                al.Add("Silver Coin");
                al.Add("Gold Coin");
                al.Add("Wood");
                al.Add("Stone Block");
                al.Add("Dirt Block");
                al.Add("Sand Block");
                al.Add("Cobweb");
                al.Add("Mud Block");
                al.Add("Ebonstone Block");
                al.Add("Obsidian");
                al.Add("Hellstone");
                al.Add("Ash Block");
                al.Add("Sunflower");
                al.Add("Glass");
                al.Add("Bottle");
                al.Add("Grappling Hook");
                al.Add("Sign");
                al.Add("Wood Platform");
                al.Add("Rocket Boots");
                al.Add("Angel Statue");
                al.Add("Vile Mushroom");
                al.Add("Snorkle");
                al.Add("Empty Bucket");
                al.Add("Books");
                al.Add("Magic Mirror");
                al.Add("Ivy Whip");
                al.Add("Silk");
                al.Add("Suspicious Looking Eye");
                al.Add("Crystal Heart");
                al.Add("Corrupt Seeds");
                al.Add("Mushroom Grass Seeds");
                al.Add("Grass Seeds");
                al.Add("Acorn");
                al.Add("Purification Powder");
                al.Add("Worm Food");
                al.Add("Clay Pot");
                al.Add("Sapphire");
                al.Add("Amethyst");
                al.Add("Emerald");
                al.Add("Topaz");
                al.Add("Diamonds");
                al.Add("Gel");
                al.Add("Lens");
                al.Add("Hook");
                al.Add("Rotten Chunks");
                al.Add("Heart");
                al.Add("Star");
                al.Add("Shadow Scales");
                al.Add("Hermes Boots");
                al.Add("Cloud in a Bottle");
                al.Add("Ring of Regeneration");
                al.Add("Flippers");
                al.Add("Obsidian Skull");
                al.Add("Band of Starpower");
                al.Add("Depth Meter");
                al.Add("Lucky Horseshoes");
                al.Add("Cobalt Shield");
                al.Add("Fallen Star");
                al.Add("Mana Crystal");
                al.Add("Lesser Mana Potion");
                al.Add("Dirt Rod");
                al.Add("Orb of Light");
                al.Add("Sunfury");

                al.Add("Molten Pickaxe");
                al.Add("Molten Hamaxe");
                al.Add("The Breaker");
                al.Add("Breathing Reed");

                al.Add("Copper Greaves");
                al.Add("Copper Chainmail");
                al.Add("Copper Helmet");
                al.Add("Iron Chainmail");
                al.Add("Iron Greaves");
                al.Add("Iron Helmet");
                al.Add("Silver Greaves");
                al.Add("Silver Chainmail");
                al.Add("Gold Greaves");
                al.Add("Gold Chainmail");
                al.Add("Gold Helmet");
                al.Add("Meteor Leggings");
                al.Add("Meteor Suit");
                al.Add("Meteor Helmet");

                // shadow
                al.Add("Shadow Helmet");
                al.Add("Shadow Scalemail");
                al.Add("Shadow Greaves");
                
                // cobalt
                al.Add("Cobalt Helmet");
                al.Add("Cobalt Breastplate");
                al.Add("Cobalt Greaves");

                // necro
                al.Add("Necro Helmet");
                al.Add("Necro Breastplate");
                al.Add("Necro Greaves");

                // molten
                al.Add("Molten Helmet");
                al.Add("Molten Breastplate");
                al.Add("Molten Greaves");
                
                al.Sort();
                return al;

            }
        }

    }
}
