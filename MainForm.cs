/*
 * Created by SharpDevelop.
 * User: KWIAT
 * Date: 2018-10-02
 * Time: 14:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ets_save_editor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			// TODO: trim dla pól gdzie mają być tylko liczby
			// TODO: po wyszukaniu player_job zmieniać tylko pierwsze wartości
			//
		}
		
/* ------------ EXTRACT ------------- */
public static void extractResource(String embeddedFileName, String destinationPath)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var arrResources = currentAssembly.GetManifestResourceNames();
        foreach (var resourceName in arrResources)
        {
            if (resourceName.ToUpper().EndsWith(embeddedFileName.ToUpper()))
            {
                using (var resourceToSave = currentAssembly.GetManifestResourceStream(resourceName))
                {
                    using (var output = File.OpenWrite(destinationPath))
                        resourceToSave.CopyTo(output);
                    resourceToSave.Close();
                }
            }
        }
    }
        /* ------------ EXTRACT ------------- */

        string[] locationsATS = new string[] {"- Default -",
"Alamogordo",
"Albuquerque",
"Artesia",
"Barstow",
"Camp Verde",
"Carlsbad",
"Carson City",
"Clifton",
"Clovis",
"Coos Bay",
"Ehrenberg",
"El Centro",
"Eugene",
"Everett",
"Farmington",
"Flagstaff",
"Gallup",
"Grand Canyon Village",
"Hobbs",
"Holbrook",
"Kayenta",
"Kingman",
"Las Cruces",
"Las Vegas",
"Longview",
"Los Angeles",
"NewPort",
"Nogales",
"Oakdale",
"Page",
"Phoenix",
"Primm",
"Raton",
"Roswell",
"Salem",
"San Diego",
"San Simon",
"Santa Fe",
"Show Low",
"Sierra Vista",
"Socorro",
"Tucson",
"Tumicari",
"Yuma",};



        string[] locationsETS = new string[] { "- Default -",
                                            "Bergen",
                                            "Berlin",
                                            "Bordeaux",
                                            "Catanzaro",
                                            "Kopenhaga",
                                            "Olbia",
                                            "Palmero",
                                            "Paris",
                                            "Petersburg",
                                            "Sassari",
                                            "Tampere",
                                            "Uppsala - GNT",
                                            "Uppsala",
                                            "VillaSan",
                                            "Vyborg-Kamen"};

        string[] truck_locationATS = new string[] { "",
"(&c7376656, &428a34b2, &46f2d965) (&3ecb18e8; &b7d97593, &3f6aff63, &38741661)",
"(&c74501ac, &4287dcb2, &4698d537) (&3f7edca4; &b8062a4b, &3dc0e6e4, &b5cc5560)",
"(&c71b08b1, &424b5158, &4701ac9e) (&3cdc4dae; &b70e6981, &3f7fe84b, &b9cb9997)",
"(&c7bd3f6e, &421f3964, &463d6846) (&3f1edb02; &b7e216a4, &bf48c03c, &b8125a63)",
"(&c790842c, &4264fffe, &4694e13f) (&3d8b66d4; &3939d771, &3f7f6800, &b97ff26e)",
"(&c716421f, &424e0981, &470a0757) (&3f67611a; &b8d62409, &3edb15e5, &3814ceca)",
"(&c7c77ae4, &429300b3, &c62c24e9) (&3f0cba40; &371ebe11, &bf55d990, &b62f453a)",
"(&c774509c, &41a69323, &46dd9450) (&3f42790d; &b9048b14, &bf267b6e, &b8dd82b6)",
"(&c7005e35, &4282ade7, &46c0d1b3) (&bd04cfff; &3a07ca21, &3f7fdd82, &3a574a96)",
"(&c7ddcfef, &40a816db, &c727cfc3) (&3f54d41e; &b89ce261, &bf0e4470, &b79d2d49)",
"(&c7a791f2, &4161236b, &46a6b4fb) (&3f2c6408; &b84850ec, &bf3d4143, &b85e0a66)",
"(&c7b3630b, &4085cd0e, &46b9517d) (&3f3ecf10; &b8c7eac4, &3f2aab52, &b93092e4)",
"(&c7933e5a, &42910ecb, &465b7c6b) (&3e44d6ec; &b9c9fdbf, &3f7b39cb, &b897643f)",
"(&c7c25987, &40a00ae1, &c78060a3) (&3f2499ec; &b6bae1c1, &3f441141, &36c32523)",
"(&c7536903, &42a0f85d, &460de4be) (&bd2b4a81; &baaf120d, &3f7fc652, &bb4311ed)",
"(&c78f7a4d, &42d888a9, &46234b78) (&bef26de9; &b8364414, &3f617be3, &b899a9d4)",
"(&c76395c4, &42cec8e5, &466ba94e) (&3f349243; &b9445c6e, &bf35775a, &b75b63b0)",
"(&c78f7a4d, &42d888a9, &46234b78) (&bef26de9; &b8364414, &3f617be3, &b899a9d4)",
"(&c702ddf2, &4256d996, &47032a55) (&3f7fdfa2; &38233d7d, &3d00b676, &b83c552d)",
"(&c77dd79f, &429df75b, &468b60b6) (&3db86b67; &3b902838, &3f7ef29a, &bc0f3bb6)",
"(&c77a3e1d, &42ab62d8, &45e7b6e6) (&3f16e708; &b83fd1f9, &3f4ecbb0, &3865186d)",
"(&c7a0a675, &424b26fb, &465481c8) (&3f2809f2; &b81d1e5e, &bf41211d, &b83286af)",
"(&c74ba1d3, &4271f729, &47079c7e) (&bd9fc3f7; &baf66fa0, &3f7f3806, &bb08599c)",
"(&c7a520a1, &421de300, &45d2670b) (&be13d446; &39381724, &3f7d517b, &b8b208c6)",
"(&c7cb9450, &40961d0d, &c75c3e07) (&3f7df470; &39d9ca17, &3e012d36, &3a049a38)",
"(&c7cb29cd, &412eeede, &4684e731) (&3f32f488; &3b8287e4, &bf370e71, &3b15d5b5)",
"(&c7d8f5f3, &3fde2be0, &c73f23a3) (&3f588a39; &b6ba2b59, &3f088d52, &37210026)",
"(&c78d0637, &4246abed, &470f8604) (&be98cc86; &b7d88f53, &3f745583, &b8e00ff5)",
"(&c7d58eb1, &4028854d, &c5db0cb2) (&3e253d8e; &b71be5e0, &3f7ca51c, &389b11cc)",
"(&c7872e71, &428484f0, &45af27f3) (&3f5dd266; &b7888bc7, &beff9607, &37f269f1)",
"(&c7952471, &41860b67, &46b5ab1a) (&3f7f4a25; &396db36b, &bd987684, &b981ce3c)",
"(&c7a9dd28, &41eaa005, &4618eb70) (&3f6c1227; &392fb88e, &bec60e44, &b9c9ea2c)",
"(&c7142cc9, &42c8010d, &461dc9af) (&3f0bdc60; &390faa46, &bf566aed, &397a7c2d)",
"(&c71ae12b, &425ac3d5, &46e14931) (&3f19eeda; &3a5e2766, &3f4c8c6c, &bb319c6a)",
"(&c7d03dd5, &41145dfd, &c740e48b) (&3ebba60f; &bb3f9392, &3f6e2f69, &3afd71f9)",
"(-98888, &41a1bbb5, &46bee363) (&3f24bf62; &39031656, &bf43f1c8, &b8e2cc14)",
"(&c774509c, &41a69323, &46dd9450) (&3f42790d; &b9048b14, &bf267b6e, &b8dd82b6)",
"(&c72ec1df, &42b45d17, &467c1d92) (&3f73a9d8; &3b7de1d0, &3e9d0044, &bb66262b)",
"(&c77f27a6, &42c0d6b2, &46a67fbc) (&bc4dee5f; &3593ad88, &3f7ffad3, &3851a123)",
"(&c785d878, &428e00af, &470eaf5c) (&3da24948; &b6a7ff82, &3f7f31eb, &3852e5d6)",
"(&c7467ed2, &428c31f4, &46c12a68) (&3f34c667; &3b0966fd, &bf35430f, &baec089a)",
"(&c78b14bd, &4218055e, &46fa606f) (&3d6058eb; &b7c5f88b, &3f7f9d9f, &37d69a7a)",
"(&c7087bfa, &42700165, &469ed944) (&3f3a68d7; &399677a5, &3f2f76af, &b985c5d1)",
"(&c7ad3aae, &409a8cf0, &46cd9dce) (&3e04a732; &b8e1693b, &3f7dd7c5, &b8f85358)",};





        string[] truck_locationETS = new string[] { "",
                                                 "(&c6232e09, &40597874, &c75ac393)",
                                                 "(&4622d106, &420507b7, &c61cf6d7)",
                                                 "(&c7385fee, &422e3782, &46d04b07)",
                                                 "(&46ba8db0, &3fea2993, &4783746f)",
                                                 "(&45e14a68, &40f41138, &c6d84592)",
                                                 "(&c5dee006, &3d1343c4, &47582d67)",
                                                 "(&4610e85e, &41a27382, &478fb774)",
                                                 "(&c6f985d2, &422a0ba9, &45986fef)",
                                                 "(&476efbcc, &41082f00, &c75d3bf0)",
                                                 "(&c6285bbb, &40a128b9, &475867df)",
                                                 "(&47234cb0, &40423cfe, &c772bcd9)",
                                                 "(&46bb437a, &4180daaa, &c749cbb1)",
                                                 "(&46bb1fb6, &4184a6dc, &c7495bd5)",
                                                 "(&4691fe56, &40c6913a, &478a70ec)",
                                                 "(&47592e70, &412ee3c8, &c76f8946)"};

        string[] trailer_locationATS = new string[] { "",
"(&c7376082, &428a2d2f, &46f2ce6d) (&3ecb18d3; &b705a2af, &3f6aff67, &37be773c)",
"(&c745002a, &4287d528, &4698e4f0) (&3f7ed87b; &b829221a, &3dc24575, &b6005c91)",
"(&c71b0848, &424b41df, &4701a49e) (&3ccc70f8; &392dae47, &3f7feb96, &397fb329)",
"(&c7bd4353, &421f2a52, &463d60ea) (&3f1edb92; &b7dcd5cb, &bf48bfca, &b793634b)",
"(&c79083a1, &4264f04e, &4694d162) (&3d8b1cf0; &b8dce113, &3f7f68a2, &39115ceb)",
"(&c7163bdb, &424dfaa3, &470a0c51) (&3f661ddf; &b781416e, &3ee05780, &b6013bba)",
"(&c7c760c7, &4292f91e, &c62c7d66) (&3f5db3fd; &b82bfb79, &3effff7d, &37b11f8f)",
"(&c7745882, &41a6757a, &46dd96e8) (&3f43794f; &381873c0, &bf254e42, &b787b360)",
"(&c7005eb6, &4282aec8, &46c0c1b8) (&bcfdc2a9; &39e74fc8, &3f7fe080, &3a98f8af)",
"(&c7ddd37f, &40a77322, &c727cc22) (&3f5cd572; &ba16bea0, &bf017e31, &b9acb11c)",
"(&c7a795ee, &4160e808, &46a6b37d) (&3f2c6424; &b7e6ea7a, &bf3d412a, &b7cf5234)",
"(&c7b35f10, &40855302, &46b95333) (&3f3e4651; &383192f9, &3f2b43b9, &3911d76c)",
"(&c7933c2c, &42910379, &465b7138) (&3f2b5c29; &b96eabd0, &3f3e3050, &3939939)",
"(&c7c25596, &409f98e3, &c7806154) (&3f2499d9; &37874b11, &3f441151, &b74b0f64)",
"(&c7536a6f, &42a0794c, &460dc578) (&bde63658; &3b2e498d, &3f7e5237, &bca9eb55)",
"(&c78f7dad, &42d8810f, &46233a41) (&bef8050b; &37ce73c3, &3f5ff576, &38c32574)",
"(&c7639dc5, &42cec15a, &466ba909) (&3f342014; &393318a8, &bf35e8b2, &b90cb56f)",
"(&c78f7dad, &42d8810f, &46233a41) (&bef8050b; &37ce73c3, &3f5ff576, &38c32574)",
"(&c702ddae, &4256ca50, &47033255) (&3f7ffd32; &b8812067, &3c1799da, &b89a1e79)",
"(&c77dd621, &429deb65, &468b50ef) (&3dc26189; &3b2f784b, &3f7ed762, &3b82f363)",
"(&c77a367e, &42ab5b69, &45e7a349) (&3f16b425; &36b6af4f, &3f4ef0c9, &384b9079)",
"(&c7a0aa6b, &424b17ec, &46547d5b) (&3f280a04; &b7850546, &bf41210d, &b7957007)",
"(&c74ba315, &42710d9f, &470794a1) (&bda3245f; &baefb220, &3f7f241e, &bc994539)",
"(&c7a521fb, &421dd226, &45d22ad0) (&be3d04a5; &ba4f150d, &3f7b99cf, &38a8b4f3)",
"(&c7cb918e, &409566f2, &c75c392f) (&3f582f54; &3916e97e, &3f091ce7, &3ac7ca66)",
"(&c7cb2dc9, &412acc20, &4684e6cb) (&3f328c91; &3c66006c, &bf376181, &3c75e5f4)",
"(&c7d8f257, &3fdc6456, &c73f2030) (&3f588a2a; &37a3d8c7, &3f088d6a, &b6b3caf4)",
"(&c78d087e, &42469c45, &470f7f70) (&be98ca7a; &37d40160, &3f7455d5, &387f1ee5)",
"(&c7d58d6e, &402792ed, &c5db4973) (&3e22fd3d; &b5cd5254, &3f7cbc81, &3651fb66)",
"(&c78731e9, &42847d60, &45af47cf) (&3f5d5fe4; &b7af1a75, &bf0090fb, &b890e36b)",
"(&c7952507, &4185ef2f, &46b5baf1) (&3f7f4fb8; &b988ee8b, &bd961c9f, &b87cefb3)",
"(&c7a9e001, &41ea7ff5, &461901ee) (&3f6c412f; &392a1e16, &bec52d73, &b9b095bd)",
"(&c714341c, &42c7f98b, &461dbcbb) (&3f0ba1c2; &398d2869, &bf56911c, &b9df79af)",
"(&c71ad981, &4259d7a9, &46e144d3) (&3f1a9604; &3c7de2b7, &3f4bfed9, &bc42d458)",
"(&c7d03a8e, &4114df36, &c740e8f4) (&3f04bd97; &bb165bbd, &3f5ae551, &3afa2611)",
"(&c7c127f1, &41a19d2f, &46bee091) (&3f2412d6; &b9360d67, &bf44825a, &38c897c8)",
"(&c7745882, &41a6757a, &46dd96e8) (&3f43794f; &381873c0, &bf254e42, &b787b360)",
"(&c72ebd39, &42b3d546, &467c3772) (&3f73ab26; &3ca538b9, &3e9c9f30, &bbc57e0a)",
"(&c77f27d9, &42c0cf29, &46a66fbb) (&bc4de1d4; &b637ff19, &3f7ffad3, &37e549e5)",
"(&c785d7d7, &428df927, &470ea775) (&3da243f0; &36ccd7b5, &3f7f31f9, &37f264dc)",
"(&c74686d4, &428c2a66, &46c12a62) (&3f34eea6; &3ad280e6, &bf351af5, &baf58c2d)",
"(&c78b144f, &4217f71b, &46fa5084) (&3d5af9bd; &38349785, &3f7fa248, &3901569c)",
"(&c70873fc, &426ff1d4, &469eda3d) (&3f3a6e80; &b9576af0, &3f2f70ad, &38f530a1)",
"(&c7ad39ab, &409a10e4, &46cd8e50) (&3e00df8d; &3842a2e6, &3f7df6eb, &38aef1a1)",};

        string[] trailer_locationETS = new string[] { "",
                                                 "(&3ee7faed; &3b4cfd88, &3f64359e, &bbb9ee61)",
                                                 "(&3f1d6755; &3b874ecf, &3f49e273, &bba1f62c)",
                                                 "(&3f7d0298; &3bd2facc, &3e1be73f, &ba4a53d3)",
                                                 "(&3ea9b214; &b898e29d, &3f7187bc, &395b69fb)",
                                                 "(1; &b97153c4, &333ee94a, &344414e9)",
                                                 "(&3f7fc96a; &ba2fe5ba, &3d271d49, &b99bb776)",
                                                 "(&3f55767b; &b993e78b, &bf0d5059, &b9fd058)",
                                                 "(&3f68d6aa; &3bc337ce, &3ed4c944, &bb22be5b)",
                                                 "(&3f7f6966; &3bd1afa2, &bd8a2266, &3a2a8015)",
                                                 "(&3f158927; &38ec87d4, &bf4fc93d, &38bff239)",
                                                 "(&3ead5a79; &b8a17294, &3f70e144, &39624c63)",
                                                 "(&3f7f5585; &b8c61a6b, &bd939fee, &b6e1cc50)",
                                                 "(&bd130bdc; &b7864431, &3f7fd45e, &bbd53031)",
                                                 "(&3f686f51; &3ba266eb, &bed68d51, &3b0b193c)",
                                                 "(&3f7f7855; &3ac578b6, &bd83ac23, &39814f76)"};

