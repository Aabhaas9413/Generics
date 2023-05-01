using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Generics.GenericCase
{
    public class LoadOrSaveGenerics
    {
        public List<T> loadData<T>(string path) where T : class, new() {
            var lines = System.IO.File.ReadAllLines(path).ToList();
            List<T> result = new List<T>();
            var entry = new T();
            var cols = entry.GetType().GetProperties();
            var headers = lines[0].Split(',');
            lines.RemoveAt(0);
             
            foreach ( var line in lines )
            {
                entry = new T();
                var value = line.Split(",");
                foreach (var header in headers.Select((value, id) => new { id, value }))
                {
                    foreach (var col in cols)
                    {
                        if(col.Name == header.value)
                        {
                            col.SetValue(entry, Convert.ChangeType(value[header.id], col.PropertyType));
                        }
                    }
                }
                result.Add(entry);
            } 
            return result;
        }

        public List<T> saveData<T>(List<T> data, string path) where T : class, new()
        {
            var lines = new List<string>();
            List<T> result = new List<T>();
            StringBuilder line = new StringBuilder();
            var cols = data[0].GetType().GetProperties();
            //lines.RemoveAt(0);

            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(',');
            }
            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach(var item in data)
            {
                line = new StringBuilder();
                foreach(var col in cols)
                {
                    line.Append(col.GetValue(item));
                    line.Append(",");
                }
                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }
            System.IO.File.WriteAllLines(path, lines.ToArray());
            return result;
        }
    }
}
