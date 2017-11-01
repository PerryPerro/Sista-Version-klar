using System;
using System.Runtime.Serialization;

namespace Data
{
    public abstract class Pods
    {
        [Serializable()]
        public class Pod : ISerializable
        {
            public string Url { get; set; }
            public string Category { get; set; }
            public double UpdateIntervall { get; set; }


            public Pod() { }

            public Pod(string url = "",
            string category = "",
            double updateIntervall = 3)
            {
                Url = url;
                Category = category;
                UpdateIntervall = updateIntervall;
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {

                info.AddValue("Url", Url);
                info.AddValue("Category", Category);
                info.AddValue("Intervall", UpdateIntervall);
            }

            internal Pod(SerializationInfo info, StreamingContext ctxt)
            {
                //Get the values from info and assign them to the properties
                Url = (string)info.GetValue("Url", typeof(string));
                Category = (string)info.GetValue("Category", typeof(string));
                UpdateIntervall = (double)info.GetValue("UpdateIntervall", typeof(double));
            }
        }
        }
}
