# PlexReportII.Sample.GUI

這是一個基於 Windows Forms (WinForms) 的圖形化測試與展示介面，用於呈現與測試 `PlexReportII` 核心函式庫的各項 PDF 報表繪圖功能。

## 系統需求
- **目標框架**: .NET 8.0-windows
- **相依專案/套件**: 
  - 核心程式庫: `PlexReportII.dll` (請確保已正確參照或由專案本身參照)
  - `System.Drawing.Common` (v10.0.2)
  - `ComponentOne C1.Pdf` (v10.0.20252.203) - **需有效商業授權**

## 授權注意
本專案為內部私有專案，包含需付費授權的元件（[SOUP] ComponentOne C1.Pdf）。
請勿將專案設為 Public，且在不同電腦建置前，請確保已安裝 GrapeCity License Manager 並啟用合法的金鑰，否則編譯出的 PDF 會無法產生或帶有浮水印。
