using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static modul8_103022330077.Bank_transfer_config;

namespace modul8_103022330077
{
    public class Bank_transfer_config
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public Confirmation confirmation { get; set; }
        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        public List<String> method { get; set; }
        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }
        public const String filePath = @"bank_transfer_config";
        public Bank_transfer_config()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        private Bank_transfer_config ReadConfigFile()
        {
            Bank_transfer_config config = new Bank_transfer_config();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string json = sr.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Bank_transfer_config>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return config;
        }
        private void SetDefault()
        {
            lang = "en";
            transfer = new Transfer();
            transfer.threshold = 25000000;
            transfer.low_fee = 6500;
            transfer.high_fee = 15000;
            method = new List<String>();
            method.Add("SKN");
            method.Add("RTGS");
            method.Add("BIFAST");
            confirmation = new Confirmation();
            confirmation.en = "yes";
            confirmation.id = "ya";
        }
        private void WriteNewConfigFile()
        {
            Bank_transfer_config config = new Bank_transfer_config();
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                    sw.Write(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
        }
    }
//sebenernya ini yang bener tapi ga keburu
    //public class uiConfig {
    //     public Bank_transfer_config config;
    //     public const String filePath = @"bank_transfer_config.json";
    //     public UIConfig() { … }
    //     private Bank_transfer_config ReadConfigFile() {
    //         String configJsonData = File.ReadAllText(filePath);
    //         config = JsonSerializer.Deserialize<Config>(configJsonData);
    //         return config;
    //     }
    //     private void SetDefault() {
    //         lang = "en";
    //         transfer = new Transfer();
    //         transfer.threshold = 25000000;
    //         transfer.low_fee = 6500;
    //         transfer.high_fee = 15000;
    //         method = new List<String>();
    //         method.Add("SKN");
    //         method.Add("RTGS");
    //         method.Add("BIFAST");
    //         confirmation = new Confirmation();
    //         confirmation.en = "yes";
    //         confirmation.id = "ya";
    //     }
    //     private void WriteNewConfigFile() { … }
    // }

}
