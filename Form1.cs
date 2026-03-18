// File Version: 1.0.2
// Last Modified: 2026-02-04
// Change Owner: Office of William

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlexReportII.Reports;
using PlexReportII.Infrastructure;
using C1.Win.FlexViewer;
using C1.Win.Document;

namespace PlexReportII.Sample.GUI
{
    /// <summary>
    /// 主視窗表單。
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly IPlexLogger _logger;

        private System.Drawing.Bitmap? _currentLogo = null;
        private Dictionary<Control, string> _tempValues = new Dictionary<Control, string>();
        private SampleReport? _currentReport = null; // 記憶體中的報表實例
        private System.Data.DataTable? _kitInfoData = null; // 載入的 Kit Info 資料 (4 欄格式)


        private List<PcncLegendItem> _pcncData = new List<PcncLegendItem>();
        private List<PcncTableItem> _pcncTableData = new List<PcncTableItem>();
        private List<PcncDetailItem> _pcncDetailData = new List<PcncDetailItem>();
        private bool _isFlagNoteCsvLoaded = false;
        private List<string> _flagNoteData = new List<string>();
        private List<List<string>> _summaryResultData = new List<List<string>>();
        private List<WellInfoItem> _wellInfoData = new List<WellInfoItem>();
        private List<List<string>> _sampleControlData = new List<List<string>>();
        private List<List<string>> _indvResultData = new List<List<string>>();

        /// <summary>
        /// 記錄所有繪圖操作的 Action 委派清單，供無損預覽重播使用。
        /// </summary>
        private List<Action<SampleReport>> _reportActions = new List<Action<SampleReport>>();


        /// <summary>
        /// 初始化主視窗。
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _logger = new PlexLogger();

