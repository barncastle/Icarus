using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Icarus.Components
{
    internal class ProcessSource : IListSource, IDisposable
    {
        private readonly BindingSource Source;
        private readonly ListBox ListBox;

        public ProcessSource(ListBox listBox)
        {
            Source = new BindingSource();
            ListBox = listBox;
            ListBox.DataSource = GetList();
        }

        public bool ContainsListCollection => false;

        public IList GetList()
        {
            Refresh();
            return Source;
        }

        public void Refresh()
        {
            Source.Clear();

            var processes = Process.GetProcesses();
            foreach (var proc in processes)
            {
                if (proc.ProcessName.StartsWith("WOW", StringComparison.OrdinalIgnoreCase))
                    Source.Add(new ProcessItem(proc));
            }

            ListBox.DisplayMember = "Details";
            ListBox.ValueMember = "ProcessID";
        }

        public void Dispose()
        {
            Source.Dispose();
        }
    }

    internal class ProcessItem
    {
        public string Details { get; }
        public int ProcessID { get; }

        public ProcessItem(Process process)
        {
            Details = $"{process.ProcessName}, PID: {process.Id}";
            ProcessID = process.Id;
        }
    }
}