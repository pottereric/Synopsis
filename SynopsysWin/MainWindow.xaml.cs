using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SynopsysWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
//            memberAccessModifierView.FileText = @"using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace SimpleDocStore
//{
//    public class JsonDocStore : SimpleDocStore.IDocStore
//    {
//        private IStringPersistor _fileWriter;
//
//        public JsonDocStore(IStringPersistor persister)
//        {
//            _fileWriter = persister;
//        }
//
//        public void Save<T>(T item)
//        {
//            var list = GetAll<T>() ?? new List<T>();
//            list.Add(item);
//
//            string foo = JsonConvert.SerializeObject(list);
//            _fileWriter.SaveString(GetFileNameForType<T>(), foo);
//        }
//
//        public IList<T> GetAll<T>()
//        {
//            var list = JsonConvert.DeserializeObject(_fileWriter.GetString(GetFileNameForType<T>()));
//
//            if (list != null)
//            {
//                //return list as IList<T>;
//                JArray foo = list as JArray;
//                return foo.ToObject<List<T>>();
//            }
//            else
//            {
//                return null;
//            }
//        }
//
//        private string GetFileNameForType<T>()
//        {
//            return String.Format(""{0}.json"", typeof(T).FullName);
//        }
//    }
//}";
        }
    }
}
