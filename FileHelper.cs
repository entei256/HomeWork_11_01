using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfApp1
{
    class FileHelper
    {

        /*private ObservableCollection<DataModel.Deportament> LoadFromFile ()
        {
            ObservableCollection<DataModel.Deportament> resoult = new ObservableCollection<DataModel.Deportament>();

            return resoult;
        }*/

        public void saveJson(ObservableCollection<DataModel.Deportament> deports)
        {
            var path = new SaveFileDialog();
            if ((bool)!path.ShowDialog())
                return;

            string jsonString = JsonConvert.SerializeObject(deports);
            File.WriteAllText(path.FileName, jsonString);
        }

        public void saveXML(ObservableCollection<DataModel.Deportament> deports)
        {
            var path = new SaveFileDialog();
            if ((bool)!path.ShowDialog())
                return;

            var xmlSerializer = new XmlSerializer(typeof(ObservableCollection<DataModel.Deportament>));
            using (var fs = new FileStream(path.FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, deports);
            }


        }

        public ObservableCollection<DataModel.Deportament> loadJson()
        {
            ObservableCollection<DataModel.Deportament> resoult;
            var path = new OpenFileDialog();
            if (!(bool)path.ShowDialog())
                return null;

            string jsonText = File.ReadAllText(path.FileName);

            resoult = JsonConvert.DeserializeObject<ObservableCollection<DataModel.Deportament>>(jsonText);

            return resoult;
        }

        public ObservableCollection<DataModel.Deportament> loadXML()
        {
            ObservableCollection<DataModel.Deportament> resoult;
            var path = new OpenFileDialog();
            if (!(bool)path.ShowDialog())
                return null;

            var Deserealization = new XmlSerializer(typeof(ObservableCollection<DataModel.Deportament>));

            using (var fs = new FileStream(path.FileName,FileMode.Open,FileAccess.Read))
            {
                resoult = Deserealization.Deserialize(fs) as ObservableCollection<DataModel.Deportament>;
            }

            return resoult;
        }
    }
}
