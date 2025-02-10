using AxWMPLib;

namespace thuchanh3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }
        private void LoadDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    comboBox1.Items.Add(drive.Name);
                }
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Chọn ổ đĩa đầu tiên
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDrive = comboBox1.SelectedItem.ToString();
            LoadFolders(selectedDrive);
        }
        private void LoadFolders(string drive)
        {
            comboBox2.Items.Clear();
            try
            {
                string[] directories = Directory.GetDirectories(drive);
                foreach (string directory in directories)
                {
                    comboBox2.Items.Add(directory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadSongs(string folderPath)
        {
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(folderPath, "*.mp3");
            foreach (string file in files)
            {
                listBox1.Items.Add(file); // Display the full file path
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
               string currentFolderPath = comboBox2.SelectedItem.ToString();
                LoadSongs(currentFolderPath);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedSong = listBox1.SelectedItem.ToString();
                string songPath = selectedSong;
                PlaySong(songPath);
                DisplayLyrics(songPath);
            }
        }
        private void PlaySong(string songPath)
        {
            axWindowsMediaPlayer1.URL= songPath;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        private void DisplayLyrics(string songPath)
        {
            string lyrics = GetLyricsForSong(songPath);
            richTextBox1.Text = lyrics;
        }

        private string GetLyricsForSong(string songPath)
        {
            string lyricsFilePath = Path.ChangeExtension(songPath, ".txt");
            if (File.Exists(lyricsFilePath))
            {
                return File.ReadAllText(lyricsFilePath);
            }
            return "Lời bài hát không có sẵn.";
        }
    }
}
