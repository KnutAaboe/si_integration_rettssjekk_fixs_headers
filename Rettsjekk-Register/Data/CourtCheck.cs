using Newtonsoft.Json;
using Rettsjekk_Register.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;
using System.Diagnostics;

namespace Rettsjekk_Register.Data
{
    public class CourtCheck : ICourtCheck
    {

        public CourtCheck()
        {
            apiKey = Environment.GetEnvironmentVariable("RettssjekkApiNokkel");
            email = Environment.GetEnvironmentVariable("RettssjekEmail");
            password = Environment.GetEnvironmentVariable("RettssjekkPassword");
            GetToken();
        }
        private string email = "";
        private string password = "";
        private string apiToken = "";
        private string apiKey = "";

        //Gets all the trials from a company given vatnum and, if you want, date.
        public List<Trials.Trial> TrialsSearch(string vatnum, string date)
        {
            string url = string.Format("http://api.infochain.no/v1/company/search/" + vatnum);
            string contentType = "application/json";

            WebRequest requestObj = WebRequest.Create(url);
            requestObj.Method = "GET";
            requestObj.ContentType = contentType;
            requestObj.Headers.Add("Authorization", apiToken);
            var jsonData = Fetch(requestObj);

            if (jsonData == null || jsonData == "")
            {
                return null;
            } else
            {

            
            var parsedObject = JObject.Parse(jsonData);
            var jsonTrials = parsedObject["data"]["trials"].ToString(); 

            List<Trials.Trial> trials = (List<Trials.Trial>)JsonConvert.DeserializeObject<IEnumerable<Trials.Trial>>(jsonTrials);

            List<Trials.Trial> chosenTrials = new();

            if (trials.Count >= 1)
            {
                int count = 1;
                trials.Reverse();
                foreach (Trials.Trial t in trials)
                {
                    if (count <= 10) 
                    {
                        if (t.trial_date.CompareTo(date) >= 0)
                        {
                            chosenTrials.Add(t);
                            count++;
                        }

                    } else
                    {
                        break;
                    }
                }

                return chosenTrials;
            } else
            {
                return null;
            }
            }
        }

        //Gets all the bankruptcy data from a company given vatnum, if there are any.
        public List<Trials.Bankruptcy> BankruptcySearch(string vatnum)
            {
            string url = string.Format("http://api.infochain.no/v1/company/search/" + vatnum);
            string contentType = "application/json";

            WebRequest requestObj = WebRequest.Create(url);
            requestObj.Method = "GET";
            requestObj.ContentType = contentType;
            requestObj.Headers.Add("Authorization", apiToken);
            var jsonData = Fetch(requestObj);

            if (jsonData == null || jsonData == "")
            {
                return null;
            }
            else
            {
                var parsedObject = JObject.Parse(jsonData);
                var jsonBankruptcy = parsedObject["data"]["bankruptcies"].ToString();

                List<Trials.Bankruptcy> bankruptcyInfo = (List<Trials.Bankruptcy>)JsonConvert.DeserializeObject<IEnumerable<Trials.Bankruptcy>>(jsonBankruptcy);

                if (bankruptcyInfo.Count < 1)
                {
                    return null;
                }
                else
                {
                    return bankruptcyInfo;
                }
            }
        }

        //Gets all the solvent data from a company given vatnum, if there are any.
        public List<Trials.Solvent> SolventSearch(string vatnum)
        {
            string url = string.Format("http://api.infochain.no/v1/company/solvent/" + vatnum);
            string contentType = "application/json";

            WebRequest requestObj = WebRequest.Create(url);
            requestObj.Method = "GET";
            requestObj.ContentType = contentType;
            requestObj.Headers.Add("Authorization", apiToken);
            var jsonData = Fetch(requestObj);

            if (jsonData == null || jsonData == "")
            {
                return null;
            }
            else
            {

                var parsedObject = JObject.Parse(jsonData);

                var jsonSolvent = parsedObject["data"]["solvent"].ToString();

                List<Trials.Solvent> solventInfo = (List<Trials.Solvent>)JsonConvert.DeserializeObject<IEnumerable<Trials.Solvent>>(jsonSolvent);

                if (solventInfo.Count < 1)
                {
                    return null;
                }
                else
                {
                    return solventInfo;
                }
            }
        }

        //Gets the information about the account and valod auth_token given api-credentials
        public void GetToken()
        {
            //Enviorment variable 
            string url = string.Format("http://api.infochain.no/v1/authorize?" + "email=" + email + "&password=" + password + "&api_key=" + apiKey);
            WebRequest requestObj = WebRequest.Create(url);
            requestObj.Method = "POST";

            var jsonData = Fetch(requestObj);

            if (jsonData == null || jsonData == "")
            {
                Debug.WriteLine("no data, some wrong inputs or server issues");
            }
            else
            {

                var parsedObject = JObject.Parse(jsonData);
                var jsontoken = parsedObject["data"]["auth_token"].ToString();

                if (jsontoken != null || !(jsontoken.Equals("")))
                {
                    Debug.WriteLine("no valid api-key");
                }
                else
                {
                    apiToken = jsontoken;
                }
            }
            
        }


        //Used to get the json data the API call returns
        public String Fetch(WebRequest requestObject)
        {

            if (apiToken == null || apiToken == "")
            {
                //
                return "";

            } else { 
            try
            {
                HttpWebResponse respObject = (HttpWebResponse)requestObject.GetResponse();
                    string response = "";

                    using (Stream stream = respObject.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    response = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                return response;

            }
            catch (WebException error)
            {
                System.Console.WriteLine(error.Message);
                return error.ToString();
            }
            }
        }

        
    }
}
