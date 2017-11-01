using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Logic.FillComboBoxes;
using static Logic.ChangeFeedsAndUrls;
using static Logic.GenereraLista;
using static Logic.Validator;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        public string xml = "";
        private List<string> pods = new List<string>();
        System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
        private Stream ms = new MemoryStream();
        fillBoxes fyll = new fillBoxes();
            public Form1()

        {
            
            if (!File.Exists(@"C:\lista.xml"))
            {
                addPods.serializePods();
            }

            if (!File.Exists(@"C:\uppspeladePods.xml"))
            {
                addPods.serializeuppSpeladePods();
            }

            InitializeComponent();
            addPods.deSerializePods();
            addPods.deSerializeUppspeladePods();
            new fillBoxes();

           

            comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
            comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
            comboBox3.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());

        }

        public Dictionary<String, String> categorys = new Dictionary<String, String>();
        public List<KeyValuePair<String, String>> kategorier = new List<KeyValuePair<String, String>>();

        public List<string> Pods { get => Pods1; set => Pods1 = value; }
        public List<string> Pods1 { get => pods; set => pods = value; }
        public List<string> Pods2 { get => pods; set => pods = value; }
        string xmlen;


    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new GenereradLista();

                if (validera.emptyTextbox(textBox1.Text) &&
                   validera.emptyTextbox(textBox3.Text) &&
                   validera.emptyTextbox(textBox4.Text))
                {
                    var ListItems = GenereradLista.SkapaNyttXml(textBox1.Text);
                    addPods.addList(textBox1.Text, textBox3.Text, int.Parse(textBox4.Text));
                    foreach (string item in ListItems)
                    {
                        Pods.Add(item);
                        listBox1.Text = item;
                    }
                    addPods.serializePods();
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox1.Items.Clear();
                    comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
                    comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
                    comboBox3.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
                    
                }
                else
                {
                    MessageBox.Show("Något av fälten är tomma.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            try
            {
                listBox2.Items.AddRange(GenereradLista.listboxettmetoden(listBox1.SelectedItem.ToString()).ToArray());
                fillBoxes.Methodintervall(fillBoxes.updatePodcasts(listBox1.SelectedItem.ToString()), listBox2, listBox1);
            }
            catch (Exception)
            {
                
            }         
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            
            listBox1.Items.Clear();
            listBox1.Items.AddRange(fillBoxes.fyllListboxMedFeeds(comboBox1.SelectedItem.ToString()).ToArray());

        }

        private void button3_Click(object sender, EventArgs e)
        {
      
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(GenereradLista.knappfyrametoden(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString()));
            }
            catch (Exception)
            {
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                addPods.addList(listBox2.SelectedItem.ToString());
                xmlen = listBox1.SelectedItem.ToString();
                GenereradLista.spelaUppPod(xmlen, listBox2.SelectedItem.ToString());
                addPods.serializeuppSpeladePods();
            }
            catch (Exception)
            {

            }           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                fillBoxes.removeCategory(textBox2.Text);
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
                comboBox3.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());

            }
            catch (Exception)
            {

            }      
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Changer.changeCategory(comboBox3.SelectedItem.ToString(), textBox8.Text);
                comboBox2.Items.Clear();
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
                comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
                comboBox3.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
            }
            catch (Exception)
            {      
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Changer.changeFeedUrl(comboBox2.SelectedItem.ToString(), textBox5.Text, textBox6.Text, textBox7.Text);
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox1.Items.Clear();
                comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
                comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
                comboBox3.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
            }
            catch (Exception)
            {  
            }
            new Changer();   
        }

        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                fillBoxes.removeFeed(comboBox2.SelectedItem.ToString());
                comboBox2.Items.Clear();
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.Items.AddRange(fillBoxes.fyllComboBoxMedUrl().ToArray());
                comboBox1.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
                comboBox3.Items.AddRange(fillBoxes.fyllComboBoxMedKategori().ToArray());
            }
            catch (Exception)
            {
      
            }
        }

        private async void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Task<string> task = fillBoxes.fyllLabel(listBox2.SelectedItem.ToString());
                string x = await task;
                label1.Text = "";
                label1.Text = await fillBoxes.fyllLabel(listBox2.SelectedItem.ToString());
            }
            catch (Exception)
            {
            }
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
