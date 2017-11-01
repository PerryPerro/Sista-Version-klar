using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UppspeladePods
    {
        [Serializable()]
        public class uppSpeladPod : ISerializable
        {
            public virtual string Title { get; set; }


            public uppSpeladPod() { }

            public uppSpeladPod(string title = "hej")
            {
                Title = title;
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {

                info.AddValue("Title", Title);
            }

            public uppSpeladPod(SerializationInfo info, StreamingContext ctxt)
            {
                //Get the values from info and assign them to the properties
                Title = (string)info.GetValue("Title", typeof(string));
            }
        }
    }
}
