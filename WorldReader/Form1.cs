using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WorldReader {



    public partial class Form1 : Form {

        public String PlayerFileName = "";

        public Form1() {
            InitializeComponent();

            // Load our list of items
            cboItems.Items.Clear();
            cboItems.Items.Add("");
            foreach (var i in Item.ItemList) {
                cboItems.Items.Add(i);
            }

        }


        private bool[] tileFrameImportant = new bool[80];
        private void SetImportantFrames() {
            tileFrameImportant[3] = true;
            tileFrameImportant[5] = true;
            tileFrameImportant[10] = true;
            tileFrameImportant[11] = true;
            tileFrameImportant[12] = true;
            tileFrameImportant[13] = true;
            tileFrameImportant[14] = true;
            tileFrameImportant[15] = true;
            tileFrameImportant[16] = true;
            tileFrameImportant[17] = true;
            tileFrameImportant[18] = true;
            tileFrameImportant[20] = true;
            tileFrameImportant[21] = true;
            tileFrameImportant[24] = true;
            tileFrameImportant[26] = true;
            tileFrameImportant[27] = true;
            tileFrameImportant[28] = true;
            tileFrameImportant[29] = true;
            tileFrameImportant[31] = true;
            tileFrameImportant[33] = true;
            tileFrameImportant[34] = true;
            tileFrameImportant[35] = true;
            tileFrameImportant[36] = true;
            tileFrameImportant[42] = true;
            tileFrameImportant[50] = true;
            tileFrameImportant[55] = true;
            tileFrameImportant[61] = true;
            tileFrameImportant[71] = true;
            tileFrameImportant[72] = true;
            tileFrameImportant[73] = true;
            tileFrameImportant[74] = true;
            tileFrameImportant[77] = true;
            tileFrameImportant[78] = true;
            tileFrameImportant[79] = true;
        }

        // This was for working with world data... I never got anywhere with it.
        private void button1_Click(object sender, EventArgs e) {

            // initializations
            var br = System.Environment.NewLine;
            NPC[] npc = new NPC[1001];
            Chest[] chest = new Chest[1000];
            Sign[] sign = new Sign[1000];
            SetImportantFrames();

            var filename = ""; //textBox1.Text
            using (var fileStream = new FileStream(filename, FileMode.Open)) {

                using (var binaryReader = new BinaryReader((Stream)fileStream)) {

                    var version = binaryReader.ReadInt32();

                    //lblResults.Text = "File Version: " + version.ToString() + br;

                    var worldName = binaryReader.ReadString();
                    var worldID = binaryReader.ReadInt32();
                    var leftWorld = (float)binaryReader.ReadInt32();
                    var rightWorld = (float)binaryReader.ReadInt32();
                    var topWorld = (float)binaryReader.ReadInt32();
                    var bottomWorld = (float)binaryReader.ReadInt32();
                    var maxTilesY = binaryReader.ReadInt32();
                    var maxTilesX = binaryReader.ReadInt32();

                    var spawnTileX = binaryReader.ReadInt32();
                    var spawnTileY = binaryReader.ReadInt32();
                    var worldSurface = binaryReader.ReadDouble();
                    var rockLayer = binaryReader.ReadDouble();
                    var WorldGen_tempTime = binaryReader.ReadDouble();
                    var WorldGen_tempDayTime = binaryReader.ReadBoolean();
                    var WorldGen_tempMoonPhase = binaryReader.ReadInt32();
                    var WorldGen_tempBloodMoon = binaryReader.ReadBoolean();
                    var dungeonX = binaryReader.ReadInt32();
                    var dungeonY = binaryReader.ReadInt32();
                    var NPC_downedBoss1 = binaryReader.ReadBoolean();
                    var NPC_downedBoss2 = binaryReader.ReadBoolean();
                    var NPC_downedBoss3 = binaryReader.ReadBoolean();
                    var WorldGen_shadowOrbSmashed = binaryReader.ReadBoolean();
                    var WorldGen_spawnMeteor = binaryReader.ReadBoolean();
                    var WorldGen_shadowOrbCount = (int)binaryReader.ReadByte();
                    var invasionDelay = binaryReader.ReadInt32();
                    var invasionSize = binaryReader.ReadInt32();
                    var invasionType = binaryReader.ReadInt32();
                    var invasionX = binaryReader.ReadDouble();


                    // secondary initializations
                    Tile[,] tile = new Tile[maxTilesX, maxTilesY];

                    for (int index1 = 0; index1 < maxTilesX; ++index1) {
                        //tssLblResults.Text = "Loading world data: " + (object)(int)((double)((float)index1 / (float)maxTilesX) * 100.0 + 1.0) + "%";
                        //progressBar1.Value = (int)((double)((float)index1 / (float)maxTilesX) * 100.0 + 1.0);
                        for (int index2 = 0; index2 < maxTilesY; ++index2) {

                            tile[index1, index2] = new Tile();

                            tile[index1, index2].active = binaryReader.ReadBoolean();
                            if (tile[index1, index2].active) {
                                tile[index1, index2].type = binaryReader.ReadByte();
                                if (tileFrameImportant[(int)tile[index1, index2].type]) {
                                    tile[index1, index2].frameX = binaryReader.ReadInt16();
                                    tile[index1, index2].frameY = binaryReader.ReadInt16();
                                } else {
                                    tile[index1, index2].frameX = (short)-1;
                                    tile[index1, index2].frameY = (short)-1;
                                }
                            }
                            tile[index1, index2].lighted = binaryReader.ReadBoolean();
                            if (binaryReader.ReadBoolean())
                                tile[index1, index2].wall = binaryReader.ReadByte();
                            if (binaryReader.ReadBoolean()) {
                                tile[index1, index2].liquid = binaryReader.ReadByte();
                                tile[index1, index2].lava = binaryReader.ReadBoolean();
                            }
                        }
                    }
                    for (int index1 = 0; index1 < 1000; ++index1) {
                        if (binaryReader.ReadBoolean()) {
                            chest[index1] = new Chest();
                            chest[index1].x = binaryReader.ReadInt32();
                            chest[index1].y = binaryReader.ReadInt32();
                            for (int index2 = 0; index2 < Chest.maxItems; ++index2) {
                                chest[index1].item[index2] = new Item();
                                byte num = binaryReader.ReadByte();
                                if ((int)num > 0) {
                                    string ItemName = binaryReader.ReadString();
                                    chest[index1].item[index2].SetDefaults(ItemName);
                                    chest[index1].item[index2].stack = (int)num;
                                }
                            }
                        }
                    }
                    for (int index1 = 0; index1 < 1000; ++index1) {
                        if (binaryReader.ReadBoolean()) {
                            string str = binaryReader.ReadString();
                            int index2 = binaryReader.ReadInt32();
                            int index3 = binaryReader.ReadInt32();
                            if (tile[index2, index3].active && (int)tile[index2, index3].type == 55) {
                                sign[index1] = new Sign();
                                sign[index1].x = index2;
                                sign[index1].y = index3;
                                sign[index1].text = str;
                            }
                        }
                    }
                    bool flag = binaryReader.ReadBoolean();
                    int index = 0;
                    while (flag) {
                        npc[index] = new NPC();
                        npc[index].SetDefaults(binaryReader.ReadString());
                        //npc[index].position.X = binaryReader.ReadSingle();
                        var x = binaryReader.ReadSingle();
                        //npc[index].position.Y = binaryReader.ReadSingle();
                        var y = binaryReader.ReadSingle();
                        npc[index].homeless = binaryReader.ReadBoolean();
                        npc[index].homeTileX = binaryReader.ReadInt32();
                        npc[index].homeTileY = binaryReader.ReadInt32();
                        flag = binaryReader.ReadBoolean();
                        ++index;
                    }
                    binaryReader.Close();


                    // output other information
                    //lblResults.Text += "World: " + worldName + br;



                }

            }
        }

        // For choosing the player file
        private void button2_Click(object sender, EventArgs e) {
            var file = new OpenFileDialog();
            file.Title = "Choose Character File";
            file.Filter = "PLR Files|*.plr";
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\My Games\\Terraria\\Players";
            if (file.ShowDialog() == DialogResult.OK) {

                var filename = file.FileName.ToString();
                PlayerFileName = filename; // save for later use

                Player player = new Player();
                bool flag;
 
                //string str = playerPath + ".dat";
                var str = filename + ".dec"; // this will hold the decrypted data
                flag = Player.DecryptFile(filename, str);
                if (!flag) {
                    using (FileStream fileStream = new FileStream(str, FileMode.Open)) {
                        using (BinaryReader binaryReader = new BinaryReader((Stream)fileStream)) {
                            binaryReader.ReadInt32();
                            player.name = binaryReader.ReadString();
                            player.hair = binaryReader.ReadInt32();
                            player.statLife = binaryReader.ReadInt32();
                            player.statLifeMax = binaryReader.ReadInt32();
                            player.statMana = binaryReader.ReadInt32();
                            player.statManaMax = binaryReader.ReadInt32();
                            player.hairColor.R = binaryReader.ReadByte();
                            player.hairColor.G = binaryReader.ReadByte();
                            player.hairColor.B = binaryReader.ReadByte();
                            player.skinColor.R = binaryReader.ReadByte();
                            player.skinColor.G = binaryReader.ReadByte();
                            player.skinColor.B = binaryReader.ReadByte();
                            player.eyeColor.R = binaryReader.ReadByte();
                            player.eyeColor.G = binaryReader.ReadByte();
                            player.eyeColor.B = binaryReader.ReadByte();
                            player.shirtColor.R = binaryReader.ReadByte();
                            player.shirtColor.G = binaryReader.ReadByte();
                            player.shirtColor.B = binaryReader.ReadByte();
                            player.underShirtColor.R = binaryReader.ReadByte();
                            player.underShirtColor.G = binaryReader.ReadByte();
                            player.underShirtColor.B = binaryReader.ReadByte();
                            player.pantsColor.R = binaryReader.ReadByte();
                            player.pantsColor.G = binaryReader.ReadByte();
                            player.pantsColor.B = binaryReader.ReadByte();
                            player.shoeColor.R = binaryReader.ReadByte();
                            player.shoeColor.G = binaryReader.ReadByte();
                            player.shoeColor.B = binaryReader.ReadByte();
                            for (int index = 0; index < 8; ++index) {
                                player.armor[index] = new Item();
                                player.armor[index].name = binaryReader.ReadString();

                            }

                            listInventory.Items.Clear();

                            for (int index = 0; index < 44; ++index) {


                                player.inventory[index] = new Item();
                                player.inventory[index].name = binaryReader.ReadString();
                                player.inventory[index].stack = binaryReader.ReadInt32();

                                listInventory.Items.Add((index+1).ToString() + " - " + player.inventory[index].name + " (" + player.inventory[index].stack + ")");

                            }
                            for (int index = 0; index < Chest.maxItems; ++index) {

                                player.bank[index] = new Item();
                                player.bank[index].name = binaryReader.ReadString();
                                player.bank[index].stack = binaryReader.ReadInt32();

                            }
                            for (int index = 0; index < 200; ++index) {
                                int num = binaryReader.ReadInt32();
                                if (num != -1) {
                                    player.spX[index] = num;
                                    player.spY[index] = binaryReader.ReadInt32();
                                    player.spI[index] = binaryReader.ReadInt32();
                                    player.spN[index] = binaryReader.ReadString();
                                } else
                                    break;
                            }
                            binaryReader.Close();


                            // display information
                            lblPlayerResults.Text = "Player: " + player.name;


                        }
                    }
                        
                }

                


            }
        }

        // Individual picked a new inventory slot
        private void listInventory_SelectedIndexChanged(object sender, EventArgs e) {

            // (index+1).ToString() + " - " + player.inventory[index].name + " (" + player.inventory[index].stack + ")"
            var selVal = listInventory.SelectedItem.ToString();

            var selIndex = selVal.Substring(0, selVal.IndexOf(" "));
            lblInventoryIndex.Text = selIndex;

            var selName = selVal.Substring(selVal.IndexOf(" - ") + 3, selVal.LastIndexOf(" (") - selVal.IndexOf(" - ") - 3);

            cboItems.SelectedIndex = cboItems.Items.IndexOf(selName);

            var selQty = selVal.Substring(selVal.LastIndexOf(" (") + 2, selVal.LastIndexOf(")") - selVal.LastIndexOf(" (") - 2);
            txtQuantity.Text = selQty;

        }

        // Edit a particular inventory slot
        private void btnEditInventorySlot_Click(object sender, EventArgs e) {

            Object newItem = "";
            if (cboItems.SelectedIndex != -1) 
                newItem = cboItems.Items[cboItems.SelectedIndex];

            var i = Convert.ToInt32(lblInventoryIndex.Text);
            var item = (i).ToString() + " - " + newItem + " (" + txtQuantity.Text + ")";

            var al = new ArrayList();
            foreach (var j in listInventory.Items) {
                al.Add(j);
            }

            al[i - 1] = item;

            listInventory.Items.Clear();
            foreach (var k in al) {
                listInventory.Items.Add(k);
            }
        }

        // This is where we create the new player file
        private void CreateNewPlayerFile() {

            var filename = PlayerFileName;
            try {
                File.Delete(filename + ".invbak");
            } catch (Exception ex) {
                // throw your hands in the air
            }
            File.Copy(filename, filename + ".invbak"); // before we go crazy, let's back our original up

            Player player = new Player();
            bool flag;

            var str = filename + ".dec2"; // this will hold the decrypted data
            var strEdit = filename + ".edit"; // this will hold unencrypted data with our new items
            var strEditEnc = filename + ".editenc"; // this will hold the new items, encrypted
            flag = Player.DecryptFile(filename, str);
            if (!flag) {
                using (FileStream fileStream = new FileStream(str, FileMode.Open)) {
                    using (BinaryReader binaryReader = new BinaryReader((Stream)fileStream)) {

                        var newFile = new FileStream(strEdit, FileMode.Create);
                        var bw = new BinaryWriter((Stream)newFile);

                        bw.Write(binaryReader.ReadInt32());
                        bw.Write(binaryReader.ReadString());
                        bw.Write(binaryReader.ReadInt32());
                        bw.Write(binaryReader.ReadInt32());
                        bw.Write(binaryReader.ReadInt32());
                        bw.Write(binaryReader.ReadInt32());
                        bw.Write(binaryReader.ReadInt32());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        bw.Write(binaryReader.ReadByte());
                        for (int index = 0; index < 8; ++index) {
                            bw.Write(binaryReader.ReadString());

                        }
                        if (listInventory.Items.Count != 44) {
                            throw new Exception("Numbers not matching up");
                        }
                        foreach (var i in listInventory.Items) {
                            var oldItem = binaryReader.ReadString();
                            var oldQty = binaryReader.ReadInt32();

                            var selVal = i.ToString();
                            var selName = selVal.Substring(selVal.IndexOf(" - ") + 3, selVal.LastIndexOf(" (") - selVal.IndexOf(" - ") - 3);
                            var selQty = selVal.Substring(selVal.LastIndexOf(" (") + 2, selVal.LastIndexOf(")") - selVal.LastIndexOf(" (") - 2);

                            bw.Write(selName.ToString());
                            bw.Write(Convert.ToInt32(selQty));

                        }
                        for (int index = 0; index < Chest.maxItems; ++index) {

                            bw.Write(binaryReader.ReadString());
                            bw.Write(binaryReader.ReadInt32());

                        }
                        for (int index = 0; index < 200; ++index) {
                            int num = binaryReader.ReadInt32();
                            bw.Write(num);
                            if (num != -1) {
                                bw.Write(binaryReader.ReadInt32());
                                bw.Write(binaryReader.ReadInt32());
                                bw.Write(binaryReader.ReadString());
                            } else
                                break;
                        }
                        binaryReader.Close();
                        bw.Close();

                        Player.EncryptFile(strEdit, strEditEnc);
                        File.Delete(filename);
                        File.Copy(strEditEnc, filename);


                        // display information
                        lblPlayerResults.Text = "Player: " + player.name;


                    }
                }

            }




            
        }

        private void button3_Click(object sender, EventArgs e) {
            CreateNewPlayerFile();
        }

    }

    public class Tile {
        public bool active;
        public bool lighted;
        public byte type;
        public byte wall;
        public byte wallFrameX;
        public byte wallFrameY;
        public byte wallFrameNumber;
        public byte liquid;
        public bool checkingLiquid;
        public bool skipLiquid;
        public bool lava;
        public byte frameNumber;
        public short frameX;
        public short frameY;
    }

    public class NPC {

        public void SetDefaults(String _name) {
            name = _name;
        }

        public static int immuneTime = 20;
        public static int maxAI = 4;
        private static int spawnSpaceX = 4;
        private static int spawnSpaceY = 4;
        //private static int spawnRangeX = (int)((double)(screenWidth / 16) * 1.2);
        //private static int spawnRangeY = (int)((double)(screenHeight / 16) * 1.2);
        //public static int safeRangeX = (int)((double)(screenWidth / 16) * 0.55);
        //public static int safeRangeY = (int)((double)(screenHeight / 16) * 0.55);
        //private static int activeRangeX = screenWidth * 2;
        //private static int activeRangeY = screenHeight * 2;
        //private static int townRangeX = screenWidth * 3;
        //private static int townRangeY = screenHeight * 3;
        private static int activeTime = 1000;
        private static int defaultSpawnRate = 700;
        private static int defaultMaxSpawns = 4;
        public static bool downedBoss1 = false;
        public static bool downedBoss2 = false;
        public static bool downedBoss3 = false;
        private static int spawnRate = NPC.defaultSpawnRate;
        private static int maxSpawns = NPC.defaultMaxSpawns;
        public int[] immune = new int[9];
        public int direction = 1;
        public int directionY = 1;
        public float[] ai = new float[NPC.maxAI];
        public int target = -1;
        public float scale = 1f;
        public float knockBackResist = 1f;
        public int spriteDirection = -1;
        public int homeTileX = -1;
        public int homeTileY = -1;
        public bool wet;
        public byte wetCount;
        public bool lavaWet;
        public int soundDelay;
        //public Vector2 position;
        //public Vector2 velocity;
        //public Vector2 oldPosition;
        //public Vector2 oldVelocity;
        public int width;
        public int height;
        public bool active;
        public int type;
        public int aiAction;
        public int aiStyle;
        public int timeLeft;
        public int damage;
        public int defense;
        public int soundHit;
        public int soundKilled;
        public int life;
        public int lifeMax;
        public Rectangle targetRect;
        public double frameCounter;
        public Rectangle frame;
        public string name;
        public Color color;
        public int alpha;
        public int oldDirection;
        public int oldDirectionY;
        public int oldTarget;
        public int whoAmI;
        public float rotation;
        public bool noGravity;
        public bool noTileCollide;
        public bool netUpdate;
        public bool collideX;
        public bool collideY;
        public bool boss;
        public bool behindTiles;
        public float value;
        public bool townNPC;
        public bool homeless;
        public bool friendly;
        public bool closeDoor;
        public int doorX;
        public int doorY;
        public int friendlyRegen;

    }

    public class Chest {
        public static int maxItems = 20;
        public Item[] item = new Item[Chest.maxItems];
        public int x;
        public int y;
    }

    

    public class Sign {
        public const int maxSigns = 1000;
        public int x;
        public int y;
        public string text;
    }

}