bool isinsavefolder = false;
string savefolder = "";
		
		
		void Button3Click(object sender, EventArgs e)
		{
	System.Windows.Forms.Application.Exit();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			if (File.Exists(Environment.CurrentDirectory + "//" +"game.sii"))
			{
			 textBox4.AppendText("Gotowe" + Environment.NewLine);
			 isinsavefolder = true;
			}
			else
			{
				textBox4.AppendText("Brak pliku: game.sii" + Environment.NewLine);
				isinsavefolder = false;
				button1.Enabled = false;
				button2.Enabled = false;
				//button5.Enabled = true;
		}
		}
	
		
/*--------------- WCZYTYWANIE SAVE'A ---------------*/
		void Button1Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			textBox7.Text = "";
			textBox8.Text = "";
			textBox9.Text = "";
			textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            checkBox6.Enabled = true;
;			textBox4.AppendText("Rozkodowywanie pliku game.sii" + Environment.NewLine);
			
/* ------------ EXTRACT ------------- */
{
			try
            {
			extractResource("decrypt", Environment.CurrentDirectory + "\\" + "decrypt.exe");
            }
            catch (Exception ex)
            {
                textBox4.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }
/* ------------ EXTRACT ------------- */
if (isinsavefolder == true)
{
           try
            {
           	System.Diagnostics.Process clientProcess = new Process();
			clientProcess.StartInfo.FileName = @"decrypt.exe";
			clientProcess.StartInfo.Arguments = "game.sii";
			clientProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			clientProcess.Start();
			clientProcess.WaitForExit();
			File.Delete("decrypt.exe");			
                
            }
           catch (Exception ex)
            {
                textBox4.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }
}

else if (isinsavefolder == false)
		{
           try
            {
           	System.Diagnostics.Process clientProcess = new Process();
			clientProcess.StartInfo.FileName = @"decrypt.exe";
			clientProcess.StartInfo.Arguments = "\"" + savefolder + "\"";
			clientProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			clientProcess.Start();
			clientProcess.WaitForExit();
			File.Delete("decrypt.exe");			
                
            }
            catch (Exception ex)
            {
                textBox4.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }
		}
        	
			textBox4.AppendText("Wczytywanie pliku game.sii" + Environment.NewLine);
			if (isinsavefolder == false)
			{
				string save_file = File.ReadAllText(savefolder); /* wczytywanie pliku */
				textBox5.Text = save_file;
			}
			else if (isinsavefolder == true)
			{
				string save_file = File.ReadAllText(Environment.CurrentDirectory + "\\" +"game.sii");
				textBox5.Text = save_file;
			}


                Regex regex_planned_distance = new Regex(@"player_job : ([\s\S]*) planned_distance_km: ([0-9]){1,16}");
                Regex regex_job_distance = new Regex(@"job_distance: ([0-9]){1,9}");
                Regex regex_time_limit = new Regex(@"time_upper_limit: ([0-9]){1,9}");
                Regex regex_filter = new Regex(@"([0-9]){1,16}");
                Regex regex_pd_filter = new Regex(@"planned_distance_km: ([0-9]){1,16}");
                Regex regex_money = new Regex(@"money_account: ([0-9]){1,16}");
                Regex regex_experience = new Regex(@"total_distance: (.*)\n experience_points: ([0-9]){1,16}");
                Regex regex_body_mass = new Regex(@"body_mass: ([0-9]){1,9}");
                Regex regex_chassis_mass = new Regex(@"chassis_mass: ([0-9]){1,9}");
                Regex regex_truck_placement = new Regex(@"truck_placement:\s(.*)");
                Regex regex_trailer_placement = new Regex(@"trailer_placement:\s(.*)");
                Regex regex_truck_placement_filter = new Regex(@"\((.*)");

                /*--------------- PRZEJECHANY DYSTANS --------------------*/

                string tmp="";

foreach (Match match in regex_job_distance.Matches(textBox5.Text))
		{
			 tmp = (match.Value.ToString());
		}
foreach (Match match in regex_filter.Matches(tmp))
		{
			 tmp = (match.Value.ToString());
			textBox4.AppendText("Przejechany dystans w aktualnym zleceniu: " + tmp + " km" + Environment.NewLine);
		}
                tmp = ""; //TRUCk PLACEMENT
 foreach (Match match in regex_truck_placement.Matches(textBox5.Text))
         {
                tmp = (match.Value.ToString());
         }
foreach (Match match in regex_truck_placement_filter.Matches(tmp))
         {
                tmp = (match.Value.ToString());
                textBox11.AppendText(tmp);
         }
                tmp = "";  //TRAILER PLACEMENT
foreach (Match match in regex_trailer_placement.Matches(textBox5.Text))
                {
                    tmp = (match.Value.ToString());
                }
foreach (Match match in regex_truck_placement_filter.Matches(tmp))
                {
                    tmp = (match.Value.ToString());
                    textBox12.AppendText(tmp);
                }


                /*--------------- KONIEC PRZEJECHANY DYSTANS -------------*/


                /*--------------- TIME LIMIT ---------------*/
                foreach (Match match in regex_time_limit.Matches(textBox5.Text))
		{
    		textBox6.AppendText(match.Value.ToString() + Environment.NewLine);
		}
			foreach (Match match in regex_filter.Matches(textBox6.Text))
		{
			textBox6.Text = "";
    		textBox6.AppendText(match.Value.ToString());
		}
/*--------------- KONIEC TIME LIMIT ---------------*/

/*--------------- KASA NA KONCIE W GRZE ---------------*/

			foreach (Match match in regex_money.Matches(textBox5.Text))
		{
    		textBox7.AppendText(match.Value.ToString() + Environment.NewLine);
		}
			foreach (Match match in regex_filter.Matches(textBox7.Text))
		{
			textBox7.Text = "";
    		textBox7.AppendText(match.Value.ToString());
		}
			
/*--------------- KONIEC KASA NA KONCIE W GRZE ---------------*/

/*--------------- PUNKTY DOŚWIADCZENIA ----------------------- */
			foreach (Match match in regex_experience.Matches(textBox5.Text))
		{
    		textBox8.AppendText(match.Value.ToString() + Environment.NewLine);
		}
			foreach (Match match in regex_filter.Matches(textBox8.Text))
		{
			textBox8.Text = "";
    		textBox8.AppendText(match.Value.ToString());
		}


				textBox4.AppendText("Wczytano pomyślnie" + Environment.NewLine);
}
		}
		
