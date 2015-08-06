using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace ESPPT
{
    public class IniFile
    {
        private string fileName;
        private List<Dictionary<string, string>> iniKeys;
        private Dictionary<string, Dictionary<string, string>> iniSections;

        public void setKey(string section, string key,string value)
        {
            Dictionary<string, string> sectionVal;
            if (iniSections.TryGetValue(section, out sectionVal))
            {
                if (sectionVal.ContainsKey(key))
                    sectionVal[key] = value;
                 else
                    sectionVal.Add(key, value);
            }
            else
            {
                iniSections.Add(section, new Dictionary<string, string>());
                iniSections[section].Add(key, value);
            }

            writeFile();
        }

        public int getInt(string section, string key)
        {
            int i;
            if (int.TryParse(getKey(section, key), out i))
            {
                return i;
            }
            else
            {
                return -1;
            }  
        }

        public string getKey(string section, string key)
        {
            if (iniSections.ContainsKey(section))
            {
                Dictionary<string, string> value = iniSections[section];
                if (value.ContainsKey(key))
                {
                    return value[key];
                }
            }
            return "";
        }

        public IniFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName + " does not exist", fileName);
            this.fileName = fileName;
            ReadSections();
        }

        public void ReadSections()
        {

            string[] ini = File.ReadAllLines(fileName);
            int count = 0;
            int KeyCount = 0;
            string section = "";
            iniKeys = new List<Dictionary<string, string>>();
            iniSections = new Dictionary<string, Dictionary<string, string>>();

            try
            {
                while (true)
                {
                    if (ini[count].StartsWith("[") && ini[count].Contains("]"))
                    {
                        section = ini[count];
                        iniKeys.Add(new Dictionary<string, string>());

                        count++;
                        while (true)
                        {
                            if (ini.LongLength == count)
                            {
                                iniSections.Add(section, iniKeys[KeyCount]);
                                KeyCount++;
                                return;
                            }
                            else if (ini[count].StartsWith("["))
                            {
                                iniSections.Add(section, iniKeys[KeyCount]);
                                KeyCount++;
                                count--;
                                break;
                            }
                            else if (ini[count] != "" && ini[count].Contains("="))
                            {
                                string[] tmp = ini[count].Split('=');
                                iniKeys[KeyCount].Add(tmp[0].Trim(' '), tmp[1].Trim(' '));
                            }
                            count++;
                        }
                    }
                    count++;
                }
            }
            catch (Exception e) { }

        }

        public void writeFile()
        {
            FileStream fileStream = File.Open(fileName, FileMode.Truncate);
            using (StreamWriter file = new StreamWriter(fileStream))
            {
                foreach (KeyValuePair<string, Dictionary<string, string>> section in iniSections)
                {
                    file.WriteLine(section.Key);
                    foreach (KeyValuePair<string,string> val in section.Value)
                    {
                        file.WriteLine(string.Format("{0}={1}",val.Key,val.Value));
                    }
                }
            }
        }
    }
}