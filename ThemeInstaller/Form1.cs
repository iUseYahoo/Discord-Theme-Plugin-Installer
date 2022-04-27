namespace ThemeInstaller
{
    public partial class Form1 : Form
    {


        public void addlog(String message)
        {
            var logbox = monoFlat_TextBox1;

            logbox.Text += message + Environment.NewLine;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            monoFlat_TextBox1.Text = "";
            addlog("Log was cleared.");
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            if (monoFlat_CheckBox1.Checked == false)
            {
                addlog("[-] No discord version was selected.");
            }

            if (monoFlat_TextBox2.Text.Length > 1)
            {
                var username = System.Environment.UserName.ToString();
                var themefilename = monoFlat_TextBox2.Text;
                var discordpath = "C:\\Users\\" + username + "\\AppData\\Roaming\\BetterDiscord\\themes\\";

                string sourceFile = System.IO.Path.Combine(themefilename);

                // trying to remove all words except for the <filename>.css part.
                var rawname = Path.GetFileName(themefilename);
                // destfile which takes the discord path and the rawname which has stripped the dir path except for the filename.css
                string destFile = System.IO.Path.Combine(discordpath, rawname);

                System.IO.Directory.CreateDirectory(discordpath);
                //copy file (filename.css) to the discord theme folder
                System.IO.File.Copy(sourceFile, destFile, true);
                
                addlog("[+] Installed Theme: '" + rawname + "'.");
            }
            else
            {
                addlog("[-] No theme was located.");
            }
        }

        private void monoFlat_CheckBox1_CheckedChanged(object sender)
        {

        }

        private void monoFlat_Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Css Files (*.css)|*.css|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                addlog("[+] Picked theme: " + ofd.FileName.ToString() + ".");
                monoFlat_TextBox2.Text = ofd.FileName.ToString();
            }
            else
            {
                addlog("[-] Aborted theme picker.");
            }
        }
    }
}
