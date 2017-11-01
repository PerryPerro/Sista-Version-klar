using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using static Logic.GenereraLista;

namespace Logic
{
    public abstract class FillComboBoxes
    {
        public class fillBoxes
        {
          
            public fillBoxes() {
             
                    }
            
            public static List<string> fyllComboBoxMedUrl()
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Url").Value != null
                            select item.Element("Url").Value;

                List<string> kategorier = new List<string>();

                foreach (string itemElement in items)
                {
                    kategorier.Add(itemElement);
                }

                return kategorier;
            }

            public static List<string> fyllComboBoxMedKategori()
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Category").Value != null
                            select item.Element("Category").Value;
                List<string> kategorier = new List<string>();

                string hej = items.ToString();

                foreach (string itemElement in items)
                {
                    if (!kategorier.Contains(itemElement.ToString()))
                    {
                        kategorier.Add(itemElement);
                    }

                }

                return kategorier;
            }

            public static List<string> fyllListboxMedFeeds(string category)
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Category").Value == category
                            select item.Element("Url").Value;

                List<string> feeds = new List<string>();

                foreach (string itemElement in items)
                {

                    feeds.Add(itemElement);
                }

                return feeds;
            }

            public static void removeFeed(string url)
            {
                var xdoc = XDocument.Load(@"C:\lista.xml");

                xdoc.XPathSelectElements($"//ArrayOfPod/Pod").Where(x => (string)x.Element("Url") == url).Remove();
                xdoc.Save(@"C:\lista.xml");
            }

            public static void removeCategory(string category)
            {
                var xdoc = XDocument.Load(@"C:\lista.xml");
               
                xdoc.XPathSelectElements($"//ArrayOfPod/Pod").Where(x => (string)x.Element("Category") == category).Remove();


                xdoc.Save(@"C:\lista.xml");
            }

            public static async Task<string> fyllLabel(string pod)
            {
                await Task.Delay(500);
                var xmlDoc = XDocument.Load(@"C:\uppspeladePods.xml");
                var items = from item in xmlDoc.Descendants("uppSpeladPod")
                            where item.Element("Title").Value != null
                            select item.Element("Title").Value;
                string retur = "";

                List<string> uppspelade = new List<string>();

                foreach (string itemElement in items)
                {

                    uppspelade.Add(itemElement);
                }

                if (uppspelade.Contains(pod))
                {

                    retur = "uppspelad";
                }
                else
                {
                    retur = "ej uppspelad";
                }

                return retur;
            }

            public static int updatePodcasts(string url)
            {
                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Url").Value == url
                            select item.Element("UpdateIntervall");
                int intervall = 0;
                foreach (string itemElement in items)
                {
                    intervall = int.Parse(itemElement);
                }
                return intervall;
            }

            public static void Methodintervall(int intervall, ListBox list, ListBox list1)
            {
                System.Timers.Timer TimerSet = new System.Timers.Timer();
                TimerSet.Interval = intervall*1000*60;
                TimerSet.Elapsed += (sender, e) => OnTimedEvent(sender, e, list, list1);
                TimerSet.AutoReset = true;
                TimerSet.Enabled = true;
            }

            public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e, ListBox list, ListBox list1)
            {
                list.Invoke(new Action(() => list.Items.Clear()));
                Debug.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
                list.Invoke(new Action(() => list.Items.AddRange(GenereradLista.listboxettmetoden(list1.SelectedItem.ToString()).ToArray())));
            }
        }
    }
}