            // 設定視窗標題
            // Form size
            this.Size = new System.Drawing.Size(1420, 1000);
            this.Text = "PlexReportII GUI (sample)";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // 設定表單圖示（假設 appicon.ico 在專案根目錄）
            this.Icon = new System.Drawing.Icon("../../../logo48_48.ico");
        }



        private void DrawMultiColorTextButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_multiColorInput != null)
                {
                    // 根據 CheckBox 狀態傳遞參數
                    bool outline = outlineCheck.Checked;
                    bool linkTarget = linkTargetCheck.Checked;

                    // 快取參數值供重播使用
                    string textCopy = _multiColorInput.Text;
                    bool outlineCopy = outline;
                    bool linkTargetCopy = linkTarget;

                    _currentReport.DrawMultiColorParagraph(textCopy, outlineCopy, linkTargetCopy);
                    _reportActions.Add(r => r.DrawMultiColorParagraph(textCopy, outlineCopy, linkTargetCopy));
                    
                    UpdatePositionInfo();
                    AddStatusMessage($"已繪製多色段落 (Outline: {outline}, LinkTarget: {linkTarget})");
                    RefreshPreview();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("繪製多色段落失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditModeCombo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_editModeCombo == null) return;
            
            int idx = _editModeCombo.SelectedIndex;
            if (_panelKitInfo != null) _panelKitInfo.Visible = idx == 0;
            if (_panelLine != null) _panelLine.Visible = idx == 1;
            if (_panelPageBreak != null) _panelPageBreak.Visible = idx == 2;
            if (_panelSpacing != null) _panelSpacing.Visible = idx == 3;
            if (_panelMultiColor != null) _panelMultiColor.Visible = idx == 4;
            if (_panelPcncNote != null) _panelPcncNote.Visible = idx == 5;
            if (_panelPcncTable != null) _panelPcncTable.Visible = idx == 6;
            if (_panelPcncDetailTable != null) _panelPcncDetailTable.Visible = idx == 7;
            if (_panelSignature != null) _panelSignature.Visible = idx == 8;
            if (_panelSummaryTable != null) _panelSummaryTable.Visible = idx == 9;
            if (_panelSampleControlTable != null) _panelSampleControlTable.Visible = idx == 10;
            if (_panelWellInfo != null) _panelWellInfo.Visible = idx == 11;
            if (_panelIndvResultTable != null) _panelIndvResultTable.Visible = idx == 12;
        }

        private void MarginInput_ValueChanged(object? sender, EventArgs e)
        {
            if (_marginHorizontalInput != null && _marginVerticalInput != null)
            {
                PdfGlobalConfig.SetMargins(
                    (float)_marginHorizontalInput.Value,
                    (float)_marginVerticalInput.Value);
                
                AddStatusMessage($"邊界變更: 左右 {_marginHorizontalInput.Value}, 上下 {_marginVerticalInput.Value}");
            }
        }

        private void ResetMargins_Click(object? sender, EventArgs e)
        {
            PdfGlobalConfig.ResetToDefaults();

            if (_marginHorizontalInput != null)
            {
                _marginHorizontalInput.Value = (decimal)PdfGlobalConfig.MarginHorizontal;
            }

            if (_marginVerticalInput != null)
            {
                _marginVerticalInput.Value = (decimal)PdfGlobalConfig.MarginVertical;
            }

            AddStatusMessage("邊界已重置為預設值");
        }

        private void LoadLogoButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.ico";
                
                // 設定預設路徑: D:\PlexReportII\SrcImage\
                string defaultPath = @"D:\PlexReportII\SrcImage\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (var tempImg = System.Drawing.Image.FromStream(fs))
                            {
                                _currentLogo = new System.Drawing.Bitmap(tempImg);
                            }
                        }
                        
                        // 更新狀態
                        AddStatusMessage($"Logo 已載入: {Path.GetFileName(ofd.FileName)}");

                        // 即時更新預覽
                        RefreshPreview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("載入圖片失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RemoveLogoButton_Click(object? sender, EventArgs e)
        {
            _currentLogo = null;
            AddStatusMessage("Logo 已移除");
            RefreshPreview();
        }

        private void LoadPcncCsvButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv|All Files|*.*";
                // 設定預設路徑: D:\PlexReportII\DataSource\
                string defaultPath = @"D:\PlexReportII\DataSource\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _pcncData.Clear();
                        var lines = File.ReadAllLines(ofd.FileName);
                        bool isFirstLine = true;

                        foreach (var line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            if (isFirstLine)
                            {
                                isFirstLine = false;
                                continue; // Skip header
                            }

                            // 簡單解析 CSV (處理引號)
                            // 假設格式: LegendTitle,ShowOnEveryPage,ItemText
                            // ItemText 被引號包圍
                            
                            // 使用簡易解析邏輯：尋找第一個逗號，第二個逗號
                            // 因為 ItemText 可能包含逗號，所以最後一個欄位需特別處理
                            // 但範例中 ItemText 在最後
                            
                            // 修正：使用 Regex 或逐字解析較安全，但為求簡單且符合範例：
                            // split by comma, but rejoin the last part if quoted?
                            // 範例: ,TRUE,"1: ..."
                            // split -> ["", "TRUE", "\"1: ...\""]
                            
                            // 考慮到 ItemText 可能有逗號，最安全的 split 是 split(3) 但需確認是否有巢狀
                            
                            // 用簡單的 Regex 或微軟VB parser? 這裡用手動尋找
                            
                            string[] parts = line.Split(',');
                            if (parts.Length < 3) continue;

                            string legendTitle = parts[0];
                            bool showOnEveryPage = parts[1].Trim().Equals("TRUE", StringComparison.OrdinalIgnoreCase);
                            
                            // 組合 ItemText
                            // 找到第二個逗號的位置
                            int firstComma = line.IndexOf(',');
                            int secondComma = line.IndexOf(',', firstComma + 1);
                            
                            string itemText = "";
                            if (secondComma != -1 && secondComma < line.Length - 1)
                            {
                                itemText = line.Substring(secondComma + 1).Trim();
                                // 去除前後引號
                                if (itemText.StartsWith("\"") && itemText.EndsWith("\""))
                                {
                                    itemText = itemText.Substring(1, itemText.Length - 2);
                                }
                                // 處理雙引號轉義 ("") -> (")
                                itemText = itemText.Replace("\"\"", "\"");
                            }

                            _pcncData.Add(new PcncLegendItem
                            {
                                LegendTitle = legendTitle,
                                ShowOnEveryPage = showOnEveryPage,
                                ItemText = itemText
                            });
                        }

                        AddStatusMessage($"PC/NC CSV 已載入: {_pcncData.Count} 筆資料");
                        AddStatusMessage($"來源檔案: {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show("載入 CSV 失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawPcncButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_pcncData == null || _pcncData.Count == 0)
                {
                    MessageBox.Show("請先載入 CSV 資料。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pcncDataCopy = new List<PcncLegendItem>(_pcncData);
                _currentReport.DrawPcncNote(pcncDataCopy);
                _reportActions.Add(r => r.DrawPcncNote(pcncDataCopy));
                
                UpdatePositionInfo();
                AddStatusMessage("PC/NC 註解已繪製");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 PC/NC 註解失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPcncTableCsvButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv|All Files|*.*";
                string defaultPath = @"D:\PlexReportII\DataSource\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _pcncTableData.Clear();
                        var lines = File.ReadAllLines(ofd.FileName);
                        bool isFirstLine = true;

                        foreach (var line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            if (isFirstLine)
                            {
                                isFirstLine = false;
                                continue; // Skip header
                            }

                            // CSV Parsing: Well ID, Control, Result, Flag
                            // Flag might be quoted
                            
                            string[] parts = line.Split(',');
                            if (parts.Length < 3) continue;

                            string wellId = parts[0];
                            string control = parts[1];
                            string result = parts[2];
                            string flag = "";

                            // Reconstruct Flag if it was split
                            if (parts.Length > 3)
                            {
                                // Find where Flag starts (3rd comma index)
                                int firstComma = line.IndexOf(',');
                                int secondComma = line.IndexOf(',', firstComma + 1);
                                int thirdComma = line.IndexOf(',', secondComma + 1);

                                if (thirdComma != -1 && thirdComma < line.Length - 1)
                                {
                                    flag = line.Substring(thirdComma + 1).Trim();
                                    // Remove quotes
                                    if (flag.StartsWith("\"") && flag.EndsWith("\""))
                                    {
                                        flag = flag.Substring(1, flag.Length - 2);
                                    }
                                    flag = flag.Replace("\"\"", "\"");
                                }
                                else if (parts.Length == 4) // Simple case
                                {
                                    flag = parts[3];
                                }
                            }

                            _pcncTableData.Add(new PcncTableItem
                            {
                                WellId = wellId,
                                Control = control,
                                Result = result,
                                Flag = flag
                            });
                        }

                        AddStatusMessage($"PC/NC Table CSV 已載入: {_pcncTableData.Count} 筆資料");
                        AddStatusMessage($"來源檔案: {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show("載入 CSV 失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawPcncTableButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_pcncTableData == null || _pcncTableData.Count == 0)
                {
                    MessageBox.Show("請先載入 PC/NC Table CSV 資料。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pcncTableDataCopy = new List<PcncTableItem>(_pcncTableData);
                _currentReport.DrawPcncTable(pcncTableDataCopy);
                _reportActions.Add(r => r.DrawPcncTable(pcncTableDataCopy));
                
                UpdatePositionInfo();
                AddStatusMessage("PC/NC Table 已繪製");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 PC/NC Table 失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPcncDetailCsvButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv|All Files|*.*";
                string defaultPath = @"D:\PlexReportII\DataSource\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _pcncDetailData.Clear();
                        string fileContent = File.ReadAllText(ofd.FileName);
                        var rows = ParseCsvWithQuotes(fileContent);

                        bool isFirstRow = true;
                        foreach (var row in rows)
                        {
                            if (isFirstRow)
                            {
                                isFirstRow = false;
                                continue; // Skip header
                            }

                            if (row.Count < 6) continue;

                            _pcncDetailData.Add(new PcncDetailItem
                            {
                                WellId = row[0].Trim(),
                                Control = row[1].Trim(),
                                NucleotideChange = row[2].Trim(),
                                Mutation = row[3].Trim(),
                                MFI = row[4].Trim(),
                                Cutoff = row[5].Trim()
                            });
                        }

                        AddStatusMessage($"PC/NC Detail CSV 已載入: {_pcncDetailData.Count} 筆資料");
                        AddStatusMessage($"來源檔案: {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("載入 CSV 失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawPcncDetailButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_pcncDetailData == null || _pcncDetailData.Count == 0)
                {
                    MessageBox.Show("請先載入 PC/NC Detail CSV 資料。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var style = new DetailTableStyle
                {
                    Headers = new[] { "Well ID", "Control", "Nucleotide Change", "Mutation", "MFI", "Cutoff" },
                    WidthBaseDivider = 8,
                    ColumnWidthFactors = new float[] { 1, 1, 2, 2, 1, 1 },
                    ColumnWidthOffsets = new float[] { -5, -15, 20, 30, -15, -15 },
                    ColumnAlignments = new int[] { 0, 0, 0, 0, 1, 1 },

                    EnableColumnMerge = true,
                    MergeColumnIndices = new int[] { 0, 1 },

                    RowSeparator = RowSeparatorMode.SkipMergedColumns,

                    AlternatingRowBackground = true,
                    EvenRowColor = System.Drawing.Color.White,
                    OddRowColor = System.Drawing.Color.FromArgb(245, 245, 245),

                    BorderWidth = 0.2f,
                    BorderColor = System.Drawing.Color.Gray,
                    FontSize = 10f,
                    CellPadding = 5f,

                    RedrawHeaderOnNewPage = true,
                };

                var pcncDetailDataCopy = new List<PcncDetailItem>(_pcncDetailData);
                var styleCopy = style;
                _currentReport.DrawPcncDetailTable(pcncDetailDataCopy, styleCopy);
                _reportActions.Add(r => r.DrawPcncDetailTable(pcncDetailDataCopy, styleCopy));

                UpdatePositionInfo();
                AddStatusMessage($"PC/NC Detail Table 已繪製 ({_pcncDetailData.Count} 筆資料)");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 PC/NC Detail Table 失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawSignatureButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _currentReport.DrawSignatureArea();
                _reportActions.Add(r => r.DrawSignatureArea());

                UpdatePositionInfo();
                AddStatusMessage("已繪製簽名區");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製簽名區失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 解析含引號的 CSV 內容 (處理引號內的逗號和換行)。
        /// </summary>
        private List<List<string>> ParseCsvWithQuotes(string content)
        {
            var result = new List<List<string>>();
            var currentRow = new List<string>();
            var currentField = new System.Text.StringBuilder();
            bool inQuotes = false;
            bool fieldHadQuotes = false;
            int i = 0;

            void AddField()
            {
                string val = currentField.ToString();
                if (!fieldHadQuotes)
                {
                    val = val.Trim();
                }
                currentRow.Add(val);
                currentField.Clear();
                fieldHadQuotes = false;
            }

            while (i < content.Length)
            {
                char c = content[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < content.Length && content[i + 1] == '"')
                        {
                            currentField.Append('"');
                            i += 2;
                        }
                        else
                        {
                            inQuotes = false;
                            i++;
                        }
                    }
                    else
                    {
                        currentField.Append(c);
                        i++;
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                        fieldHadQuotes = true;
                        i++;
                    }
                    else if (c == ',')
                    {
                        AddField();
                        i++;
                    }
                    else if (c == '\r' || c == '\n')
                    {
                        if (c == '\r' && i + 1 < content.Length && content[i + 1] == '\n')
                        {
                            i += 2;
                        }
                        else
                        {
                            i++;
                        }

                        AddField();

                        if (currentRow.Count > 0)
                        {
                            result.Add(currentRow);
                            currentRow = new List<string>();
                        }
                    }
                    else
                    {
                        currentField.Append(c);
                        i++;
                    }
                }
            }

            if (currentField.Length > 0 || currentRow.Count > 0)
            {
                AddField();
                result.Add(currentRow);
            }

            return result;
        }

        private void CreatePdfButton_Click(object? sender, EventArgs e)
        {
            try
            {
                // 檢查是否已有 PDF 在記憶體中
                if (_currentReport != null)
                {
                    MessageBox.Show("目前記憶體中已有 PDF 物件。請先按「清除 PDF」釋放記憶體後再建立新文件。", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AddStatusMessage("正在建立 PDF...");

                // 建立新的報表實例
                _currentReport = new SampleReport(_logger);

                // 套用 Header/Footer 設定
                ApplyHeaderFooterSettings(_currentReport);

                // 在記憶體中建立 PDF (會重新建立 C1PdfDocument 物件)
                _currentReport.InitializeInMemory();

                // 設定參數 (需在初始化後設定，否則會被覆蓋)
                if (_allowCopyContentCheck != null)
                {
                    _currentReport.AllowCopyContent = _allowCopyContentCheck.Checked;
                }
                
                Control? flagSpacingCombo = null;
                foreach (Control c in this.Controls) { 
                    if (c.Name == "headerFooterGroup") {
                        flagSpacingCombo = c.Controls["_flagNoteSpacingCombo"];
                    }
                }
                if (flagSpacingCombo is ComboBox combo && float.TryParse(combo.Text, out float spacing))
                {
                    _currentReport.FlagNoteSpacing = spacing;
                }

                // 動態更新線條繪製的預設值 (對應當前邊距設定)
                if (_lineStartXInput != null) _lineStartXInput.Value = (decimal)_currentReport.PageRect.X;
                if (_lineLengthInput != null) _lineLengthInput.Value = (decimal)_currentReport.PageRect.Width;

                UpdatePositionInfo();

                AddStatusMessage("PDF 文件已建立並初始化完成");

                // 即時預覽（顯示含 Header/Footer 的空白頁面）
                RefreshPreview();

                MessageBox.Show("PDF 已在記憶體中建立完成！\n\n您可以按「輸出 PDF」將其儲存為檔案。", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.Error("建立 PDF 失敗", ex);
                AddStatusMessage($"錯誤: {ex.Message}");
                MessageBox.Show($"建立 PDF 時發生錯誤：\n{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 即時重新產生預覽。建立暫存 SampleReport 重播所有操作後匯出至 FlexViewer。
        /// 原始 _currentReport 完全不受影響。
        /// </summary>
        private void RefreshPreview()
        {
            if (_currentReport == null)
            {
                return;
            }

            string tempPath = Path.Combine(Path.GetTempPath(), $"PlexReport_Preview_{Guid.NewGuid():N}.pdf");

            try
            {
                using (SampleReport tempReport = new SampleReport(_logger))
                {
                    // 套用與原始報表相同的 Header/Footer 設定
                    ApplyHeaderFooterSettings(tempReport);

                    // 初始化暫存報表
                    tempReport.InitializeInMemory();

                    // 套用相同的全域設定
                    tempReport.AllowCopyContent = _currentReport.AllowCopyContent;
                    tempReport.FlagNoteSpacing = _currentReport.FlagNoteSpacing;

                    // 重播所有繪圖操作
                    foreach (var action in _reportActions)
                    {
                        action(tempReport);
                    }

                    // 匯出暫存報表至檔案 (含 Header/Footer)
                    tempReport.ExportToFile(tempPath);
                }

                // 讀取暫存檔案並載入至 FlexViewer
                byte[] pdfBytes = File.ReadAllBytes(tempPath);
                MemoryStream ms = new MemoryStream(pdfBytes);

                var pdfSource = new C1PdfDocumentSource();
                pdfSource.LoadFromStream(ms);
                _flexViewer.DocumentSource = pdfSource;

                AddStatusMessage($"預覽已更新 (共 {_reportActions.Count} 個操作)");
            }
            catch (Exception ex)
            {
                _logger.Error("即時預覽失敗", ex);
                AddStatusMessage($"預覽錯誤: {ex.Message}");
            }
            finally
            {
                // 清理暫存檔案
                try
                {
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }
                }
                catch { /* 忽略清理錯誤 */ }
            }
        }

        private void ExportPdfButton_Click(object? sender, EventArgs e)
        {
            try
            {
                // 檢查是否有 PDF 在記憶體中
                if (_currentReport == null)
                {
                    MessageBox.Show("請先按「建立 PDF」在記憶體中建立 PDF 文件。", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddStatusMessage("輸出失敗: 尚未建立 PDF");
                    return;
                }

                AddStatusMessage("正在輸出 PDF...");

                // 產生輸出路徑
                string pdfFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pdf");
                string fileName = $"output_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string outputPath = Path.Combine(pdfFolder, fileName);

                // 使用重播機制匯出，確保最新的 Header/Footer 設定（含 Logo）皆有套用
                using (SampleReport exportReport = new SampleReport(_logger))
                {
                    ApplyHeaderFooterSettings(exportReport);
                    exportReport.InitializeInMemory();
                    exportReport.AllowCopyContent = _currentReport.AllowCopyContent;
                    exportReport.FlagNoteSpacing = _currentReport.FlagNoteSpacing;

                    // 重播所有繪圖操作
                    foreach (var action in _reportActions)
                    {
                        action(exportReport);
                    }

                    // 匯出至檔案 (含 Header/Footer)
                    exportReport.ExportToFile(outputPath);
                }

                AddStatusMessage($"PDF 已輸出: {fileName}");
                MessageBox.Show($"PDF 已成功輸出！\n\n路徑: {outputPath}", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.Error("輸出 PDF 失敗", ex);
                AddStatusMessage($"錯誤: {ex.Message}");
                MessageBox.Show($"輸出 PDF 時發生錯誤：\n{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPdfButton_Click(object? sender, EventArgs e)
        {
            if (_currentReport != null)
            {
                _currentReport.Dispose();
                _currentReport = null;
                _reportActions.Clear();

                // 清除預覽面板
                _flexViewer.DocumentSource = null;

                AddStatusMessage("已釋放 PDF 物件記憶體 (繪圖操作紀錄已清除)");
                
                // 重設位置資訊
                if (_positionInfoLabel != null)
                {
                    _positionInfoLabel.Text = "CurrentX: -- | CurrentY: -- | TotalPages: -- | CurrentPage: -- | Header: -- | Footer: --";
                }
                MessageBox.Show("PDF 已從記憶體中清除。", "完成",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AddStatusMessage("目前沒有 PDF 物件需要清除");
            }
        }

        private void ApplyHeaderFooterSettings(SampleReport report)
        {
            Control? headerFooterGroup = null;
            foreach (Control c in this.Controls) { if (c.Text == "Header / Footer 設定") headerFooterGroup = c; }

            if (headerFooterGroup != null)
            {
                CheckBox? showHeader = headerFooterGroup.Controls["showHeaderCheck"] as CheckBox;
                CheckBox? showFooter = headerFooterGroup.Controls["showFooterCheck"] as CheckBox;
                CheckBox? showPageNum = headerFooterGroup.Controls["showPageNumberCheck"] as CheckBox;
                TextBox? headerTitle = headerFooterGroup.Controls["headerTitleInput"] as TextBox;
                TextBox? softwareName = headerFooterGroup.Controls["softwareNameInput"] as TextBox;
                TextBox? versionInput = headerFooterGroup.Controls["versionInput"] as TextBox;
                TextBox? operatorInput = headerFooterGroup.Controls["operatorInput"] as TextBox;
                CheckBox? ruoCheck = headerFooterGroup.Controls["ruoCheck"] as CheckBox;

                report.SetHeaderFooter(config =>
                {
                    if (showHeader != null) config.ShowHeader = showHeader.Checked;
                    if (showFooter != null) config.ShowFooter = showFooter.Checked;
                    if (showPageNum != null) config.ShowPageNumber = showPageNum.Checked;
                    if (headerTitle != null) config.HeaderTitle = headerTitle.Text;
                    if (softwareName != null) config.SoftwareNameText = softwareName.Text;
                    if (versionInput != null) config.VersionText = versionInput.Text;
                    if (operatorInput != null) config.OperatorName = operatorInput.Text;
                    if (ruoCheck != null) config.IsResearchUseOnly = ruoCheck.Checked;
                    if (_currentLogo != null) config.Logo = _currentLogo;
                });
            }
        }

        private void LoadKitInfoCsvButton_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV 檔案|*.csv|所有檔案|*.*",
                Title = "選取 Kit Info CSV 檔案"
            };

            // 設定預設路徑: D:\PlexReportII\DataSource\
            string defaultPath = @"D:\PlexReportII\DataSource\";
            if (Directory.Exists(defaultPath))
            {
                ofd.InitialDirectory = defaultPath;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 讀取 4 欄 CSV 格式
                    _kitInfoData = new System.Data.DataTable();
                    for (int i = 1; i <= 4; i++)
                    {
                        var dc = new System.Data.DataColumn(i.ToString(), typeof(string));
                        dc.ExtendedProperties.Add("ColWidth", 1); // 等寬
                        _kitInfoData.Columns.Add(dc);
                    }

                    string[] lines = File.ReadAllLines(ofd.FileName);
                    bool firstLine = true;
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        if (firstLine) { firstLine = false; continue; } // 跳過標題列
                        
                        string[] parts = line.Split(',');
                        object[] row = new object[4];
                        for (int i = 0; i < 4; i++)
                        {
                            row[i] = i < parts.Length ? parts[i].Trim() : "";
                        }
                        _kitInfoData.Rows.Add(row);
                    }
                    AddStatusMessage($"Kit Info 已載入: {_kitInfoData.Rows.Count} 列, 4 欄格式");
                    AddStatusMessage($"來源檔案: {ofd.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"載入 CSV 失敗: {ex.Message}", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawKitInfoButton_Click(object? sender, EventArgs e)
        {
            if (_currentReport == null || !_currentReport.IsPdfInitialized)
            {
                MessageBox.Show("請先按「建立 PDF」在記憶體中建立 PDF 文件。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_kitInfoData == null || _kitInfoData.Rows.Count == 0)
            {
                MessageBox.Show("請先載入 Kit Info CSV 檔案。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 取得選擇的方法與樣式
                string selectedMethod = _renderMethodCombo?.SelectedItem?.ToString() ?? "RenderTable_V1";
                string selectedStyle = _tableStyleCombo?.SelectedItem?.ToString() ?? "TbSetting1";

                var kitDataCopy = _kitInfoData!.Copy();
                string methodCopy = selectedMethod;
                string styleCopy = selectedStyle;

                RectangleF rect = _currentReport.DrawKitInfoTableWithStyle(kitDataCopy, methodCopy, styleCopy);
                _reportActions.Add(r => r.DrawKitInfoTableWithStyle(kitDataCopy, methodCopy, styleCopy));
                UpdatePositionInfo();
                AddStatusMessage($"Kit Info 已繪製 [{selectedMethod}|{selectedStyle}] (x: {rect.X:F0}, y: {rect.Y:F0}, w: {rect.Width:F0}, h: {rect.Height:F0})");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 Kit Info 失敗", ex);
                AddStatusMessage($"錯誤: {ex.Message}");
                MessageBox.Show($"繪製 Kit Info 時發生錯誤：\n{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawLineButton_Click(object? sender, EventArgs e)
        {
            if (_currentReport == null || !_currentReport.IsPdfInitialized)
            {
                MessageBox.Show("請先按「建立 PDF」在記憶體中建立 PDF 文件。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 讀取 UI 設定
                string colorName = _lineColorCombo?.SelectedItem?.ToString() ?? "Gray";
                Color color = Color.FromName(colorName);
                float x = (float)(_lineStartXInput?.Value ?? 0);
                float length = (float)(_lineLengthInput?.Value ?? 450);
                float thickness = (float)(_lineThicknessInput?.Value ?? 0.2m);
                float spacing = (float)(_lineSpacingAfterInput?.Value ?? 0);

                // 驗證邊界
                RectangleF pageRect = _currentReport.PageRect;
                if (x < pageRect.Left || x > pageRect.Right)
                {
                    MessageBox.Show($"起始位置 X ({x}) 超過可編輯區域範圍 ({pageRect.Left:F1} ~ {pageRect.Right:F1})，請重新選擇。", "驗證失敗",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (x + length > pageRect.Right)
                {
                    MessageBox.Show($"線條總長度 ({x} + {length} = {x + length}) 超過可編輯區域右邊界 ({pageRect.Right:F1})，請重新設定長度。", "驗證失敗",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 快取參數供重播
                Color colorCopy = color;
                float xCopy = x;
                float lengthCopy = length;
                float thicknessCopy = thickness;
                float spacingCopy = spacing;

                // 執行繪製
                float y = _currentReport.DrawHorizontalLine(
                    lineColor: colorCopy,
                    lineWidth: thicknessCopy,
                    addSpacingAfter: spacingCopy,
                    x: xCopy,
                    length: lengthCopy
                );
                _reportActions.Add(r => r.DrawHorizontalLine(
                    lineColor: colorCopy,
                    lineWidth: thicknessCopy,
                    addSpacingAfter: spacingCopy,
                    x: xCopy,
                    length: lengthCopy
                ));

                UpdatePositionInfo();

                // 詳細日誌顯示於 listBox
                string logMsg = $"[水平線] Y:{y:F0}, X:{x:F0}, 長度:{length:F0}, 顏色:{colorName}, 粗細:{thickness:F1}, 間距:{spacing:F0}";
                AddStatusMessage(logMsg);
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製水平線失敗", ex);
                AddStatusMessage($"錯誤: {ex.Message}");
                MessageBox.Show($"繪製水平線時發生錯誤：\n{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PageBreakButton_Click(object? sender, EventArgs e)
        {
            if (_currentReport == null || !_currentReport.IsPdfInitialized)
            {
                MessageBox.Show("請先按「建立 PDF」在記憶體中建立 PDF 文件。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _currentReport.PageBreak();
                _reportActions.Add(r => r.PageBreak());
                UpdatePositionInfo();
                AddStatusMessage($"已執行換頁。目前頁數: {_currentReport.PageCount}");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("換頁失敗", ex);
                AddStatusMessage($"錯誤: {ex.Message}");
                MessageBox.Show($"換頁時發生錯誤：\n{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawSpacingButton_Click(object? sender, EventArgs e)
        {
            if (_currentReport == null || !_currentReport.IsPdfInitialized)
            {
                MessageBox.Show("請先按「建立 PDF」在記憶體中建立 PDF 文件。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_spacingHeightCombo == null) return;

            if (!float.TryParse(_spacingHeightCombo.Text, out float height) || height < 0)
            {
                 MessageBox.Show("請輸入有效的間隔高度數值 (pt)。", "警告",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 執行插入間隔 (內部已包含自動換頁檢查)
                float heightCopy = height;
                _currentReport.AddVerticalSpacing(heightCopy);
                _reportActions.Add(r => r.AddVerticalSpacing(heightCopy));
                
                UpdatePositionInfo();
                
                // 更新狀態
                AddStatusMessage($"已插入垂直間隔: {height} pt。目前頁數: {_currentReport.PageCount}");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("插入間隔失敗", ex);
                AddStatusMessage($"錯誤: {ex.Message}");
                MessageBox.Show($"插入間隔時發生錯誤：\n{ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePositionInfo()
        {
            if (_currentReport != null && _positionInfoLabel != null)
            {
                // CurrentPageIndex 是 0-based，顯示時 +1
                int currentPage = _currentReport.CurrentPageIndex + 1;
                int totalPages = _currentReport.PageCount;

                _positionInfoLabel.Text = $"CurrentX: {_currentReport.CurrentX:F1} | CurrentY: {_currentReport.CurrentY:F1} | TotalPages: {totalPages} | CurrentPage: {currentPage} | Header height: {_currentReport.HeaderAreaRect.Height:F0} | Footer height: {_currentReport.FooterAreaRect.Height:F0}" +
                    Environment.NewLine +
                    $"PageKind: {_currentReport.PagePaperKind} (W={(_currentReport.PageRect.Width + PdfGlobalConfig.MarginHorizontal * 2):F1}, H={(_currentReport.PageRect.Height + PdfGlobalConfig.MarginVertical * 2):F1})" +
                    Environment.NewLine +
                    $"HeaderArea: X={_currentReport.HeaderAreaRect.X:F1}, Y={_currentReport.HeaderAreaRect.Y:F1}, " +
                    $"W={_currentReport.HeaderAreaRect.Width:F1}, H={_currentReport.HeaderAreaRect.Height:F1}, " +
                    $"R={_currentReport.HeaderAreaRect.Right}, L={_currentReport.HeaderAreaRect.Left}" +
                    Environment.NewLine +
                    $"BodyArea: X={_currentReport.PageRect.X:F1}, Y={_currentReport.PageRect.Y:F1}, " +
                    $"W={_currentReport.PageRect.Width:F1}, H={_currentReport.PageRect.Height:F1}, " +
                    $"R={_currentReport.PageRect.Right}, L={_currentReport.PageRect.Left}" +
                    Environment.NewLine +
                    $"FooterArea: X={_currentReport.FooterAreaRect.X:F1}, Y={_currentReport.FooterAreaRect.Y:F1}, " +
                    $"W={_currentReport.FooterAreaRect.Width:F1}, H={_currentReport.FooterAreaRect.Height:F1}, " +
                    $"R={_currentReport.FooterAreaRect.Right}, L={_currentReport.FooterAreaRect.Left}";
            }
        }

        private void OpenFolderButton_Click(object? sender, EventArgs e)
        {
            string pdfFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pdf");

            if (!Directory.Exists(pdfFolder))
            {
                Directory.CreateDirectory(pdfFolder);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = pdfFolder,
                UseShellExecute = true
            });
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void HeaderFooterSetting_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                // 紀錄進入時的值
                _tempValues[tb] = tb.Text;
            }
        }

        private void HeaderFooterSetting_Changed(object? sender, EventArgs e)
        {
            if (sender is Control control)
            {
                string msg = "";
                if (control is CheckBox cb)
                {
                    msg = $"{control.Text}: {(cb.Checked ? "開啟" : "關閉")}";
                }
                else if (control is TextBox tb)
                {
                    // 檢查是否真的變更
                    string initialValue = "";
                    if (_tempValues.TryGetValue(tb, out string? val))
                    {
                        initialValue = val;
                    }

                    if (tb.Text != initialValue)
                    {
                        // 對應標籤名稱
                        string label = control.Name switch
                        {
                            "headerTitle" => "Header 標題",
                            "softwareNameInput" => "軟體名稱",
                            "versionInput" => "版本資訊",
                            "operatorInput" => "操作者",
                            _ => control.Name
                        };
                        msg = $"{label} 變更: {tb.Text}";
                        
                        // 更新暫存值
                        _tempValues[tb] = tb.Text;
                    }
                }
                
                if (!string.IsNullOrEmpty(msg))
                {
                    AddStatusMessage(msg);
                }
            }
        }

        private void AddStatusMessage(string message)
        {
            ListBox? statusList = this.Controls["statusList"] as ListBox;
            if (statusList != null)
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                statusList.Items.Insert(0, $"[{timestamp}] {message}");
            }
        }

        private void CopySelectedStatus(ListBox listBox)
        {
            if (listBox.SelectedItem != null)
            {
                Clipboard.SetText(listBox.SelectedItem.ToString() ?? string.Empty);
            }
        }

        private void LoadFlagNoteCsvButton_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV 檔案|*.csv|所有檔案|*.*",
                Title = "選取 Flag Note CSV 檔案"
            };

            // 設定預設路徑: D:\PlexReportII\DataSource\
            string defaultPath = @"D:\PlexReportII\DataSource\";
            if (Directory.Exists(defaultPath))
            {
                ofd.InitialDirectory = defaultPath;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string content = File.ReadAllText(ofd.FileName);
                    var parsedCsv = ParseCsvWithQuotes(content);

                    _flagNoteData.Clear();
                    
                    bool isFirstRow = true;
                    foreach (var row in parsedCsv)
                    {
                        if (isFirstRow)
                        {
                            isFirstRow = false; // 略過 Header
                            continue;
                        }

                        // 依據參考的 EGFR_SAMPLE_20251216_legend.csv，資料在第三欄 (index 2)
                        // 若列數大於等於 3 且該值不為空，則加入清單
                        if (row.Count >= 3)
                        {
                            string itemText = row[2].Trim();
                            if (!string.IsNullOrEmpty(itemText))
                            {
                                _flagNoteData.Add(itemText);
                            }
                        }
                    }

                    _isFlagNoteCsvLoaded = true;
                    AddStatusMessage($"Flag Note 已載入: {_flagNoteData.Count} 筆資料");
                    AddStatusMessage($"來源檔案: {ofd.FileName}");
                    
                    var msgBuilder = new System.Text.StringBuilder();
                    msgBuilder.AppendLine($"CSV 載入成功！共載入 {_flagNoteData.Count} 筆資料。");
                    if (_flagNoteData.Count > 0)
                    {
                        msgBuilder.AppendLine();
                        msgBuilder.AppendLine("載入項目：");
                        for (int i = 0; i < _flagNoteData.Count; i++)
                        {
                            msgBuilder.AppendLine($"- {_flagNoteData[i]}");
                        }
                    }

                    MessageBox.Show(msgBuilder.ToString(), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // 載入完成後立即更新並顯示預估高度
                    UpdateFlagNoteHeightLabel();
                }
                catch (Exception ex)
                {
                    _logger.Error("載入 Flag Note CSV 失敗", ex);
                    MessageBox.Show($"載入 CSV 失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddSupplementalTextCheck_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                if (cb.Checked && !_isFlagNoteCsvLoaded)
                {
                    cb.Checked = false;
                    MessageBox.Show("請先執行載入CSV (Load CSV) 後，再執行此設定。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Control? textInput = null;
                Control? textLabel = null;
                CheckBox? aboveFooterCheck = null;
                foreach (Control c in this.Controls) { 
                    if (c.Name == "headerFooterGroup") {
                            textInput = c.Controls["supplementalTextInput"];
                            textLabel = c.Controls["supplementalTextLabel"];
                            aboveFooterCheck = c.Controls["addAboveFooterCheck"] as CheckBox;
                    }
                }
                
                if (textInput != null) textInput.Visible = cb.Checked;
                if (textLabel != null) textLabel.Visible = cb.Checked;

                // 若勾選 addSupplementalTextCheck，自動勾選 addAboveFooterCheck
                if (cb.Checked && aboveFooterCheck != null && !aboveFooterCheck.Checked)
                {
                    aboveFooterCheck.Checked = true;
                }

                UpdateFlagNoteHeightLabel();
            }
        }

        private void AddAboveFooterCheck_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                if (cb.Checked && !_isFlagNoteCsvLoaded)
                {
                    cb.Checked = false;
                    MessageBox.Show("請先執行載入CSV (Load CSV) 後，再執行此設定。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateFlagNoteHeightLabel();
            }
        }

        private void FlagNoteSpacingCombo_TextChanged(object? sender, EventArgs e)
        {
            UpdateFlagNoteHeightLabel();
        }

        private void UpdateFlagNoteHeightLabel()
        {
            Control? heightLabel = null;
            Control? textInput = null;
            CheckBox? suppCheck = null;
            CheckBox? aboveCheck = null;
            
            Control? spacingCombo = null;
            Control? spacingLabel = null;
            
            foreach (Control c in this.Controls) { 
                if (c.Name == "headerFooterGroup") {
                        heightLabel = c.Controls["flagNoteHeightLabel"];
                        textInput = c.Controls["supplementalTextInput"];
                        suppCheck = c.Controls["addSupplementalTextCheck"] as CheckBox;
                        aboveCheck = c.Controls["addAboveFooterCheck"] as CheckBox;
                        spacingCombo = c.Controls["_flagNoteSpacingCombo"];
                        spacingLabel = c.Controls["flagNoteSpacingLabel"];
                }
            }

            if (heightLabel == null) return;

            bool isAnyChecked = (suppCheck != null && suppCheck.Checked) || (aboveCheck != null && aboveCheck.Checked);

            if (isAnyChecked)
            {
                float totalHeight = 0f;
                // 取出上方間距設定
                float spacingGap = 2f;
                if (spacingCombo is ComboBox cb && float.TryParse(cb.Text, out float gap))
                {
                    spacingGap = gap;
                }

                // 使用簡易估算邏輯：每個 note 14pt (或透過 BasePdfReport)
                if (_currentReport != null)
                {
                    string? suppText = (suppCheck != null && suppCheck.Checked && textInput != null) ? textInput.Text : null;
                    totalHeight = _currentReport.CalculateTotalFlagNoteHeight(_flagNoteData, suppText) + spacingGap;
                }
                else
                {
                    // Fallback 如果還沒產生 PDF 物件
                    float defaultLineHeight = 14f;
                    totalHeight += _flagNoteData.Count * defaultLineHeight;
                    if (suppCheck != null && suppCheck.Checked)
                    {
                        totalHeight += defaultLineHeight;
                    }
                    totalHeight += spacingGap;
                }

                heightLabel.Text = $"Flag Note 預估高度: {totalHeight:F1} pt";
            }
            else
            {
                // 如果未勾選，顯示預設文字 "Flag Note Height: ---"
                heightLabel.Text = "Flag Note Height: ---";
            }
            
            // 只要 CSV 有載入，就保持顯示
            bool showElements = _isFlagNoteCsvLoaded;
            if (heightLabel != null) heightLabel.Visible = showElements;
            if (spacingCombo != null) spacingCombo.Visible = showElements;
            if (spacingLabel != null) spacingLabel.Visible = showElements;
        }

        // ===== Summary Result Table =====

        private void LoadSummary6ColumnDataCsvButton_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV 檔案|*.csv|所有檔案|*.*",
                Title = "選取 Summary Result Data CSV 檔案"
            };

            string defaultPath = @"D:\PlexReportII\DataSource\";
            if (Directory.Exists(defaultPath))
            {
                ofd.InitialDirectory = defaultPath;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string content = File.ReadAllText(ofd.FileName);
                    var parsedCsv = ParseCsvWithQuotes(content);

                    _summaryResultData.Clear();

                    bool isFirstRow = true;
                    foreach (var row in parsedCsv)
                    {
                        if (isFirstRow)
                        {
                            isFirstRow = false; // 略過 Header
                            continue;
                        }

                        // 確保至少有資料 (允許部分欄位缺失)
                        if (row.Count > 0)
                        {
                            // 標準化為 6 欄
                            var normalizedRow = new List<string>();
                            for (int i = 0; i < 6; i++)
                            {
                                normalizedRow.Add(i < row.Count ? row[i].Trim() : "");
                            }
                            _summaryResultData.Add(normalizedRow);
                        }
                    }

                    AddStatusMessage($"Summary Data 已載入: {_summaryResultData.Count} 筆資料");
                    AddStatusMessage($"來源檔案: {ofd.FileName}");

                    var msgBuilder = new System.Text.StringBuilder();
                    msgBuilder.AppendLine($"CSV 載入成功！共載入 {_summaryResultData.Count} 筆資料。");

                    MessageBox.Show(msgBuilder.ToString(), "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.Error("載入 Summary Data CSV 失敗", ex);
                    MessageBox.Show($"載入 CSV 失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawSummary6ColumnTableButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF 物件後才能執行此操作。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_summaryResultData.Count == 0)
                {
                    MessageBox.Show("請先載入 Summary Result Data CSV。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 判斷是否需要包含 Flag Note
                CheckBox? suppCheck = null;
                CheckBox? aboveCheck = null;
                Control? textInput = null;
                foreach (Control c in this.Controls)
                {
                    if (c.Name == "headerFooterGroup")
                    {
                        suppCheck = c.Controls["addSupplementalTextCheck"] as CheckBox;
                        aboveCheck = c.Controls["addAboveFooterCheck"] as CheckBox;
                        textInput = c.Controls["supplementalTextInput"];
                    }
                }

                bool shouldDrawFlagNote = (suppCheck != null && suppCheck.Checked) || (aboveCheck != null && aboveCheck.Checked);
                string? supplementalText = (suppCheck != null && suppCheck.Checked && textInput != null) ? textInput.Text : null;

                var summaryDataCopy = _summaryResultData.Select(r => new List<string>(r)).ToList();
                var flagNoteCopy = shouldDrawFlagNote ? new List<string>(_flagNoteData) : null;
                string? suppTextCopy = supplementalText;
                bool flagNoteFlagCopy = shouldDrawFlagNote;

                _currentReport.DrawSummaryResult6ColumnTable(
                    summaryDataCopy,
                    flagNoteCopy,
                    suppTextCopy,
                    flagNoteFlagCopy);
                _reportActions.Add(r => r.DrawSummaryResult6ColumnTable(
                    summaryDataCopy,
                    flagNoteCopy,
                    suppTextCopy,
                    flagNoteFlagCopy));

                AddStatusMessage($"Summary Result Table 繪製完成 (共 {_summaryResultData.Count} 筆資料)");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 Summary Result Table 失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWellInfoCsvButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv|All Files|*.*";
                string defaultPath = @"D:\PlexReportII\DataSource\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _wellInfoData.Clear();
                        var lines = File.ReadAllLines(ofd.FileName);
                        bool isFirstLine = true;

                        foreach (var line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            if (isFirstLine)
                            {
                                isFirstLine = false;
                                continue;
                            }

                            string[] parts = line.Split(',');
                            if (parts.Length < 2) continue;

                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            bool is2Col = false;
                            if (parts.Length >= 3)
                            {
                                is2Col = parts[2].Trim().Equals("true", StringComparison.OrdinalIgnoreCase);
                            }

                            _wellInfoData.Add(new WellInfoItem
                            {
                                Key = key,
                                Value = value,
                                Is2Column = is2Col
                            });
                        }

                        AddStatusMessage($"Well Info CSV 已載入: {_wellInfoData.Count} 筆資料");
                        AddStatusMessage($"來源檔案: {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("載入 CSV 失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawWellInfoButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_wellInfoData == null || _wellInfoData.Count == 0)
                {
                    MessageBox.Show("請先載入 Well Info CSV 資料。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var wellInfoCopy = new List<WellInfoItem>(_wellInfoData);
                _currentReport.DrawWellInfoTable(wellInfoCopy);
                _reportActions.Add(r => r.DrawWellInfoTable(wellInfoCopy));

                UpdatePositionInfo();
                AddStatusMessage($"Well Info Table 繪製完成 (共 {_wellInfoData.Count} 筆資料)");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 Well Info Table 失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIndividualControlCsvButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv|All Files|*.*";
                string defaultPath = @"D:\PlexReportII\DataSource\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _sampleControlData.Clear();
                        string content = File.ReadAllText(ofd.FileName);
                        List<List<string>> parsedCsv = ParseCsvWithQuotes(content);

                        foreach (List<string> row in parsedCsv)
                        {
                            // 確保每列 5 欄
                            while (row.Count < 5)
                            {
                                row.Add("");
                            }
                            _sampleControlData.Add(row);
                        }

                        int bodyCount = _sampleControlData.Count > 0 ? _sampleControlData.Count - 1 : 0;
                        AddStatusMessage($"Sample Control CSV 已載入: {bodyCount} 筆資料 (含 Header)");
                        AddStatusMessage($"來源檔案: {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("載入 CSV 失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawIndividualControlButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_sampleControlData == null || _sampleControlData.Count < 2)
                {
                    MessageBox.Show("請先載入 Sample Control CSV 資料 (至少含 Header + 1 筆資料)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sampleCtrlCopy = _sampleControlData.Select(r => new List<string>(r)).ToList();
                _currentReport.DrawSampleControlTable(sampleCtrlCopy);
                _reportActions.Add(r => r.DrawSampleControlTable(sampleCtrlCopy));

                UpdatePositionInfo();
                AddStatusMessage($"Sample Control Table 繪製完成 (共 {_sampleControlData.Count - 1} 筆資料)");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 Sample Control Table 失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Individual Result Table =====

        private void LoadIndvResultCsvButton_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv|All Files|*.*";
                string defaultPath = @"D:\PlexReportII\DataSource\";
                if (Directory.Exists(defaultPath))
                {
                    ofd.InitialDirectory = defaultPath;
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _indvResultData.Clear();
                        string content = File.ReadAllText(ofd.FileName);
                        List<List<string>> parsedCsv = ParseCsvWithQuotes(content);

                        foreach (List<string> row in parsedCsv)
                        {
                            // 確保每列 5 欄
                            while (row.Count < 5)
                            {
                                row.Add("");
                            }
                            _indvResultData.Add(row);
                        }

                        int bodyCount = _indvResultData.Count > 0 ? _indvResultData.Count - 1 : 0;
                        AddStatusMessage($"Individual Result CSV 已載入: {bodyCount} 筆資料 (含 Header)");
                        AddStatusMessage($"來源檔案: {ofd.FileName}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("載入 CSV 失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DrawIndvResultButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_currentReport == null || !_currentReport.IsPdfInitialized)
                {
                    MessageBox.Show("請先建立 PDF (按「建立 PDF」按鈕)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_indvResultData == null || _indvResultData.Count < 2)
                {
                    MessageBox.Show("請先載入 Individual Result CSV 資料 (至少含 Header + 1 筆資料)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var indvResultCopy = _indvResultData.Select(r => new List<string>(r)).ToList();
                _currentReport.DrawIndividualResultTable5Col(indvResultCopy);
                _reportActions.Add(r => r.DrawIndividualResultTable5Col(indvResultCopy));

                UpdatePositionInfo();
                AddStatusMessage($"Individual Result Table 繪製完成 (共 {_indvResultData.Count - 1} 筆資料)");
                RefreshPreview();
            }
            catch (Exception ex)
            {
                _logger.Error("繪製 Individual Result Table 失敗", ex);
                MessageBox.Show($"繪製失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
