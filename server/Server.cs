using server.Network;
using System;
using System.Windows.Forms;

namespace server {
    public partial class wfServer : Form {
        private const string path = "../../Database/";
        private const string xmlFile = "Dummy.xml";
        private const string result = "result.xml";

        private readonly Gate gate;

        public wfServer() {
            InitializeComponent();

            dataSet.ReadXml(path + xmlFile);
            dgvTable.AutoGenerateColumns = true;

            foreach (var table in dataSet.Tables) {
                cbTable.Items.Add(table.ToString());
            }

            gate = new Gate(dataSet);
            gate.startAsync();
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e) {
            dgvTable.DataMember = cbTable.SelectedItem.ToString();
        }
    }
}
