using System.Linq;
using System.Xml.Linq;

namespace Logic
{
    public abstract class ChangeFeedsAndUrls
    {
        public class Changer
        {
          
            public Changer() { }
            
            public static void changeFeedUrl(string url, string newUrl, string newCategory, string newUpdateIntervall)
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Url").Value == url
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetElementValue("Url", newUrl);
                    itemElement.SetElementValue("Category", newCategory);
                    itemElement.SetElementValue("UpdateIntervall", newUpdateIntervall);
                }

                xmlDoc.Save(@"C:\lista.xml");
            }

            public static void changeFeedCategory(string url, string newCategory)
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Url").Value == url
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetElementValue("Category", newCategory);
                }

                xmlDoc.Save(@"C:\lista.xml");
            }
            public static void removeFeedCategory(string category)
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Category").Value == category
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.Remove();
                }

                xmlDoc.Save(@"C:\lista.xml");
            }
            public static void changeFeedUpdateInteval(string url, string newInterval)
            {

                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Url").Value == url
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetElementValue("UpdateIntervall", newInterval);
                }

                xmlDoc.Save(@"C:\lista.xml");
            }

            public static void changeCategory(string category, string newCategory)
            {
                var xmlDoc = XDocument.Load(@"C:\lista.xml");
                var items = from item in xmlDoc.Descendants("Pod")
                            where item.Element("Category").Value == category
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetElementValue("Category", newCategory);
                }

                xmlDoc.Save(@"C:\lista.xml");
            }
        }
    }
}
