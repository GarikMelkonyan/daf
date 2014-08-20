using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAF.DataAccess
{
    public partial class Demo:IDocumentDemo
    {
        public string Path
        {
            get { return this.DemoPath; }
            set { DemoPath = value; }
        }
    }

    public partial class Document : IDocumentDemo
    {
        public string Path
        {
            get { return this.DocumentPath; }
            set { DocumentPath = value; }
        }
    }

    public partial class SoftApplication
    {
        public List<long> DocumentIDs { get; set; }
        public List<long> DemoIDs { get; set; }
        public List<long> FeatureIDs { get; set; }
        public string[] FeatureNames { get; set; }
    }
    public interface IDocumentDemo
    {
        string Title { get; set; }
        string Path { get; set; }
        long ID { get; set; }
    }
}
