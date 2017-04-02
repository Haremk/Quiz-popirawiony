using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Quizowy
{
    public partial class Form1 : Form
    {
        List<string> wczytanie = new List<string>();
        int nr_p = 1, wynik=0, ile_p;
        public Form1()
        {
            InitializeComponent();
            Wczytanie();
            int s = spwczt();
            if (s == 0)
            {
                textBox1.Text = "nie działa";
            }
            else
            {
            start();
            wcztanie();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = check("a");
            przcisk(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int p = check("b");
            przcisk(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int p = check("c");
            przcisk(p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int p = check("d");
            przcisk(p);
        }
        public void przcisk(int p)
        {
            if (textBox4.Text == "Git")
                wynik++;
            nr_p++;
            if (nr_p-1 != ile_p)
            {
                start();
            }
            else
            {
                reset();
            }
            wcztanie();

        }

        public void Wczytanie()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Quiz.txt");
            while ((line = file.ReadLine()) != null)
            {
                wczytanie.Add(line);
            }
            ile_p = wczytanie.Count / 6;
            file.Close();
        }
        public void start()
        {
           {
                int g = nr_p * 6;
                for (int i = g - 6; i <= g; i++)
                {
                    if ((wczytanie[i] == "a") || (wczytanie[i] == "b") || (wczytanie[i] == "c") || (wczytanie[i] == "d"))
                    {
                        break;
                    }
                    string s = wczytanie[i];
                    switch (s.Remove(1))
                    {
                        case "A":
                            button1.Text = wczytanie[i];
                            break;
                        case "B":
                            button2.Text = wczytanie[i];
                            break;
                        case "C":
                            button3.Text = wczytanie[i];
                            break;
                        case "D":
                            button4.Text = wczytanie[i];
                            break;
                    }
                    s = wczytanie[i];
                    s = s.Remove(1);
                    bool a = false;
                    for (int ip = 0; ip <= 1000; ip++)
                    {
                        if (s == Convert.ToString(ip))
                            a = true;
                    }
                    if (a == true)
                    {
                        textBox1.Text = wczytanie[i];
                    }
                }
            }
        }
        public int check(string odp)
        {
            int g = wczytanie.Count;
            for (int i = (nr_p * 6) - 1; i <= g; i++)
            {
                if ((wczytanie[i] == "a") || (wczytanie[i] == "b") || (wczytanie[i] == "c") || (wczytanie[i] == "d"))
                {
                    if (odp == wczytanie[i])
                    {
                        textBox4.Text = "Git";
                        return 1;
                    }
                    else
                    {
                        textBox4.Text = "NieGit";
                        return 0;
                    }
                }
            }
            return 0;
        }
        public void wcztanie()
        {
            textBox2.Text = nr_p +"/"+ (wczytanie.Count/6);
            textBox3.Text = wynik +" NA "+ (wczytanie.Count/6);
        }
        public int spwczt()
        {
            if (!System.IO.Directory.Exists(@"C:\Quiz.txt"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            wynik = 0;
            nr_p = 1;
            button5.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            textBox3.Text = wynik + "z " + (wczytanie.Count / 6);
            textBox2.Text = "Quest" + nr_p + "/" + (wczytanie.Count / 6);
            start();
        }

        public void reset()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            textBox1.Text = "Twój wynik to"+ wynik;
        }

    }
}