/*--------------- KONIEC WCZYTYWANIE SAVE'A ---------------*/



		void Button2Click(object sender, EventArgs e)
		{
			
				textBox4.AppendText("Zapisywanie do pliku: game.sii" + Environment.NewLine);
				

				/* replace planned distance */
				if (textBox1.Text != "")
				{
				textBox5.Text = Regex.Replace(textBox5.Text, @"planned_distance_km: ([0-9]){1,9}", "planned_distance_km: " + textBox1.Text);
				}
				else
				{
					textBox4.AppendText("Pomijanie podmiany planowanego dystansu" + Environment.NewLine);
				}
                /* truck and cargo placement */
                if (textBox11.Text != "")
                {
                textBox5.Text = Regex.Replace(textBox5.Text, @"truck_placement:\s(.*)", "truck_placement: " + textBox11.Text);
               
                }
                else
                {
                textBox4.AppendText("Pomijanie lokowania ciągnika" + Environment.NewLine);
                }

                if (textBox12.Text != "" && textBox12.Enabled == true)
                {
                    textBox5.Text = Regex.Replace(textBox5.Text, @"trailer_placement:\s(.*)", "trailer_placement: " + textBox12.Text);
                }
                else
                {
                    textBox4.AppendText("Pomijanie lokowania naczepy" + Environment.NewLine);
                }

                /* replace cargo mass */
                if (textBox2.Text != "")
				{
				textBox5.Text = Regex.Replace(textBox5.Text, @"cargo_mass: ([0-9]){1,9}", "cargo_mass: " + textBox2.Text);
				textBox5.Text = Regex.Replace(textBox5.Text, @"cargo_mass: &([a-z0-9]){1,9}", "cargo_mass: " + textBox2.Text);
				}
				else
				{
					textBox4.AppendText("Pomijanie podmiany masy ładunku" + Environment.NewLine);
				}
				
				/* replace license plates */
				if (textBox3.Text != "")
				{
				textBox5.Text = Regex.Replace(textBox5.Text, @"license_plate: ([\s\S]{1,150}[|])", "license_plate: " + "\""+ textBox3.Text + "|");
				}
				else
				{
					textBox4.AppendText("Pomijanie podmiany tablic rejestracyjnych" + Environment.NewLine);
				}
				
				/* repair trucks and load */
				if (checkBox1.Checked == true)
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @"wear: &([a-z0-9]){1,9}", "wear: 0");
					textBox5.Text = Regex.Replace(textBox5.Text, @"wear: 1", "wear: 0");
					textBox5.Text = Regex.Replace(textBox5.Text, @"cargo_damage: &([a-z0-9]){1,9}", "cargo_damage: 0");
					textBox5.Text = Regex.Replace(textBox5.Text, @"cargo_damage: 1", "cargo_damage: 0");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie naprawy uszkodzeń" + Environment.NewLine);
				}
				
				/* refuel tank */
				if (checkBox2.Checked == true)
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @"fuel_relative: &([a-z0-9]){1,9}", "fuel_relative: 1");
					textBox5.Text = Regex.Replace(textBox5.Text, @"fuel_relative: 0", "fuel_relative: 1");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie tankowania zbiornika" + Environment.NewLine);
				}
				
				/* repaint trailers to red */
				if (checkBox5.Checked == true)
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @" base_color: (.*)\n wear: (.*)\n data_path: " + "\"" + "/def/vehicle/trailer/(.*)" + "\"", " base_color: (0.4709727028066129, 0, 0)\n wear: 0\n data_path: " + "\"" + "/def/vehicle/trailer/krone/profiliner/company_paint_job/default.sii" + "\"");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie malowania naczep" + Environment.NewLine);
				}
				
				/* replace ETS2 transmission form volvo fh16 */
				if ((checkBox4.Checked == true) && (radioButton3.Checked == true))
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @"data_path: " + "\"" + "/def/vehicle/truck/([_.a-z0-9]{1,32})/transmission/\\S{1,32}" + "\"", "data_path: " + "\"" + "/def/vehicle/truck/volvo.fh16/transmission/12_speed_ret_over.sii" + "\"");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie tuningu skrzyni biegów ETS2" + Environment.NewLine);
				}					
				
				/* replace ATS transmission form kenworth w900 */
				if ((checkBox4.Checked == true) && (radioButton4.Checked == true))
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @"data_path: " + "\"" + "/def/vehicle/truck/([_.a-z0-9]{1,32})/transmission/\\S{1,32}" + "\"", "data_path: " + "\"" + "/def/vehicle/truck/kenworth.w900/transmission/18_speed_retarder.sii" + "\"");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie tuningu skrzyni biegów ATS" + Environment.NewLine);
				}					
				
				/* replace ETS2 engine to 750KM form volvo fh16 */
				if ((checkBox3.Checked == true) && (radioButton1.Checked == true))
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @"data_path: " + "\"" + "/def/vehicle/truck/([_.a-z0-9]{1,32})/engine/\\S{1,32}" + "\"", "data_path: " + "\"" + "/def/vehicle/truck/volvo.fh16/engine/d16g750.sii" + "\"");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie tuningu silników ETS2" + Environment.NewLine);
				}
				
				/* replace ATS engine to 625KM from kenworth w900 */
				if ((checkBox3.Checked == true) && (radioButton2.Checked == true))
				{
					textBox5.Text = Regex.Replace(textBox5.Text, @"data_path: " + "\"" + "/def/vehicle/truck/([_.a-z0-9]{1,32})/engine/\\S{1,32}" + "\"", "data_path: " + "\"" + "/def/vehicle/truck/kenworth.w900/engine/catc15.sii" + "\"");
				} 
				else 
				{
					textBox4.AppendText("Pomijanie tuningu silników ATS" + Environment.NewLine);
				}
				
				/* change experience points */
				if (textBox8.Text != "")
				{ 			//textBox5.Text = Regex.Replace(textBox5.Text, @" base_color: (.*)\n wear: (.*)\n data_path: " + "\"" + "/def/vehicle/trailer/(.*)" + "\"", " base_color: (0.4709727028066129, 0, 0)\n wear: 0\n data_path: " + "\"" + "/def/vehicle/trailer/krone/profiliner/company_paint_job/default.sii" + "\"");
				textBox5.Text = Regex.Replace(textBox5.Text, @"experience_points: ([0-9]){1,16}", "experience_points: " + textBox8.Text);
				}
				else
				{
					textBox4.AppendText("Pomijanie podmiany punktów doświadczenia" + Environment.NewLine);
				}
				
				/* change body mass */
				if (textBox9.Text != "")
				{ 			
				textBox5.Text = Regex.Replace(textBox5.Text, @"body_mass: ([0-9]){1,16}", "body_mass: " + textBox9.Text);
				}
				else
				{
					textBox4.AppendText("Pomijanie podmiany masy ładunku" + Environment.NewLine);
				}
				
				/* change chassis mass */
				if (textBox10.Text != "")
				{		
				textBox5.Text = Regex.Replace(textBox5.Text, @"chassis_mass: ([0-9]){1,16}", "chassis_mass: " + textBox10.Text);
				}
				else
				{
					textBox4.AppendText("Pomijanie podmiany masy podwozia" + Environment.NewLine);
				}
				
				/* TO TRZEBA NAPRAWIĆ ALBO COŚ */
					textBox5.Text = Regex.Replace(textBox5.Text, @"time_upper_limit: ([0-9]){1,9}", "time_upper_limit: " + textBox6.Text);
					textBox5.Text = Regex.Replace(textBox5.Text, @"money_account: ([0-9]){1,16}", "money_account: " + textBox7.Text);
	
				
