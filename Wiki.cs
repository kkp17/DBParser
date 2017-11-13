using Parser.Core;
using Parser.Core.Wiki;
using System;
using System.Windows.Forms;


namespace Parser
{
    public partial class Wiki : Form
    {
        ParserWorker<string[]> parser;

        public Wiki()
        {
            InitializeComponent();

            parser = new ParserWorker<string[]>(new WikiParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new WikiSettings(1, 1);
            parser.Start();
        }
    }
}
