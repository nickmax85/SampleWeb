using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SampleWeb
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet]
        public bool Ping()
        {
            return true;
        }


        [OperationContract]
        [WebGet]
        public string Sessions()
        {
            //fake read sessions from DB
            var contentFile = System.Web.Hosting.HostingEnvironment.MapPath("~/data/sessions.json");
            var content = File.ReadAllText(contentFile);

            List<Session> sessions = JsonConvert.DeserializeObject<List<Session>>(content);
            sessions.Add(new Session() { title = "Berndt Schulung", room = "C" });

            var json = JsonConvert.SerializeObject(sessions);

            return json;
        }

        // Add more operations here and mark them with [OperationContract]
    }

    public class Session
    {
        public string id { get; set; }
        public string title { get; set; }
        public string subTitle { get; set; }
        public string speakerName { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public List<int> tracks { get; set; }
        public string room { get; set; }
        public int starCount { get; set; }
    }

}
