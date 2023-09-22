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

        /// <summary>
        /// ����PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            plc = new Plc(CpuType.S71200, IPTxt.Text, 0, 0);
            plc.Open();
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

        /// <summary>
        /// �Ͽ�PLC����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("PLC�Ѿ��Ͽ�����");
                return;
            }
            MessageBox.Show("��ȡ�ɹ�");
        }
    }
}