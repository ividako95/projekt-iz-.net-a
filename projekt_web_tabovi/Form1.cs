using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_web_tabovi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/");
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;

            if (web != null) {

                web.Navigate(textBox1.Text);
            }

        }

        WebBrowser webTab = null;

        private void Button4_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New tab";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://www.google.com/");
            textBox1.Text = "https://www.google.com/";
            webTab.DocumentCompleted += WebTab_DocumentCompleted;
        }

        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = webTab.DocumentTitle;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null) {
                if (web.CanGoBack) { web.GoBack(); }

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward) { web.GoForward(); }

            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                WebBrowser web = tabControl1.SelectedTab.Controls[0] as WebBrowser;
                if (web != null)
                {

                    web.Navigate(textBox1.Text);
                }
            }
        }


        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {

                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projekt iz .neta");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri("https://www.google.com/"));
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPropertiesDialog();
        }
    }
}
