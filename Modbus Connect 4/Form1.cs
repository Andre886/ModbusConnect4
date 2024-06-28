using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace Modbus_Connect_4
{
    public partial class Form1 : Form
    {
        private DataSet data;
        private static SerialPort serialPort;


        private static TimeSpan  differenza;
        private static DateTime oravecchia;
        private static DateTime ora;
        private static string file;
        private static BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        private static Boolean richieste = true;
        private static Boolean risposte = true;
        private Boolean chiaro = true;

        private String porta=null;
        private String baudrate;
        private String databits;
        private String parità;
        private String stopbits;

        private String porta2;
        private String baudrate2;
        private String databits2;
        private String parità2;
        private String stopbits2;

        public Form1()
        {
            InitializeComponent();
            file = "ModbusConnect4_LOG_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".log";

            
            string[] portNames = SerialPort.GetPortNames();
            string[] baud = { "300", "1200", "9600","19200", "28800", "57600", "115200" };
            string[] databit = { "7 Bit", "8 Bit" };
            string[] parity = { "Nessuna", "Odd", "Even" };
            string[] stop = { "1 Bit", "2 Bit" };

            data = new DataSet("prova");
            DataTable table = new DataTable("prova2");
            table.Columns.Add("Ora");
            table.Columns.Add("Differenza (ms)");
            table.Columns.Add("ID");
            table.Columns.Add("FC");
            table.Columns.Add("N.Byte/Indirizzo iniziale");
            table.Columns.Add("N registri");
            table.Columns.Add("Contenuto Registri");
            table.Columns.Add("CRC");
            data.Tables.Add(table);
            dataGridView1.DataSource = data.Tables["prova2"];

            dataGridView1.Columns["Ora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["FC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["N.Byte/Indirizzo iniziale"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["N registri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Contenuto Registri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["CRC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;



            foreach (string port in portNames)
            {
                ToolStripMenuItem portItem = new ToolStripMenuItem(port);
                portItem.Click += PortItem_Click;
                portItem.CheckOnClick = true;
                portaToolStripMenuItem.DropDownItems.Add(portItem);
            }

            foreach (string port in baud)
            {
                ToolStripMenuItem baudratemenu = new ToolStripMenuItem(port);
                baudratemenu.Click += baudItem_Click;
                baudratemenu.CheckOnClick = true;
                baudrateToolStripMenuItem.DropDownItems.Add(baudratemenu);
            }
            baudrateToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            baudrateToolStripMenuItem.DropDownItems.Add("Personalizzato [WIP]");


            foreach (string port in databit)
            {
                ToolStripMenuItem databitsmenu = new ToolStripMenuItem(port);
                databitsmenu.Click += databitsItem_Click;
                databitsmenu.CheckOnClick = true;
                dataBitsToolStripMenuItem.DropDownItems.Add(databitsmenu);
            }


            foreach (string port in parity)
            {
                ToolStripMenuItem paritamenu = new ToolStripMenuItem(port);
                paritamenu.Click += paritaItem_Click;
                paritamenu.CheckOnClick = true;
                paritàToolStripMenuItem.DropDownItems.Add(paritamenu);
            }

            foreach (string port in stop)
            {
                ToolStripMenuItem stopmenu = new ToolStripMenuItem(port);
                stopmenu.Click += stopItem_Click;
                stopmenu.CheckOnClick = true;
                stopBitToolStripMenuItem.DropDownItems.Add(stopmenu);
            }


            /*
            foreach (string port in portNames)
            {
                ToolStripMenuItem portItem = new ToolStripMenuItem(port);
                portItem.Click += PortItem_Click2;
                portItem.CheckOnClick = true;
                porta2ToolStripMenuItem1.DropDownItems.Add(portItem);
            }

            foreach (string port in baud)
            {
                ToolStripMenuItem baudratemenu = new ToolStripMenuItem(port);
                baudratemenu.Click += baudItem_Click2;
                baudratemenu.CheckOnClick = true;
                baudrate2ToolStripMenuItem1.DropDownItems.Add(baudratemenu);
            }
            baudrate2ToolStripMenuItem1.DropDownItems.Add(new ToolStripSeparator());
            baudrate2ToolStripMenuItem1.DropDownItems.Add("Personalizzato [WIP]");


            foreach (string port in databit)
            {
                ToolStripMenuItem databitsmenu = new ToolStripMenuItem(port);
                databitsmenu.Click += databitsItem_Click2;
                databitsmenu.CheckOnClick = true;
                dataBits2ToolStripMenuItem1.DropDownItems.Add(databitsmenu);
            }


            foreach (string port in parity)
            {
                ToolStripMenuItem paritamenu = new ToolStripMenuItem(port);
                paritamenu.Click += paritaItem_Click2;
                paritamenu.CheckOnClick = true;
                parità2ToolStripMenuItem1.DropDownItems.Add(paritamenu);
            }

            foreach (string port in stop)
            {
                ToolStripMenuItem stopmenu = new ToolStripMenuItem(port);
                stopmenu.Click += stopItem_Click2;
                stopmenu.CheckOnClick = true;
                stopBits2ToolStripMenuItem.DropDownItems.Add(stopmenu);
            }*/
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            int baudRate = Int32.Parse(baudrate);
            var parity = CalculateParity();
            var dataBits = ParseDataBits();
            var stopBits = ParseStopBits();

            /*int baudRate2 = Int32.Parse(baudrate2);
            var parity2 = CalculateParity2();
            var dataBits2 = ParseDataBits2();
            var stopBits2 = ParseStopBits2();*/

            serialPort = new SerialPort(porta, baudRate, parity, dataBits, stopBits);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.Open();

            // Keep the serial port open while the background worker is running.
            while (!backgroundWorker1.CancellationPending)
            {
                // Prevent tight loop, can be adjusted as needed.
                System.Threading.Thread.Sleep(100);

            }

            serialPort.Close();

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string[] values)
            {
                if (data != null)
                {
                    DataTable table = data.Tables["prova2"];
                    if (table != null)
                    {
                        table.Rows.Add(values);
                        dataGridView1.Refresh();
                    }
                }
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else if (e.Result is Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (porta != null && baudrate != null && parità != null && databits != null && stopbits != null)
            {
                button3.BackColor = Color.FromArgb(0, 255, 0);
                button4.BackColor = Color.FromArgb(0, 255, 0);

                richieste = true;
                risposte = true;
                avviaLetturaToolStripMenuItem.Enabled = false;
                button1.Enabled = false;
                fermaLetturaToolStripMenuItem.Enabled = true;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            } else
            {
                MessageBox.Show("Compila tutti i campi nelle impostazioni");
            }
                
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string hexLine = BitConverter.ToString(ReadBytesFromSerialPort(sp)).Replace("-", " ");

            ParseModbusLine(hexLine);
        }

        private static byte[] ReadBytesFromSerialPort(SerialPort sp)
        {
            int bytesToRead = sp.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            sp.Read(buffer, 0, bytesToRead);
            return buffer;
        }

        public static void ParseModbusLine(string hexLine)
        {
            string[] bytes = hexLine.Split(' ');

            if (bytes.Length < 5)
            {
                return;
            }

            string slaveAddress = bytes[0];
            string functionCode = bytes[1];

            if (functionCode == "03")
            {
                if ((bytes.Length - 5) % 2 == 0)
                {
                    ParseModbusResponse(bytes);
                }
                else
                {
                    ParseModbusRequest(bytes);
                }
            }
        }

        public static void ParseModbusRequest(string[] bytes)
        {
            if (bytes.Length < 8)
            {
                return;
            }


            
            ora = DateTime.Now;

            // Calcola la differenza tra i due tempi
            TimeSpan differenza = ora - oravecchia;

            // Aggiorna il tempo precedente per il prossimo calcolo
            oravecchia = ora;

            // Visualizza la differenza in millisecondi (o in qualsiasi formato desiderato)
           // MessageBox.Show("Differenza di tempo: " + differenza.TotalMilliseconds + " millisecondi");


            string slaveAddress = bytes[0];
            string functionCode = bytes[1];
            string addressFirstRegister = bytes[2] + bytes[3];
            string amountRegisters = bytes[4] + bytes[5];
            string crc = bytes[6] + bytes[7];

            // Prepare values to send to the DataGridView
            string[] values = new string[]
            {
                ora + "",
                differenza.TotalMilliseconds + " ms",
                slaveAddress,
                functionCode + " - Read Request",
                addressFirstRegister,
                amountRegisters,
                string.Empty, // No register content for requests
                crc
            };

            // Report the values to the main thread to update the DataGridView
            if (backgroundWorker1.IsBusy)
            {
                System.Threading.Thread.Sleep(200);

                if (richieste == true)
                {
                    
                    string rootPath = @"C:\modbus";
                    string filePath = Path.Combine(rootPath, file);

                    using (StreamWriter outputFile = new StreamWriter(filePath,true))
                    {
                        foreach (string line in values)
                        {
                            outputFile.WriteLine(line);
                        }
                        outputFile.WriteLine("\n");
                    }


                    backgroundWorker1.ReportProgress(0, values);
                }
                    
                
            }
        }

        public static void ParseModbusResponse(string[] bytes)
        {
            if (bytes.Length < 5)
            {
                return;
            }

            string slaveAddress = bytes[0];
            string functionCode = bytes[1];
            string numberOfBytes = bytes[2];

            if (!byte.TryParse(numberOfBytes, System.Globalization.NumberStyles.HexNumber, null, out byte byteCount))
            {
                return;
            }

            int expectedLength = 3 + byteCount + 2;

            if (bytes.Length < expectedLength)
            {
                return;
            }

            string crc = bytes[bytes.Length - 2] + bytes[bytes.Length - 1];

            for (int i = 3; i < 3 + byteCount; i += 2)
            {
                if (i + 1 < bytes.Length)
                {
                    string registerValue = bytes[i] + bytes[i + 1];
                    


                    ora = DateTime.Now;

                    // Calcola la differenza tra i due tempi
                    TimeSpan differenza = ora - oravecchia;

                    // Aggiorna il tempo precedente per il prossimo calcolo
                    oravecchia = ora;



                    // Prepare values to send to the DataGridView
                    string[] values = new string[]
                    {
                        ora + "",
                        differenza.TotalMilliseconds + " ms",
                        slaveAddress,
                        functionCode+ " - Read Response",
                        numberOfBytes,
                        "1", // Since we are adding one register per row
                        registerValue,
                        crc
                    };

                    // Report the values to the main thread to update the DataGridView
                    if (backgroundWorker1.IsBusy)
                    {
                        System.Threading.Thread.Sleep(200);
                        if (risposte==true)
                        {

                            string rootPath = @"C:\modbus";
                            string filePath = Path.Combine(rootPath, file);

                            using (StreamWriter outputFile = new StreamWriter(filePath, true))
                            {
                                foreach (string line in values)
                                {
                                    outputFile.WriteLine(line);
                                }
                                outputFile.WriteLine("\n");
                            }
                            backgroundWorker1.ReportProgress(0, values);
                        }
                        
                    }
                }
            }
        }

        private void avviaLetturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (baudrate != null && parità != null && databits != null && stopbits != null)
            {
                button3.BackColor = Color.FromArgb(0, 255, 0);
                button4.BackColor = Color.FromArgb(0, 255, 0);

                richieste = true;
                risposte = true;
                avviaLetturaToolStripMenuItem.Enabled = false;
                button1.Enabled = false;
                fermaLetturaToolStripMenuItem.Enabled = true;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Compila tutti i campi nelle impostazioni");
            }

        }

        private void fermaLetturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 0, 0);
            button4.BackColor = Color.FromArgb(255, 0, 0);

            richieste = false;
            risposte = false;
            avviaLetturaToolStripMenuItem.Enabled = true;
            button1.Enabled = true;
            fermaLetturaToolStripMenuItem.Enabled = false;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancellaTabella();
        }

        private void cancellaTabella()
        {

            data.Tables["prova2"].Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = data.Tables["prova2"];

            dataGridView1.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["FC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["N.Byte/Indirizzo iniziale"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["N registri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Contenuto Registri"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["CRC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richieste == true)
            {
                button3.BackColor = Color.FromArgb(255, 0, 0);
                richieste = false;

            }
            else if (richieste == false)
            {
                button3.BackColor = Color.FromArgb(0, 255, 0);

                richieste = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (risposte == true)
            {
                button4.BackColor = Color.FromArgb(255, 0, 0);
                risposte = false;

            }
            else if (risposte == false)
            {
                button4.BackColor = Color.FromArgb(0, 255, 0);
                risposte = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void temaChiaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chiaro = true;
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;

            this.dataGridView1.BackgroundColor = SystemColors.Window;
            this.dataGridView1.ForeColor = SystemColors.ControlText;
            this.dataGridView1.GridColor = SystemColors.ControlDark;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.Window;
                row.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void celleScure(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Imposta lo sfondo delle celle sul colore di sfondo scuro
            if (chiaro == true)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    row.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }

        }
        private void temaScuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chiaro = false;
            this.dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 48);
            this.dataGridView1.ForeColor = Color.White;
            this.dataGridView1.GridColor = Color.FromArgb(64, 64, 64);
            this.dataGridView1.CellFormatting += celleScure;
            this.BackColor = Color.FromArgb(31, 31, 31);
            this.ForeColor = Color.White;


            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;


        }


        private void PortItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            porta = clickedItem.Text;
            
            foreach (ToolStripMenuItem item in portaToolStripMenuItem.DropDownItems)
            {
                item.Checked = item == clickedItem;
            }
        }

        /*private void PortItem_Click2(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            porta2 = clickedItem.Text;
            string[] dascrivere = { porta };
            string rootPath = @"C:\modbus";
            string filePath = Path.Combine(rootPath, "com2.txt");

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                foreach (string line in dascrivere)
                {
                    outputFile.WriteLine(line);
                }
            }

            foreach (ToolStripMenuItem item in porta2ToolStripMenuItem1.DropDownItems)
            {
                item.Checked = item == clickedItem;
            }
        } */

            private void baudItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            baudrate = clickedItem.Text;

            foreach (ToolStripItem item in baudrateToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        }

       /* private void baudItem_Click2(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            baudrate2 = clickedItem.Text;

            foreach (ToolStripItem item in baudrate2ToolStripMenuItem1.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        } */

        private void databitsItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            databits = clickedItem.Text;

            foreach (ToolStripItem item in dataBitsToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        }

      /*  private void databitsItem_Click2(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            databits2 = clickedItem.Text;

            foreach (ToolStripItem item in dataBits2ToolStripMenuItem1.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        } */

        private void paritaItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            parità = clickedItem.Text;

            foreach (ToolStripItem item in paritàToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        }
      /*  private void paritaItem_Click2(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            parità2 = clickedItem.Text;

            foreach (ToolStripItem item in parità2ToolStripMenuItem1.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        } */

        private void stopItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            stopbits = clickedItem.Text;

            foreach (ToolStripItem item in stopBitToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        }

       /* private void stopItem_Click2(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            stopbits2 = clickedItem.Text;

            foreach (ToolStripItem item in stopBits2ToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == clickedItem;
                }
            }
        } */


        Parity CalculateParity()
        {

            switch (parità.ToLower())
            {
                case "nessuna":
                    return Parity.None;
                case "odd":
                    return Parity.Odd;
                case "even":
                    return Parity.Even;
                default:
                    throw new ArgumentException("Invalid parity value. Valid values are 'none', 'odd', or 'even'.");
            }
        }

      /*  Parity CalculateParity2()
        {

            switch (parità2.ToLower())
            {
                case "nessuna":
                    return Parity.None;
                case "odd":
                    return Parity.Odd;
                case "even":
                    return Parity.Even;
                default:
                    throw new ArgumentException("Invalid parity value. Valid values are 'none', 'odd', or 'even'.");
            }
        } */

        StopBits ParseStopBits()
        {
            switch (stopbits.ToLower())
            {
                case "0":
                    return StopBits.None;
                case "1 bit":
                    return StopBits.One;
                case "2 bit":
                    return StopBits.Two;
                case "onepointfive":
                case "1.5":
                case "one and a half":
                    return StopBits.OnePointFive;
                default:
                    throw new ArgumentException("Invalid StopBits value");
            }
        }

      /*  StopBits ParseStopBits2()
        {
            switch (stopbits2.ToLower())
            {
                case "0":
                    return StopBits.None;
                case "1 bit":
                    return StopBits.One;
                case "2 bit":
                    return StopBits.Two;
                case "onepointfive":
                case "1.5":
                case "one and a half":
                    return StopBits.OnePointFive;
                default:
                    throw new ArgumentException("Invalid StopBits value");
            }
        } */

        int ParseDataBits()
        {
            switch (databits.ToLower())
            {
                case "7 bit":
                    return 7;
                case "8 bit":
                    return 8;

                default:
                    throw new ArgumentException("Invalid dataBits value");
            }
        }

      /* int ParseDataBits2()
        {
            switch (databits2.ToLower())
            {
                case "7 bit":
                    return 7;
                case "8 bit":
                    return 8;

                default:
                    throw new ArgumentException("Invalid dataBits value");
            }
        } */

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}
