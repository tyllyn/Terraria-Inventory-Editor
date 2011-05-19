using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace WorldReader {

    public class Color {
        public int R, G, B;
        public Color(int _r, int _g, int _b) {
            R = _r; G = _g; B = _b;
        }
    }

    public class Player {
        public static int tileRangeX = 5;
        public static int tileRangeY = 4;
        private static int jumpHeight = 15;
        private static float jumpSpeed = 5.01f;
        private static int itemGrabRange = 38;
        private static float itemGrabSpeed = 0.45f;
        private static float itemGrabSpeedMax = 4f;
        public string chatText = "";
        public int sign = -1;
        public int changeItem = -1;
        public Item[] armor = new Item[8];
        public int breathMax = 200;
        public int breath = 200;
        public string setBonus = "";
        public Item[] inventory = new Item[44];
        public Item[] bank = new Item[Chest.maxItems];
        public string name = "";
        public int head = -1;
        public int body = -1;
        public int legs = -1;
        public int width = 20;
        public int height = 42;
        public int direction = 1;
        public float manaCost = 1f;
        //public Vector2[] shadowPos = new Vector2[3];
        public int step = -1;
        public float meleeSpeed = 1f;
        public int statLifeMax = 100;
        public int statLife = 100;
        public int SpawnX = -1;
        public int SpawnY = -1;
        public int[] spX = new int[200];
        public int[] spY = new int[200];
        public string[] spN = new string[200];
        public int[] spI = new int[200];
        public bool[] adjTile = new bool[80];
        public bool[] oldAdjTile = new bool[80];
        public Color hairColor = new Color(215, 90, 55);
        public Color skinColor = new Color((int)byte.MaxValue, 125, 90);
        public Color eyeColor = new Color(105, 90, 75);
        public Color shirtColor = new Color(175, 165, 140);
        public Color underShirtColor = new Color(160, 180, 215);
        public Color pantsColor = new Color((int)byte.MaxValue, 230, 175);
        public Color shoeColor = new Color(160, 105, 60);
        public int[] grappling = new int[20];
        public int chest = -1;
        public int talkNPC = -1;
        public bool pvpDeath;
        public bool zoneDungeon;
        public bool zoneEvil;
        public bool zoneMeteor;
        public bool zoneJungle;
        public bool boneArmor;
        public int townNPCs;
        //public Vector2 position;
        //public Vector2 velocity;
        //public Vector2 oldVelocity;
        public double headFrameCounter;
        public double bodyFrameCounter;
        public double legFrameCounter;
        public bool immune;
        public int immuneTime;
        public int immuneAlphaDirection;
        public int immuneAlpha;
        public int team;
        public int chatShowTime;
        public int activeNPCs;
        public bool mouseInterface;
        public int selectedItem;
        public int itemAnimation;
        public int itemAnimationMax;
        public int itemTime;
        public float itemRotation;
        public int itemWidth;
        public int itemHeight;
        //public Vector2 itemLocation;
        public int breathCD;
        public float headRotation;
        public float bodyRotation;
        public float legRotation;
        //public Vector2 headPosition;
        //public Vector2 bodyPosition;
        //public Vector2 legPosition;
        //public Vector2 headVelocity;
        //public Vector2 bodyVelocity;
        //public Vector2 legVelocity;
        public bool dead;
        public int respawnTimer;
        public int attackCD;
        public int potionDelay;
        public bool wet;
        public byte wetCount;
        public bool lavaWet;
        public int hitTile;
        public int hitTileX;
        public int hitTileY;
        public int jump;
        //public Rectangle headFrame;
        //public Rectangle bodyFrame;
        //public Rectangle legFrame;
        //public Rectangle hairFrame;
        public bool controlLeft;
        public bool controlRight;
        public bool controlUp;
        public bool controlDown;
        public bool controlJump;
        public bool controlUseItem;
        public bool controlUseTile;
        public bool controlThrow;
        public bool controlInv;
        public bool releaseJump;
        public bool releaseUseItem;
        public bool releaseUseTile;
        public bool releaseInventory;
        public bool delayUseItem;
        public bool active;
        public bool showItemIcon;
        public int showItemIcon2;
        public int whoAmi;
        public int runSoundDelay;
        public float shadow;
        public bool fireWalk;
        public int shadowCount;
        public bool channel;
        public int statDefense;
        public int statAttack;
        public int statMana;
        public int statManaMax;
        public int lifeRegen;
        public int lifeRegenCount;
        public int manaRegen;
        public int manaRegenCount;
        public int manaRegenDelay;
        public bool noKnockback;
        private static int tileTargetX;
        private static int tileTargetY;
        public int hair;
        public bool hostile;
        public int accWatch;
        public int accDepthMeter;
        public bool accFlipper;
        public bool doubleJump;
        public bool jumpAgain;
        public bool spawnMax;
        public int grapCount;
        public int rocketDelay;
        public int rocketDelay2;
        public bool rocketRelease;
        public bool rocketFrame;
        public bool rocketBoots;
        public bool canRocket;
        public bool jumpBoost;
        public bool noFallDmg;
        public int swimTime;
        public int chestX;
        public int chestY;
        public int fallStart;
        public int slowCount;



        public static bool DecryptFile(string inputFile, string outputFile) {
            byte[] bytes = new UnicodeEncoding().GetBytes("h3y_gUyZ");
            FileStream fileStream1 = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            CryptoStream cryptoStream = new CryptoStream((Stream)fileStream1, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
            try {
                int num;
                while ((num = cryptoStream.ReadByte()) != -1)
                    fileStream2.WriteByte((byte)num);
                fileStream2.Close();
                cryptoStream.Close();
                fileStream1.Close();
            } catch {
                fileStream2.Close();
                fileStream1.Close();
                File.Delete(outputFile);
                return true;
            }
            return false;
        }

        public static void EncryptFile(string inputFile, string outputFile) {
            byte[] bytes = new UnicodeEncoding().GetBytes("h3y_gUyZ");
            FileStream fileStream1 = new FileStream(outputFile, FileMode.Create);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            CryptoStream cryptoStream = new CryptoStream((Stream)fileStream1, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
            int num;
            while ((num = fileStream2.ReadByte()) != -1)
                cryptoStream.WriteByte((byte)num);
            fileStream2.Close();
            cryptoStream.Close();
            fileStream1.Close();
        }



    }

    

}
