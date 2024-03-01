using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace NoteTaking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //بستن کامل برنامه
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //پاک کردن تمامی متون داخل ریچ تکست باکس و نوشتن از نو
            DialogResult result = MessageBox.Show("آیا مطمعن هستید تمامی متون پاک شوند و از اول شروع به کار کنید؟", "نوشتن از نو", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                rtxmain.Clear();
            }//اگر روی دکمه خیر بزنه هیچ عملی انجام نمیشه
            else { }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //باز کردن فایل با فرمت .txt در برنامه

            //باز کردن دیالوگ باز کردن فایل و تعین فیلتر های پسوندی
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "txt";
            openFile.Filter = "Text Files (*.txt) | *txt";
            if(openFile.ShowDialog() == DialogResult.OK) //شرط بر این است که اگر دکمه اوکی بزنه فایل در برنامه اجرا میشود
            {
                rtxmain.Text = File.ReadAllText(openFile.FileName);
                this.Text = openFile.FileName;
            }//در غیر این صورت هیچ اتفاقی نمیوفتد
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rtxmain.Text != String.Empty)// شرط بر این است که ریچ تکست باکسمون خالی نباشه
            {
                string dir = @"c:\\logs\\" + DateTime.Today.ToString("dd_MMM_yy"); //ساخت فولدر برای ذخیره اتوماتیک برنامه
                string path = @"c:\\logs\\" + DateTime.Today.ToString("dd_MMM_yy") + "\\" + DateTime.Now.ToString("HH.mm.ss") + ".txt"; //ساخت فایل مورد نظر با پسوند دات تکست به مشخصه تایم دقیق
                if (!Directory.Exists(dir)){ //اگر فولدر مورد نظر وجود نداشته باشد میسازیمش
                    Directory.CreateDirectory(dir);
                }//در غیر این صورت فقط کافیه متن داخل ریچ تکست باکس رو در قالب فایل تکست ذخیره کنیم
                if (!File.Exists(path))
                {
                    using (File.Create(path)) ;
                    rtxmain.SaveFile(path, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //تعیین رنگ نوشتاری
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();
            rtxmain.ForeColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //تعین قلم نوشتاری مورد نظر (فونت) برای برنامه
            FontDialog fontdialog1 =  new FontDialog();
            fontdialog1.ShowDialog();
            rtxmain.Font = fontdialog1.Font;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //سیو کردن به صورت دستی : انتخاب نام مشخص برای فایل و محل ذخیره آن
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxmain.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ارتباط با بنده
            System.Diagnostics.Process.Start("https://t.me/Psycho8247");
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ارتباط با بنده
            System.Diagnostics.Process.Start("https://www.instagram.com/mahdi_psycho?igsh=YXA4NzkyMmJ6Yjl6");
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //نوشتن تاریخ امروز در خط بعدی
            rtxmain.Text += System.Environment.NewLine + DateTime.Now.ToString("dd,MM,yyyy");
        }
    }
}
