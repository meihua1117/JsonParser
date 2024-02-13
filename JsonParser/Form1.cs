using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace JsonParser
{

    public partial class Form1 : Form
    {
        string jsonFile = null;
        string targetFile = null;
        string checkBaseFile = null;
        string checkResultFile = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void fileClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "json 파일 (*.json)|*.json|모든 파일 (*.*)|*.*"; // 허용할 파일 유형을 지정합니다.
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 대화 상자가 열릴 기본 디렉토리를 지정합니다.

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    // 선택한 파일 경로를 사용하여 원하는 작업을 수행합니다.
                    jsonFile = openFileDialog.FileName;
                    targetFile = jsonFile.Replace(".json", ".xlsx");
                }
            }
        }

        private void btnParsing_Click(object sender, EventArgs e)
        {
            if (jsonFile == null)
            {
                MessageBox.Show("파싱할 json파일을 선택해주세요.");
                return;
            }
            var index = 0;
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            // 예시로 선택한 파일 경로를 출력합니다.
            using (StreamReader sr = new StreamReader(jsonFile))
            {
                string jsonContent;
                // 파일의 끝까지 한 줄씩 읽어오기
                while ((jsonContent = sr.ReadLine()) != null)
                {
                    JObject jsonObject = JObject.Parse(jsonContent);
                    var tag_str = jsonObject["tags"];
                    var ip = (string)jsonObject["ip_str"];
                    bool is_honeypot = false;
                    if (tag_str != null)
                    {
                        JArray tags = (JArray)tag_str;
                        foreach (var item in tags)
                        {
                            string tag = (string)item;
                            if (tag == "honeypot")
                            {
                                is_honeypot = true;
                                break;
                            }
                        }
                    }
                    if(!is_honeypot)
                    {
                        var http_status = 200;
                        var http_str = jsonObject["http"];
                        if (http_str != null)
                        {
                            http_status = (int)jsonObject["http"]["status"];
                        }
                        if(http_status == 200)
                        {
                            index++;
                            worksheet.Cells[index, 1] = ip;
                            worksheet.Cells[index, 2] = (string)jsonObject["port"];
                            var country_code = (string)jsonObject["location"]["country_code"];
                            worksheet.Cells[index, 3] = country_code;
                            var domains_str = jsonObject["domains"];
                            if (domains_str != null)
                            {
                                JArray domains = (JArray)domains_str;
                                worksheet.Cells[index, 4] = string.Join(",", domains);
                            }
                        }
                    }
                }
            }
            workbook.SaveAs(targetFile);
            // Excel 관련 객체 해제
            workbook.Close();
            excelApp.Quit();
            jsonFile = null;
            MessageBox.Show("json파싱이 완료되었습니다.");
        }
        private void Btn_Check_File_Create_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "json 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*"; // 허용할 파일 유형을 지정합니다.
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 대화 상자가 열릴 기본 디렉토리를 지정합니다.

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    // 선택한 파일 경로를 사용하여 원하는 작업을 수행합니다.
                    checkBaseFile = openFileDialog.FileName;
                    checkResultFile = checkBaseFile.Replace(".txt", ".chk");
                    string base_content = null;
                    using (StreamReader sr = new StreamReader(checkBaseFile))
                    {
                        using (StreamWriter sw = new StreamWriter(checkResultFile))
                        {
                            // 파일의 끝까지 한 줄씩 읽어오기
                            while ((base_content = sr.ReadLine()) != null)
                            {
                                string[] contents = base_content.Split('\t');
                                sw.WriteLine("set rport " + contents[1]);
                                sw.WriteLine("check " + contents[0]);
                            }
                            MessageBox.Show("Check파일생성이 완료되었습니다.");
                        }
                    }
                }
            }
        }
    }
}