/* ------- ZAPIS DO PLIKU */
				
if (isinsavefolder == true)
{
				File.WriteAllText(Environment.CurrentDirectory + "\\" + "game.sii", textBox5.Text);
				textBox4.AppendText("Zapisano do pliku" + Environment.NewLine);
}
else if (isinsavefolder == false)
{
				File.WriteAllText(savefolder, textBox5.Text);	
				textBox4.AppendText("Zapisano do pliku game.sii" + Environment.NewLine);
}
				
/* ------- KONIEC ZAPIS DO PLIKU */				
				
				
				
			}

		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
	
		}
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
				if (checkBox3.Checked == true)
				{
					radioButton1.Enabled = true;
					radioButton2.Enabled = true;
				} 
				else 
				{
					radioButton1.Enabled = false;
					radioButton1.Checked = false;
					radioButton2.Enabled = false;
					radioButton2.Checked = false;
				}
		}
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
	
		}
		void CheckBox4CheckedChanged(object sender, EventArgs e)
		{
					if (checkBox4.Checked == true)
				{
					radioButton3.Enabled = true;
					radioButton4.Enabled = true;
				} 
				else 
				{
					radioButton3.Enabled = false;
					radioButton3.Checked = false;
					radioButton4.Enabled = false;
					radioButton4.Checked = false;
				}
		}
		void CheckBox5CheckedChanged(object sender, EventArgs e)
		{
	
		}
		
