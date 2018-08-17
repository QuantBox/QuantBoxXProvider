using System;
using System.ComponentModel;
using System.Windows.Forms;
using QuantBox.XApi;

namespace QuantBox.Design
{
    internal partial class XApiSettingsDialog : Form
    {
        private readonly XProvider _provider;
        private readonly BindingList<UserInfo> _userBindingList;
        private readonly BindingList<ServerInfo> _serverBindingList;
        private readonly BindingList<ConnectionInfo> _connectionBindingList;

        public XApiSettingsDialog(XProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            var settings = provider.Settings;
            ServerInfoConverter.Provider = provider;
            UserInfoConverter.Provider = provider;
            UserSelectorConverter.Users = settings.Users;
            ServerSelectorConverter.Servers = settings.Servers;
            _userBindingList = new BindingList<UserInfo>(settings.Users);
            userInfoBindingSource.DataSource = _userBindingList;
            _serverBindingList = new BindingList<ServerInfo>(settings.Servers);
            serverInfoBindingSource.DataSource = _serverBindingList;
            _connectionBindingList = new BindingList<ConnectionInfo>(settings.Connections);
            connectionInfoBindingSource.DataSource = _connectionBindingList;
        }

        private void XApiSettingsDialogs_FormClosed(object sender, FormClosedEventArgs e)
        {
            _provider.SaveSettings();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            _userBindingList.Add(new UserInfo());
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (lstUser.SelectedItem != null) {
                _userBindingList.Remove((UserInfo)lstUser.SelectedItem);
            }
        }

        private void btnCopyUser_Click(object sender, EventArgs e)
        {
            if (lstUser.SelectedItem != null) {
                _userBindingList.Add(((UserInfo)lstUser.SelectedItem).Clone());
            }
            else {
                _userBindingList.Add(new UserInfo());
            }
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            _serverBindingList.Add(new ServerInfo());
        }

        private void btnRemoveServer_Click(object sender, EventArgs e)
        {
            var item = (ServerInfo)lstServer.SelectedItem;
            if (item != null && !item.ReadOnly) {
                _serverBindingList.Remove((ServerInfo)lstServer.SelectedItem);
            }
        }

        private void btnCopyServer_Click(object sender, EventArgs e)
        {
            if (lstServer.SelectedItem != null) {
                _serverBindingList.Add(((ServerInfo)lstServer.SelectedItem).Clone());
            }
            else {
                _serverBindingList.Add(new ServerInfo());
            }
        }

        private void btnAddConnection_Click(object sender, EventArgs e)
        {
            _connectionBindingList.Add(new ConnectionInfo());
        }

        private void btnRemoveConnection_Click(object sender, EventArgs e)
        {
            if (lstConnection.SelectedItem != null) {
                _connectionBindingList.Remove((ConnectionInfo)lstConnection.SelectedItem);
            }
        }

        private void btnCopyConnection_Click(object sender, EventArgs e)
        {
            if (lstConnection.SelectedItem != null) {
                _connectionBindingList.Add(((ConnectionInfo)lstConnection.SelectedItem).Clone());
            }
            else {
                _connectionBindingList.Add(new ConnectionInfo());
            }
        }

        private void lstConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConnection.SelectedItem != null) {
                propertyGrid.SelectedObject = lstConnection.SelectedItem;
            }
        }

        private void lstServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ServerInfo)lstServer.SelectedItem;
            if (item != null) {
                propertyGrid.ReadOnly = item.ReadOnly;
                propertyGrid.SelectedObject = lstServer.SelectedItem;
            }
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedItem != null) {
                propertyGrid.SelectedObject = lstUser.SelectedItem;
            }
        }

        private void XApiSettingsDialog_Load(object sender, EventArgs e)
        {
            Text = _provider.Name;
            propertyGrid.Dock = DockStyle.Fill;
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "ApiPath" && propertyGrid.SelectedObject.GetType() == typeof(ConnectionInfo)) {
                var value = e.ChangedItem.Value.ToString();
                var instance = (ConnectionInfo)propertyGrid.SelectedObject;
                //if (value != e.OldValue.ToString()) 
                {
                    try {
                        using (var api = _provider.CreateXApi(value)) {
                            instance.Name = api.ApiName;
                            instance.Version = api.ApiVersion;
                            instance.Type = api.ApiTypes;
                        }
                    }
                    catch (Exception ex) {
                        instance.Name = ex.Message;
                        instance.Version = "请使用depends检查一下是否缺少依赖";
                        instance.Type = ApiType.None;
                    }
                }
            }
        }
    }
}
