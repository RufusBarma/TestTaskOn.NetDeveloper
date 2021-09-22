using System.IO;
using System.Text;
using System.Windows.Controls;

namespace TestTask
{
    public class ControlWriter : TextWriter
    {
        private TextBlock textbox;
        public ControlWriter(TextBlock textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.Text += value;
        }

        public override void Write(string value)
        {
            textbox.Text += value;
        }

        public override Encoding Encoding => Encoding.Unicode;
    }
}