/* ----------- OPEN FILE DIALOG -----------------------*/

		void Button5Click(object sender, EventArgs e)
		{
            Stream myStream = null;
    OpenFileDialog openFileDialog1 = new OpenFileDialog();

    //openFileDialog1.InitialDirectory = Environment.CurrentDirectory ;
    openFileDialog1.Filter = "ETS2/ATS Save Games|game.sii" ;
    openFileDialog1.FilterIndex = 1 ;
    openFileDialog1.RestoreDirectory = true ;

    if(openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        try
        {
            if ((myStream = openFileDialog1.OpenFile()) != null)
            {
                using (myStream)
                {
                	savefolder = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                	textBox4.Text = "";
                	textBox4.AppendText(savefolder + Environment.NewLine);
                	button1.Enabled = true;
                	button2.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Błąd: Nie można odczytać pliku: " + ex.Message);
        }
    }
            button1.PerformClick();
/* ----------- OPEN FILE DIALOG -----------------------*/		
		}

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox12.Text = "";
            if (radioButton5.Checked == true)
            {
                textBox11.AppendText(truck_locationETS[comboBox1.SelectedIndex]);
                textBox12.AppendText(trailer_locationETS[comboBox1.SelectedIndex]);
            }
            else if (radioButton6.Checked == true)
            {
                textBox11.AppendText(truck_locationATS[comboBox1.SelectedIndex]);
                textBox12.AppendText(trailer_locationATS[comboBox1.SelectedIndex]);
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox7.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                textBox11.Enabled = true;
                //textBox12.Enabled = true;
                comboBox1.Enabled = true;
            }
            else
            { checkBox7.Enabled = false;
              radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                comboBox1.Enabled = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                checkBox7.Checked = false;
                textBox11.Text = "";
                textBox12.Text = "";
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < locationsETS.Length; i++)
                {
                    comboBox1.Items.Add(locationsETS[i]);
                }
            }
            else {
                radioButton5.Checked = false;
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < locationsATS.Length; i++)
                {
                    comboBox1.Items.Add(locationsATS[i]);
                }
            }
            else { radioButton6.Checked = false; }
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                textBox12.Enabled = true;
            }
            else { textBox12.Enabled = false; }
        }
    } }
