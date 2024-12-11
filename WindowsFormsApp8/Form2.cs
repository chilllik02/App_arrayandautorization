using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml.Schema;
using Newtonsoft.Json;
using System.Collections.Specialized;


namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public static int[] spisok = new int[10];
       
        public Form2()
        {
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // метод открытия третьего окна для ввода значений в массив.
        {
            Form3 fr3 = new Form3();
            fr3.b1 = this.button2;

            fr3.Show();
        }

        public void add(int a, int b) // метод добавления индекс это переменная a, значение это переменная b.
        {
            
           spisok[a] = b;
            
        }

        public void update() // метод обновления листбокса,если добавилось новое значение.
        {
            listBox1.Items.Clear();
            for (int i = 0; i < spisok.Count(); i++)
            {
                listBox1.Items.Add(spisok[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e) // при нажатии по кнопке происходит сортировка массива по методо sortlist, а после по методу update происходит обновление листбокса.
        {
            sortlist(spisok);
            update();
        }

        public void sortlist(int[] value) //метод сортировки массива.
        {
            int temp = 0;
            for (int i = 0; i < value.Count(); i++)
            {
                for (int j = i + 1; j < value.Count(); j++)
                {
                    if (value[i] > value[j])
                    {
                        temp = value[i];
                        value[i] = value[j];
                        value[j] = temp;
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)// по кнопке происходит обновление листбокса.
        {
            update();
        }

        public void save() //сохранения массива в файл txt.
        {

            OpenFileDialog openfileDialog = new OpenFileDialog();
            saveFileDialog1.Filter = "JSON Files (*.json)|*.|All files (*.*)|*.*";
            saveFileDialog1.FileName = "text.json";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string json = JsonConvert.SerializeObject(spisok, Formatting.Indented);
                File.WriteAllText(filePath, json);
                MessageBox.Show($"Файл сохранен в {filePath}");
            }
        }

        public void open()// загрузка в приложение сохраненного массива.
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog1.Filter = "JSON Files (*.json)|*.|All files (*.*)|*.*";
            openFileDialog1.FileName = "text.json";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string loaded = File.ReadAllText(filePath);
                spisok = JsonConvert.DeserializeObject<int[]>(loaded);
            }
        }

        public void testarray(int size_array) // метод который тестирует правильность работы загрузки текстового файла в массив на C# (сравнение ожидаемой длины массива с длиной массива, которая была получена в результате загрузки из текстового файла).
        {
            if(spisok.Length == size_array)
            {
                MessageBox.Show("тест успешно пройден!");

            }
            else
            {
                MessageBox.Show("тест не пройден!");
            }
        }

        

        private void button3_Click(object sender, EventArgs e) // кнопка сохранения массива в файл
        {
            save();
        }

        private void button4_Click(object sender, EventArgs e)// кнопка загрузки массива в программу.
        {
            open();
        }

        private void button6_Click(object sender, EventArgs e)// кнока теста
        {
            testarray(10);
        }
    }
}
