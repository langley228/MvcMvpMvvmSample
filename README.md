# MvcMvpMvvmSample

本專案示範 ASP.NET Core 三層式架構，並分別實作 MVC、MVP、MVVM 三種設計模式的 CRUD 範例，底層（Data、Business）共用。

## 專案結構

```
MvcMvpMvvmSample.sln
│
├─MvcMvpMvvmSample.Data         // 共用資料層（Model）
├─MvcMvpMvvmSample.Business     // 共用商業邏輯層（Service）
│
├─MvcMvpMvvmSample.Mvc          // MVC 範例（Controller + View + ViewModel）
├─MvcMvpMvvmSample.Mvp          // MVP 範例（Controller + Presenter + View）
├─MvcMvpMvvmSample.Mvvm         // MVVM 範例（Controller + ViewModel + View）
```

## 執行方式

1. 以 Visual Studio 或 VS Code 開啟方案。
2. 選擇要執行的專案（Mvc、Mvp、Mvvm 任一）。
3. 執行 `dotnet run` 或 F5 啟動。

## 各模式簡介

- **MVC**：Controller 負責協調 Model 與 View，View 綁定 ViewModel。
- **MVP**：Presenter 處理所有邏輯，View 只負責顯示，Controller 實作 View 介面。
- **MVVM**：View 綁定 ViewModel，ViewModel 處理資料與邏輯，Controller 負責流程控制。

## 主要功能

- 產品（Product）CRUD 範例
- 三層式架構（Data/Business/Presentation）
- DI 注入服務
- 前端驗證

## 參考

- [ASP.NET Core 官方文件](https://docs.microsoft.com/aspnet/core)
- [MVC、MVP、MVVM 設計模式比較](https://medium.com/@yuchinghung890403/mvc-mvp-和-mvvm-三種設計模式的異同-ab505b73bc5d)

---