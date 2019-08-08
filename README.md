# Test0704
### Visual Studio 2019 Community
### Xamarin.Forms
-----------------------------------
## Overview
This app is an webview application with Firebase Cloud Messaging on both Android and iOS.

Using Xamarin.Forms, it is possible to develop both Android and iOS application in the same time.

[What's Xamarin.Forms](https://www.telerik.com/blogs/what-is-xamarin-forms)

[Xamarin App Fundamentals](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/)

----------------------------------
## Start to use

### On Android:

[中文教程](https://dotblogs.com.tw/supershowwei/2018/02/08/144157)

1.建立Firebase專案並下載設定檔google-services.json

2.注意：Firebase中所設定的套件名稱需要與VS中設定的相同（位於方案總管，Test0704.Android右鍵，點選屬性，Android資訊清單）

3.下載NuGet套件：Xamarin.GooglePlayServices.Base、Xamarin.Firebase.Messaging（位於方案總管，Test0704.Android右鍵，點選管理Nuget套件）

4.第一步下載的google-services.json取代Android專案底下的google-services.json檔案

5.萬事俱備，啟動模擬器測試

在發行前的小修改：

*更改通知的icon，在AndroidManifest.xml中修改 android:name="com.google.firebase.messaging.default_notification_icon" 的resource

*若想在App中增加返回鍵，修改Shared Code中的MainPage.xaml

    NavigationPage.HasNavigationBar="false" --> false to true

    將<ContentPage.ToolbarItems>註解拿掉啟用功能

![image](https://github.com/shinco0327/Test0704/blob/master/readme_img/Android_MainPage_without_bar.png)

to

![image](https://github.com/shinco0327/Test0704/blob/master/readme_img/Android_MainPage_with_bar.png)

#

### On iOS:

[中文教程](https://dotblogs.com.tw/supershowwei/2018/02/14/171219)

*注意：需要有Apple開發者帳戶

--------------------------------------------
## Additional Functions May Use

### DependencyService

[DependencyService Docs](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/dependency-service/)

[中文教程](https://dotblogs.com.tw/lapland/2017/03/24/092910)

DependencyService 類別是服務定位器，讓 Xamarin.Forms 應用程式能夠從共用程式碼叫用原生平台功能

例如：文字轉語音、Photo Picker、裝置方向等

這個專案也有使用DependencyService，處理Android App前景運作時接受Firebase的訊息，並以DisplayAlert方式顯示；iOS暫無使用。相關內容可參照程式註解。

#

### 再按一次返回鍵退出

注意：iOS受限於App Store規範，無法設計此功能

在MainPage.xmal.cs中，當返回鍵按下時，運行protected override bool OnBackButtonPressed()

    設計平台判斷式，若為Android則呼叫ExitTHeApp();

    if (Device.RuntimePlatform == Device.Android)
                {
                    ExitTheApp();
                }

    設計函數ExitTheApp()

    async void ExitTheApp()
        {
            bool answer = await DisplayAlert("Leaving", "You're going to exiting the app", "Exit", "Cancel");
            if (answer)
            {
                System.Environment.Exit(0);
            }
        }

--------------------------------------------
## Problems May Face

請拜訪[CodeCharge Forum](https://codecharge.com.tw/phpBB2/)，與我們一起討論

#

### Android 無法顯示http網頁

_這個專案已實作解決方法_

[Android http 網頁 net::ERR_CLEARTEXT_NOT_PERMITTED](https://codecharge.com.tw/phpBB2/viewtopic.php?f=105&t=22560)

#

### iOS webview無法顯示http網頁的問題

_這個專案已實作解決方法_

因為App Transport Security阻擋，http網頁將無法顯示

[App Transport Security Docs](https://docs.microsoft.com/zh-tw/xamarin/ios/app-fundamentals/ats)

解決方法：

    在 Info.plist 檔案內，加入底下的設定：（比較不安全，所有網頁將可以照訪）
    <key>NSAppTransportSecurity</key>
    <dict>
        <key>NSAllowsArbitraryLoads</key>
        <true/>
    </dict>

    或設定Exception（較安全）
    <key>NSAppTransportSecurity</key>
    <dict>
        <key>NSExceptionDomains</key>
        <dict>
            <key>www.the-domain-name.com</key>
            <dict>
                <key>NSExceptionMinimumTLSVersion</key>
                <string>TLSv1.0</string>
                <key>NSExceptionRequiresForwardSecrecy</key>
                <false/>
                <key>NSExceptionAllowsInsecureHTTPLoads</key>
                <true/>
                <key>NSIncludesSubdomains</key>
                <true/>
            </dict>
        </dict>
    </dict>

    如何編輯Info.plist？按右鍵，開啟方式，用xml開啟

--------------------------------------------
## Documents

[Xamarin.Forms Docs](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/)

[Google Firebase Docs](https://firebase.google.com/docs/cloud-messaging)

[About Terminate App](https://csharpkh.blogspot.com/2017/10/xamarinforms.html)





 


