using server.Network;
using System;
using System.Data;
using System.Windows.Forms;

namespace server {
    public partial class wfServer : Form {
        private const string path = "../../Database/";
        private const string xmlFile = "Dummy.xml";
        private const string result = "result.xml";

        // private readonly Gate gate;

        public wfServer() {
            InitializeComponent();
        }

        private void wfServer_Load(object sender, EventArgs e) {
            dataSet.ReadXml(path + xmlFile);
            dgvTable.AutoGenerateColumns = true;

            foreach (DataTable table in dataSet.Tables) {
                cbTable.Items.Add(table.TableName);
            }
            cbTable.SelectedItem = "MemberInfo";

            var gate = new Gate(dataSet);
            gate.start();
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e) {
            dgvTable.DataMember = cbTable.SelectedItem.ToString();
        }

        private void wfServer_FormClosed(object sender, FormClosedEventArgs e) {

        }
    }
}
