using S7.Net;

namespace SiemensPLCDemo
{
    public partial class Form1 : Form
    {

        Plc plc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Thread tr = new Thread(ConnectPlc);
            tr.Start();
            SendHeartBeat();
            if (plc != null && plc.IsConnected)
            {
                ConnectState.Text = "������";
                ConnectState.BackColor = Color.Green;
            }
            else
            {
                ConnectState.BackColor = Color.Red;
            }
        }

        private void SendHeartBeat()
        {
            Thread heartBeat = new Thread(SendHeartBeat);
            heartBeat.Start();
            if (plc != null && plc.IsConnected)
            {
                try
                {
                    plc.WriteAsync("DB5.DBX0.0", 1);
                    ConnectState.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    ConnectState.BackColor = Color.Red;
                    Console.WriteLine("��������PLC" + ex.Message);
                    ConnectPlc();
                }
            }
            else if (plc != null && !plc.IsConnected)
            {
                ConnectState.BackColor = Color.Red;
                Console.WriteLine("��������PLC");
                ConnectPlc();
            }
        }


        public void ConnectPlc()
        {
            plc = new Plc(CpuType.S71200, IPTxt.Text, 0, 0);
            try
            {
                plc.Open();
                ConnectState.Text = "������";
                ConnectState.BackColor = Color.Green;
            }
            catch (Exception)
            {
                Console.WriteLine("PLC����ʧ��");
            }

        }

        /// <summary>
        /// д��ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (WriteDBNoTxt.Text == null || WriteDBValue.Text == null)
            {
                MessageBox.Show("Ҫд���DB���д��DB���ֵ����Ϊ��");
                return;
            }
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("��������PLC");
                return;
            }
            int dbValue = int.Parse(WriteDBValue.Text.ToString());
            try
            {
                plc.Write(WriteDBNoTxt.Text, dbValue);
                MessageBox.Show("д��ɹ�");
            }
            catch (Exception ex)
            {

                MessageBox.Show("���,�����쳣:" + ex.Message);
            }
        }

        /// <summary>
        /// ��ȡֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ReadDBNoTxt.Text == null)
            {
                MessageBox.Show("Ҫ��ȡ��DB�鲻��Ϊ��");
                return;
            }
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("��������PLC");
                return;
            }
            object? v = plc.Read(ReadDBNoTxt.Text);
            if (v == null)
            {
                MessageBox.Show("��ȡʧ��");
                return;
            }
            string val = v.ToString();
            ReadDBValue.Text = val;
            MessageBox.Show("��ȡ�ɹ�");
        }

    }
}